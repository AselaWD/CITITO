--SELECT
--		tsk.WORKDATE,
--		--NULL AS PCP_Project,
--		tsk.PCP_Project AS IDLE_Project,
--		tsk.TR_UID,
--		tsk.TR_MID,
--		tsk.TR_PIC, 
--		SUM(tsk.WORKED_HOURS) AS ACTUAL_WORKED_HOURS, 		
--		NULL AS USER_OUTPUT, 
--		NULL AS ACTUAL_OUTPUT, 
--		NULL AS APPROVED_IDLE,
--		NULL SUM_OF_X1,
--		NULL Y
--	FROM 
--		tbl_Report_TemptaskDetailsQUOTA_Updated tsk
--		--LEFT JOIN tbl_Report_TempsumofidleDetails idle ON tsk.WORKDATE=idle.WORKDATE AND tsk.TR_UID=idle.IDLE_UID
--	WHERE 
--		tsk.[LOGIN] IS NOT NULL AND tsk.[LOGOUT] IS NOT NULL AND tsk.WORKDATE BETWEEN '2018-06-01' AND '2018-06-30'  AND tsk.TR_PIC='LR3' AND tsk.TR_UID='WJ3'
	
--	GROUP BY 
--		tsk.WORKDATE,
--		tsk.PCP_Project,
--		tsk.TR_UID,
--		tsk.TR_MID,
--		tsk.TR_PIC


----/*****************************************


--SELECT 
--		tsk.WORKDATE,
--		tsk.TR_UID,
--		tsk.TR_MID,
--		tsk.TR_PIC, 
--		MAX(tsk.ACTUAL_WORKED_HOURS) AS ACTUAL_WORKED_HOURS, 
--		SUM(tsk.WORKED_HOURS) AS ACTUAL_WORKED_HOURS,
--		MAX(tsk.ACTUAL_WORKED_HOURS)-SUM(tsk.WORKED_HOURS) AS WASTAGE
--	FROM 
--		tbl_Report_TemptaskDetailsQUOTA_Updated tsk
--		--LEFT JOIN tbl_Report_TempsumofidleDetails idle ON tsk.WORKDATE=idle.WORKDATE AND tsk.TR_UID=idle.IDLE_UID
--	WHERE 
--		tsk.[LOGIN] IS NOT NULL AND tsk.[LOGOUT] IS NOT NULL AND tsk.WORKDATE BETWEEN '2018-06-01' AND '2018-06-30'  AND tsk.TR_PIC='LR3' AND tsk.TR_UID='WJ3'
	
--	GROUP BY 
--		tsk.WORKDATE,
--		tsk.TR_UID,
--		tsk.TR_MID,
--		tsk.TR_PIC


----/*****************************************

SELECT
		tsk.WORKDATE,
		--NULL AS PCP_Project,
		tsk.PCP_Project AS IDLE_Project,
		tsk.TR_UID,
		tsk.TR_MID,
		tsk.TR_PIC, 
		SUM(tsk.WORKED_HOURS)+((SUM(tsk.WORKED_HOURS)/Wastage.SUM_WORKED_HOURS) * Wastage.WASTAGE) AS ACTUAL_WORKED_HOURS, 		
		NULL AS USER_OUTPUT, 
		NULL AS ACTUAL_OUTPUT, 
		NULL AS APPROVED_IDLE,
		NULL SUM_OF_X1,
		NULL Y
	FROM 
		tbl_Report_TemptaskDetailsQUOTA_Updated tsk
		INNER JOIN (
			SELECT 
				tsk.WORKDATE,
				tsk.TR_UID,
				tsk.TR_MID,
				tsk.TR_PIC, 
				MAX(tsk.ACTUAL_WORKED_HOURS) AS ACTUAL_WORKED_HOURS, 
				SUM(tsk.WORKED_HOURS) AS SUM_WORKED_HOURS,
				MAX(tsk.ACTUAL_WORKED_HOURS)-SUM(tsk.WORKED_HOURS) AS WASTAGE
			FROM 
				tbl_Report_TemptaskDetailsQUOTA_Updated tsk
				--LEFT JOIN tbl_Report_TempsumofidleDetails idle ON tsk.WORKDATE=idle.WORKDATE AND tsk.TR_UID=idle.IDLE_UID
			WHERE 
				tsk.[LOGIN] IS NOT NULL AND tsk.[LOGOUT] IS NOT NULL AND tsk.WORKDATE BETWEEN '2018-06-01' AND '2018-06-30'  AND tsk.TR_PIC='LR3' AND tsk.TR_UID='WJ3'
	
			GROUP BY 
				tsk.WORKDATE,
				tsk.TR_UID,
				tsk.TR_MID,
				tsk.TR_PIC
		) Wastage ON Wastage.WORKDATE=tsk.WORKDATE AND Wastage.TR_UID=tsk.TR_UID
	WHERE 
		tsk.[LOGIN] IS NOT NULL AND tsk.[LOGOUT] IS NOT NULL AND tsk.WORKDATE BETWEEN '2018-06-01' AND '2018-06-30'  AND tsk.TR_PIC='LR3' AND tsk.TR_UID='WJ3'
	
	GROUP BY 
		tsk.WORKDATE,
		tsk.PCP_Project,
		tsk.TR_UID,
		tsk.TR_MID,
		tsk.TR_PIC,
		Wastage.SUM_WORKED_HOURS,
		Wastage.WASTAGE
