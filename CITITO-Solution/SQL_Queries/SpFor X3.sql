CREATE PROC ScheduledX3Calculation 
AS 

set xact_abort on

/* Wokred Shift for 9 hours */
DECLARE @K int;
declare @starttime datetime
declare @endtime datetime
 

SET @K=32400;
set @starttime = getdate()  

TRUNCATE TABLE tbl_Report_TempidleDetails;
TRUNCATE TABLE tbl_Report_TempsumofidleDetails;
--TRUNCATE TABLE tbl_Report_TempModifiedTaskDetails;
TRUNCATE TABLE tbl_Report_TemptblDifference;
TRUNCATE TABLE tbl_Report_TemptaskDetails;
TRUNCATE TABLE tbl_Report_TemptaskDetailsQUOTA_Updated;


/* IDLE DETAILS */
INSERT INTO tbl_Report_TempidleDetails
	SELECT i.IDLE_Index, CONVERT(date, i.IDLE_InDate) AS [WORKDATE], i.IDLE_ID, i.IDLE_UID, i.IDLE_InDate,i.IDLE_OutDate,ROUND(ISNULL(CAST(i.IDLE_OutDate- i.IDLE_InDate AS float),0),2) AS [IDLE_TIME], i.IDLE_Reason,i.IDLE_MID, i.IDLE_PIC, h.IDLE_Project
	FROM tbl_IDLEDetail i
	INNER JOIN tbl_IDLEHeader h ON h.IDLE_ID=i.IDLE_ID
	/*WHERE i.IDLE_Apporval=2 AND i.IDLE_InDate BETWEEN @mFrom AND @mTo AND i.IDLE_PIC=@mPIC AND h.IDLE_UID=@mUID*/

/* SUM OF IDLE DETAILS */
INSERT INTO tbl_Report_TempsumofidleDetails
	SELECT TOP (999999999999999999) [WORKDATE], IDLE_UID, SUM ([IDLE_TIME]) AS [APPROVED_IDLE], IDLE_Project
	FROM tbl_Report_TempidleDetails 
	GROUP BY [WORKDATE], IDLE_UID, IDLE_Project
	ORDER BY [WORKDATE], IDLE_UID, IDLE_Project

/* MODIFIED TASK RECORDS */
--INSERT INTO tbl_Report_TempModifiedTaskDetails
--SELECT h.TR_ID
--      ,MAX(d.[TR_FileSize]) AS [MODIFIED_OUTPUT]
--      ,d.[TR_UID]
--      ,d.[TRM_PIC]
--      ,d.[TRM_MID]
--      ,MAX(d.[TRM_Hours]) AS [MODIFIED_HOURS]
--  FROM [CITITO].[dbo].[tbl_TaskRecordDetailModify] d
--  INNER JOIN [tbl_TaskRecordHeaderModify] h ON h.TRM_ID=d.TRM_ID
--  WHERE d.TRM_Apporval=2
--  GROUP BY h.TR_ID,d.[TR_UID],d.[TRM_PIC],d.[TRM_MID] 

/* TASK TIME GAP */
INSERT INTO tbl_Report_TemptblDifference 
	SELECT TOP (999999999999999999) ROW_NUMBER() OVER(ORDER BY d.TR_UID) AS RowNumber, d.TR_Index, CONVERT(date, d.TR_ActualTaskIn) AS [WORKDATE], d.TR_ID, d.TR_UID, d.TR_ActualTaskIn, d.TR_OutDate, d.TR_Status, d.TR_Apporval,d.TR_MID,d.TR_PIC,d.TR_Shipment,d.TR_File,ROUND(ISNULL(CAST(d.TR_FileSize AS float),0),2) AS [ACTUAL_OUTPUT],d.TR_Hours AS [WORKED_HOURS], 
	ams.FIRSTLOGIN,ams.LASTLOGOUT,ISNULL(CAST(ams.LASTLOGOUT - ams.FIRSTLOGIN AS float)*24,0),idl.IDLE_InDate,IDLE_OutDate,ISNULL(CAST(idl.IDLE_OutDate - idl.IDLE_InDate AS float)*24,0),
	ROUND(ISNULL(CAST(d.TR_Quota AS float),0),2) AS [QUOTA], d.TR_UOM, d.PCP_ID, d.Task_ID, p.PC_ProcessCode, p.PCP_Project
    FROM tbl_TaskRecordDetail d
	LEFT OUTER JOIN tbl_UserLILO ams ON d.TR_UID=ams.[UID] AND CONVERT(date, d.TR_ActualTaskIn)=CONVERT(date, ams.[DATE])
	LEFT OUTER JOIN tbl_PCPDetail p ON d.PCP_ID=p.PCP_ID AND p.Task_ID=d.Task_ID
	LEFT OUTER JOIN tbl_Report_TempidleDetails idl ON idl.IDLE_Project=p.PCP_Project AND  d.TR_UID=idl.IDLE_UID AND CONVERT(date, d.TR_OutDate)=idl.WORKDATE
	/*WHERE d.TR_ActualTaskIn BETWEEN @mFrom AND @mTo AND d.TR_PIC=@mPIC AND d.TR_Status IS NOT NULL*/
	ORDER BY d.TR_UID

/* TASK DETAILS */ -- Any Fiter Apply to This ###################
INSERT INTO tbl_Report_TemptaskDetails 
	SELECT cur.RowNumber, cur.TR_Index, CONVERT(date, cur.TR_OutDate) AS [WORKDATE], cur.TR_ID, cur.TR_UID, cur.TR_ActualTaskIn, cur.TR_OutDate,cur.[WORKED_HOURS], 
	cur.[LOGIN],cur.[LOGOUT],
	/*ISNULL(CAST(cur.TR_OutDate - cur.TR_ActualTaskIn AS float),0)*24 AS ACTUAL_WORKED_HOURS*/
	CASE WHEN (SELECT COUNT(rec.TR_ID) AS [RecCOUNT] FROM tbl_TaskRecordDetail rec WHERE cur.PCP_ID=rec.PCP_ID AND cur.Task_ID=rec.Task_ID) > 1 THEN (CASE WHEN cur.TR_Apporval=2 AND cur.TR_Status=3 THEN ISNULL((cur.AMS_DIFF+(SELECT SUM(rec.AMS_DIFF) FROM tbl_Report_TemptblDifference rec WHERE cur.PCP_ID=rec.PCP_ID AND cur.Task_ID=rec.Task_ID AND rec.TR_Status=2 AND rec.TR_Apporval=4)),cur.AMS_DIFF) ELSE (cur.AMS_DIFF) END) ELSE (cur.AMS_DIFF) END AS [ACTUAL_WORKED_HOURS]
	, cur.TR_Status, cur.TR_Apporval,cur.TR_MID,cur.TR_PIC,cur.TR_Shipment,cur.TR_File,cur.[ACTUAL_OUTPUT],
	CASE WHEN (SELECT COUNT(rec.TR_ID) AS [RecCOUNT] FROM tbl_TaskRecordDetail rec WHERE cur.PCP_ID=rec.PCP_ID AND cur.Task_ID=rec.Task_ID) > 1 THEN (CASE WHEN cur.TR_Apporval=2 AND cur.TR_Status=3 THEN (cur.[ACTUAL_OUTPUT]-(SELECT SUM(rec.TR_FileSize) FROM tbl_TaskRecordDetail rec WHERE cur.PCP_ID=rec.PCP_ID AND cur.Task_ID=rec.Task_ID AND rec.TR_Status=2 AND rec.TR_Apporval=4)) ELSE (cur.[ACTUAL_OUTPUT]) END) ELSE (cur.[ACTUAL_OUTPUT]) END AS [ACTUAL_OUTPUT]
	,cur.[QUOTA],cur.TR_UOM,cur.PCP_ID,cur.Task_ID,cur.PC_ProcessCode,cur.PCP_Project
	FROM tbl_Report_TemptblDifference cur
	LEFT OUTER JOIN tbl_Report_TemptblDifference previous
	ON cur.RowNumber = previous.RowNumber + 1 AND CONVERT(date, previous.TR_OutDate) = CONVERT(date, cur.TR_ActualTaskIn) AND previous.TR_UID=cur.TR_UID AND CONVERT(date, previous.TR_OutDate) = CONVERT(date, cur.TR_OutDate)
	--WHERE cur.[LOGIN] IS NOT NULL OR cur.[LOGOUT] IS NOT NULL
	WHERE cur.TR_Status=3 AND cur.TR_Apporval=2 /*AND cur.TR_UID=@mUID*/


INSERT INTO tbl_Report_TemptaskDetailsQUOTA_Updated 
	SELECT cur.RowNumber, cur.TR_Index, CONVERT(date, cur.TR_OutDate) AS [WORKDATE], cur.TR_ID, cur.TR_UID, cur.TR_ActualTaskIn, cur.TR_OutDate,cur.[WORKED_HOURS], 
	cur.[LOGIN],cur.[LOGOUT], cur.ACTUAL_WORKED_HOURS, cur.TR_Status, cur.TR_Apporval,cur.TR_MID,cur.TR_PIC,cur.TR_Shipment,cur.TR_File,cur.USER_OUTPUT,
	cur.[ACTUAL_OUTPUT] AS [ACTUAL_OUTPUT],cur.[QUOTA],cur.TR_UOM,cur.PCP_ID,cur.Task_ID,cur.PC_ProcessCode,cur.PCP_Project, ((cur.USER_OUTPUT/cur.QUOTA) * @K) AS X1, (cur.WORKED_HOURS * 3600)  AS Y, ((cur.USER_OUTPUT/cur.QUOTA) * @K/(cur.WORKED_HOURS * 3600)) * 100 AS X3
FROM tbl_Report_TemptaskDetails cur


set @endtime = GETDATE()
INSERT INTO tbl_QueryLog (WorkDate,StartTime,EndTime,ExecutedTime,QueryOwner,Workstation) VALUES(CONVERT(date, @starttime),@starttime,@endtime,ROUND(ISNULL(CAST(@endtime - @starttime AS float),0),4),CURRENT_USER, HOST_NAME())

GO