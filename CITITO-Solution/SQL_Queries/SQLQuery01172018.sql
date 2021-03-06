/****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP (1000) [TR_Index]
      ,[Task_ID]
      ,[PC_ProcessCode]
      ,[PIC_Project]
      ,[SkipOutputValidation]
  FROM [CITITO].[dbo].[tbl_TaskHeader]
  WHERE [PIC_Project]='TESTJ'

  SELECT s.Task_ID AS [Task Code],s.Task_Description AS [Description], s.Task_UOM AS [UOM], s.Task_Quota AS [Quota] , s.PIC_Project AS [Project], s.PC_ProcessCode AS [Item/Process Code], h.SkipOutputValidation AS [User Output Validation]
  FROM tbl_TaskDetail s 
  INNER JOIN tbl_TaskHeader h ON s.Task_ID=h.Task_ID AND h.PC_ProcessCode=s.PC_ProcessCode
  INNER JOIN tbl_ProjectDetail p ON s.PIC_Project = p.ProjectName 
  WHERE p.PIC_UID = 'ZDQ'
