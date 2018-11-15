SELECT ROW_NUMBER() OVER(ORDER BY TR_UID) AS RowNumber,TR_ID, CONVERT(date, TR_OutDate) AS [WORKDATE], TR_InDate, TR_OutDate, TR_UID,  SUM(TR_Hours) AS [WORKED HOURS], SUM(TR_FileSize) AS [OUTPUT]
FROM tbl_TaskRecordDetail
WHERE TR_InDate BETWEEN '2018-02-01' AND '2018-02-28' AND TR_PIC='ZDQ' AND (TR_Apporval=2 OR TR_Apporval=4)
GROUP BY CONVERT(date, TR_OutDate), TR_UID ,TR_ID, TR_InDate, TR_OutDate
ORDER BY TR_UID

SELECT TR_ID, [WORKDATE], TR_InDate, TR_OutDate, TR_UID, SUM([WORKED HOURS]) AS [WORKED HOURS], SUM([OUTPUT]) AS [OUTPUT], [REAL TASKED IN]
FROM (
	SELECT TOP (999999999999999999) new.TR_ID, CONVERT(date, new.TR_OutDate) AS [WORKDATE], new.TR_UID, CASE (CONVERT(date, new.TR_InDate)) WHEN CONVERT(date, new.TR_OutDate) THEN new.TR_Hours ELSE ((new.TR_Hours)-(SELECT SUM(old.TR_Hours) FROM tbl_TaskRecordDetail old WHERE old.TR_Apporval=4 AND new.PCP_ID=old.PCP_ID AND new.Task_ID=old.Task_ID)) END AS [WORKED HOURS], CASE (CONVERT(date, new.TR_InDate)) WHEN CONVERT(date, new.TR_OutDate) THEN new.TR_FileSize ELSE ((new.TR_FileSize)-(SELECT SUM(old.TR_FileSize) FROM tbl_TaskRecordDetail old WHERE old.TR_Apporval=4 AND new.PCP_ID=old.PCP_ID AND new.Task_ID=old.Task_ID)) END AS [OUTPUT], TR_InDate, TR_OutDate, CASE (CONVERT(date, new.TR_InDate)) WHEN CONVERT(date, new.TR_OutDate) THEN new.TR_Hours ELSE ((new.TR_OutDate)-(CASE (CONVERT(date, new.TR_InDate)) WHEN CONVERT(date, new.TR_OutDate) THEN new.TR_Hours ELSE ((new.TR_Hours)-(SELECT SUM(old.TR_Hours) FROM tbl_TaskRecordDetail old WHERE old.TR_Apporval=4 AND new.PCP_ID=old.PCP_ID AND new.Task_ID=old.Task_ID)) END)) END AS [REAL TASKED IN]
	FROM tbl_TaskRecordDetail new
	WHERE TR_InDate BETWEEN '2018-02-01' AND '2018-02-28' AND TR_PIC='ZDQ' AND (TR_Apporval=2 OR TR_Apporval=4)
	ORDER BY new.TR_UID,CONVERT(date, new.TR_OutDate)
) A 
GROUP BY [WORKDATE], TR_UID ,TR_ID, TR_InDate, TR_OutDate,[REAL TASKED IN]
ORDER BY TR_UID, TR_InDate
--, TR_InDate, TR_OutDate, TR_Quota, TR_UOM, TR_MID, TR_PIC, Task_ID, PCP_ID