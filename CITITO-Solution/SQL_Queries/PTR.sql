SELECT *
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
  ) TASKS
  
  UNION ALL
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
	  , CONCAT('[IDLE] ', IDL.[IDLE_Reason]) AS [Activity Task Code]
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

  ORDER BY [User ID], [Date]