SELECT tskd.Task_Description, SUM(trd.TR_Productivity)
FROM tbl_TaskRecordDetail trd 
INNER JOIN tbl_TaskDetail tskd ON tskd.Task_ID=trd.Task_ID
WHERE trd.TR_InDate BETWEEN '12-01-2017 00:00:00' AND '12-31-2017 23:59:59' AND trd.TR_PIC='ZDQ' AND trd.TR_Apporval=2
GROUP BY tskd.Task_Description





SELECT s.PIC_Project AS [Project], s.PC_ProcessCode AS [Item/Process Code], s.Task_ID AS [Task Code],s.Task_Description AS [Description], s.Task_UOM AS [UOM], s.Task_Quota AS [Quota] 
FROM tbl_TaskDetail s 
INNER JOIN tbl_ProjectDetail p ON s.PIC_Project = p.ProjectName

SELECT *
FROM tbl_TaskRecordDetail
WHERE Task_ID='TNI_DA8'
