/*Tasks*/
SELECT 
	result.[User ID],
	result.[Employee Name],
	result.[Resource ID],
	ptr.PTR_Resources AS [Res ID],
	'RT01' AS [P Type],
	ptr.[PTR_RT01] AS [RT01 Rate],
	result.[DEPT],
	result.[Date],
	result.[Project],
	result.[New Assigned Project],
	result.[Activity Task Code],
	result.[Hours],
	(result.[Hours] * ptr.[PTR_RT01]) AS [RT Cost],
	result.[New Task Code],
	result.[New Task Description],
	result.[CLUSTER]
FROM (
	SELECT  TOP (999999999999999999) [TR_UID] AS [User ID]
		  ,UH.P_Name AS [Employee Name]
		  ,NULL AS [Resource ID]
		  ,NULL AS [Res ID]
		  ,NULL AS [P Type]
		  ,NULL AS [DEPT]
		 ,CONVERT(Date, TR.[TR_ActualTaskIn]) AS [Date]
		  ,usr.P_Project AS [Project]
		  ,NULL AS [New Assigned Project]
		  ,TD.Task_Description AS [Activity Task Code]
		  ,ROUND(ISNULL(CAST(TR.TR_OutDate - TR.TR_ActualTaskIn AS float),0)*24,2) AS [Hours]
		  ,NULL AS [New Task Code]
		  ,NULL AS [New Task Description]
		  ,NULL AS [CLUSTER]
	  FROM [CITITO].[dbo].[tbl_TaskRecordDetail] TR
	  INNER JOIN [tbl_PCPDetail] PCP ON PCP.PCP_ID=TR.PCP_ID AND TR.Task_ID=PCP.Task_ID
	  INNER JOIN [tbl_UserManagementHeader] UH ON UH.P_UID=TR.TR_UID
	  INNER JOIN tbl_UserManagementDetail usr ON usr.P_UID=TR.TR_UID AND usr.P_Project_Availability='Active' AND PCP.PCP_Project=usr.P_Project
	  INNER JOIN [tbl_TaskDetail] TD ON TD.Task_ID=PCP.Task_ID AND TD.PIC_Project=PCP.PCP_Project AND TD.PC_ProcessCode=PCP.PC_ProcessCode
	  WHERE usr.PIC_UID='ZDQ' AND CONVERT(Date, TR.[TR_ActualTaskIn]) BETWEEN '2018-05-01' AND '2018-05-31' AND TR.TR_TaskStatus!=1
	  ORDER BY TR.TR_UID, CONVERT(Date, TR.[TR_ActualTaskIn]) 

  
  UNION ALL

	  /*IDLE*/
	  SELECT * 
	  FROM (
	  SELECT  TOP (999999999999999999) IDL.IDLE_UID AS [User ID]
		  ,UH.P_Name AS [Employee Name]
		  ,NULL AS [Resource ID]
		  ,NULL AS [Res ID]
		  ,NULL AS [P Type]
		  ,NULL AS [DEPT]
		 ,CONVERT(Date, IDL.[IDLE_InDate]) AS [Date]
		  ,usr.P_Project AS [Project]
		  ,NULL AS [New Assigned Project]
		  ,CONCAT('[IDLE] ', IDL.[IDLE_Reason]) AS [Activity Task Code]
		  ,ROUND(ISNULL(IDL.IDLE_Hours,0),2) AS [Hours]
		  ,NULL AS [New Task Code]
		  ,NULL AS [New Task Description]
		  ,NULL AS [CLUSTER]
	  FROM [tbl_IDLEDetail] IDL 
	  INNER JOIN tbl_IDLEHeader IDLH  ON IDLH.IDLE_ID=IDL.IDLE_ID
	  INNER JOIN [tbl_UserManagementHeader] UH ON UH.P_UID=IDL.IDLE_UID
	  INNER JOIN tbl_UserManagementDetail usr ON usr.P_UID=IDL.IDLE_UID AND usr.P_Project_Availability='Active' AND IDLH.IDLE_Project=usr.P_Project
	  WHERE usr.PIC_UID='ZDQ' AND CONVERT(Date, IDL.[IDLE_InDate]) BETWEEN '2018-05-01' AND '2018-05-31' AND IDL.IDLE_Apporval=2
	  ) IDLE

 UNION ALL

	 /*WASTE*/
	  SELECT * 
	  FROM (
	   SELECT  TOP (999999999999999999) WTE.[UID] AS [User ID]
		  ,UH.P_Name AS [Employee Name]
		  ,NULL AS [Resource ID]
		  ,NULL AS [Res ID]
		  ,NULL AS [P Type]
		  ,NULL AS [DEPT]
		  ,WTE.[WORKDATE] AS [Date]
		  ,MAX(usr.P_Project) AS [Project]
		  ,NULL AS [New Assigned Project]
		  ,'[WASTE]' AS [Activity Task Code]
		  ,ROUND(ISNULL(WTE.[WASTE],0),2) AS [Hours]
		  ,NULL AS [New Task Code]
		  ,NULL AS [New Task Description]
		  ,NULL AS [CLUSTER]
	  FROM [tbl_Report_TempIDLEAndWastage] WTE 
	  INNER JOIN [tbl_UserManagementHeader] UH ON UH.P_UID=WTE.[UID]
	  INNER JOIN tbl_UserManagementDetail usr ON usr.P_UID=WTE.[UID] AND usr.P_Project_Availability='Active'
	  WHERE usr.PIC_UID='ZDQ' AND WTE.[WORKDATE] BETWEEN '2018-05-01' AND '2018-05-01'
	  GROUP BY WTE.[UID], UH.P_Name, WTE.[WORKDATE],WTE.[WASTE]
		)Waste
  ) result
INNER JOIN tbl_UserManagementHeader ud ON result.[User ID]=ud.P_UID
INNER JOIN tbl_PTR_QA_StdRates ptr ON ud.PTR_Resources=ptr.PTR_Resources
ORDER BY [User ID], [Date]