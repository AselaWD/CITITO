/****** Script for SelectTopNRows command from SSMS  ******/
--SELECT TD.PIC_Project
--	  ,PD.[PCPD_Index]
--      ,PD.[PCP_ID]
--      ,PD.[PCP_File]
--      ,PD.[PCP_FileSize]
--      ,PD.[PCP_Status]
--      ,PD.[PCP_Project]
--      ,PD.[Task_UOM]
--      ,PD.[Task_Quota]
--      ,PD.[PCP_StartDate]
--      ,PD.[PCP_EndDate]
--      ,PD.[PCP_CreatorUID]
--      ,PD.[PC_ProcessCode]
--      ,PD.[Task_ID]
--  FROM [CITITO].[dbo].[tbl_PCPDetail] PD
--  INNER JOIN [tbl_PCPHeader] PH ON PH.PCP_ID=PD.PCP_ID
--  INNER JOIN [tbl_TaskDetail] TD ON TD.PC_ProcessCode=PD.PC_ProcessCode AND TD.Task_ID=PD.Task_ID


--SELECT PD.[PCP_Project]
--      ,(PD.[PCP_Status])AS [PENDING]
--  FROM [CITITO].[dbo].[tbl_PCPDetail] PD
--  INNER JOIN [tbl_PCPHeader] PH ON PH.PCP_ID=PD.PCP_ID
--  --INNER JOIN [tbl_TaskDetail] TD ON TD.PC_ProcessCode=PD.PC_ProcessCode AND TD.Task_ID=PD.Task_ID
--  WHERE PD.PCP_StartDate BETWEEN '2018-04-01' AND '2018-04-30' AND PD.[PCP_Status]=2
--  GROUP BY PD.[PCP_Project]

  /* 0-Fresh, 1-Hold, 2-Pending, 3-Done */
SELECT [PROJECT], ISNULL(SUM([REGISTERED VOLUME]),0) AS [REGISTERED VOLUME], ISNULL(MAX(DONE),0) AS [COMPLETED], ISNULL(MAX(PENDING),0) AS [IN-PROCESS], ISNULL(MAX(FRESH),0) AS [FRESH], ISNULL(MAX(HOLD),0) AS [HOLD],  ISNULL(SUM([ACTIVE STATUS]),0) AS  [ACTIVE STATUS]
FROM(
  SELECT TOP 999999999999999 PD.[PCP_Project] AS [PROJECT], COUNT(PD.[PCP_Status]) AS [REGISTERED VOLUME],
  case PD.[PCP_Status] when 2  then SUM(CASE PD.[PCP_Status] when 2 Then 1 END) end AS [PENDING],
  case PD.[PCP_Status] when 3  then SUM(CASE PD.[PCP_Status] when 3 Then 1 END) end AS [DONE],
  case PD.[PCP_Status] when 0  then SUM(CASE PD.[PCP_Status] when 0 Then 1 END) end AS [FRESH],
  case PD.[PCP_Status] when 1  then SUM(CASE PD.[PCP_Status] when 1 Then 1 END) end AS [HOLD],
  case TD.TR_TaskStatus when 1  then SUM(CASE TD.TR_TaskStatus when 1 Then 1 END) end AS [ACTIVE STATUS]
  FROM [CITITO].[dbo].[tbl_PCPDetail] PD
  --INNER JOIN [tbl_PCPHeader] PH ON PH.PCP_ID=PD.PCP_ID
	INNER JOIN [tbl_TaskRecordDetail] TD ON TD.PCP_ID=PD.PCP_ID AND TD.Task_ID=PD.Task_ID
  WHERE TD.TR_ActualTaskIn BETWEEN '2018-04-01' AND '2018-04-30'
GROUP BY PD.[PCP_Project], [PCP_Status],TD.TR_TaskStatus
ORDER BY PD.[PCP_Project]
) A
LEFT OUTER JOIN tbl_ProjectDetail PrD ON PrD.ProjectName=A.[PROJECT]
WHERE PrD.PIC_UID='EC4' 
GROUP BY [PROJECT]
ORDER BY [PROJECT]

--SELECT *
--FROM tbl_PCPDetail
--WHERE PCP_StartDate BETWEEN '2018-02-01' AND '2018-04-30' AND PCP_Project='TNIDA' AND PCP_Status=0
