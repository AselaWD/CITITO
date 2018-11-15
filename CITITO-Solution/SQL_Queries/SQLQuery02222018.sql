--CREATE PROC Dboard_TaskAndWastageCount  @mPIC nvarchar(30)

--AS

--SELECT COUNT(tskd.Task_ID)
--FROM tbl_TaskDetail tskd
--INNER JOIN tbl_ProjectDetail prjd ON tskd.PIC_Project=prjd.ProjectName
--WHERE prjd.PIC_UID=@mPIC

--GO

--EXEC Dboard_TaskAndWastageCount 'EC4'

-- //TR_Apporval     int               Unchecked /* 1 - Pending, 2 - Approved, 3 - Disapproved */

--SELECT tsrd.TR_UID AS [UID], pcpd.PCP_ID AS [JOB CODE], prjd.ProjectName [PROJECT], tskd.Task_ID AS [TASK], tskd.Task_Description AS [DESCRIPTION], tskd.Task_UOM AS [UOM], tskd.Task_Quota AS [QUOTA], tskd.PC_ProcessCode AS [PROCESS CODE], tsrd.TR_Productivity AS [PRODUCTIVITY]
--FROM tbl_TaskDetail tskd
--INNER JOIN tbl_ProjectDetail prjd ON tskd.PIC_Project=prjd.ProjectName
--INNER JOIN tbl_PCPDetail pcpd ON pcpd.PC_ProcessCode=tskd.PC_ProcessCode AND tskd.Task_ID=pcpd.Task_ID
--INNER JOIN tbl_TaskRecordDetail tsrd ON pcpd.Task_ID=tsrd.Task_ID AND pcpd.PCP_ID=tsrd.PCP_ID
--WHERE prjd.PIC_UID='ZDQ' AND tsrd.TR_InDate BETWEEN '2018-02-01 00:00:00.000' AND '2018-02-28 23:59:59.000' AND tsrd.TR_Apporval=2
--GROUP BY prjd.ProjectName, tskd.Task_ID,  tskd.Task_UOM, tskd.Task_Quota, tskd.PC_ProcessCode

--CREATE PROC DBoard_TasksAndQuota @mPIC nvarchar(30), @mFrom DateTime, @mTo DateTime

--AS
--	SELECT [PROJECT], [PROCESS CODE] AS [ITEM CODE], [TASK] AS [TASK CODE], [DESCRIPTION], [UOM], [QUOTA], COUNT(DISTINCT [UID]) AS [# OF OPERATORS], AVG([PRODUCTIVITY]) AS [AVERAGE PRODUCTIVITY], MAX([PRODUCTIVITY]) AS [HIGHEST PRODUCTIVITY], MIN([PRODUCTIVITY]) AS [LOWEST PRODUCTIVITY], STDEV([PRODUCTIVITY]) AS [STANDARD DEVIATION], COUNT([UID]) AS [# OF RECORDS]
--	FROM (
--		SELECT tsrd.TR_Index AS [INDEX], tsrd.TR_UID AS [UID], pcpd.PCP_ID AS [JOB CODE], prjd.ProjectName [PROJECT], tskd.Task_ID AS [TASK], tskd.Task_Description AS [DESCRIPTION], tskd.Task_UOM AS [UOM], tskd.Task_Quota AS [QUOTA], tskd.PC_ProcessCode AS [PROCESS CODE], tsrd.TR_Productivity AS [PRODUCTIVITY]
--		FROM tbl_TaskDetail tskd
--		INNER JOIN tbl_ProjectDetail prjd ON tskd.PIC_Project=prjd.ProjectName
--		INNER JOIN tbl_PCPDetail pcpd ON pcpd.PC_ProcessCode=tskd.PC_ProcessCode AND tskd.Task_ID=pcpd.Task_ID
--		INNER JOIN tbl_TaskRecordDetail tsrd ON pcpd.Task_ID=tsrd.Task_ID AND pcpd.PCP_ID=tsrd.PCP_ID
--		WHERE prjd.PIC_UID=@mPIC AND tsrd.TR_InDate BETWEEN @mFrom AND @mTo AND tsrd.TR_Apporval=2
--	) GroupDetails
--	GROUP BY [PROJECT], [PROCESS CODE], [TASK], [DESCRIPTION], [UOM], [QUOTA]
--GO

--EXEC DBoard_TasksAndQuota 'EC4', '2018-02-01 00:00:00.000', '2018-02-28 23:59:59.000' 



--CREATE PROC DBoard_AllTasksAndQuota @mPIC nvarchar(30), @mFrom DateTime, @mTo DateTime

--AS
--SELECT tsrd.TR_UID AS [UID], tskd.PC_ProcessCode AS [PROCESS CODE], prjd.ProjectName [PROJECT], tskd.Task_ID AS [TASK], tskd.Task_Description AS [DESCRIPTION], tskd.Task_UOM AS [UOM], tskd.Task_Quota AS [QUOTA], tsrd.TR_Productivity AS [PRODUCTIVITY]
--	FROM tbl_TaskDetail tskd
--	INNER JOIN tbl_ProjectDetail prjd ON tskd.PIC_Project=prjd.ProjectName
--	INNER JOIN tbl_PCPDetail pcpd ON pcpd.PC_ProcessCode=tskd.PC_ProcessCode AND tskd.Task_ID=pcpd.Task_ID
--	INNER JOIN tbl_TaskRecordDetail tsrd ON pcpd.Task_ID=tsrd.Task_ID AND pcpd.PCP_ID=tsrd.PCP_ID
--WHERE prjd.PIC_UID=@mPIC AND tsrd.TR_InDate BETWEEN @mFrom AND @mTo AND tsrd.TR_Apporval=2
--ORDER BY tskd.Task_Description
--GO


--EXEC DBoard_AllTasksAndQuota 'EC4', '2018-02-01 00:00:00.000', '2018-02-28 23:59:59.000'

