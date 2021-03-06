/****** Script for SelectTopNRows command from SSMS  ******/
SELECT [TR_Index]
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
  WHERE [TR_ActualTaskIn] IS NULL /*AND [TR_PIC]!='7AO'*/
  ORDER BY [TR_Index] DESC



  UPDATE TD
  SET TD.TR_ActualTaskIn=AMS.FIRSTLOGIN
  FROM tbl_TaskRecordDetail AS TD
  INNER JOIN tbl_UserLILO AS AMS 
  ON CONVERT(date, TD.TR_OutDate)=CONVERT(date, AMS.FIRSTLOGIN) AND TD.TR_UID=AMS.[UID]
  WHERE TD.[TR_ActualTaskIn] IS NULL AND CONVERT(date, TD.TR_InDate)!=CONVERT(date, TD.TR_OutDate)


  --UPDATE [tbl_TaskRecordDetail]
  --SET [TR_ActualTaskIn]=[TR_InDate]
  --WHERE [TR_ActualTaskIn] IS NULL AND CONVERT(date, TR_InDate)!=CONVERT(date, TR_OutDate)

  UPDATE [tbl_TaskRecordDetail]
  SET [TR_ActualTaskIn]=[TR_InDate]
  WHERE [TR_ActualTaskIn] IS NULL AND CONVERT(date, TR_InDate)=CONVERT(date, TR_OutDate)

  UPDATE [tbl_TaskRecordDetail]
  SET [TR_ActualTaskIn]=[TR_InDate]
  WHERE [TR_ActualTaskIn] IS NULL AND TR_TaskStatus=1
  
  --UPDATE [tbl_TaskRecordDetail]
  --SET [TR_ActualTaskIn]='2018-01-17 07:33:54.147'
  --WHERE TR_Index='1685'

-- AND CONVERT(date, TR_InDate)!=CONVERT(date, TR_OutDate)
-- AND TR_TaskStatus=1

/****** Script for SelectTopNRows command from SSMS  ******/
SELECT CONVERT(date, TR_OutDate) AS [WORKDATE]
      ,[TR_UID] AS [USER]
      ,[TR_PIC] AS [PIC]

  FROM [CITITO].[dbo].[tbl_TaskRecordDetail]
  WHERE [TR_ActualTaskIn] IS NULL AND [TR_PIC]!='7AO'
  ORDER BY [TR_Index] DESC


