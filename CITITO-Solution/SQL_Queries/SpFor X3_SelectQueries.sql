--######################################## QUERIES START ##################################
--SELECT *
--FROM tbl_Report_TempidleDetails

--SELECT *
--FROM tbl_Report_TempsumofidleDetails

--SELECT *
--FROM tbl_Report_TempModifiedTaskDetails

--SELECT *
--FROM tbl_Report_TemptblDifference
--WHERE TR_ActualTaskIn BETWEEN '2018-02-01' AND '2018-02-28'

--SELECT *
--FROM tbl_Report_TemptaskDetails

--SELECT *
--FROM tbl_Report_TemptaskDetailsQUOTA_Updated
--WHERE TR_PIC='ZDQ' AND WORKDATE BETWEEN '2018-02-01' AND '2018-02-28'
--ORDER BY TR_UID

/* DAILY X3 */
--SELECT tsk.WORKDATE,tsk.TR_UID,userd.PIC_UID,userd.M_UID, SUM(tsk.WORKED_HOURS) AS WORKED_HOURS, MAX(tsk.ACTUAL_WORKED_HOURS) AS ACTUAL_WORKED_HOURS, SUM(tsk.USER_OUTPUT) AS USER_OUTPUT, SUM(tsk.ACTUAL_OUTPUT) AS ACTUAL_OUTPUT, MAX(ISNULL(idle.APPROVED_IDLE,0)) AS APPROVED_IDLE, SUM(tsk.X1) AS SUM_OF_X1, (MAX(tsk.ACTUAL_WORKED_HOURS) * 3600)  AS Y, (SUM(tsk.X1)/((MAX(tsk.ACTUAL_WORKED_HOURS) * 3600)- ISNULL(idle.APPROVED_IDLE,0))) * 100 AS X3/**/
--FROM tbl_Report_TemptaskDetailsQUOTA_Updated tsk
--LEFT OUTER JOIN tbl_Report_TempsumofidleDetails idle ON tsk.WORKDATE=idle.WORKDATE AND tsk.TR_UID=idle.IDLE_UID
--LEFT OUTER JOIN [tbl_UserManagementDetail] userd ON userd.P_UID=tsk.TR_UID
--WHERE tsk.[LOGIN] IS NOT NULL AND tsk.[LOGOUT] IS NOT NULL  /*AND tsk.WORKDATE BETWEEN '2018-02-01' AND '2018-02-28'  AND userd.PIC_UID='ZDQ'*/
--GROUP BY tsk.WORKDATE, tsk.TR_UID, idle.APPROVED_IDLE,userd.PIC_UID,userd.M_UID
--ORDER BY WORKDATE

/* DAILY X3 */
--SELECT tsk.TR_UID, SUM(tsk.WORKED_HOURS) AS WORKED_HOURS, MAX(tsk.ACTUAL_WORKED_HOURS) AS ACTUAL_WORKED_HOURS, SUM(tsk.USER_OUTPUT) AS USER_OUTPUT, SUM(tsk.ACTUAL_OUTPUT) AS ACTUAL_OUTPUT, MAX(ISNULL(idle.APPROVED_IDLE,0)) AS APPROVED_IDLE, SUM(tsk.X1) AS SUM_OF_X1, ((MAX(tsk.ACTUAL_WORKED_HOURS) * 3600))  AS Y, (SUM(tsk.X1)/((MAX(tsk.ACTUAL_WORKED_HOURS) * 3600)- ISNULL(idle.APPROVED_IDLE,0))) * 100 AS X3/**/
--FROM tbl_Report_TemptaskDetailsQUOTA_Updated tsk
--LEFT OUTER JOIN tbl_Report_TempsumofidleDetails idle ON tsk.WORKDATE=idle.WORKDATE AND tsk.TR_UID=idle.IDLE_UID
--LEFT OUTER JOIN [tbl_UserManagementDetail] userd ON userd.P_UID=tsk.TR_UID
--WHERE tsk.[LOGIN] IS NOT NULL AND tsk.[LOGOUT] IS NOT NULL AND tsk.WORKDATE BETWEEN '2018-02-01' AND '2018-02-28'  AND userd.PIC_UID='ZDQ'
--GROUP BY tsk.TR_UID, idle.APPROVED_IDLE

--CREATE TABLE tbl_Report_TempDailyX3Users(
--WORKDATE Date,
--TR_UID varchar(50),
--TR_MID varchar(50),
--TR_PIC varchar(50),
--WORKED_HOURS float,
--ACTUAL_WORKED_HOURS float,
--USER_OUTPUT float,
--ACTUAL_OUTPUT float,
--APPROVED_IDLE float, 
--SUM_OF_X1 float, 
--Y float, 
--X3 float 
--); 



/* DAILY X3 USER */
SELECT [WORKDATE]
      ,[TR_UID]
      ,[WORKED_HOURS]
      ,[ACTUAL_WORKED_HOURS]
      ,[USER_OUTPUT]
      ,[ACTUAL_OUTPUT]
      ,[APPROVED_IDLE]
      ,[SUM_OF_X1]
      ,[Y]
      ,[X3]
FROM tbl_Report_TempDailyX3Users
WHERE WORKDATE BETWEEN '2018-02-01' AND '2018-02-28'  AND TR_PIC='ZDQ'
ORDER BY WORKDATE, TR_UID

/* MONTHLY X3 USER */
SELECT [TR_UID]
      ,[WORKED_HOURS]
      ,[ACTUAL_WORKED_HOURS]
      ,[USER_OUTPUT]
      ,[ACTUAL_OUTPUT]
      ,[APPROVED_IDLE]
      ,[SUM_OF_X1]
      ,[Y]
      ,X3
FROM tbl_Report_TempDailyX3Users
WHERE WORKDATE BETWEEN '2018-02-01' AND '2018-02-28'  AND TR_PIC='ZDQ'
GROUP BY TR_UID
