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
  WHERE PCP_ID='REX0818EB84'

  --UPDATE [tbl_PCPDetail]
  --SET PCP_Status=3
  --WHERE [PCPD_Index]=357382