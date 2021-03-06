SELECT
	TR_UID 
	,[PCP_Project] AS [PROJECT]
	--,SUM([USER_OUTPUT]) AS [USER OUTPUT]
    --,SUM([ACTUAL_OUTPUT]) AS [OUTPUT]
	--,ROUND(SUM([WORKED_HOURS]),2) AS [WORKED HOURS]
      ,ROUND(SUM([ACTUAL_WORKED_HOURS]),2) AS [WORKED HOURS]
      ,ROUND(SUM([APPROVED_IDLE]),2) AS [APPROVED IDLE]
      ,ROUND(SUM([SUM_OF_X1]),2) AS [X1]
      ,ROUND(SUM([Y]),2) AS [Y]
      ,ROUND((SUM([SUM_OF_X1])/SUM([Y])) * 100,2) AS [X3]
	  --,RANK() OVER (ORDER BY ((SUM([SUM_OF_X1])/SUM([Y])) * 100) DESC) AS [RANK]
FROM tbl_Report_TempDailyX3Project
WHERE WORKDATE BETWEEN '2018-05-01' AND '2018-05-31' AND TR_PIC='ZDQ'
GROUP BY TR_UID,[PCP_Project]
ORDER BY TR_UID,(SUM([SUM_OF_X1])/SUM([Y])) * 100 DESC