/****** Script for SelectTopNRows command from SSMS  ******/
SELECT *
FROM tbl_TaskRecordDetail
WHERE TR_File='9780829762815'

SELECT p.Task_ID, t.Task_Description 
FROM tbl_PCPDetail p INNER JOIN tbl_TaskDetail t 
ON p.Task_ID = t.Task_ID AND p.PC_ProcessCode = t.PC_ProcessCode 
WHERE p.PCP_ID = 'TNI1217DA100' AND p.PCP_Status = '2'


