/* MONTHLY X3 USER */
SELECT [TR_MID] AS [TEAM]
      ,ROUND((SUM([SUM_OF_X1])/SUM([Y])) * 100,2) AS [X3]
FROM tbl_Report_TempDailyX3Project
WHERE WORKDATE BETWEEN '2018-03-01' AND '2018-03-31' AND TR_PIC='ZDQ' AND PCP_Project='APPEB'
GROUP BY [TR_MID]
ORDER BY (SUM([SUM_OF_X1])/SUM([Y])) * 100 DESC

SELECT [TR_UID] AS [UID]
      ,ROUND((SUM([SUM_OF_X1])/SUM([Y])) * 100,2) AS [X3]
FROM tbl_Report_TempDailyX3Project
WHERE WORKDATE BETWEEN '2018-03-01' AND '2018-03-31' AND TR_PIC='EC4' AND PCP_Project='00LEB'
GROUP BY TR_UID
ORDER BY (SUM([SUM_OF_X1])/SUM([Y])) * 100 DESC

SELECT PCP_Project AS [PROJECT]
      ,ROUND((SUM([SUM_OF_X1])/SUM([Y])) * 100,2) AS [X3]
FROM tbl_Report_TempDailyX3Project
WHERE WORKDATE BETWEEN '2018-03-01' AND '2018-03-31' AND TR_PIC='16v'
GROUP BY PCP_Project
ORDER BY (SUM([SUM_OF_X1])/SUM([Y])) * 100 DESC

/* MONTHLY X3 PROJECT */
SELECT [PCP_Project] AS [PROJECT]
	--,SUM([USER_OUTPUT]) AS [USER OUTPUT]
      ,SUM([ACTUAL_OUTPUT]) AS [OUTPUT]
	--,ROUND(SUM([WORKED_HOURS]),2) AS [WORKED HOURS]
      ,ROUND(SUM([ACTUAL_WORKED_HOURS]),2) AS [WORKED HOURS]
      ,ROUND(SUM([APPROVED_IDLE]),2) AS [APPROVED IDLE]
      ,ROUND(SUM([SUM_OF_X1]),2) AS [X1]
      ,ROUND(SUM([Y]),2) AS [Y]
      ,ROUND((SUM([SUM_OF_X1])/SUM([Y])) * 100,2) AS [X3]
	  ,RANK() OVER (ORDER BY ((SUM([SUM_OF_X1])/SUM([Y])) * 100) DESC) AS [RANK]
FROM tbl_Report_TempDailyX3Project
WHERE WORKDATE BETWEEN '2018-03-01' AND '2018-03-31' AND TR_PIC='16v'
GROUP BY [PCP_Project]
ORDER BY (SUM([SUM_OF_X1])/SUM([Y])) * 100 DESC