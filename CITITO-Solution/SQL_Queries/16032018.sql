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
  FROM [CITITO].[dbo].[tbl_TaskRecordDetail_BackUp]
  WHERE CONVERT(date, TR_InDate)!=CONVERT(date, TR_OutDate)
  ORDER BY TR_Index DESC


UPDATE TD
  SET TD.TR_ActualTaskIn=AMS.FIRSTLOGIN
  FROM tbl_TaskRecordDetail_BackUp AS TD
  INNER JOIN tbl_UserLILO AS AMS 
  ON CONVERT(date, TD.TR_OutDate)=CONVERT(date, AMS.FIRSTLOGIN) AND TD.TR_UID=AMS.[UID]
	WHERE TD.[TR_ActualTaskIn] IS NULL AND CONVERT(date, TD.TR_InDate)!=CONVERT(date, TD.TR_OutDate)


  --UPDATE [tbl_TaskRecordDetail_BackUp]
  --SET TR_ActualTaskIn=TR_InDate
  --WHERE TR_Apporval=4 AND TR_Status=2 AND CONVERT(date, TR_InDate)=CONVERT(date, TR_OutDate) AND TR_ActualTaskIn IS NULL

