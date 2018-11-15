/* This script has created to insert CCC tool date to CITIO live database */
/* No. Tables affected: 04 */
/* Tables affected (Relationship Order): 
	1. tbl_PCPHeader
	2. tbl_PCPDetail
	3. tbl_TaskRecordHeader
	4. tbl_TaskRecordDetail
*/

/* INSERT PCP HEADER */
INSERT INTO tbl_PCPHeader (
	   [PCP_ID]
      ,[PC_ProcessCode]
      ,[PCP_Shipment]
)
SELECT 
	CCCB.TR_Job_ID
	,CCCB.[TR_ItemCode]
	,CCCB.[TR_Shipment]
FROM tbl_CCCTaskDetails_Backup CCCB
WHERE NOT EXISTS
(
  SELECT PCPH.[PCP_ID] FROM tbl_PCPHeader PCPH WHERE PCPH.[PCP_ID] = CCCB.TR_Job_ID
)

/* INSERT PCP DETAIL */
INSERT INTO tbl_PCPDetail (
	   [PCP_ID]
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
)
SELECT 
	   CCCB.TR_Job_ID
	  ,CCCB.[TR_File]
      ,CCCB.[TR_FileSize]
      ,CCCB.[TR_Status]
      ,CCCB.[TR_Project]
	  ,CCCB.[TR_UOM]
      ,CCCB.[TR_Quota]
	  ,CCCB.[TR_ActualTaskIn]
	  ,CCCB.[TR_OutDate]
	  ,CCCB.[TR_MID] -- DCD UID GET
      ,CCCB.[TR_ItemCode]
      ,CCCB.[Task_ID]
FROM tbl_CCCTaskDetails_Backup CCCB
WHERE NOT EXISTS
(
  SELECT PCPD.[PCP_ID] FROM tbl_PCPDetail PCPD WHERE PCPD.[PCP_ID] = CCCB.TR_Job_ID
)


/* INSERT TASK HEADER */
INSERT INTO tbl_TaskRecordHeader (
	TR_ID
	,PCP_ID
	,TR_UID
	,TR_MID
	,TR_PIC
)
SELECT 
	CONCAT('CCCDB',CCCB.TR_UID,CCCB.TR_Index)
	,CCCB.TR_Job_ID
	,CCCB.TR_UID
	,CCCB.TR_MID
	,CCCB.TR_PIC
FROM tbl_CCCTaskDetails_Backup CCCB
WHERE NOT EXISTS
(
  SELECT THB.TR_ID FROM tbl_TaskRecordHeader THB WHERE THB.PCP_ID = CCCB.TR_Job_ID
)

/* INSERT TASK DETAIL */
INSERT INTO tbl_TaskRecordDetail(
		[TR_ID]
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
)
SELECT 
	CONCAT('CCCDB',CCCB.TR_UID,CCCB.TR_Index)
	  ,CCCB.[TR_Job_ID]
	  ,CCCB.[TR_Status]
	  ,CCCB.[TR_ActualTaskIn]
      ,CCCB.[TR_OutDate]
	  ,0
	  ,CCCB.[TR_Shipment]
	  ,CCCB.[TR_File]
      ,CCCB.[TR_FileSize]
	  ,CCCB.[TR_UOM]
      ,CCCB.[TR_Quota]
	  ,CCCB.[TR_UID]
      ,CCCB.[TR_MID]
      ,CCCB.[TR_PIC]
	  ,CCCB.[TR_Apporval]
      ,CCCB.[TR_ApprovalTime]
	  ,CCCB.[TR_Hours]
	  ,CCCB.[TR_Productivity]
	  ,CCCB.[Task_ID]
	  ,CCCB.[TR_ActualTaskIn]
FROM tbl_CCCTaskDetails_Backup CCCB
WHERE NOT EXISTS
(
  SELECT THD.TR_ID FROM tbl_TaskRecordDetail THD WHERE THD.PCP_ID = CCCB.TR_Job_ID
)