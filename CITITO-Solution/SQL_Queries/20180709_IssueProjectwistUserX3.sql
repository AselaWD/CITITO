--/****** Script for SelectTopNRows command from SSMS  ******/
--SELECT TOP (1000) [WORKDATE]
--      ,[PCP_Project]
--      ,[TR_UID]
--      ,[TR_MID]
--      ,[TR_PIC]
--      ,[WORKED_HOURS]
--      ,[ACTUAL_WORKED_HOURS]
--      ,[USER_OUTPUT]
--      ,[ACTUAL_OUTPUT]
--      ,[APPROVED_IDLE]
--      ,[SUM_OF_X1]
--      ,[Y]
--      ,[X3]
--  FROM [CITITO].[dbo].[tbl_Report_TempDailyX3Project]
--  WHERE WORKDATE BETWEEN '2018-06-01' AND '2018-06-30' AND TR_PIC='LR3' AND TR_UID='WJ3'

SELECT
		tsk.WORKDATE,
		tsk.PCP_Project,
		--idle.PCP_Project AS IDLE_Project,
		tsk.TR_UID,
		tsk.TR_MID,
		tsk.TR_PIC, 
		SUM(tsk.WORKED_HOURS) AS WORKED_HOURS, 
		MAX(tsk.ACTUAL_WORKED_HOURS) AS ACTUAL_WORKED_HOURS, 
		SUM(tsk.USER_OUTPUT) AS USER_OUTPUT, 
		SUM(tsk.ACTUAL_OUTPUT) AS ACTUAL_OUTPUT, 
		NULL AS APPROVED_IDLE--, 
		--SUM(tsk.X1) AS SUM_OF_X1, 
		--(MAX(tsk.ACTUAL_WORKED_HOURS) * 3600)  AS Y, 
		--(SUM(tsk.X1)/((MAX(tsk.ACTUAL_WORKED_HOURS) * 3600)- ISNULL(idle.APPROVED_IDLE,0))) * 100 AS X3/**/
	FROM 
		tbl_Report_TemptaskDetailsQUOTA_Updated tsk
		--LEFT JOIN tbl_Report_TempsumofidleDetails idle ON tsk.WORKDATE=idle.WORKDATE AND tsk.TR_UID=idle.IDLE_UID
	WHERE 
		tsk.[LOGIN] IS NOT NULL AND tsk.[LOGOUT] IS NOT NULL AND tsk.WORKDATE BETWEEN '2018-06-01' AND '2018-06-30'  AND tsk.TR_PIC='LR3' AND tsk.TR_UID='WJ3'
	GROUP BY 
		tsk.WORKDATE, 
		tsk.PCP_Project, 
		--idle.PCP_Project,
		tsk.TR_UID, 		
		--idle.APPROVED_IDLE,
		tsk.TR_MID,
		tsk.TR_PIC

UNION

SELECT 
	WORKDATE, 
	IDLE_Project, 
	IDLE_UID, IDLE_PIC,
	IDLE_MID,
	NULL WORKED_HOURS,
	NULL ACTUAL_WORKED_HOURS,
	NULL USER_OUTPUT,
	NULL ACTUAL_UOTPUT,
	SUM(ISNULL(IDLE_TIME,0)) AS APPROVED_IDLE--, 
	--NULL SUM_OF_X1,
	--NULL Y
	
FROM tbl_Report_TempidleDetails idle
WHERE WORKDATE BETWEEN '2018-06-01' AND '2018-06-30'  AND IDLE_PIC='LR3' AND IDLE_UID='WJ3'
GROUP BY 
	WORKDATE, 
	IDLE_Project, 
	IDLE_UID, IDLE_PIC,
	IDLE_MID

ORDER BY 
		WORKDATE



