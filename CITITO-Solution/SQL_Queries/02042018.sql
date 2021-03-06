
  	SELECT [PROJECT], [PROCESS CODE] AS [ITEM CODE], [TASK] AS [TASK CODE], [DESCRIPTION], [UOM], [QUOTA], COUNT(DISTINCT [UID]) AS [# OF OPERATORS], ROUND(AVG([PRODUCTIVITY]),2) AS [AVERAGE PRODUCTIVITY], ROUND(MAX([PRODUCTIVITY]),2) AS [HIGHEST PRODUCTIVITY], ROUND(MIN([PRODUCTIVITY]),2) AS [LOWEST PRODUCTIVITY], ROUND(STDEV([PRODUCTIVITY]),2) AS [STANDARD DEVIATION], COUNT([UID]) AS [# OF RECORDS]
	FROM (
		SELECT tsrd.TR_Index AS [INDEX], tsrd.TR_UID AS [UID], pcpd.PCP_ID AS [JOB CODE], prjd.ProjectName [PROJECT], tskd.Task_ID AS [TASK], tskd.Task_Description AS [DESCRIPTION], tskd.Task_UOM AS [UOM], tskd.Task_Quota AS [QUOTA], tskd.PC_ProcessCode AS [PROCESS CODE], tsrd.TR_Productivity AS [PRODUCTIVITY]
		FROM tbl_TaskDetail tskd
		INNER JOIN tbl_ProjectDetail prjd ON tskd.PIC_Project=prjd.ProjectName
		INNER JOIN tbl_PCPDetail pcpd ON pcpd.PC_ProcessCode=tskd.PC_ProcessCode AND tskd.Task_ID=pcpd.Task_ID
		INNER JOIN tbl_TaskRecordDetail tsrd ON pcpd.Task_ID=tsrd.Task_ID AND pcpd.PCP_ID=tsrd.PCP_ID
		WHERE prjd.PIC_UID='ZDQ' AND tsrd.TR_InDate BETWEEN '2018-02-01' AND '2018-02-28' AND tsrd.TR_Apporval=2
	) GroupDetails
	GROUP BY [PROJECT], [PROCESS CODE], [TASK], [DESCRIPTION], [UOM], [QUOTA]


	SELECT TD.PCP_Project AS [PROJECT], TD.PC_ProcessCode AS [ITEM CODE], TD.Task_ID AS [TASK CODE], TDES.Task_Description AS [DESCRIPTION], TD.TR_UOM AS [UOM], TD.QUOTA AS [QUOTA], COUNT(DISTINCT TD.TR_UID) AS [# OF OPERATORS], ROUND(AVG(TD.X3),2) AS [AVERAGE PRODUCTIVITY], ROUND(MAX(TD.X3),2) AS [HIGHEST PRODUCTIVITY], ROUND(MIN(TD.X3),2) AS [LOWEST PRODUCTIVITY], ROUND(STDEV(TD.X3),2) AS [STANDARD DEVIATION], COUNT(TD.TR_UID) AS [# OF RECORDS]
	FROM [tbl_Report_TemptaskDetailsQUOTA_Updated] TD
	INNER JOIN [tbl_TaskDetail] TDES ON TDES.PIC_Project=TD.PCP_Project AND TDES.PC_ProcessCode=TD.PC_ProcessCode AND TDES.Task_ID=TD.Task_ID
	WHERE TD.TR_PIC='ZDQ' AND TD.TR_ActualTaskIn BETWEEN '2018-02-01' AND '2018-02-28'
	GROUP BY  TD.PCP_Project, TD.PC_ProcessCode, TD.Task_ID, TDES.Task_Description, TD.TR_UOM, TD.QUOTA


	SELECT CONVERT(date,tsrd.TR_ActualTaskIn) AS [WORKDATE], tsrd.TR_UID AS [UID], tskd.PC_ProcessCode AS [PROCESS CODE], prjd.ProjectName [PROJECT], tskd.Task_ID AS [TASK], tskd.Task_Description AS [DESCRIPTION], tskd.Task_UOM AS [UOM], tskd.Task_Quota AS [QUOTA], ROUND(tsrd.TR_Productivity,2) AS [PRODUCTIVITY]
	FROM tbl_TaskDetail tskd
	INNER JOIN tbl_ProjectDetail prjd ON tskd.PIC_Project=prjd.ProjectName
	INNER JOIN tbl_PCPDetail pcpd ON pcpd.PC_ProcessCode=tskd.PC_ProcessCode AND tskd.Task_ID=pcpd.Task_ID
	INNER JOIN tbl_TaskRecordDetail tsrd ON pcpd.Task_ID=tsrd.Task_ID AND pcpd.PCP_ID=tsrd.PCP_ID
	WHERE prjd.PIC_UID=@mPIC AND tsrd.TR_InDate BETWEEN @mFrom AND @mTo AND tsrd.TR_Apporval=2 AND prjd.ProjectName=@mProject AND tskd.PC_ProcessCode=@mProcessCode AND tskd.Task_ID=@mTaskCode AND tskd.Task_Description=@mTaskDesc
	ORDER BY tskd.Task_Description

	SELECT CONVERT(date,TD.TR_ActualTaskIn) AS [WORKDATE], TD.TR_UID AS [UID], TD.PC_ProcessCode AS [PROCESS CODE], TD.PCP_Project [PROJECT], TD.Task_ID AS [TASK], TDES.Task_Description AS [DESCRIPTION], TD.TR_UOM AS [UOM], TD.QUOTA AS [QUOTA], ROUND(TD.X3,2) AS [PRODUCTIVITY]
	FROM [tbl_Report_TemptaskDetailsQUOTA_Updated] TD
	INNER JOIN [tbl_TaskDetail] TDES ON TDES.PIC_Project=TD.PCP_Project AND TDES.PC_ProcessCode=TD.PC_ProcessCode AND TDES.Task_ID=TD.Task_ID
	WHERE TD.TR_PIC=@mPIC AND TD.TR_ActualTaskIn BETWEEN @mFrom AND @mTo AND TD.PCP_Project=@mProject AND TD.PC_ProcessCode=@mProcessCode AND TD.Task_ID=@mTaskCode AND TDES.Task_Description=@mTaskDesc