CREATE PROC Dboard_CurrentTeamCapacity_DetailedByPIC @mPIC nvarchar(30) 

AS

DECLARE @CurrentProductivity TABLE(
	Team varchar(50),
    TaskedIn varchar(50),
    IDLE varchar(50),
	[Absent] varchar(50)
);
DECLARE @CurrentProductivityFinal TABLE(
	TTeam varchar(50),
    TTaskedIn varchar(50),
    TIDLE varchar(50),
	TAbsent varchar(50)
);
DECLARE @CurrentProductivityFinal1 TABLE(
    ATaskedIn varchar(50),
    AIDLE varchar(50),
	AAbsent varchar(50)
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
SELECT Team, TaskedIn
FROM @CurrentProductivity
GROUP BY Team, TaskedIn

INSERT INTO @CurrentProductivityFinal (TTeam, TIDLE)
SELECT Team, IDLE
FROM @CurrentProductivity
GROUP BY Team, IDLE


INSERT INTO @CurrentProductivityFinal (TTeam, TAbsent)
SELECT Team, [Absent]
FROM @CurrentProductivity
GROUP BY Team, [Absent];


WITH CTE AS (

SELECT
        TTeam,
        MAX(TTaskedIn) AS [TASKED-IN],
        MAX(TIDLE) AS [DILE],
        MAX(TAbsent) AS [ABSENT]
    FROM @CurrentProductivityFinal
    GROUP BY TTeam
    HAVING MAX(TTaskedIn) = MIN(TTaskedIn)
        AND MAX(TIDLE) = MIN(TIDLE)
        AND MAX(TAbsent) = MIN(TAbsent)
),
FINAL AS(
    SELECT [TASKED-IN],[DILE],[ABSENT]
    FROM CTE
    UNION ALL
    SELECT TTaskedIn,TIDLE,TAbsent
    FROM @CurrentProductivityFinal
    WHERE TTeam NOT IN (SELECT TTeam FROM CTE) 
	GROUP BY TTaskedIn,TIDLE,TAbsent
	HAVING TTaskedIn!='NULL' OR TIDLE!='NULL' OR TAbsent!='NULL'
	),
TASKEDIN AS(

	SELECT [TASKED-IN]
	FROM FINAL
	WHERE [TASKED-IN] IS NOT NULL),

DILES AS(
	SELECT [DILE]
	FROM FINAL
	WHERE [DILE] IS NOT NULL),

ABSENTS AS(
	SELECT [ABSENT]
	FROM FINAL
	WHERE [ABSENT] IS NOT NULL)

SELECT [TASKED-IN],[DILE],[ABSENT] FROM 
    (SELECT [TASKED-IN], row_number() OVER ( ORDER BY [TASKED-IN] ) as num FROM TASKEDIN) AS X
FULL OUTER JOIN 
    (SELECT [DILE], row_number() OVER ( ORDER BY [DILE] )as num FROM DILES) AS Y
		ON x.num = y.num
FULL OUTER JOIN 
    (SELECT [ABSENT], row_number() OVER ( ORDER BY [ABSENT] ) as num FROM ABSENTS) AS Z
		ON z.num=x.num

GO