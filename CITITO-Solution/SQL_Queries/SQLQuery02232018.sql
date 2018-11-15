--CREATE PROC Dboard_ExceedProductivity150ByProject @mPIC nvarchar(30), @mFrom DateTime, @mTo DateTime, @mProject nvarchar(30)

--AS

--SELECT T.TR_UID AS [UID], T.TR_InDate [TASKED-IN],ROUND(T.TR_Productivity,3) AS [PRODUCTIVITY] 
--FROM tbl_TaskRecordDetail T
--INNER JOIN tbl_PCPDetail P ON T.PCP_ID=P.PCP_ID AND P.Task_ID=T.Task_ID
--WHERE T.TR_Apporval = 2  AND T.TR_PIC = @mPIC AND T.TR_InDate BETWEEN @mFrom AND @mTo AND P.PCP_Project=@mProject
--GROUP BY T.TR_UID, T.TR_InDate, T.TR_Productivity
--HAVING T.TR_Productivity > 150
--ORDER BY T.TR_InDate DESC

--GO

--EXEC Dboard_ExceedProductivity150ByProject 'ZDQ','','',''


--CREATE PROC Dboard_Exceed5MinsByProject @mPIC nvarchar(30), @mFrom DateTime, @mTo DateTime, @mProject nvarchar(30)

--AS

--SELECT T.TR_UID AS [UID], L.[DATE] AS [DATE], L.FIRSTLOGIN AS [FIRST-IN], MIN(T.TR_InDate) AS [TASKED-IN], CAST(ROUND(DATEDIFF(MINUTE,L.FIRSTLOGIN, MIN(T.TR_InDate))/60.0, 3)AS decimal (6,3)) AS [HOURS]
--	FROM tbl_TaskRecordDetail T
--	INNER JOIN tbl_UserLILO L ON T.TR_UID=L.[UID] AND L.[DATE]=convert(date, T.TR_InDate)
--	INNER JOIN tbl_PCPDetail P ON T.PCP_ID=P.PCP_ID AND P.Task_ID=T.Task_ID
--	WHERE T.TR_PIC=@mPIC AND T.TR_InDate BETWEEN @mFrom AND @mTo AND P.PCP_Project=@mProject
--	GROUP BY  T.TR_UID, L.[DATE], L.FIRSTLOGIN
--	HAVING DATEDIFF(MINUTE,L.FIRSTLOGIN, MIN(T.TR_InDate)) > 5
--	ORDER BY L.[DATE] DESC

--GO

--EXEC Dboard_Exceed5MinsByProject 'ZDQ','','',''


--CREATE PROC Dboard_ExceedProductivity150PICAndManager @mPIC nvarchar(30), @mFrom DateTime, @mTo DateTime, @mMID nvarchar(30)

--AS

--	SELECT TR_UID AS [UID], TR_InDate [TASKED-IN],ROUND(TR_Productivity,3) AS [PRODUCTIVITY] 
--	FROM tbl_TaskRecordDetail 
--	WHERE TR_Apporval = 2  AND TR_PIC = @mPIC AND TR_InDate BETWEEN @mFrom AND @mTo AND TR_MID=@mMID
--	GROUP BY TR_UID, TR_InDate, TR_Productivity
--	HAVING TR_Productivity > 150
--	ORDER BY TR_InDate DESC

--GO

--EXEC Dboard_ExceedProductivity150PICAndManager 'ZDQ','','',''

CREATE PROC Dboard_Exceed5MinsByPICAndManager @mPIC nvarchar(30), @mFrom DateTime, @mTo DateTime, @mMID nvarchar(30)

AS

	SELECT T.TR_UID AS [UID], L.[DATE] AS [DATE], L.FIRSTLOGIN AS [FIRST-IN], MIN(T.TR_InDate) AS [TASKED-IN], CAST(ROUND(DATEDIFF(MINUTE,L.FIRSTLOGIN, MIN(T.TR_InDate))/60.0, 3)AS decimal (6,3)) AS [HOURS]
	FROM tbl_TaskRecordDetail T
	INNER JOIN tbl_UserLILO L ON T.TR_UID=L.[UID] AND L.[DATE]=convert(date, T.TR_InDate)
	WHERE T.TR_PIC=@mPIC AND T.TR_InDate BETWEEN @mFrom AND @mTo AND T.TR_MID=@mMID
	GROUP BY  T.TR_UID, L.[DATE], L.FIRSTLOGIN
	HAVING DATEDIFF(MINUTE,L.FIRSTLOGIN, MIN(T.TR_InDate)) > 5
	ORDER BY L.[DATE] DESC

GO

EXEC Dboard_Exceed5MinsByPICAndManager 'ZDQ','','',''