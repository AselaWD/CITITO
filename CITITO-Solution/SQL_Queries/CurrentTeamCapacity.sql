CREATE PROC Dboard_CurrentTeamCapacityByPIC @mPIC nvarchar(30) 

AS

DECLARE @CurrentProductivity TABLE(
	Team varchar(50),
    TaskedIn varchar(50),
    IDLE varchar(50),
	[Absent] varchar(50)
);
DECLARE @CurrentProductivityFinal TABLE(
	TTeam varchar(50),
    TTaskedIn int,
    TIDLE int,
	TAbsent int
);


/*IDELE*/

INSERT INTO @CurrentProductivity (Team, IDLE)
SELECT [MUID] AS [Team],[UID] AS [IDLE]
FROM (
SELECT ud.M_UID AS [MUID], [UID]
FROM tbl_UserLILO ams
INNER JOIN tbl_UserManagementDetail ud ON ud.P_UID=ams.[UID]
WHERE ud.[PIC_UID]=@mPIC AND [DATE]=CONVERT (date, SYSDATETIME()) 
GROUP BY ud.M_UID, [UID]
) AMSTodayUID

WHERE [UID] NOT IN (
SELECT *
FROM(
SELECT TR_UID
FROM tbl_TaskRecordDetail 
WHERE TR_PIC=@mPIC AND TR_InDate BETWEEN CAST(CONVERT(VARCHAR(10), GETDATE(), 110) + ' 00:00:00' AS DATETIME) AND CAST(CONVERT(VARCHAR(10), GETDATE(), 110) + ' 23:59:59' AS DATETIME)
GROUP BY TR_UID

--UNION ALL 

--SELECT IDLE_UID
--FROM tbl_IDLEDetail 
--WHERE IDLE_PIC=@mPIC AND IDLE_InDate BETWEEN CAST(CONVERT(VARCHAR(10), GETDATE(), 110) + ' 00:00:00' AS DATETIME) AND CAST(CONVERT(VARCHAR(10), GETDATE(), 110) + ' 23:59:59' AS DATETIME)
--GROUP BY IDLE_UID
) AllTasksToday)

/*Tasked In*/
INSERT INTO @CurrentProductivity (Team, TaskedIn)
SELECT [MUID] AS [Team], [UID] AS [Tasked-In]
FROM (
SELECT ud.M_UID AS [MUID], [UID]
FROM tbl_UserLILO ams
INNER JOIN tbl_UserManagementDetail ud ON ud.P_UID=ams.[UID]
WHERE ud.[PIC_UID]=@mPIC AND [DATE]=CONVERT (date, SYSDATETIME()) 
GROUP BY ud.M_UID, [UID]
) AMSTodayUID

WHERE [UID] IN (
SELECT *
FROM(
SELECT TR_UID
FROM tbl_TaskRecordDetail 
WHERE TR_PIC=@mPIC AND TR_InDate BETWEEN CAST(CONVERT(VARCHAR(10), GETDATE(), 110) + ' 00:00:00' AS DATETIME) AND CAST(CONVERT(VARCHAR(10), GETDATE(), 110) + ' 23:59:59' AS DATETIME)
GROUP BY TR_UID

--UNION ALL 

--SELECT IDLE_UID
--FROM tbl_IDLEDetail 
--WHERE IDLE_PIC=@mPIC AND IDLE_InDate BETWEEN CAST(CONVERT(VARCHAR(10), GETDATE(), 110) + ' 00:00:00' AS DATETIME) AND CAST(CONVERT(VARCHAR(10), GETDATE(), 110) + ' 23:59:59' AS DATETIME)
--GROUP BY IDLE_UID
) AllTasksToday)


/**Absent*/

INSERT INTO @CurrentProductivity (Team, [Absent])
SELECT M_UID AS [Team], P_UID AS [Absent] 
FROM ( SELECT ud.M_UID, uh.P_UID
	  FROM tbl_UserManagementHeader uh
	  INNER JOIN tbl_UserManagementDetail ud ON ud.P_UID=uh.P_UID
	  WHERE ud.PIC_UID=@mPIC AND uh.P_Availability=1 AND P_AccessLevel='Common User'
	  GROUP BY ud.M_UID, uh.P_UID
) OperatorCount

WHERE P_UID NOT IN (
SELECT [UID] AS [IDLE]
FROM (
SELECT [UID]
FROM tbl_UserLILO ams
INNER JOIN tbl_UserManagementDetail ud ON ud.P_UID=ams.[UID]
WHERE ud.[PIC_UID]=@mPIC AND [DATE]=CONVERT (date, SYSDATETIME()) 
GROUP BY [UID]
) AMSTodayUID
)


INSERT INTO @CurrentProductivityFinal (TTeam, TTaskedIn)
SELECT Team, COUNT(TaskedIn)
FROM @CurrentProductivity
GROUP BY Team

INSERT INTO @CurrentProductivityFinal (TTeam, TIDLE)
SELECT Team, COUNT(IDLE)
FROM @CurrentProductivity
GROUP BY Team


INSERT INTO @CurrentProductivityFinal (TTeam, TAbsent)
SELECT Team, COUNT([Absent])
FROM @CurrentProductivity
GROUP BY Team


SELECT TTeam AS [TEAM], SUM(TTaskedIn) AS [TASKED-IN],SUM(TIDLE) AS [DILE] ,SUM(TAbsent) AS [ABSENT]
FROM @CurrentProductivityFinal
GROUP BY TTeam

