/****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP (1000) [TR_Index]
      ,[TR_ID]
      ,[PCP_ID]
      ,[TR_Status]
      ,[TR_InDate]
      ,[TR_OutDate]
      ,[TR_TaskStatus]
      ,[TR_Shipment]
      ,[TR_File]
      ,[TR_FileSize]
      ,[TR_UOM]
      ,[TR_Quota]
      ,[TR_UID]
      ,[TR_MID]
      ,[TR_PIC]
      ,[TR_Apporval]
      ,[TR_ApprovalTime]
      ,[TR_Hours]
      ,[TR_Productivity]
      ,[Task_ID]
      ,[TR_ActualTaskIn]
  FROM [CITITO].[dbo].[tbl_TaskRecordDetail]
  WHERE TR_UID='3DD'
  ORDER BY [TR_Index] DESC

  --DELETE [tbl_TaskRecordDetail]
  --WHERE [TR_Index]=140922