EXEC DBoard_X3byUser_Ranked 'ZDQ', '2018-04-01', '2018-04-30'
EXEC Dboard_PTRdetails 'ZDQ', '2018-04-01', '2018-04-30'
EXEC DBoard_TasksAndQuota 'ZDQ', '2018-04-01', '2018-04-30'
EXEC ScheduledX3Calculation

SELECT TOP (999999999999999999) ROW_NUMBER() OVER(ORDER BY d.TR_UID) AS RowNumber, d.TR_Index, CONVERT(date, d.TR_ActualTaskIn) AS [WORKDATE], d.TR_ID, d.TR_UID, d.TR_InDate,d.TR_ActualTaskIn, d.TR_OutDate, d.TR_Status, d.TR_Apporval,d.TR_MID,d.TR_PIC,d.TR_Shipment,d.TR_File,ROUND(ISNULL(CAST(d.TR_FileSize AS float),0),2) AS [ACTUAL_OUTPUT],d.TR_Hours AS [WORKED_HOURS], 
	ams.FIRSTLOGIN,ams.LASTLOGOUT,ISNULL(CAST(ams.LASTLOGOUT - ams.FIRSTLOGIN AS float)*24,0),idl.IDLE_InDate,IDLE_OutDate,ISNULL(CAST(idl.IDLE_OutDate - idl.IDLE_InDate AS float)*24,0),
	ROUND(ISNULL(CAST(d.TR_Quota AS float),0),2) AS [QUOTA], d.TR_UOM, d.PCP_ID, d.Task_ID, p.PC_ProcessCode, p.PCP_Project
    FROM tbl_TaskRecordDetail d
	LEFT OUTER JOIN tbl_UserLILO ams ON d.TR_UID=ams.[UID] AND CONVERT(date, d.TR_ActualTaskIn)=CONVERT(date, ams.[DATE])
	LEFT OUTER JOIN tbl_PCPDetail p ON d.PCP_ID=p.PCP_ID AND p.Task_ID=d.Task_ID
	LEFT OUTER JOIN tbl_Report_TempidleDetails idl ON idl.IDLE_Project=p.PCP_Project AND  d.TR_UID=idl.IDLE_UID AND CONVERT(date, d.TR_OutDate)=idl.WORKDATE
	/*WHERE d.TR_ActualTaskIn BETWEEN @mFrom AND @mTo AND d.TR_PIC=@mPIC AND d.TR_Status IS NOT NULL*/
	ORDER BY d.TR_UID

	SELECT TOP (999999999999999999) ROW_NUMBER() OVER(ORDER BY d.TR_UID) AS RowNumber, d.TR_Index, CONVERT(date, d.TR_ActualTaskIn) AS [WORKDATE], d.TR_ID, d.TR_UID, d.TR_InDate,d.TR_ActualTaskIn, d.TR_OutDate, d.TR_Status, d.TR_Apporval,usr.M_UID,usr.PIC_UID,d.TR_Shipment,d.TR_File,ROUND(ISNULL(CAST(d.TR_FileSize AS float),0),2) AS [ACTUAL_OUTPUT],d.TR_Hours AS [WORKED_HOURS], 
	ams.FIRSTLOGIN,ams.LASTLOGOUT,ISNULL(CAST(ams.LASTLOGOUT - ams.FIRSTLOGIN AS float)*24,0),idl.IDLE_InDate,IDLE_OutDate,ISNULL(CAST(idl.IDLE_OutDate - idl.IDLE_InDate AS float)*24,0),
	ROUND(ISNULL(CAST(d.TR_Quota AS float),0),2) AS [QUOTA], d.TR_UOM, d.PCP_ID, d.Task_ID, p.PC_ProcessCode, p.PCP_Project
    FROM tbl_TaskRecordDetail d
	LEFT OUTER JOIN tbl_UserLILO ams ON d.TR_UID=ams.[UID] AND CONVERT(date, d.TR_ActualTaskIn)=CONVERT(date, ams.[DATE])
	LEFT OUTER JOIN tbl_PCPDetail p ON d.PCP_ID=p.PCP_ID AND p.Task_ID=d.Task_ID
	LEFT OUTER JOIN tbl_UserManagementDetail usr ON usr.P_UID=d.TR_UID AND usr.P_Project_Availability='Active' AND usr.P_Project=p.PCP_Project
	LEFT OUTER JOIN tbl_Report_TempidleDetails idl ON idl.IDLE_Project=p.PCP_Project AND  d.TR_UID=idl.IDLE_UID AND CONVERT(date, d.TR_OutDate)=idl.WORKDATE AND idl.IDLE_Project=usr.P_Project
	/*WHERE d.TR_ActualTaskIn BETWEEN @mFrom AND @mTo AND d.TR_PIC=@mPIC AND d.TR_Status IS NOT NULL*/
	ORDER BY d.TR_UID

SELECT T.TR_UID AS [UID], usr.M_UID AS [MID], usr.PIC_UID AS [PIC], convert(date,L.[DATE]) AS [DATE],L.FIRSTLOGIN, L.LASTLOGOUT, ROUND(ISNULL(CAST(L.LASTLOGOUT-L.FIRSTLOGIN AS float)*24,0),2) AS [AMSDIFF], MIN(T.TR_ActualTaskIn) AS [TASKED-IN], MAX(T.TR_OutDate) AS [TASKED-OUT], ROUND(ISNULL(CAST(MAX(T.TR_OutDate)-MIN(T.TR_ActualTaskIn) AS float)*24,0),2) AS [TASKDIFF], ISNULL((I.APPROVED_IDLE),0) AS [APPROVED_IDLE], ((ROUND(ISNULL(CAST(L.LASTLOGOUT-L.FIRSTLOGIN AS float)*24,0),2))-(ROUND(ISNULL(CAST(MAX(T.TR_OutDate)-MIN(T.TR_ActualTaskIn) AS float)*24,0),2)))-(ISNULL((I.APPROVED_IDLE),0)) AS [WASTAGE]
	FROM tbl_TaskRecordDetail T
	INNER JOIN tbl_UserLILO L ON T.TR_UID=L.[UID] AND L.[DATE]=convert(date, T.TR_ActualTaskIn)
	LEFT OUTER JOIN tbl_Report_TempsumofidleDetails I ON I.WORKDATE=convert(date, T.TR_ActualTaskIn) AND T.TR_UID=I.IDLE_UID
	LEFT OUTER JOIN tbl_UserManagementDetail usr ON usr.P_UID=T.TR_UID AND usr.P_Project_Availability='Active'
	--WHERE T.TR_PIC='16V' AND T.TR_InDate BETWEEN '2018-02-01' AND '2018-02-28' 
	GROUP BY  T.TR_UID, usr.M_UID,  usr.PIC_UID, L.[DATE], L.FIRSTLOGIN, L.LASTLOGOUT,L.[UID],I.APPROVED_IDLE
	--HAVING (CAST(ROUND(DATEDIFF(MINUTE,L.LASTLOGOUT, MAX(T.TR_OutDate))/60.0, 3)AS decimal (6,3))) NOT IN (0)
	ORDER BY L.[DATE] DESC
--SELECT T.TR_UID AS [UID], T.TR_MID AS [MID], T.TR_PIC AS [PIC], convert(date,L.[DATE]) AS [DATE],L.FIRSTLOGIN, L.LASTLOGOUT, ROUND(ISNULL(CAST(L.LASTLOGOUT-L.FIRSTLOGIN AS float)*24,0),2) AS [AMSDIFF], MIN(T.TR_ActualTaskIn) AS [TASKED-IN], MAX(T.TR_OutDate) AS [TASKED-OUT], ROUND(ISNULL(CAST(MAX(T.TR_OutDate)-MIN(T.TR_ActualTaskIn) AS float)*24,0),2) AS [TASKDIFF], ISNULL(SUM(I.APPROVED_IDLE),0) AS [APPROVED_IDLE], ((ROUND(ISNULL(CAST(L.LASTLOGOUT-L.FIRSTLOGIN AS float)*24,0),2))-(ROUND(ISNULL(CAST(MAX(T.TR_OutDate)-MIN(T.TR_ActualTaskIn) AS float)*24,0),2)))-(ISNULL(SUM(I.APPROVED_IDLE),0)) AS [WASTAGE]
--	FROM tbl_TaskRecordDetail T
--	INNER JOIN tbl_UserLILO L ON T.TR_UID=L.[UID] AND L.[DATE]=convert(date, T.TR_ActualTaskIn)
--	LEFT OUTER JOIN tbl_Report_TempsumofidleDetails I ON I.WORKDATE=convert(date, T.TR_ActualTaskIn) AND T.TR_UID=I.IDLE_UID
--	--WHERE T.TR_PIC='16V' AND T.TR_InDate BETWEEN '2018-02-01' AND '2018-02-28' 
--	GROUP BY  T.TR_UID, T.TR_MID, T.TR_PIC, L.[DATE], L.FIRSTLOGIN, L.LASTLOGOUT
--	--HAVING (CAST(ROUND(DATEDIFF(MINUTE,L.LASTLOGOUT, MAX(T.TR_OutDate))/60.0, 3)AS decimal (6,3))) NOT IN (0)
--	ORDER BY L.[DATE] DESC


SELECT T.TR_UID AS [UID], T.TR_MID AS [MID], T.TR_PIC AS [PIC], convert(date,L.[DATE]) AS [DATE],L.FIRSTLOGIN, L.LASTLOGOUT, ROUND(ISNULL(CAST(L.LASTLOGOUT-L.FIRSTLOGIN AS float)*24,0),2) AS [AMSDIFF], MIN(T.TR_ActualTaskIn) AS [TASKED-IN], MAX(T.TR_OutDate) AS [TASKED-OUT], ROUND(ISNULL(CAST(MAX(T.TR_OutDate)-MIN(T.TR_ActualTaskIn) AS float)*24,0),2) AS [TASKDIFF], ISNULL((I.APPROVED_IDLE),0) AS [APPROVED_IDLE], ((ROUND(ISNULL(CAST(L.LASTLOGOUT-L.FIRSTLOGIN AS float)*24,0),2))-(ROUND(ISNULL(CAST(MAX(T.TR_OutDate)-MIN(T.TR_ActualTaskIn) AS float)*24,0),2)))-(ISNULL((I.APPROVED_IDLE),0)) AS [WASTAGE]
	FROM tbl_TaskRecordDetail T
	INNER JOIN tbl_UserLILO L ON T.TR_UID=L.[UID] AND L.[DATE]=convert(date, T.TR_ActualTaskIn)
	LEFT OUTER JOIN tbl_Report_TempsumofidleDetails I ON I.WORKDATE=convert(date, T.TR_ActualTaskIn) AND T.TR_UID=I.IDLE_UID
	--WHERE T.TR_PIC='16V' AND T.TR_InDate BETWEEN '2018-02-01' AND '2018-02-28' 
	GROUP BY  T.TR_UID, T.TR_MID, T.TR_PIC, L.[DATE], L.FIRSTLOGIN, L.LASTLOGOUT,L.[UID],I.APPROVED_IDLE
	--HAVING (CAST(ROUND(DATEDIFF(MINUTE,L.LASTLOGOUT, MAX(T.TR_OutDate))/60.0, 3)AS decimal (6,3))) NOT IN (0)
	ORDER BY L.[DATE] DESC
--SELECT T.TR_UID AS [UID], T.TR_MID AS [MID], T.TR_PIC AS [PIC], convert(date,L.[DATE]) AS [DATE],L.FIRSTLOGIN, L.LASTLOGOUT, ROUND(ISNULL(CAST(L.LASTLOGOUT-L.FIRSTLOGIN AS float)*24,0),2) AS [AMSDIFF], MIN(T.TR_ActualTaskIn) AS [TASKED-IN], MAX(T.TR_OutDate) AS [TASKED-OUT], ROUND(ISNULL(CAST(MAX(T.TR_OutDate)-MIN(T.TR_ActualTaskIn) AS float)*24,0),2) AS [TASKDIFF], ISNULL(SUM(I.APPROVED_IDLE),0) AS [APPROVED_IDLE], ((ROUND(ISNULL(CAST(L.LASTLOGOUT-L.FIRSTLOGIN AS float)*24,0),2))-(ROUND(ISNULL(CAST(MAX(T.TR_OutDate)-MIN(T.TR_ActualTaskIn) AS float)*24,0),2)))-(ISNULL(SUM(I.APPROVED_IDLE),0)) AS [WASTAGE]
--	FROM tbl_TaskRecordDetail T
--	INNER JOIN tbl_UserLILO L ON T.TR_UID=L.[UID] AND L.[DATE]=convert(date, T.TR_ActualTaskIn)
--	LEFT OUTER JOIN tbl_Report_TempsumofidleDetails I ON I.WORKDATE=convert(date, T.TR_ActualTaskIn) AND T.TR_UID=I.IDLE_UID
--	--WHERE T.TR_PIC='16V' AND T.TR_InDate BETWEEN '2018-02-01' AND '2018-02-28' 
--	GROUP BY  T.TR_UID, T.TR_MID, T.TR_PIC, L.[DATE], L.FIRSTLOGIN, L.LASTLOGOUT
--	--HAVING (CAST(ROUND(DATEDIFF(MINUTE,L.LASTLOGOUT, MAX(T.TR_OutDate))/60.0, 3)AS decimal (6,3))) NOT IN (0)
--	ORDER BY L.[DATE] DESC


SELECT [TR_UID] AS [User ID]
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
  WHERE usr.PIC_UID='ZDQ' AND CONVERT(Date, TR.[TR_ActualTaskIn]) BETWEEN '2018-04-01' AND '2018-04-30' AND TR.TR_TaskStatus!=1
  ORDER BY TR.TR_UID, CONVERT(Date, TR.[TR_ActualTaskIn])


