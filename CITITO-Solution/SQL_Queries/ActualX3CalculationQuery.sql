/* Wokred Shift for 9 hours */
DECLARE @K int;
DECLARE @mPIC nvarchar(20); 
DECLARE @mFrom DateTime; 
DECLARE @mTo DateTime;
DECLARE @mUID nvarchar(20); 

SET @K=32400;
SET @mPIC = 'ZDQ';
SET @mFrom = '2018-02-01';
SET @mTo = '2018-02-28';
SET @mUID = '1AO';

DECLARE @TemptblDifference_@mPIC TABLE(
RowNumber bigint,
TR_Index bigint,
WORKDATE Date,
TR_ID varchar(100),
TR_UID varchar(50), 
TR_ActualTaskIn DateTime,
TR_OutDate DateTime,
TR_Status int,
TR_Apporval int,
TR_MID varchar(50),
TR_PIC varchar(50),
TR_Shipment varchar(1000),
TR_File varchar(500),
ACTUAL_OUTPUT float,
WORKED_HOURS float,
AMS_DIFF float,
APPROVED_IDLE float, 
QUOTA float, 
TR_UOM varchar(50), 
PCP_ID varchar(50),
Task_ID varchar(50),
PC_ProcessCode varchar(50), 
PCP_Project varchar(50)
); 

DECLARE @TemptaskDetails_@mPIC TABLE(
RowNumber bigint,
TR_Index bigint,
WORKDATE Date,
TR_ID varchar(100),
TR_UID varchar(50), 
TR_ActualTaskIn DateTime,
TR_OutDate DateTime,
WORKED_HOURS float,  
ACTUAL_WORKED_HOURS float, 
TR_Status int,
TR_Apporval int,
TR_MID varchar(50),
TR_PIC varchar(50),
TR_Shipment varchar(1000),
TR_File varchar(500),
[USER_OUTPUT] float,
ACTUAL_OUTPUT float,
QUOTA float, 
ACTUAL_QUOTA float, 
TR_UOM varchar(50), 
PCP_ID varchar(50),
Task_ID varchar(50),
PC_ProcessCode varchar(50), 
PCP_Project varchar(50)
); 

DECLARE @TempSUMtaskDetails_@mPIC TABLE(
WORKDATE Date,
TR_UID varchar(50), 
WORKED_HOURS float, 
ACTUAL_WORKED_HOURS float, 
[USER_OUTPUT] float,
ONLY_DONE_OUTPUT float,
QUOTA float, 
ACTUAL_QUOTA float
); 


DECLARE @TempidleDetails_@mPIC TABLE(
IDLE_Index bigint,
WORKDATE Date,
IDLE_ID varchar(100),
IDLE_UID varchar(50), 
IDLE_InDate DateTime,
IDLE_OutDate DateTime,
IDLE_TIME float, 
IDLE_Reason varchar(200),
IDLE_MID varchar(50), 
IDLE_PIC varchar(50), 
IDLE_Project nvarchar(50)
);

DECLARE @TempsumofidleDetails_@mPIC TABLE(
WORKDATE Date,
IDLE_UID varchar(50), 
APPROVED_IDLE float,
IDLE_Project nvarchar(50)
);

DECLARE @TempAMSDIFF_@mPIC TABLE(
[UID] varchar(50), 
[WORKDATE] DateTime,
[LOGIN] DateTime,
[LOGOUT] DateTime,
[AMSDIFF] float,
[TASKIN] DateTime,
[TASKOUT] DateTime,
[TASKDIFF] float,
[DAY_DIFF] float
); 

/* AMS DIFF AND TASK DIFF */
INSERT INTO @TempAMSDIFF_@mPIC
SELECT T.TR_UID,CONVERT(date, T.TR_ActualTaskIn) AS [WORKDATE],L.FIRSTLOGIN,L.LASTLOGOUT,ROUND(ISNULL(CAST(L.LASTLOGOUT - L.FIRSTLOGIN AS float),0)*24,2),MIN(T.TR_ActualTaskIn),MAX(T.TR_OutDate), ROUND(ISNULL(CAST(MAX(T.TR_OutDate) - MIN(T.TR_ActualTaskIn) AS float),0)*24,2),  ROUND((ROUND(ISNULL(CAST(L.LASTLOGOUT - L.FIRSTLOGIN AS float),0)*24,2)) - (ROUND(ISNULL(CAST(MAX(T.TR_OutDate) - MIN(T.TR_ActualTaskIn) AS float),0)*24,2)),2) AS [DAY_DIFF]
FROM tbl_TaskRecordDetail T
INNER JOIN tbl_UserLILO L ON T.TR_UID=L.[UID] AND L.[DATE]=convert(date, T.TR_ActualTaskIn)
WHERE T.TR_PIC=@mPIC AND T.TR_ActualTaskIn BETWEEN @mFrom AND @mTo
GROUP BY T.TR_UID,CONVERT(date, T.TR_ActualTaskIn),L.FIRSTLOGIN,L.LASTLOGOUT

/* IDLE DETAILS */
INSERT INTO @TempidleDetails_@mPIC 
	SELECT i.IDLE_Index, CONVERT(date, i.IDLE_InDate) AS [WORKDATE], i.IDLE_ID, i.IDLE_UID, i.IDLE_InDate,i.IDLE_OutDate,ROUND(ISNULL(CAST(i.IDLE_OutDate- i.IDLE_InDate AS float),0),2) AS [IDLE_TIME], i.IDLE_Reason,i.IDLE_MID, i.IDLE_PIC, h.IDLE_Project
	FROM tbl_IDLEDetail i
	INNER JOIN tbl_IDLEHeader h ON h.IDLE_ID=i.IDLE_ID
	WHERE i.IDLE_Apporval=2 AND i.IDLE_InDate BETWEEN @mFrom AND @mTo AND i.IDLE_PIC=@mPIC AND h.IDLE_UID=@mUID

/* SUM OF IDLE DETAILS */
INSERT INTO @TempsumofidleDetails_@mPIC
	SELECT TOP (999999999999999999) [WORKDATE], IDLE_UID, SUM ([IDLE_TIME]) AS [APPROVED_IDLE], IDLE_Project
	FROM @TempidleDetails_@mPIC 
	GROUP BY [WORKDATE], IDLE_UID, IDLE_Project
	ORDER BY [WORKDATE], IDLE_UID, IDLE_Project

/* TASK TIME GAP */
INSERT INTO @TemptblDifference_@mPIC 
	SELECT TOP (999999999999999999) ROW_NUMBER() OVER(ORDER BY d.TR_UID) AS RowNumber, d.TR_Index, CONVERT(date, d.TR_ActualTaskIn) AS [WORKDATE], d.TR_ID, d.TR_UID, d.TR_ActualTaskIn, d.TR_OutDate, d.TR_Status, d.TR_Apporval,d.TR_MID,d.TR_PIC,d.TR_Shipment,d.TR_File,ROUND(ISNULL(CAST(d.TR_FileSize AS float),0),2) AS [ACTUAL_OUTPUT],d.TR_Hours AS [WORKED_HOURS], 
	CASE WHEN (SELECT COUNT(rec.TR_ID) AS [RecCOUNT] FROM tbl_TaskRecordDetail rec WHERE d.PCP_ID=rec.PCP_ID AND d.Task_ID=rec.Task_ID) > 1 THEN (CASE WHEN d.TR_Apporval=2 AND d.TR_Status=3 THEN (ams.AMSDIFF+(SELECT SUM(rec.AMS_DIFF) FROM @TemptblDifference_@mPIC rec WHERE d.PCP_ID=rec.PCP_ID AND d.Task_ID=rec.Task_ID AND rec.TR_Status=2 AND rec.TR_Apporval=4)) ELSE (ams.AMSDIFF) END) ELSE (ISNULL(ams.AMSDIFF,0)) END AS [ACTUAL_AMSDIFF]
	,ISNULL(idl.APPROVED_IDLE,0),ROUND(ISNULL(CAST(d.TR_Quota AS float),0),2) AS [QUOTA], d.TR_UOM, d.PCP_ID, d.Task_ID, p.PC_ProcessCode, p.PCP_Project
    FROM tbl_TaskRecordDetail d
	LEFT OUTER JOIN @TempAMSDIFF_@mPIC ams ON d.TR_UID=ams.[UID] AND CONVERT(date, d.TR_OutDate)=ams.WORKDATE
	LEFT OUTER JOIN tbl_PCPDetail p ON d.PCP_ID=p.PCP_ID AND p.Task_ID=d.Task_ID
	LEFT OUTER JOIN @TempsumofidleDetails_@mPIC idl ON idl.IDLE_Project=p.PCP_Project AND  d.TR_UID=idl.IDLE_UID AND CONVERT(date, d.TR_OutDate)=idl.WORKDATE
	WHERE d.TR_ActualTaskIn BETWEEN @mFrom AND @mTo AND d.TR_PIC=@mPIC AND d.TR_Apporval=2
	ORDER BY d.TR_UID

/* TASK DETAILS */ -- Any Fiter Apply to This ###################
INSERT INTO @TemptaskDetails_@mPIC 
	SELECT cur.RowNumber, cur.TR_Index, CONVERT(date, cur.TR_OutDate) AS [WORKDATE], cur.TR_ID, cur.TR_UID, cur.TR_ActualTaskIn, cur.TR_OutDate,cur.[WORKED_HOURS], ISNULL(CAST(cur.TR_OutDate - cur.TR_ActualTaskIn AS float),0)*24 AS ACTUAL_WORKED_HOURS, cur.TR_Status, cur.TR_Apporval,cur.TR_MID,cur.TR_PIC,cur.TR_Shipment,cur.TR_File,cur.[ACTUAL_OUTPUT],CASE WHEN (SELECT COUNT(rec.TR_ID) AS [RecCOUNT] FROM tbl_TaskRecordDetail rec WHERE cur.PCP_ID=rec.PCP_ID AND cur.Task_ID=rec.Task_ID) > 1 THEN (CASE WHEN cur.TR_Apporval=2 AND cur.TR_Status=3 THEN (cur.[ACTUAL_OUTPUT]-(SELECT SUM(rec.TR_FileSize) FROM tbl_TaskRecordDetail rec WHERE cur.PCP_ID=rec.PCP_ID AND cur.Task_ID=rec.Task_ID AND rec.TR_Status=2 AND rec.TR_Apporval=4)) ELSE (cur.[ACTUAL_OUTPUT]) END) ELSE (cur.[ACTUAL_OUTPUT]) END AS [ACTUAL_OUTPUT],cur.[QUOTA], (cur.[QUOTA]/9) * (ISNULL(CAST(cur.TR_OutDate - cur.TR_ActualTaskIn AS float),0)*24) AS ACTUAL_QOUTA,cur.TR_UOM,cur.PCP_ID,cur.Task_ID,cur.PC_ProcessCode,cur.PCP_Project
	FROM @TemptblDifference_@mPIC cur
	LEFT OUTER JOIN @TemptblDifference_@mPIC previous
	ON cur.RowNumber = previous.RowNumber + 1 AND CONVERT(date, previous.TR_OutDate) = CONVERT(date, cur.TR_ActualTaskIn) AND previous.TR_UID=cur.TR_UID AND CONVERT(date, previous.TR_OutDate) = CONVERT(date, cur.TR_OutDate)


/* SUM OF TASK DETAILS */ ------- ##### ONLY BASED ON CLEAR AMS RECORDS #### 
INSERT INTO @TempSUMtaskDetails_@mPIC 
	SELECT cur.[WORKDATE], cur.TR_UID, SUM(cur.[WORKED_HOURS]) AS [SUM_WORKED_HOURS], SUM(cur.ACTUAL_WORKED_HOURS) AS [SUM_ACTUAL_WORKED_HOURS], SUM(cur.[USER_OUTPUT]) AS [SUM_USER_OUTPUT], SUM([ACTUAL_OUTPUT]) AS [SUM_ACTUAL_OUTPUT], SUM(cur.[QUOTA]) AS [SUM_QUOTA],  SUM(cur.ACTUAL_QUOTA) AS [SUM_ACTUAL_QUOTA]
	FROM @TemptaskDetails_@mPIC cur
	GROUP BY cur.[WORKDATE], cur.TR_UID
	ORDER BY cur.[WORKDATE]

SELECT *
FROM @TemptblDifference_@mPIC
WHERE TR_Status=3

--SELECT *
--FROM @TempNULLAMStaskDetails_@mPIC