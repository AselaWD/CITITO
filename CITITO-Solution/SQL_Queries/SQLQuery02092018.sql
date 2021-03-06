/****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP (1000) [PCPD_Index]
      ,[PCP_ID]
      ,[PCP_File]
      ,[PCP_FileSize]
      ,[PCP_Status]
      ,[PCP_Project]
      ,[Task_UOM]
      ,[Task_Quota]
      ,[PCP_StartDate]
      ,[PCP_EndDate]
      ,[PCP_CreatorUID]
      ,[PC_ProcessCode]
      ,[Task_ID]
  FROM [CITITO].[dbo].[tbl_PCPDetail]
  WHERE PCP_ID='MSI0218XM110'


  SELECT d.PCPD_Index AS [#], h.PCP_ID AS[Job Code], h.PCP_Shipment AS [Shipment], h.PC_ProcessCode AS [Process Code], d.Task_ID AS [Task Code], d.PCP_File AS [File Name], d.PCP_FileSize AS [File Size], d.PCP_Status AS [Job Status], d.PCP_StartDate As [Created Date/Time], d.PCP_EndDate AS [Done Date/Time], d.PCP_CreatorUID AS [DCD User] 
  FROM tbl_PCPHeader h 
  INNER JOIN tbl_PCPDetail d ON h.PCP_ID = d.PCP_ID
  INNER JOIN tbl_ManagerDetail u ON u.M_Project = d.PCP_Project AND u.M_UID = 'YE3'
  WHERE h.PCP_ID='MSI0218XM110'
  ORDER BY d.PCPD_Index
