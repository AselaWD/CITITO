/* Wokred Shift for 9 hours */
DECLARE @K int;
DECLARE @mPIC nvarchar(20); 
DECLARE @mFrom DateTime; 
DECLARE @mTo DateTime;
DECLARE @mUID nvarchar(20); 

SET @K=32400;
SET @mPIC = 'EC4';
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
[LOGIN] DateTime,
[LOGOUT] DateTime,
AMS_DIFF float,
IDLE_InDate DateTime,
IDLE_OutDate DateTime,
IDLE_TIME float, 
QUOTA float, 
TR_UOM varchar(50), 
PCP_ID varchar(50),
Task_ID varchar(50),
PC_ProcessCode varchar(50), 
PCP_Project varchar(50)
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

DECLARE @TemptaskDetails_@mPIC TABLE(
RowNumber bigint,
TR_Index bigint,
WORKDATE Date,
TR_ID varchar(100),
TR_UID varchar(50), 
TR_ActualTaskIn DateTime,
TR_OutDate DateTime,
WORKED_HOURS float,  
[LOGIN] DateTime,
[LOGOUT] DateTime,
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


DECLARE @TemptaskDetailsQUOTA_Updated_@mPIC TABLE(
RowNumber bigint,
TR_Index bigint,
WORKDATE Date,
TR_ID varchar(100),
TR_UID varchar(50), 
TR_ActualTaskIn DateTime,
TR_OutDate DateTime,
WORKED_HOURS float,  
[LOGIN] DateTime,
[LOGOUT] DateTime,
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
PCP_Project varchar(50),
X1 float,
Y float,
X3 float
); 


DECLARE @TempsumofidleDetails_@mPIC TABLE(
WORKDATE Date,
IDLE_UID varchar(50), 
APPROVED_IDLE float,
PCP_Project varchar(50)
);

DECLARE @TempX1AndY_@mPIC TABLE(
RowNumber bigint,
TR_Index bigint,
WORKDATE Date,
TR_ID varchar(100),
TR_UID varchar(50), 
WORKED_HOURS float, 
[LOGIN] DateTime,
[LOGOUT] DateTime,
SUM_OF_AMS_HOURS float,
IDLE_HOURS float, 
TR_Status int,
TR_Apporval int,
TR_MID varchar(50),
TR_PIC varchar(50),
TR_Shipment varchar(1000),
TR_File varchar(500),
USER_OUTPUT float,
ACTUAL_OUTPUT float,
QUOTA float, 
ACTUAL_QUOTA float, 
TR_UOM varchar(50), 
PCP_ID varchar(50),
Task_ID varchar(50),
PC_ProcessCode varchar(50), 
PCP_Project varchar(50),
X1 float,
Y float
); 

DECLARE @TempX1AndY_@mPIC_DAY TABLE(
WORKDATE Date,
TR_UID varchar(50), 
WORKED_HOURS float, 
SUM_OF_AMS_HOURS float,
IDLE_HOURS float, 
USER_OUTPUT float,
ACTUAL_OUTPUT float,
QUOTA float, 
ACTUAL_QUOTA float, 
X1 float,
Y float
); 

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
	ams.FIRSTLOGIN,ams.LASTLOGOUT,ISNULL(CAST(ams.LASTLOGOUT - ams.FIRSTLOGIN AS float)*24,0),idl.IDLE_InDate,IDLE_OutDate,ISNULL(CAST(idl.IDLE_OutDate - idl.IDLE_InDate AS float)*24,0),
	ROUND(ISNULL(CAST(d.TR_Quota AS float),0),2) AS [QUOTA], d.TR_UOM, d.PCP_ID, d.Task_ID, p.PC_ProcessCode, p.PCP_Project
    FROM tbl_TaskRecordDetail d
	LEFT OUTER JOIN tbl_UserLILO ams ON d.TR_UID=ams.[UID] AND CONVERT(date, d.TR_ActualTaskIn)=CONVERT(date, ams.[DATE])
	LEFT OUTER JOIN tbl_PCPDetail p ON d.PCP_ID=p.PCP_ID AND p.Task_ID=d.Task_ID
	LEFT OUTER JOIN @TempidleDetails_@mPIC idl ON idl.IDLE_Project=p.PCP_Project AND  d.TR_UID=idl.IDLE_UID AND CONVERT(date, d.TR_OutDate)=idl.WORKDATE
	WHERE d.TR_ActualTaskIn BETWEEN @mFrom AND @mTo AND d.TR_PIC=@mPIC AND d.TR_Status IS NOT NULL
	ORDER BY d.TR_UID

/* TASK DETAILS */ -- Any Fiter Apply to This ###################
INSERT INTO @TemptaskDetails_@mPIC 
	SELECT cur.RowNumber, cur.TR_Index, CONVERT(date, cur.TR_OutDate) AS [WORKDATE], cur.TR_ID, cur.TR_UID, cur.TR_ActualTaskIn, cur.TR_OutDate,cur.[WORKED_HOURS], 
	cur.[LOGIN],cur.[LOGOUT],
	/*ISNULL(CAST(cur.TR_OutDate - cur.TR_ActualTaskIn AS float),0)*24 AS ACTUAL_WORKED_HOURS*/
	CASE WHEN (SELECT COUNT(rec.TR_ID) AS [RecCOUNT] FROM tbl_TaskRecordDetail rec WHERE cur.PCP_ID=rec.PCP_ID AND cur.Task_ID=rec.Task_ID) > 1 THEN (CASE WHEN cur.TR_Apporval=2 AND cur.TR_Status=3 THEN ISNULL((cur.AMS_DIFF+(SELECT SUM(rec.AMS_DIFF) FROM @TemptblDifference_@mPIC rec WHERE cur.PCP_ID=rec.PCP_ID AND cur.Task_ID=rec.Task_ID AND rec.TR_Status=2 AND rec.TR_Apporval=4)),cur.AMS_DIFF) ELSE (cur.AMS_DIFF) END) ELSE (cur.AMS_DIFF) END AS [ACTUAL_WORKED_HOURS]
	, cur.TR_Status, cur.TR_Apporval,cur.TR_MID,cur.TR_PIC,cur.TR_Shipment,cur.TR_File,cur.[ACTUAL_OUTPUT],
	CASE WHEN (SELECT COUNT(rec.TR_ID) AS [RecCOUNT] FROM tbl_TaskRecordDetail rec WHERE cur.PCP_ID=rec.PCP_ID AND cur.Task_ID=rec.Task_ID) > 1 THEN (CASE WHEN cur.TR_Apporval=2 AND cur.TR_Status=3 THEN (cur.[ACTUAL_OUTPUT]-(SELECT SUM(rec.TR_FileSize) FROM tbl_TaskRecordDetail rec WHERE cur.PCP_ID=rec.PCP_ID AND cur.Task_ID=rec.Task_ID AND rec.TR_Status=2 AND rec.TR_Apporval=4)) ELSE (cur.[ACTUAL_OUTPUT]) END) ELSE (cur.[ACTUAL_OUTPUT]) END AS [ACTUAL_OUTPUT]
	,cur.[QUOTA], (0) AS ACTUAL_QOUTA,cur.TR_UOM,cur.PCP_ID,cur.Task_ID,cur.PC_ProcessCode,cur.PCP_Project
	FROM @TemptblDifference_@mPIC cur
	LEFT OUTER JOIN @TemptblDifference_@mPIC previous
	ON cur.RowNumber = previous.RowNumber + 1 AND CONVERT(date, previous.TR_OutDate) = CONVERT(date, cur.TR_ActualTaskIn) AND previous.TR_UID=cur.TR_UID AND CONVERT(date, previous.TR_OutDate) = CONVERT(date, cur.TR_OutDate)
	--WHERE cur.[LOGIN] IS NOT NULL OR cur.[LOGOUT] IS NOT NULL
	WHERE cur.TR_Status=3 AND cur.TR_Apporval=2 /*AND cur.TR_UID=@mUID*/


INSERT INTO @TemptaskDetailsQUOTA_Updated_@mPIC 
	SELECT cur.RowNumber, cur.TR_Index, CONVERT(date, cur.TR_OutDate) AS [WORKDATE], cur.TR_ID, cur.TR_UID, cur.TR_ActualTaskIn, cur.TR_OutDate,cur.[WORKED_HOURS], 
	cur.[LOGIN],cur.[LOGOUT], cur.ACTUAL_WORKED_HOURS, cur.TR_Status, cur.TR_Apporval,cur.TR_MID,cur.TR_PIC,cur.TR_Shipment,cur.TR_File,cur.USER_OUTPUT,
	cur.[ACTUAL_OUTPUT] AS [ACTUAL_OUTPUT],cur.[QUOTA], (cur.[QUOTA]/9) * cur.[WORKED_HOURS] AS ACTUAL_QOUTA,cur.TR_UOM,cur.PCP_ID,cur.Task_ID,cur.PC_ProcessCode,cur.PCP_Project, (cur.ACTUAL_OUTPUT/cur.QUOTA) * @K AS X1, (cur.WORKED_HOURS * 3600)  AS Y, (((cur.ACTUAL_OUTPUT/cur.QUOTA) * @K)/(cur.WORKED_HOURS * 3600)) * 100 AS X3
FROM @TemptaskDetails_@mPIC cur


--######################################## QUERIES START ##################################
--SELECT *
--FROM @TemptblDifference_@mPIC

SELECT *
FROM @TemptaskDetailsQUOTA_Updated_@mPIC

SELECT tsk.WORKDATE,tsk.TR_UID, SUM(tsk.WORKED_HOURS) AS WORKED_HOURS, MAX(tsk.ACTUAL_WORKED_HOURS) AS ACTUAL_WORKED_HOURS, SUM(tsk.USER_OUTPUT) AS USER_OUTPUT, SUM(tsk.ACTUAL_OUTPUT) AS ACTUAL_OUTPUT, MAX(ISNULL(idle.APPROVED_IDLE,0)) AS APPROVED_IDLE, SUM(tsk.X1) AS SUM_OF_X1, (MAX(tsk.ACTUAL_WORKED_HOURS) * 3600)  AS Y, (SUM(tsk.X1)/((MAX(tsk.ACTUAL_WORKED_HOURS) * 3600)- ISNULL(idle.APPROVED_IDLE,0))) * 100 AS X3/**/
FROM @TemptaskDetailsQUOTA_Updated_@mPIC tsk
LEFT OUTER JOIN @TempsumofidleDetails_@mPIC idle ON tsk.WORKDATE=idle.WORKDATE AND tsk.TR_UID=idle.IDLE_UID
WHERE tsk.[LOGIN] IS NOT NULL AND tsk.[LOGOUT] IS NOT NULL
GROUP BY tsk.WORKDATE, tsk.TR_UID, idle.APPROVED_IDLE
