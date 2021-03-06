/*Get Counts for Dashboard*/
--SELECT COUNT(*) FROM ( SELECT mh.M_UID
--	  FROM tbl_ManagerHeader mh
--	  INNER JOIN tbl_ManagerDetail md ON md.M_UID=mh.M_UID
--	  WHERE md.PIC_UID='" + mPIC + "' AND mh.M_Availability=1 AND M_AccessLevel='Immediate Manager'
--	  GROUP BY mh.M_UID
--) TeamCount

--SELECT COUNT(*) FROM ( SELECT uh.P_UID
--	  FROM tbl_UserManagementHeader uh
--	  INNER JOIN tbl_UserManagementDetail ud ON ud.P_UID=uh.P_UID
--	  WHERE ud.PIC_UID='" + mPIC + "' AND uh.P_Availability=1 AND P_AccessLevel='Common User'
--	  GROUP BY uh.P_UID
--) OperatorCount

--SELECT COUNT(*) FROM ( SELECT mh.M_UID
--	  FROM tbl_ManagerHeader mh
--	  INNER JOIN tbl_ManagerDetail md ON md.M_UID=mh.M_UID
--	  WHERE md.PIC_UID='" + mPIC + "' AND mh.M_Availability=1 AND M_AccessLevel='DCD'
--	  GROUP BY mh.M_UID
--) DCDCount

--SELECT COUNT(ProjectName)
--FROM tbl_ProjectDetail
--WHERE PIC_UID='ZDQ'


CREATE Procedure Dboard_CurrentCapacity @mPIC nvarchar(30) 

AS

DECLARE @CurrentProductivity TABLE(
    TaskedIn varchar(50),
    IDLE varchar(50),
	[Absent] varchar(50)
);
DECLARE @CurrentProductivityFinal TABLE(
    TDetail varchar(50),
    Tcount varchar(50)
);


/*IDELE*/

INSERT INTO @CurrentProductivity (IDLE)
SELECT [UID] AS [IDLE]
FROM (
SELECT [UID]
FROM tbl_UserLILO ams
INNER JOIN tbl_UserManagementDetail ud ON ud.P_UID=ams.[UID]
WHERE ud.[PIC_UID]=@mPIC AND [DATE]=CONVERT (date, SYSDATETIME()) 
GROUP BY [UID]
) AMSTodayUID

WHERE [UID] NOT IN (
SELECT *
FROM(
SELECT TR_UID
FROM tbl_TaskRecordDetail 
WHERE TR_PIC=@mPIC AND TR_InDate BETWEEN CAST(CONVERT(VARCHAR(10), GETDATE(), 110) + ' 00:00:00' AS DATETIME) AND CAST(CONVERT(VARCHAR(10), GETDATE(), 110) + ' 23:59:59' AS DATETIME)
GROUP BY TR_UID

UNION ALL 

SELECT IDLE_UID
FROM tbl_IDLEDetail 
WHERE IDLE_PIC=@mPIC AND IDLE_InDate BETWEEN CAST(CONVERT(VARCHAR(10), GETDATE(), 110) + ' 00:00:00' AS DATETIME) AND CAST(CONVERT(VARCHAR(10), GETDATE(), 110) + ' 23:59:59' AS DATETIME)
GROUP BY IDLE_UID
) AllTasksToday)

/*Tasked In*/
INSERT INTO @CurrentProductivity (TaskedIn)
SELECT [UID] AS [Tasked-In]
FROM (
SELECT [UID]
FROM tbl_UserLILO ams
INNER JOIN tbl_UserManagementDetail ud ON ud.P_UID=ams.[UID]
WHERE ud.[PIC_UID]=@mPIC AND [DATE]=CONVERT (date, SYSDATETIME()) 
GROUP BY [UID]
) AMSTodayUID

WHERE [UID] IN (
SELECT *
FROM(
SELECT TR_UID
FROM tbl_TaskRecordDetail 
WHERE TR_PIC=@mPIC AND TR_InDate BETWEEN CAST(CONVERT(VARCHAR(10), GETDATE(), 110) + ' 00:00:00' AS DATETIME) AND CAST(CONVERT(VARCHAR(10), GETDATE(), 110) + ' 23:59:59' AS DATETIME)
GROUP BY TR_UID

UNION ALL 

SELECT IDLE_UID
FROM tbl_IDLEDetail 
WHERE IDLE_PIC=@mPIC AND IDLE_InDate BETWEEN CAST(CONVERT(VARCHAR(10), GETDATE(), 110) + ' 00:00:00' AS DATETIME) AND CAST(CONVERT(VARCHAR(10), GETDATE(), 110) + ' 23:59:59' AS DATETIME)
GROUP BY IDLE_UID
) AllTasksToday)


/**Absent*/

INSERT INTO @CurrentProductivity ([Absent])
SELECT P_UID AS [Absent] 
FROM ( SELECT uh.P_UID
	  FROM tbl_UserManagementHeader uh
	  INNER JOIN tbl_UserManagementDetail ud ON ud.P_UID=uh.P_UID
	  WHERE ud.PIC_UID=@mPIC AND uh.P_Availability=1 AND P_AccessLevel='Common User'
	  GROUP BY uh.P_UID
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


INSERT INTO @CurrentProductivityFinal (TDetail, Tcount)
SELECT 'TASKED-IN', COUNT(TaskedIn)
FROM @CurrentProductivity

INSERT INTO @CurrentProductivityFinal (TDetail, Tcount)
SELECT 'IDLE', COUNT(IDLE)
FROM @CurrentProductivity

INSERT INTO @CurrentProductivityFinal (TDetail, Tcount)
SELECT 'ABSENT', COUNT([Absent])
FROM @CurrentProductivity


SELECT *
FROM @CurrentProductivityFinal

GO

EXEC Dboard_CurrentCapacity '16V'





