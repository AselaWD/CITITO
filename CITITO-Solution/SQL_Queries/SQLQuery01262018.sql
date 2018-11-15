SELECT TR_UID AS [UID], TR_InDate [Task In],TR_Productivity AS [Productivity] 
FROM tbl_TaskRecordDetail 
INNER JOIN [NTLILO].[dbo].[LILO] LILO ON 
WHERE TR_Apporval = 2 AND TR_Productivity> 150 AND TR_PIC = 'ZDQ' AND 
TR_InDate BETWEEN '01-01-2018 00:00:00' AND '11-01-2018 23:59:59' ORDER BY TR_UID desc



-----/--------
--DECLARE @TempProductivity TABLE
--(
--   Task nvarchar(100),
--   Productivity float
--);
--DECLARE @TotalAge int;

--INSERT INTO @TempProductivity 
--SELECT TaskDetail.Task_Description,SUM(d.TR_Productivity)
--FROM tbl_TaskRecordDetail d 
--INNER JOIN tbl_PCPDetail PCPDetail ON PCPDetail.PCP_ID = d.PCP_ID AND d.Task_ID = PCPDetail.Task_ID 
--INNER JOIN tbl_TaskDetail TaskDetail ON TaskDetail.Task_ID = PCPDetail.Task_ID AND TaskDetail.PC_ProcessCode = PCPDetail.PC_ProcessCode 
--WHERE d.TR_PIC = 'ZDQ' AND TR_Status = '3' AND d.TR_Apporval = '2' AND d.TR_InDate BETWEEN '01-01-2018 00:00:00' AND '11-01-2018 23:59:59' GROUP BY TaskDetail.Task_Description

--set @TotalAge=(select sum(Productivity) from @TempProductivity)

--SELECT Task,ROUND(((Productivity/@TotalAge)*100),2) AS Productivity
--FROM @TempProductivity
--ORDER BY Productivity DESC

--DECLARE @TempProjectProductivity_@mPIC  TABLE 
--( Project nvarchar(100), Productivity float ); 

--DECLARE @TotalProductivity int; 

--INSERT INTO @TempProjectProductivity_@mPIC 
--SELECT PCPDetail.PCP_Project, SUM(d.TR_Productivity) 
--FROM tbl_TaskRecordDetail d 
--INNER JOIN tbl_PCPDetail PCPDetail ON PCPDetail.PCP_ID = d.PCP_ID AND d.Task_ID = PCPDetail.Task_ID 
--INNER JOIN tbl_TaskDetail TaskDetail ON TaskDetail.Task_ID = PCPDetail.Task_ID AND TaskDetail.PC_ProcessCode = PCPDetail.PC_ProcessCode 
--WHERE d.TR_PIC = 'ZDQ' AND TR_Status = '3' AND d.TR_Apporval = '2' AND d.TR_InDate BETWEEN '01-01-2018 00:00:00' AND '11-01-2018 23:59:59'
--GROUP BY PCPDetail.PCP_Project 

--set @TotalProductivity = (select sum(Productivity) from @TempProjectProductivity_@mPIC) 

--SELECT Project,ROUND(((Productivity/@TotalProductivity)*100),2) AS Productivity FROM @TempProjectProductivity_@mPIC 
--ORDER BY Productivity DESC

--DECLARE @TempTeamProductivity_@mPIC  TABLE (Project nvarchar(100), Productivity float); 
--DECLARE @TeamProductivity int; 
--INSERT INTO @TempTeamProductivity_@mPIC 
--SELECT d.TR_MID, SUM(d.TR_Productivity) 
--FROM tbl_TaskRecordDetail d 
--INNER JOIN tbl_PCPDetail PCPDetail ON PCPDetail.PCP_ID = d.PCP_ID AND d.Task_ID = PCPDetail.Task_ID 
--INNER JOIN tbl_TaskDetail TaskDetail ON TaskDetail.Task_ID = PCPDetail.Task_ID AND TaskDetail.PC_ProcessCode = PCPDetail.PC_ProcessCode 
--WHERE d.TR_PIC = 'ZDQ' AND TR_Status = '3' AND d.TR_Apporval = '2' AND d.TR_InDate BETWEEN '01-01-2018 00:00:00' AND '11-01-2018 23:59:59'
--GROUP BY d.TR_MID
--set @TeamProductivity = (select sum(Productivity) from @TempTeamProductivity_@mPIC) 
--SELECT Project, ROUND(((Productivity / @TeamProductivity) * 100), 2) AS Productivity 
--FROM @TempTeamProductivity_@mPIC 
--ORDER BY Productivity DESC





