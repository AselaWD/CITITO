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
WASTE_HOURS float,
X1 float,
TR_Status int,
TR_Apporval int,
TR_MID varchar(50),
TR_PIC varchar(50),
TR_Shipment varchar(1000),
TR_File varchar(500),
ACTUAL_OUTPUT float,
QUOTA float, 
TR_UOM varchar(50), 
PCP_ID varchar(50),
Task_ID varchar(50),
PC_ProcessCode varchar(50), 
PCP_Project varchar(50)
); 

DECLARE @TempCompletedDataRow_@mPIC TABLE(
RowNumber bigint,
TR_Index bigint,
WORKDATE Date,
TR_ID varchar(100),
TR_UID varchar(50), 
WORKED_HOURS float, 
WASTE_HOURS float,
TR_Status int,
TR_Apporval int,
TR_MID varchar(50),
TR_PIC varchar(50),
TR_Shipment varchar(1000),
TR_File varchar(500),
ACTUAL_OUTPUT float,
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

DECLARE @TempplusWaste_@mPIC TABLE(
TR_UID nvarchar(50), 
WASTE_HOURS float,
TR_Status int,
TR_Apporval int,
TR_MID varchar(50),
TR_PIC varchar(50),
TR_File varchar(100), 
PCP_ID varchar(50),
Task_ID varchar(50),
PC_ProcessCode varchar(50), 
PCP_Project varchar(50)
);

DECLARE @TempX1AndY_@mPIC TABLE(
RowNumber bigint,
TR_Index bigint,
WORKDATE Date,
TR_ID varchar(100),
TR_UID varchar(50), 
WORKED_HOURS float, 
WASTE_HOURS float,
TR_Status int,
TR_Apporval int,
TR_MID varchar(50),
TR_PIC varchar(50),
TR_Shipment varchar(1000),
TR_File varchar(500),
ACTUAL_OUTPUT float,
QUOTA float, 
TR_UOM varchar(50), 
PCP_ID varchar(50),
Task_ID varchar(50),
PC_ProcessCode varchar(50), 
PCP_Project varchar(50),
X1 float,
Y float
); 

DECLARE @TempX3_@mPIC TABLE(
RowNumber bigint,
TR_Index bigint,
WORKDATE Date,
TR_ID varchar(100),
TR_UID varchar(50), 
WORKED_HOURS float, 
WASTE_HOURS float,
TR_Status int,
TR_Apporval int,
TR_MID varchar(50),
TR_PIC varchar(50),
TR_Shipment varchar(1000),
TR_File varchar(500),
ACTUAL_OUTPUT float,
QUOTA float, 
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
APPROVED_IDLE float
);

DECLARE @TempTASKSDIFF_@mPIC TABLE(
[UID] varchar(50), 
[WORKDATE] DateTime,
[TASKIN] DateTime,
[TASKOUT] DateTime,
[TASKDIFF] float
); 

DECLARE @TempSumOfTASKSDIFF_@mPIC TABLE(
[UID] varchar(50), 
[WORKDATE] DateTime,
[TASKDIFF] float
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


/* TASK TIME GAP */
INSERT INTO @TemptblDifference_@mPIC 
	SELECT TOP (999999999999999999) ROW_NUMBER() OVER(ORDER BY d.TR_UID) AS RowNumber, d.TR_Index, CONVERT(date, d.TR_OutDate) AS [WORKDATE], d.TR_ID, d.TR_UID, d.TR_ActualTaskIn, d.TR_OutDate, d.TR_Status, d.TR_Apporval,d.TR_MID,d.TR_PIC,d.TR_Shipment,d.TR_File,ROUND(ISNULL(CAST(d.TR_FileSize AS float),0),2) AS [ACTUAL_OUTPUT],d.TR_Hours AS [WORKED_HOURS],ROUND(ISNULL(CAST(d.TR_Quota AS float),0),2) AS [QUOTA], d.TR_UOM, d.PCP_ID, d.Task_ID, p.PC_ProcessCode, p.PCP_Project
    FROM tbl_TaskRecordDetail d
	LEFT OUTER JOIN tbl_PCPDetail p ON d.PCP_ID=p.PCP_ID AND p.Task_ID=d.Task_ID
	WHERE d.TR_ActualTaskIn BETWEEN @mFrom AND @mTo AND d.TR_PIC=@mPIC
	ORDER BY d.TR_UID

/* TASK DETAILS */
INSERT INTO @TemptaskDetails_@mPIC 
	SELECT cur.RowNumber, cur.TR_Index, CONVERT(date, cur.TR_OutDate) AS [WORKDATE], cur.TR_ID, cur.TR_UID, cur.TR_ActualTaskIn, cur.TR_OutDate,cur.[WORKED_HOURS], CASE WHEN (SELECT COUNT(rec.TR_ID) AS [RecCOUNT] FROM tbl_TaskRecordDetail rec WHERE cur.PCP_ID=rec.PCP_ID AND cur.Task_ID=rec.Task_ID) > 1 THEN (CASE WHEN cur.TR_Apporval=4 THEN (ROUND(ISNULL(CAST((cur.TR_ActualTaskIn - previous.TR_OutDate) AS float),0),2)) ELSE (999999999999999999) END) ELSE (ROUND(ISNULL(CAST((cur.TR_ActualTaskIn - previous.TR_OutDate) AS float),0),2)) END AS [WASTE_HOURS],(cur.[ACTUAL_OUTPUT]/cur.[QUOTA])* @K AS [X1],  cur.TR_Status, cur.TR_Apporval,cur.TR_MID,cur.TR_PIC,cur.TR_Shipment,cur.TR_File,CASE WHEN (SELECT COUNT(rec.TR_ID) AS [RecCOUNT] FROM tbl_TaskRecordDetail rec WHERE cur.PCP_ID=rec.PCP_ID AND cur.Task_ID=rec.Task_ID) > 1 THEN (CASE WHEN cur.TR_Apporval=2 AND cur.TR_Status=3 THEN (cur.[ACTUAL_OUTPUT]-(SELECT SUM(rec.TR_FileSize) FROM tbl_TaskRecordDetail rec WHERE cur.PCP_ID=rec.PCP_ID AND cur.Task_ID=rec.Task_ID AND rec.TR_Status=2 AND rec.TR_Apporval=4)) ELSE (cur.[ACTUAL_OUTPUT]) END) ELSE (cur.[ACTUAL_OUTPUT]) END AS [ACTUAL_OUTPUT],cur.[QUOTA],cur.TR_UOM,cur.PCP_ID,cur.Task_ID,cur.PC_ProcessCode,cur.PCP_Project
	FROM @TemptblDifference_@mPIC cur
	LEFT OUTER JOIN @TemptblDifference_@mPIC previous
	ON cur.RowNumber = previous.RowNumber + 1 AND CONVERT(date, previous.TR_OutDate) = CONVERT(date, cur.TR_ActualTaskIn) AND previous.TR_UID=cur.TR_UID AND CONVERT(date, previous.TR_OutDate) = CONVERT(date, cur.TR_OutDate)

	/*AMS DETAIL*/
	--CASE WHEN T.WASTE_HOURS='1E+18' THEN 0 ELSE T.WASTE_HOURS END 
	--T.TR_OutDate,ROUND(ISNULL(CAST(T.TR_OutDate - T.TR_ActualTaskIn AS float),0)*24,2)
	INSERT INTO @TempTASKSDIFF_@mPIC
	SELECT T.TR_UID,CONVERT(date, T.TR_ActualTaskIn) AS [WORKDATE],MIN(T.TR_ActualTaskIn),MAX(T.TR_OutDate), ROUND(ISNULL(CAST(MAX(T.TR_OutDate) - MIN(T.TR_ActualTaskIn) AS float),0)*24,2)
	FROM @TemptaskDetails_@mPIC T
	WHERE T.TR_PIC=@mPIC AND T.TR_ActualTaskIn BETWEEN @mFrom AND @mTo
	GROUP BY T.TR_UID,CONVERT(date, T.TR_ActualTaskIn)

	--INSERT INTO @TempSumOfTASKSDIFF_@mPIC
	--SELECT [UID],WORKDATE, SUM(TASKDIFF)
	--FROM @TempTASKSDIFF_@mPIC
	--GROUP BY [UID],WORKDATE
	--ORDER BY [UID]

	INSERT INTO @TempAMSDIFF_@mPIC
	SELECT T.TR_UID,CONVERT(date, T.TR_ActualTaskIn) AS [WORKDATE],L.FIRSTLOGIN,L.LASTLOGOUT,ROUND(ISNULL(CAST(L.LASTLOGOUT - L.FIRSTLOGIN AS float),0)*24,2),MIN(T.TR_ActualTaskIn),MAX(T.TR_OutDate), ROUND(ISNULL(CAST(MAX(T.TR_OutDate) - MIN(T.TR_ActualTaskIn) AS float),0)*24,2),  ROUND((ROUND(ISNULL(CAST(L.LASTLOGOUT - L.FIRSTLOGIN AS float),0)*24,2)) - (ROUND(ISNULL(CAST(MAX(T.TR_OutDate) - MIN(T.TR_ActualTaskIn) AS float),0)*24,2)),2) AS [DAY_DIFF]
	FROM tbl_TaskRecordDetail T
	INNER JOIN tbl_UserLILO L ON T.TR_UID=L.[UID] AND L.[DATE]=convert(date, T.TR_ActualTaskIn)
	WHERE T.TR_PIC=@mPIC AND T.TR_ActualTaskIn BETWEEN @mFrom AND @mTo AND T.TR_UID='0AC'
	GROUP BY T.TR_UID,CONVERT(date, T.TR_ActualTaskIn),L.FIRSTLOGIN,L.LASTLOGOUT

	--SELECT T.TR_UID AS [UID], convert(date,L.[DATE]) AS [DATE],L.FIRSTLOGIN, L.LASTLOGOUT, CONVERT(TIME,MIN(T.TR_ActualTaskIn) - L.FIRSTLOGIN) AS [DIFFIN], CONVERT(TIME, (L.LASTLOGOUT - L.FIRSTLOGIN) - ((MIN(T.TR_ActualTaskIn) - L.FIRSTLOGIN) + (L.LASTLOGOUT - MAX(T.TR_OutDate)))) AS [SHIFT], CONVERT(TIME, L.LASTLOGOUT - MAX(T.TR_OutDate)) AS [DIFFOUT]
	--	FROM tbl_TaskRecordDetail T
	--	INNER JOIN tbl_UserLILO L ON T.TR_UID=L.[UID] AND L.[DATE]=convert(date, T.TR_ActualTaskIn)
	--	WHERE T.TR_PIC=@mPIC AND T.TR_ActualTaskIn BETWEEN @mFrom AND @mTo
	--	GROUP BY  T.TR_UID, L.[DATE], L.FIRSTLOGIN, L.LASTLOGOUT
	--	HAVING (CAST(ROUND(DATEDIFF(MINUTE,L.LASTLOGOUT, MAX(T.TR_OutDate))/60.0, 3)AS decimal (6,3))) NOT IN (0)
	--	ORDER BY L.[DATE] DESC

	--SELECT convert(date, WORKDATE) AS [WORKDATE], CAST(CAST(SUM(( DATEPART(hh, [DIFFIN]) * 3600 ) + ( DATEPART(mi, [DIFFIN]) * 60 ) + DATEPART(ss, [DIFFIN])) AS float)/3600 AS decimal(6,3)) AS [MORNING WASTE], CAST(CAST(SUM(( DATEPART(hh, [SHIFT]) * 3600 ) + ( DATEPART(mi, [SHIFT]) * 60 ) + DATEPART(ss, [SHIFT])) AS float)/3600 AS decimal(6,3)) AS [PRODUCTIVE HOURS], CAST(CAST(SUM(( DATEPART(hh, [DIFFOUT]) * 3600 ) + ( DATEPART(mi, [DIFFOUT]) * 60 ) + DATEPART(ss, [DIFFOUT])) AS float)/3600 AS decimal(6,3)) AS [AFTERNOON WASTE]
	--FROM @TempAMSDIFF_@mPIC
	--GROUP BY WORKDATE





/* IDLE DETAILS */
INSERT INTO @TempidleDetails_@mPIC 
	SELECT i.IDLE_Index, CONVERT(date, i.IDLE_InDate) AS [WORKDATE], i.IDLE_ID, i.IDLE_UID, i.IDLE_InDate,i.IDLE_OutDate,ROUND(ISNULL(CAST(i.IDLE_OutDate- i.IDLE_InDate AS float),0),2) AS [IDLE_TIME], i.IDLE_Reason,i.IDLE_MID, i.IDLE_PIC, h.IDLE_Project
	FROM tbl_IDLEDetail i
	INNER JOIN tbl_IDLEHeader h ON h.IDLE_ID=i.IDLE_ID
	WHERE i.IDLE_Apporval=2 AND i.IDLE_InDate BETWEEN @mFrom AND @mTo AND i.IDLE_PIC=@mPIC AND h.IDLE_UID=@mUID

/* WASTE PLUS DETAILS */
INSERT INTO @TempplusWaste_@mPIC 
	SELECT cur.TR_UID, SUM(cur.[WASTE_HOURS]) AS [WASTE_HOURS] ,cur.TR_Status, cur.TR_Apporval,cur.TR_MID,cur.TR_PIC,cur.TR_File,cur.PCP_ID,cur.Task_ID,cur.PC_ProcessCode,cur.PCP_Project
	FROM @TemptaskDetails_@mPIC cur
	WHERE cur.TR_Status=2 AND cur.TR_Apporval=4 AND cur.WASTE_HOURS!='1E+18'
	GROUP BY cur.TR_UID,cur.TR_Status, cur.TR_Apporval,cur.TR_MID,cur.TR_PIC,cur.TR_File,cur.PCP_ID,cur.Task_ID,cur.PC_ProcessCode,cur.PCP_Project

/* COLMPETEDE ACTUAL DATASET FOR QUERRIES */
INSERT INTO @TempCompletedDataRow_@mPIC 
SELECT dts.RowNumber, dts.TR_Index, dts.[WORKDATE], dts.TR_ID, dts.TR_UID, dts.[WORKED_HOURS],
       CASE WHEN ((CASE WHEN (SELECT COUNT(pls.WASTE_HOURS) FROM  @TempplusWaste_@mPIC pls WHERE dts.PCP_ID=pls.PCP_ID AND dts.TR_UID=pls.TR_UID AND dts.PCP_Project=pls.PCP_Project AND dts.Task_ID=pls.Task_ID AND dts.PC_ProcessCode=pls.PC_ProcessCode AND  dts.TR_Status=3 AND dts.TR_Apporval=2)>0 THEN (SELECT pls.WASTE_HOURS FROM  @TempplusWaste_@mPIC pls WHERE dts.PCP_ID=pls.PCP_ID AND dts.TR_UID=pls.TR_UID AND dts.PCP_Project=pls.PCP_Project AND dts.Task_ID=pls.Task_ID AND dts.PC_ProcessCode=pls.PC_ProcessCode AND  dts.TR_Status=3 AND dts.TR_Apporval=2) ELSE (CASE WHEN dts.WASTE_HOURS='1E+18' THEN 0 ELSE dts.WASTE_HOURS END) END))<0 THEN 0 ELSE ((CASE WHEN (SELECT COUNT(pls.WASTE_HOURS) FROM  @TempplusWaste_@mPIC pls WHERE dts.PCP_ID=pls.PCP_ID AND dts.TR_UID=pls.TR_UID AND dts.PCP_Project=pls.PCP_Project AND dts.Task_ID=pls.Task_ID AND dts.PC_ProcessCode=pls.PC_ProcessCode AND  dts.TR_Status=3 AND dts.TR_Apporval=2)>0 THEN (SELECT pls.WASTE_HOURS FROM  @TempplusWaste_@mPIC pls WHERE dts.PCP_ID=pls.PCP_ID AND dts.TR_UID=pls.TR_UID AND dts.PCP_Project=pls.PCP_Project AND dts.Task_ID=pls.Task_ID AND dts.PC_ProcessCode=pls.PC_ProcessCode AND  dts.TR_Status=3 AND dts.TR_Apporval=2) ELSE (CASE WHEN dts.WASTE_HOURS='1E+18' THEN 0 ELSE dts.WASTE_HOURS END) END)) END AS [WASTE_HOURS]
	   , dts.TR_Status, dts.TR_Apporval,dts.TR_MID,dts.TR_PIC,dts.TR_Shipment,dts.TR_File,dts.[ACTUAL_OUTPUT],dts.[QUOTA],dts.TR_UOM,dts.PCP_ID,dts.Task_ID, dts.PC_ProcessCode,dts.PCP_Project
FROM @TemptaskDetails_@mPIC dts
WHERE dts.TR_Apporval=2 AND dts.TR_Status=3
;

/* SUM OF IDLE DETAILS */
INSERT INTO @TempsumofidleDetails_@mPIC
	SELECT TOP (999999999999999999) [WORKDATE], IDLE_UID, SUM ([IDLE_TIME]) AS [APPROVED_IDLE]
	FROM @TempidleDetails_@mPIC 
	GROUP BY [WORKDATE], IDLE_UID
	ORDER BY [WORKDATE], IDLE_UID

/*X1 and Y columns added */
INSERT INTO @TempX1AndY_@mPIC
	SELECT ct.RowNumber,ct.TR_Index,ct.WORKDATE,ct.TR_ID,ct.TR_UID,ct.WORKED_HOURS,ct.WASTE_HOURS,ct.TR_Status,ct.TR_Apporval,ct.TR_MID,ct.TR_PIC,ct.TR_Shipment,ct.TR_File,ct.ACTUAL_OUTPUT,ct.QUOTA,ct.TR_UOM,ct.PCP_ID,ct.Task_ID,ct.PC_ProcessCode,ct.PCP_Project, (ct.ACTUAL_OUTPUT/((ct.QUOTA/9)*ct.WORKED_HOURS)) * @K, (ISNULL(ct.WORKED_HOURS,0) + ISNULL(ct.WASTE_HOURS,0) - ISNULL(IDLE.APPROVED_IDLE,0)) * @K AS [Y]
	FROM @TempCompletedDataRow_@mPIC ct
	LEFT JOIN @TempsumofidleDetails_@mPIC IDLE ON ct.TR_UID=IDLE.IDLE_UID AND ct.WORKDATE = IDLE.WORKDATE

/*X3 column added */
INSERT INTO @TempX3_@mPIC
	SELECT * , ROUND((xy.X1/xy.Y)*100,2)
	FROM @TempX1AndY_@mPIC xy




-- ################### RESULTS #################### --
SELECT *
FROM @TempAMSDIFF_@mPIC


--SELECT *
--FROM @TempCompletedDataRow_@mPIC

--SELECT *
--FROM @TempX1AndY_@mPIC

--/* X3 by UID */
--SELECT TR_UID,ROUND((SUM(X1)/SUM(Y)*100),2) AS X3,  RANK() OVER (ORDER BY (SUM(X1)/SUM(Y)*100) DESC) AS [RANK]
--FROM @TempX3_@mPIC
--GROUP BY TR_UID

--/* X3 by Team */
--SELECT TR_MID,ROUND((SUM(X1)/SUM(Y)*100),2) AS X3
--FROM @TempX3_@mPIC
--GROUP BY TR_MID

--/* X3 by Project */
--SELECT PCP_Project,ROUND((SUM(X1)/SUM(Y)*100),2) AS X3
--FROM @TempX3_@mPIC
--GROUP BY PCP_Project

--/* X3 by Task */
--SELECT PC_ProcessCode, Task_ID,ROUND((SUM(X1)/SUM(Y)*100),2) AS X3
--FROM @TempX3_@mPIC
--GROUP BY PC_ProcessCode, Task_ID

