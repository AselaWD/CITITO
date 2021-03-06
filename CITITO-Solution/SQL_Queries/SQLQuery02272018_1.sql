----DECLARE @K int;

----SET @K= 33400;

----SELECT ([ACTUAL_OUTPUT]/[QUOTA])* @K  AS [X1]
----FROM 
----(
----SELECT TOP (1000) CONVERT(date, td.TR_InDate),  td.TR_UID AS [UID], td.TR_ID AS [ID], CAST(td.TR_FileSize AS float) AS [ACTUAL_OUTPUT], CAST(td.TR_Quota AS float) AS [QUOTA], td.TR_Hours AS [WORKED_HOURS]
----FROM tbl_TaskRecordDetail td
----ORDER BY TR_InDate
----) Source_Detail


----SELECT TOP 1000 TR_UID, TR_InDate, TR_OutDate
----FROM tbl_TaskRecordDetail
----ORDER BY TR_InDate

--DECLARE @K int;

--SET @K= 33400;

----------------------------------
--WITH tblDifference AS
--(
--	SELECT TOP (999999999999999999) ROW_NUMBER() OVER(ORDER BY TR_UID) AS RowNumber, TR_Index, CONVERT(date, TR_OutDate) AS [WORKDATE], TR_ID, TR_UID, TR_InDate, TR_OutDate, TR_Status, TR_Apporval,TR_MID,TR_PIC,TR_Shipment,TR_File,CAST(TR_FileSize AS float) AS [ACTUAL_OUTPUT],TR_Hours AS [WORKED_HOURS],CAST(TR_Quota AS float) AS [QUOTA],TR_UOM,PCP_ID,Task_ID
--    FROM tbl_TaskRecordDetail 
--	WHERE TR_InDate BETWEEN '2018-01-07' AND '2018-02-26' AND TR_PIC='ZDQ'
--	ORDER BY TR_UID
--),
--taskDetails AS(
--	SELECT cur.RowNumber, cur.TR_Index, CONVERT(date, cur.TR_OutDate) AS [WORKDATE], cur.TR_ID, cur.TR_UID, cur.TR_InDate, cur.TR_OutDate,cur.[WORKED_HOURS], CAST((cur.TR_InDate - previous.TR_OutDate) AS float) AS [WASTE_HOURS],(cur.[ACTUAL_OUTPUT]/cur.[QUOTA])* @K AS [X1],(cur.[WORKED_HOURS] + (CAST((cur.TR_OutDate - cur.TR_InDate) AS float)) ) AS [HRS+WASTE],  cur.TR_Status, cur.TR_Apporval,cur.TR_MID,cur.TR_PIC,cur.TR_Shipment,cur.TR_File,cur.[ACTUAL_OUTPUT],cur.[QUOTA],cur.TR_UOM,cur.PCP_ID,cur.Task_ID
--	FROM tblDifference cur
--	LEFT OUTER JOIN tblDifference previous
--	ON cur.RowNumber = previous.RowNumber + 1 AND CONVERT(date, previous.TR_InDate) = CONVERT(date, cur.TR_InDate)
--),
--idleRowData AS (
--	SELECT IDLE_Index, CONVERT(date, TR_OutDate) AS [WORKDATE], IDLE_ID, IDLE_UID, IDLE_InDate,IDLE_OutDate,CAST(IDLE_OutDate- IDLE_InDate AS float) AS [IDLE_TIME], IDLE_Reason,IDLE_MID, IDLE_PIC
--	FROM tbl_IDLEDetail i
--	INNER JOIN taskDetails t ON CONVERT(date, i.IDLE_InDate)=t.WORKDATE AND i.IDLE_UID=t.TR_UID
--	WHERE IDLE_Apporval=2 AND IDLE_InDate BETWEEN '2018-01-07' AND '2018-02-26' AND IDLE_PIC='ZDQ'
--)





--SELECT [WORKDATE], TR_UID, SUM(WASTE_HOURS)
--FROM taskDetails
--GROUP BY [WORKDATE], TR_UID
--ORDER BY [WORKDATE], TR_UID

--SELECT *
--FROM idleRowData


--SELECT CASE 
--            WHEN [WASTE_HOURS]<0
--               THEN 
--			   1 
--               ELSE 
--			   0 
--       END as CHECK_MINUS, * 
--FROM taskDetails