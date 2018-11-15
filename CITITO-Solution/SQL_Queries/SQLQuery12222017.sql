SELECT pd.PCP_Project, td.TR_Shipment, td.TR_File, th.PCP_ID, td.Task_ID +' - '+ tsd.Task_Description AS [Task Code], td.TR_InDate  
FROM tbl_PCPDetail pd 
INNER JOIN tbl_TaskRecordHeader th ON pd.PCP_ID = th.PCP_ID 
INNER JOIN tbl_TaskRecordDetail td ON td.TR_ID = th.TR_ID 
INNER JOIN tbl_TaskDetail tsd ON tsd.Task_ID = td.Task_ID  AND tsd.PC_ProcessCode = pd.PC_ProcessCode 
WHERE td.TR_UID = '8DM' AND pd.PCP_Status = '2' AND td.TR_TaskStatus = '1' 
GROUP BY pd.PCP_Project, td.TR_Shipment, td.TR_File, th.PCP_ID, td.Task_ID + ' - ' + tsd.Task_Description, td.TR_InDate 

SELECT td.TR_TaskStatus FROM tbl_PCPDetail pd 
INNER JOIN tbl_TaskRecordHeader th ON pd.PCP_ID = th.PCP_ID 
INNER JOIN tbl_TaskRecordDetail td ON td.TR_ID = th.TR_ID 
WHERE pd.PCP_ID = 'TNI1217DA83' AND pd.PCP_Status = '2' AND td.TR_TaskStatus='1'

SELECT td.TR_UID FROM tbl_PCPDetail pd 
INNER JOIN tbl_TaskRecordHeader th ON pd.PCP_ID = th.PCP_ID 
INNER JOIN tbl_TaskRecordDetail td ON td.TR_ID = th.TR_ID 
WHERE pd.PCP_ID = 'TNI1217DA83' AND pd.PCP_Status = '2' AND td.TR_TaskStatus='1'

SELECT COUNT(td.TR_UID) FROM tbl_PCPDetail pd 
INNER JOIN tbl_TaskRecordHeader th ON pd.PCP_ID = th.PCP_ID 
INNER JOIN tbl_TaskRecordDetail td ON td.TR_ID = th.TR_ID 
WHERE pd.PCP_ID = 'TNI1217DA83' AND pd.PCP_Status = '2' AND td.TR_TaskStatus = '1'


SELECT d.TR_ID AS [#], h.PCP_ID AS[Job Code], d.TR_Shipment AS [Shipment], d.TR_File AS [File Name], d.TR_FileSize AS [Output], d.TR_UOM AS [OUM], d.Task_ID AS [Task], d.TR_Status AS [Job Status], d.TR_InDate AS [Task In Time], d.TR_OutDate AS [Task Out Time], d.TR_Hours AS [Task Hours], d.TR_Apporval As [Approval Status], d.TR_ApprovalTime As [Approval Time], d.TR_Productivity AS [Task Productivity] 
FROM tbl_TaskRecordHeader h 
INNER JOIN tbl_TaskRecordDetail d ON h.TR_ID = d.TR_ID 
WHERE d.TR_UID = '5CA' AND TR_Status!='' ORDER BY d.TR_Index desc

SELECT COUNT(PC_ProcessCode) FROM tbl_PCPDetail 
WHERE PCP_ID = 'TNI1217DA83' AND Task_ID = '" + mTaskCode + "' AND PCP_File = '" + mFileName + "' 
GROUP BY PC_ProcessCode

SELECT COUNT(PCP_ID) FROM tbl_TaskRecordDetail 
WHERE PCP_ID = 'TNI1217DA131' AND Task_ID = 'TNI_DA1' AND TR_Status=3 AND TR_File = '9781418587642' AND TR_Apporval!=3 
GROUP BY PCP_ID