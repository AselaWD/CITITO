--CREATE PROC Dboard_Exceed5MinsByPICAndUID @mPIC nvarchar(30), @mFrom DateTime, @mTo DateTime, @mUID nvarchar(30)

--AS
--	SELECT T.TR_UID AS [UID], L.[DATE] AS [DATE], L.FIRSTLOGIN AS [FIRST-IN], MIN(T.TR_InDate) AS [TASKED-IN], CAST(ROUND(DATEDIFF(MINUTE,L.FIRSTLOGIN, MIN(T.TR_InDate))/60.0, 3)AS decimal (6,3)) AS [HOURS]
--	FROM tbl_TaskRecordDetail T
--	INNER JOIN tbl_UserLILO L ON T.TR_UID=L.[UID] AND L.[DATE]=convert(date, T.TR_InDate)
--	WHERE T.TR_PIC=@mPIC AND T.TR_InDate BETWEEN @mFrom AND @mTo AND T.TR_UID=@mUID
--	GROUP BY  T.TR_UID, L.[DATE], L.FIRSTLOGIN
--	HAVING DATEDIFF(MINUTE,L.FIRSTLOGIN, MIN(T.TR_InDate)) > 5
--	ORDER BY L.[DATE] DESC
--GO

CREATE PROC DBoard_TasksAndQuotaByViewRecords @mPIC nvarchar(30), @mFrom DateTime, @mTo DateTime, @mProject nvarchar(30), @mProcessCode nvarchar(30), @mTaskCode nvarchar(30), @mTaskDesc nvarchar(30)

AS

	SELECT tsrd.TR_UID AS [UID], tskd.PC_ProcessCode AS [PROCESS CODE], prjd.ProjectName [PROJECT], tskd.Task_ID AS [TASK], tskd.Task_Description AS [DESCRIPTION], tskd.Task_UOM AS [UOM], tskd.Task_Quota AS [QUOTA], ROUND(tsrd.TR_Productivity,2) AS [PRODUCTIVITY]
	FROM tbl_TaskDetail tskd
	INNER JOIN tbl_ProjectDetail prjd ON tskd.PIC_Project=prjd.ProjectName
	INNER JOIN tbl_PCPDetail pcpd ON pcpd.PC_ProcessCode=tskd.PC_ProcessCode AND tskd.Task_ID=pcpd.Task_ID
	INNER JOIN tbl_TaskRecordDetail tsrd ON pcpd.Task_ID=tsrd.Task_ID AND pcpd.PCP_ID=tsrd.PCP_ID
	WHERE prjd.PIC_UID=@mPIC AND tsrd.TR_InDate BETWEEN @mFrom AND @mTo AND tsrd.TR_Apporval=2 AND prjd.ProjectName=@mProject AND tskd.PC_ProcessCode=@mProcessCode AND tskd.Task_ID=@mTaskCode AND tskd.Task_Description=@mTaskDesc
	ORDER BY tskd.Task_Description

GO


	SELECT tsrd.TR_UID AS [UID], tskd.PC_ProcessCode AS [PROCESS CODE], prjd.ProjectName [PROJECT], tskd.Task_ID AS [TASK], tskd.Task_Description AS [DESCRIPTION], tskd.Task_UOM AS [UOM], tskd.Task_Quota AS [QUOTA], ROUND(tsrd.TR_Productivity,2) AS [PRODUCTIVITY]
	FROM tbl_TaskDetail tskd
	INNER JOIN tbl_ProjectDetail prjd ON tskd.PIC_Project=prjd.ProjectName
	INNER JOIN tbl_PCPDetail pcpd ON pcpd.PC_ProcessCode=tskd.PC_ProcessCode AND tskd.Task_ID=pcpd.Task_ID
	INNER JOIN tbl_TaskRecordDetail tsrd ON pcpd.Task_ID=tsrd.Task_ID AND pcpd.PCP_ID=tsrd.PCP_ID
	WHERE prjd.PIC_UID='EC4' AND tsrd.TR_InDate BETWEEN '2018-02-01' AND '2018-02-28' AND tsrd.TR_Apporval=2 AND prjd.ProjectName='00LEB' AND tskd.PC_ProcessCode='00LEBCAK' AND tskd.Task_ID='00L_EB1' AND tskd.Task_Description='TEXT EXTRACTION'
	ORDER BY tskd.Task_Description


			