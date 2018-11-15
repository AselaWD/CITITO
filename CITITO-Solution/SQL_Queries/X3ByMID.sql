EXEC Dboard_CurrentTeamCapacity_DetailedByPIC 'EC4'

EXEC DBoard_X3byProject_User 'EC4', '2018-02-01', '2018-02-28'

EXEC DBoard_X3byTask_User_FilterByUser 'ZDQ', '2018-02-01', '2018-02-28', '6CP'


CREATE PROC DBoard_X3byTeam_Ranked @mPIC nvarchar(20), @mFrom DateTime, @mTo DateTime

AS
/* Wokred Shift for 9 hours */
DECLARE @K int;

SET @K= 32400;

DECLARE @TemptblDifference_@mPIC TABLE(
RowNumber bigint,
TR_Index bigint,
WORKDATE Date,
TR_ID nvarchar(100),
TR_UID nvarchar(50), 
TR_InDate DateTime,
TR_OutDate DateTime,
TR_Status int,
TR_Apporval int,
TR_MID nvarchar(50),
TR_PIC nvarchar(50),
TR_Shipment nvarchar(100),
TR_File nvarchar(100),
ACTUAL_OUTPUT float,
WORKED_HOURS float,
QUOTA float, 
TR_UOM nvarchar(50), 
PCP_ID nvarchar(50),
Task_ID nvarchar(50),
PC_ProcessCode nvarchar(50), 
PCP_Project nvarchar(50)
); 

DECLARE @TemptaskDetails_@mPIC TABLE(
RowNumber bigint,
TR_Index bigint,
WORKDATE Date,
TR_ID nvarchar(100),
TR_UID nvarchar(50), 
TR_InDate DateTime,
TR_OutDate DateTime,
WORKED_HOURS float, 
WASTE_HOURS float,
X1 float,
HRS_WASTE float,
TR_Status int,
TR_Apporval int,
TR_MID nvarchar(50),
TR_PIC nvarchar(50),
TR_Shipment nvarchar(100),
TR_File nvarchar(100),
ACTUAL_OUTPUT float,
QUOTA float, 
TR_UOM nvarchar(50), 
PCP_ID nvarchar(50),
Task_ID nvarchar(50),
PC_ProcessCode nvarchar(50), 
PCP_Project nvarchar(50)
); 

DECLARE @TempidleDetails_@mPIC TABLE(
IDLE_Index bigint,
WORKDATE Date,
IDLE_ID nvarchar(100),
IDLE_UID nvarchar(50), 
IDLE_InDate DateTime,
IDLE_OutDate DateTime,
IDLE_TIME float, 
IDLE_Reason nvarchar(200),
IDLE_MID nvarchar(50), 
IDLE_PIC nvarchar(50), 
IDLE_Project nvarchar(50)
);

INSERT INTO @TemptblDifference_@mPIC 
	SELECT TOP (999999999999999999) ROW_NUMBER() OVER(ORDER BY d.TR_UID) AS RowNumber, d.TR_Index, CONVERT(date, d.TR_OutDate) AS [WORKDATE], d.TR_ID, d.TR_UID, d.TR_InDate, d.TR_OutDate, d.TR_Status, d.TR_Apporval,d.TR_MID,d.TR_PIC,d.TR_Shipment,d.TR_File,ISNULL(CAST(d.TR_FileSize AS float),0) AS [ACTUAL_OUTPUT],d.TR_Hours AS [WORKED_HOURS],ISNULL(CAST(d.TR_Quota AS float),0) AS [QUOTA], d.TR_UOM, d.PCP_ID, d.Task_ID, p.PC_ProcessCode, p.PCP_Project
    FROM tbl_TaskRecordDetail d
	LEFT OUTER JOIN tbl_PCPDetail p ON d.PCP_ID=p.PCP_ID AND p.Task_ID=d.Task_ID
	WHERE d.TR_InDate BETWEEN @mFrom AND @mTo AND d.TR_PIC=@mPIC
	ORDER BY d.TR_UID

INSERT INTO @TemptaskDetails_@mPIC 
	SELECT cur.RowNumber, cur.TR_Index, CONVERT(date, cur.TR_OutDate) AS [WORKDATE], cur.TR_ID, cur.TR_UID, cur.TR_InDate, cur.TR_OutDate,cur.[WORKED_HOURS], ISNULL(CAST((cur.TR_InDate - previous.TR_OutDate) AS float),0) AS [WASTE_HOURS],(cur.[ACTUAL_OUTPUT]/cur.[QUOTA])* @K AS [X1],(cur.[WORKED_HOURS] + ISNULL(CAST((cur.TR_OutDate - cur.TR_InDate) AS float),0)) AS [HRS+WASTE],  cur.TR_Status, cur.TR_Apporval,cur.TR_MID,cur.TR_PIC,cur.TR_Shipment,cur.TR_File,cur.[ACTUAL_OUTPUT],cur.[QUOTA],cur.TR_UOM,cur.PCP_ID,cur.Task_ID,cur.PC_ProcessCode,cur.PCP_Project
	FROM @TemptblDifference_@mPIC cur
	LEFT OUTER JOIN @TemptblDifference_@mPIC previous
	ON cur.RowNumber = previous.RowNumber + 1 AND CONVERT(date, previous.TR_OutDate) = CONVERT(date, cur.TR_InDate) AND previous.TR_UID=cur.TR_UID AND CONVERT(date, previous.TR_OutDate) = CONVERT(date, cur.TR_OutDate)

INSERT INTO @TempidleDetails_@mPIC 
	SELECT i.IDLE_Index, CONVERT(date, i.IDLE_InDate) AS [WORKDATE], i.IDLE_ID, i.IDLE_UID, i.IDLE_InDate,i.IDLE_OutDate,ISNULL(CAST(i.IDLE_OutDate- i.IDLE_InDate AS float),0) AS [IDLE_TIME], i.IDLE_Reason,i.IDLE_MID, i.IDLE_PIC, h.IDLE_Project
	FROM tbl_IDLEDetail i
	INNER JOIN tbl_IDLEHeader h ON h.IDLE_ID=i.IDLE_ID
	WHERE i.IDLE_Apporval=2 AND i.IDLE_InDate BETWEEN @mFrom AND @mTo AND i.IDLE_PIC=@mPIC
;
WITH approveDoneRecords AS(
	SELECT cur.RowNumber, cur.TR_Index, CONVERT(date, cur.TR_OutDate) AS [WORKDATE], cur.TR_ID, cur.TR_UID, cur.[WORKED_HOURS], cur.TR_Status, cur.TR_Apporval,cur.TR_MID,cur.TR_PIC,cur.TR_Shipment,cur.TR_File,cur.[ACTUAL_OUTPUT],cur.[QUOTA],cur.TR_UOM,cur.PCP_ID,cur.Task_ID, cur.PC_ProcessCode,cur.PCP_Project
	FROM @TemptblDifference_@mPIC cur
	LEFT OUTER JOIN @TemptblDifference_@mPIC previous
	ON cur.RowNumber = previous.RowNumber + 1 AND CONVERT(date, previous.TR_OutDate) = CONVERT(date, cur.TR_InDate) AND previous.TR_UID=cur.TR_UID AND CONVERT(date, previous.TR_OutDate) = CONVERT(date, cur.TR_OutDate)
	WHERE cur.TR_Status=3 AND cur.TR_Apporval=2
),
sumOfTapproveDoneRecords AS(
	SELECT TOP (999999999999999999) CONVERT(date, cur.TR_OutDate) AS [WORKDATE], cur.TR_UID, cur.TR_MID, SUM(cur.WORKED_HOURS) AS [WORKED_HOURS]
	FROM @TemptblDifference_@mPIC cur
	LEFT OUTER JOIN @TemptblDifference_@mPIC previous
	ON cur.RowNumber = previous.RowNumber + 1 AND CONVERT(date, previous.TR_OutDate) = CONVERT(date, cur.TR_InDate) AND previous.TR_UID=cur.TR_UID AND CONVERT(date, previous.TR_OutDate) = CONVERT(date, cur.TR_OutDate)
	WHERE cur.TR_Status=3 AND cur.TR_Apporval=2
	GROUP BY CONVERT(date, cur.TR_OutDate), cur.TR_UID, cur.TR_MID
	ORDER BY CONVERT(date, cur.TR_OutDate), cur.TR_UID, cur.TR_MID
),
sumOfTaskGap_WasteOurs AS(
	SELECT CONVERT(date, cur.TR_OutDate) AS [WORKDATE], cur.TR_UID, cur.TR_MID, ISNULL(SUM(CAST(cur.TR_InDate - previous.TR_OutDate AS float)), 0) AS [WASTE_HOURS]
	FROM @TemptblDifference_@mPIC cur
	LEFT OUTER JOIN @TemptblDifference_@mPIC previous
	ON cur.RowNumber = previous.RowNumber + 1 AND CONVERT(date, previous.TR_OutDate) = CONVERT(date, cur.TR_InDate) AND previous.TR_UID=cur.TR_UID AND CONVERT(date, previous.TR_OutDate) = CONVERT(date, cur.TR_OutDate)
	GROUP BY CONVERT(date, cur.TR_OutDate), cur.TR_UID, cur.TR_MID
),
sumOfidleDetails AS (
	SELECT TOP (999999999999999999) [WORKDATE], IDLE_UID, IDLE_MID, SUM ([IDLE_TIME]) AS [APPROVED_IDLE]
	FROM @TempidleDetails_@mPIC 
	GROUP BY [WORKDATE], IDLE_UID, IDLE_MID
	ORDER BY [WORKDATE], IDLE_UID, IDLE_MID
),

X1 AS (
	SELECT TOP (999999999999999999) WORKDATE, TR_UID, TR_MID, SUM(ACTUAL_OUTPUT) AS [OUTPUT], SUM(X1) AS [X1]
	FROM @TemptaskDetails_@mPIC
	GROUP BY WORKDATE, TR_UID, TR_MID
	ORDER BY WORKDATE, TR_UID, TR_MID
),

Y AS (
	SELECT TOP (999999999999999999) WK.WORKDATE, WK.TR_UID, WK.TR_MID,(ISNULL(WK.WORKED_HOURS,0)) AS [WORK_HOURS],(ISNULL(WK.WORKED_HOURS,0) + ISNULL(WHGAP.WASTE_HOURS,0) - ISNULL(IDLE.APPROVED_IDLE,0)) * @K AS [Y]
	FROM sumOfTapproveDoneRecords WK
	LEFT JOIN sumOfidleDetails IDLE ON WK.TR_UID =IDLE.IDLE_UID AND WK.WORKDATE = IDLE.WORKDATE AND WK.TR_MID=IDLE.IDLE_MID
	LEFT JOIN sumOfTaskGap_WasteOurs WHGAP ON  WK.TR_UID = WHGAP.TR_UID AND WK.WORKDATE = WHGAP.WORKDATE AND WHGAP.TR_MID=WK.TR_MID
),
X3 AS (
	SELECT TOP (999999999999999999) X.TR_UID, X.TR_MID, X.WORKDATE, [OUTPUT], X1, [WORK_HOURS], (X.X1/ISNULL(Y1.Y,1))*100 AS [X3]
	FROM Y Y1
	LEFT JOIN X1 X ON X.TR_UID =Y1.TR_UID AND X.WORKDATE = Y1.WORKDATE AND X.TR_MID= Y1.TR_MID
)

SELECT TR_MID AS [TEAM] AS [POJECT], SUM([OUTPUT]) AS [OUTPUT], ROUND(SUM([WORK_HOURS]),2) AS [WORK_HOURS],  ROUND(SUM(X1),2) AS [X1], ROUND(SUM(X3),2) AS [X3] 
FROM X3 WITH (NOLOCK)
GROUP BY TR_MID
ORDER BY X3 DESC

GO