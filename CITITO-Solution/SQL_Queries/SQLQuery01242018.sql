SELECT h.TRM_ID AS [Modified ID], d.TR_UID AS [UID], h.TR_ID AS [Record ID], h.PCP_ID AS[Job Code], d.TR_File AS [File Name], d.TR_FileSize AS [Output], d.TR_UOM AS [OUM], d.TR_Status AS [Job Status], d.TRM_InDate AS [Task In Time], d.TRM_OutDate AS [Task Out Time], d.TRM_Hours AS [Task Hours], d.TRM_Apporval As [Approval Status], d.TRM_ApprovalTime As [Approval Time], d.TRM_Productivity AS [Task Productivity] 
FROM tbl_TaskRecordHeaderModify h 
INNER JOIN tbl_TaskRecordDetailModify d ON h.TRM_ID = d.TRM_ID 
WHERE d.TRM_PIC = '" + mPIC + "' AND TR_Status='3' AND d.TRM_Apporval=1 ORDER BY d.TRM_Index desc

SELECT h.TRM_ID AS [Modified ID], d.TR_UID AS [UID], h.TR_ID AS [Record ID], h.PCP_ID AS[Job Code], d.TR_File AS [File Name], d.TR_FileSize AS [Output], d.TR_UOM AS [OUM], d.TR_Status AS [Job Status], d.TRM_InDate AS [Task In Time], d.TRM_OutDate AS [Task Out Time], d.TRM_Hours AS [Task Hours], d.TRM_Apporval As [Approval Status], d.TRM_ApprovalTime As [Approval Time], d.TRM_Productivity AS [Task Productivity] 
FROM tbl_TaskRecordHeaderModify h 
INNER JOIN tbl_TaskRecordDetailModify d ON h.TRM_ID = d.TRM_ID  AND d.TR_UID
WHERE d.TRM_MID = '" + mMUID + "' AND TR_Status='3' AND d.TRM_Apporval=1 ORDER BY d.TRM_Index desc


SELECT h.TRM_ID AS [Modified ID], d.TR_UID AS [UID], h.TR_ID AS [Record ID], h.PCP_ID AS[Job Code], d.TR_File AS [File Name], d.TR_FileSize AS [Output], d.TR_UOM AS [OUM], d.TR_Status AS [Job Status], d.TRM_InDate AS [Task In Time], d.TRM_OutDate AS [Task Out Time], d.TRM_Hours AS [Task Hours], d.TRM_Apporval As [Approval Status], d.TRM_ApprovalTime As [Approval Time], d.TRM_Productivity AS [Task Productivity] FROM tbl_TaskRecordHeaderModify h INNER JOIN tbl_TaskRecordDetailModify d ON h.TRM_ID = d.TRM_ID 
WHERE 
(d.TRM_MID = '" + uMUID + "' AND TR_Status = '3' AND d.TRM_Apporval = '1' AND (d.TRM_InDate BETWEEN '" + mFrom + "' AND '" + mTo + "')) 
OR (d.TRM_MID = '" + uMUID + "' AND TR_Status = '3' AND d.TRM_Apporval = '2' AND (d.TRM_InDate BETWEEN '" + mFrom + "' AND '" + mTo + "')) 
OR (d.TRM_MID = '" + uMUID + "' AND TR_Status = '3' AND d.TRM_Apporval = '3' AND (d.TRM_InDate BETWEEN '" + mFrom + "' AND '" + mTo + "')) ORDER BY d.TRM_Index desc