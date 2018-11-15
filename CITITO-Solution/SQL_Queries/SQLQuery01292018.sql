--SELECT td.TR_UID AS [UID], li.[LOGIN] AS [LOGIN], td.TR_InDate [Task In],td.TR_Productivity AS [Productivity], DATEDIFF(minute,li.[LOGIN],td.TR_InDate) AS [DIFF]
--FROM tbl_TaskRecordDetail td
--INNER JOIN [LILO] li ON li.USERID=td.TR_UID AND li.[LOGIN] BETWEEN '01-01-2018 00:00:00' AND '01-31-2018 23:59:59'
--WHERE td.TR_Apporval = 2 AND td.TR_Productivity> 150 AND td.TR_PIC = 'ZDQ' AND td.TR_InDate BETWEEN '01-01-2018 00:00:00' AND '01-31-2018 23:59:59' AND DATEDIFF(minute,li.[LOGIN],td.TR_InDate)> ((((5/60)*24)*60))
--ORDER BY td.TR_UID desc


--SELECT d.[UID], MIN(d.[Task In]) AS [FIRST TASK IN], FLILO.[FLOGIN], d.[DATE] AS [DATE]
--FROM (
--SELECT td.TR_UID AS [UID], td.TR_InDate AS [Task In],  CAST(td.TR_InDate AS date) AS [DATE]
--FROM tbl_TaskRecordDetail td
--WHERE td.TR_Apporval = 2 AND td.TR_Productivity> 150 AND td.TR_PIC = 'ZDQ' AND td.TR_InDate BETWEEN '01-01-2018 00:00:00' AND '01-31-2018 23:59:59'
--) d
--INNER JOIN
--(SELECT [USERID] AS [UID], [LOGIN] AS [FLOGIN], CAST(li.[LOGIN] AS date) AS [DATE]
--FROM [LILO] li 
--WHERE li.[LOGIN] BETWEEN '01-01-2018 00:00:00' AND '01-31-2018 23:59:59') FLILO ON FLILO.[DATE]=d.[DATE] AND FLILO.[UID]=d.[UID]

--GROUP BY d.[UID], d.[DATE],FLILO.[FLOGIN]
--ORDER BY d.[UID] desc



SELECT td.TR_Index AS [INDEX], td.TR_UID AS [UID], li.[LOGIN] AS [FLOGIN], td.TR_InDate AS [TASKIN], CAST(td.TR_InDate AS date) AS [DATE], DATEDIFF(minute,li.[LOGIN],td.TR_InDate) AS [DIFF]
FROM tbl_TaskRecordDetail td
INNER JOIN LILO li ON td.TR_UID=li.USERID AND CAST(li.[LOGIN] AS date)=CAST(td.TR_InDate AS date)
WHERE td.TR_Apporval = 2 AND td.TR_PIC = 'ZDQ' AND td.TR_InDate BETWEEN '01-01-2018 00:00:00' AND '01-31-2018 23:59:59' AND (DATEDIFF(minute,li.[LOGIN],td.TR_InDate))> ((((5/60)*24)*60))
ORDER BY td.TR_Index DESC



SELECT CAST(td.TR_InDate AS date) AS [DATE], td.TR_UID AS [UID], li.[LOGIN] AS [FLOGIN], MIN(td.TR_InDate) AS [TASKIN]
FROM tbl_TaskRecordDetail td 
INNER JOIN LILO li ON td.TR_UID=li.USERID AND CAST(li.[LOGIN] AS date)=CAST(td.TR_InDate AS date)
WHERE td.TR_Apporval = 2 AND td.TR_PIC = 'ZDQ' AND td.TR_InDate BETWEEN '01-01-2018 00:00:00' AND '01-31-2018 23:59:59'
GROUP BY CAST(td.TR_InDate AS date), td.TR_UID, li.[LOGIN]
ORDER BY CAST(td.TR_InDate AS date)



