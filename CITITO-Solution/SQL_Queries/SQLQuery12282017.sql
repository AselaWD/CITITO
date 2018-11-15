SELECT d.TR_UID AS [UID], d.TR_ID AS [Record ID], h.PCP_ID AS[Job Code], d.TR_Shipment AS [Shipment], d.TR_File AS [File Name], d.TR_FileSize AS [Output], d.TR_UOM AS [OUM], d.Task_ID AS [Task], d.TR_Status AS [Job Status], d.TR_InDate AS [Task In Time], d.TR_OutDate AS [Task Out Time], d.TR_Hours AS [Task Hours], d.TR_Apporval As [Approval Status], d.TR_ApprovalTime As [Approval Time], d.TR_Productivity AS [Task Productivity] 
FROM tbl_TaskRecordHeader h INNER JOIN tbl_TaskRecordDetail d ON h.TR_ID = d.TR_ID 
WHERE ((d.TR_PIC = 'ZDQ' AND TR_Status='3' AND d.TR_Apporval=2 AND d.TR_UID LIKE '%CW') 
OR (d.TR_PIC = 'ZDQ' AND TR_Status='3' AND d.TR_Apporval=2 AND d.TR_UID LIKE 'CW%')) 
OR ((d.TR_PIC = 'ZDQ' AND TR_Status='3' AND d.TR_Apporval=3 AND d.TR_UID LIKE '%CW') 
OR (d.TR_PIC = 'ZDQ' AND TR_Status='3' AND d.TR_Apporval=3 AND d.TR_UID LIKE 'CW%'))


SELECT d.TR_ID FROM tbl_TaskRecordDetail d INNER JOIN tbl_TaskRecordHeader h ON h.TR_ID = d.TR_ID 
WHERE d.Task_ID = 'APP_EB4' AND h.PCP_ID = 'APP1217EB2' AND TR_Status='2' AND d.TR_TaskStatus = '0'

SELECT d.TR_ID FROM tbl_TaskRecordDetail d INNER JOIN tbl_TaskRecordHeader h ON h.TR_ID = d.TR_ID 
WHERE d.Task_ID = 'TNI_DA1' AND h.PCP_ID = 'TNI1217DA153' AND TR_Status='2' AND d.TR_TaskStatus = '0'

False	3734	TNI1217DA153	HCCP_096	TNIDACAK	TNI_DA1	AAAAA	150	Fresh	12/26/2017 2:53 PM	
