/****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP (1000) [PIC_Project]
      ,[PC_ProcessCode]
      ,[PIC_UID]
  FROM [CITITO].[dbo].[tbl_ProcessCodeHeader]
  WHERE LEN(PC_ProcessCode)>8