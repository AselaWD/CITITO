--SELECT d.IDLE_ID AS [#], h.IDLE_Project AS [Project], d.IDLE_Reason AS [Reason], d.IDLE_InDate AS [Task In Time], d.IDLE_OutDate AS [Task out Time], d.IDLE_Hours  AS [IDLE Hours], d.IDLE_Apporval AS [Approval Status], d.IDLE_ApprovalTime AS [Approval Time] 
--FROM tbl_IDLEDetail d 
--INNER JOIN tbl_IDLEHeader h ON d.IDLE_ID = h.IDLE_ID
--WHERE d.IDLE_MID = '" + mMUID + "' AND IDLE_Apporval=1
--ORDER BY d.IDLE_ID DESC

SELECT *
FROM tbl_TaskRecordDetail
WHERE TR_Status= 2 AND TR_Apporval=4

UPDATE tbl_TaskRecordDetail
SET TR_Apporval=4, TR_ApprovalTime=NULL
WHERE TR_Status= 2