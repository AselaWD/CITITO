DECLARE @TempUserProductivity_@mPIC 
TABLE (UserID nvarchar(100), Productivity float); DECLARE @UserProductivity int; 
--INSERT INTO @TempUserProductivity_@mPIC SELECT d.TR_UID, SUM(d.TR_Productivity) 
--FROM tbl_TaskRecordDetail d 
--INNER JOIN tbl_PCPDetail PCPDetail ON PCPDetail.PCP_ID = d.PCP_ID AND d.Task_ID = PCPDetail.Task_ID 
--INNER JOIN tbl_TaskDetail TaskDetail ON TaskDetail.Task_ID = PCPDetail.Task_ID AND TaskDetail.PC_ProcessCode = PCPDetail.PC_ProcessCode 
--WHERE d.TR_Status = '3' AND d.TR_Apporval = '2' AND d.TR_PIC = '"+ mPIC +"' AND d.TR_InDate BETWEEN '"+ mFrom +"' AND '"+ mTo +"'
--GROUP BY d.TR_UID

--set @UserProductivity = (select sum(Productivity) 
--from @TempUserProductivity_@mPIC) 

--SELECT UserID, ROUND(((Productivity / @UserProductivity) * 100), 2) AS Productivity 
--FROM @TempUserProductivity_@mPIC 
--ORDER BY Productivity DESC

SELECT td.TR_UID FROM tbl_PCPDetail pd 
INNER JOIN tbl_TaskRecordHeader th ON pd.PCP_ID = th.PCP_ID 
INNER JOIN tbl_TaskRecordDetail td ON td.TR_ID = th.TR_ID 
WHERE pd.PCP_ID = 'WKB0118ET119' AND td.Task_ID='WKB_ET2' AND pd.PCP_Status = '2' AND td.TR_TaskStatus = '1'

SELECT td.TR_TaskStatus FROM tbl_PCPDetail pd 
INNER JOIN tbl_TaskRecordHeader th ON pd.PCP_ID = th.PCP_ID 
INNER JOIN tbl_TaskRecordDetail td ON td.TR_ID = th.TR_ID 
WHERE pd.PCP_ID = '"+ mPCPCode + "' AND td.TR_UID='" + mUID + "' AND pd.PCP_Status = '2' AND td.TR_TaskStatus='1'


SELECT p.Task_ID, t.Task_Description, td.Task_ID
FROM tbl_PCPDetail p 
INNER JOIN tbl_TaskDetail t ON p.Task_ID = t.Task_ID AND p.PC_ProcessCode = t.PC_ProcessCode 
INNER JOIN tbl_TaskRecordDetail td ON td.PCP_ID = p.PCP_ID 
WHERE p.PCP_ID = 'WKB0118ET119' AND p.PCP_Status = '2' AND td.TR_UID='VY9'