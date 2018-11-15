--CREATE Procedure Dboard_WorkLoad @mPIC nvarchar(30) 

--AS

--DECLARE @WorkLoad TABLE(
--    InProcess varchar(50),
--    IDLE varchar(50),
--	Hold varchar(50)
--);
--DECLARE @WorkLoadFinal TABLE(
--    TDetail varchar(50),
--    Tcount varchar(50)
--);



----//PCP_Status        int             Unchecked /* 0-Fresh, 1-Hold, 2-Pending, 3-Done */

--/*Fresh Titles*/
--INSERT INTO @WorkLoad (InProcess)

--SELECT PCP_ID AS [In-Process]
--FROM
--	(
--	SELECT PCP_ID
--	FROM tbl_PCPDetail pd
--	INNER JOIN tbl_ProcessCodeHeader pch ON pd.PC_ProcessCode=pch.PC_ProcessCode AND pd.PCP_Project=pch.PIC_Project
--	WHERE PCP_Status=0 AND pch.PIC_UID=@mPIC
--	GROUP BY PCP_ID
--	) FreshTitles

--/*Pending Titles*/
--INSERT INTO @WorkLoad (IDLE)
--SELECT PCP_ID AS [IDLE]
--FROM
--	(
--	SELECT PCP_ID
--	FROM tbl_PCPDetail pd
--	INNER JOIN tbl_ProcessCodeHeader pch ON pd.PC_ProcessCode=pch.PC_ProcessCode AND pd.PCP_Project=pch.PIC_Project
--	WHERE PCP_Status=2 AND pch.PIC_UID=@mPIC
--	GROUP BY PCP_ID
--	) PendingTitles


--/*On Hold Titles*/
--INSERT INTO @WorkLoad (Hold)
--SELECT PCP_ID AS [Hold]
--FROM
--	(
--	SELECT PCP_ID
--	FROM tbl_PCPDetail pd
--	INNER JOIN tbl_ProcessCodeHeader pch ON pd.PC_ProcessCode=pch.PC_ProcessCode AND pd.PCP_Project=pch.PIC_Project
--	WHERE PCP_Status=1 AND pch.PIC_UID=@mPIC
--	GROUP BY PCP_ID
--	) HoldTitles

--INSERT INTO @WorkLoadFinal (TDetail, Tcount)
--SELECT 'IN-PROCESS', COUNT(InProcess)
--FROM @WorkLoad
--WHERE InProcess!='NULL'

--INSERT INTO @WorkLoadFinal (TDetail, Tcount)
--SELECT 'FRESH', COUNT(IDLE)
--FROM @WorkLoad
--WHERE IDLE!='NULL'

--INSERT INTO @WorkLoadFinal (TDetail, Tcount)
--SELECT 'HOLD', COUNT(Hold)
--FROM @WorkLoad
--WHERE Hold!='NULL'

--SELECT *
--FROM @WorkLoadFinal

--GO

--EXEC Dboard_WorkLoad 'ZDQ'

--CREATE Procedure Dboard_Exceed5Mins @mPIC nvarchar(30), @mFrom DateTime, @mTo DateTime

--AS

--	SELECT T.TR_UID AS [UID], L.[DATE] AS [DATE], L.FIRSTLOGIN AS [FIRST-IN], MIN(T.TR_InDate) AS [TASKED-IN], CAST(ROUND(DATEDIFF(MINUTE,L.FIRSTLOGIN, MIN(T.TR_InDate))/60.0, 3)AS decimal (6,3)) AS [HOURS]
--	FROM tbl_TaskRecordDetail T
--	INNER JOIN tbl_UserLILO L ON T.TR_UID=L.[UID] AND L.[DATE]=convert(date, T.TR_InDate)
--	WHERE T.TR_PIC=@mPIC AND T.TR_InDate BETWEEN @mFrom AND @mTo
--	GROUP BY  T.TR_UID, L.[DATE], L.FIRSTLOGIN
--	HAVING DATEDIFF(MINUTE,L.FIRSTLOGIN, MIN(T.TR_InDate)) > 5
--	ORDER BY L.[DATE] DESC

--GO

--EXEC Dboard_Exceed5Mins 'ZDQ', '',''


--SELECT TR_UID AS [UID], TR_InDate [Task In],TR_Productivity AS [Productivity] 
--FROM tbl_TaskRecordDetail 
--WHERE TR_Apporval = 2  AND TR_PIC = '"+ mPIC + "' AND TR_InDate BETWEEN '"+ mFrom +"' AND '"+ mTo +"' 
--HAVING TR_Productivity > 150
--ORDER BY TR_UID DESC

CREATE Procedure Dboard_ExceedProductivity150 @mPIC nvarchar(30), @mFrom DateTime, @mTo DateTime

AS

SELECT TR_UID AS [UID], TR_InDate [TASKED-IN],ROUND(TR_Productivity,3) AS [PRODUCTIVITY] 
FROM tbl_TaskRecordDetail 
WHERE TR_Apporval = 2  AND TR_PIC = @mPIC AND TR_InDate BETWEEN @mFrom AND @mTo 
GROUP BY TR_UID, TR_InDate, TR_Productivity
HAVING TR_Productivity > 150
ORDER BY TR_InDate DESC

GO

EXEC Dboard_ExceedProductivity150 'ZDQ', '',''









