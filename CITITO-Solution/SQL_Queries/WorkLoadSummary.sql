
-- UPDATED WORKLOAD RESOURCE
SELECT pd.PCP_Project AS [PROJECT], pd.PCP_ID AS [JOB CODE], pd.PCP_File AS [FILE NAME], COUNT(pd.PCP_Status) AS [TASK COUNT], 
(SELECT COUNT(cd.PCP_Status) FROM tbl_PCPDetail cd WHERE cd.PCP_Status=0 AND  pd.PCP_File=cd.PCP_File AND  pd.PCP_ID=cd.PCP_ID) AS [FRESH COUNT],
(SELECT COUNT(cd.PCP_Status) FROM tbl_PCPDetail cd WHERE cd.PCP_Status=2 AND  pd.PCP_File=cd.PCP_File AND  pd.PCP_ID=cd.PCP_ID) AS [IN-PROCESS COUNT],
(SELECT COUNT(cd.PCP_Status) FROM tbl_PCPDetail cd WHERE cd.PCP_Status=3 AND  pd.PCP_File=cd.PCP_File AND  pd.PCP_ID=cd.PCP_ID) AS [DONE COUNT],
(SELECT COUNT(cd.PCP_Status) FROM tbl_PCPDetail cd WHERE cd.PCP_Status=1 AND  pd.PCP_File=cd.PCP_File AND  pd.PCP_ID=cd.PCP_ID) AS [HOLD COUNT]
FROM tbl_PCPDetail pd
INNER JOIN tbl_ProcessCodeHeader pch ON pd.PC_ProcessCode=pch.PC_ProcessCode AND pd.PCP_Project=pch.PIC_Project
WHERE pch.PIC_UID='ZDQ' /*AND pd.PCP_Project='APPEB' */
GROUP BY pd.PCP_Project, pd.PCP_ID, pd.PCP_File
--HAVING SUM(pd.PCP_Status) = COUNT(pd.PCP_Status)


-- UPDATED WORKLOAD SUMMARY
SELECT PROJECT, [JOB CODE], [FILE NAME],
CASE WHEN ([IN-PROCESS COUNT]>=1 AND [HOLD COUNT]=0) THEN ('In-Process') ELSE (CASE WHEN ([HOLD COUNT]>=1 AND [IN-PROCESS COUNT]=0) THEN ('Hold') ELSE (CASE WHEN ([TASK COUNT]=[DONE COUNT]) THEN ('Done') ELSE (CASE WHEN ([DONE COUNT] != 0 AND [TASK COUNT]=([DONE COUNT]+[FRESH COUNT])) THEN ('In-Process') ELSE (CASE WHEN ([TASK COUNT]=[FRESH COUNT]) THEN ('Fresh') END) END) END) END) END AS  [STATUS]
FROM(
	SELECT pd.PCP_Project AS [PROJECT], pd.PCP_ID AS [JOB CODE], pd.PCP_File AS [FILE NAME], COUNT(pd.PCP_Status) AS [TASK COUNT], 
	(SELECT COUNT(cd.PCP_Status) FROM tbl_PCPDetail cd WHERE cd.PCP_Status=0 AND  pd.PCP_File=cd.PCP_File AND  pd.PCP_ID=cd.PCP_ID) AS [FRESH COUNT],
	(SELECT COUNT(cd.PCP_Status) FROM tbl_PCPDetail cd WHERE cd.PCP_Status=2 AND  pd.PCP_File=cd.PCP_File AND  pd.PCP_ID=cd.PCP_ID) AS [IN-PROCESS COUNT],
	(SELECT COUNT(cd.PCP_Status) FROM tbl_PCPDetail cd WHERE cd.PCP_Status=3 AND  pd.PCP_File=cd.PCP_File AND  pd.PCP_ID=cd.PCP_ID) AS [DONE COUNT],
	(SELECT COUNT(cd.PCP_Status) FROM tbl_PCPDetail cd WHERE cd.PCP_Status=1 AND  pd.PCP_File=cd.PCP_File AND  pd.PCP_ID=cd.PCP_ID) AS [HOLD COUNT]
	FROM tbl_PCPDetail pd
	INNER JOIN tbl_ProcessCodeHeader pch ON pd.PC_ProcessCode=pch.PC_ProcessCode AND pd.PCP_Project=pch.PIC_Project
	WHERE pch.PIC_UID='ZDQ'
	GROUP BY pd.PCP_Project, pd.PCP_ID, pd.PCP_File
) WLResource


/* AND (SELECT COUNT(cd.PCP_Status) FROM tbl_PCPDetail cd WHERE cd.PCP_Status=2 AND  pd.PCP_File=cd.PCP_File)>=1*/
SELECT pd.PCP_Project AS [PROJECT]
, pd.PCP_ID AS [JOB CODE]
, ph.PCP_Shipment AS [SHIPMENT]
, pd.PCP_File AS [FILE NAME]
, pd.PCP_FileSize AS [SIZE]
, pd.Task_UOM AS [UOM]
, pd.Task_Quota AS [QUOTA]
, pd.PC_ProcessCode AS [ITEM CODE]
, pd.Task_ID AS [TASK CODE]
, td.Task_Description AS [DESCRIPTION]
, CASE WHEN (pd.PCP_Status=0) THEN ('Fresh') ELSE (CASE WHEN (pd.PCP_Status=1) THEN ('Hold') ELSE (CASE WHEN (pd.PCP_Status=2) THEN ('In-Process') ELSE (CASE WHEN (pd.PCP_Status=3) THEN ('Done') END) END) END) END AS  [STATUS]
, pd.PCP_StartDate AS [CREATED DATE]
, pd.PCP_EndDate AS [ENDED DATE]
, pd.PCP_CreatorUID AS [DCD UID]
FROM tbl_PCPDetail pd
INNER JOIN tbl_ProcessCodeHeader pch ON pd.PC_ProcessCode=pch.PC_ProcessCode AND pd.PCP_Project=pch.PIC_Project
INNER JOIN tbl_PCPHeader ph ON pd.PCP_ID=ph.PCP_ID
INNER JOIN tbl_TaskDetail td ON td.PIC_Project=pd.PCP_Project AND td.PC_ProcessCode=pd.PC_ProcessCode AND td.Task_ID=pd.Task_ID
WHERE pch.PIC_UID='ZDQ' AND pd.PCP_ID='00L0318EB312'

/*WORK LOAD GRAPH*/
SELECT   
  tblPivot.Property, tblPivot.Value 
FROM   
(	
	SELECT 
		SUM(CASE WHEN [STATUS]='In-Process' THEN 1 ELSE 0 END) AS  [IN-PROCESS],
		SUM(CASE WHEN [STATUS]='Fresh' THEN 1 ELSE 0 END) AS  [FRESH],
		SUM(CASE WHEN [STATUS]='Hold' THEN 1 ELSE 0 END) AS  [HOLD]
	FROM(
		SELECT PROJECT, [JOB CODE], [FILE NAME],
		CASE WHEN ([IN-PROCESS COUNT]>=1 AND [HOLD COUNT]=0) THEN ('In-Process') ELSE (CASE WHEN ([HOLD COUNT]>=1 AND [IN-PROCESS COUNT]=0) THEN ('Hold') ELSE (CASE WHEN ([TASK COUNT]=[DONE COUNT]) THEN ('Done') ELSE (CASE WHEN ([DONE COUNT] != 0 AND [TASK COUNT]=([DONE COUNT]+[FRESH COUNT])) THEN ('In-Process') ELSE (CASE WHEN ([TASK COUNT]=[FRESH COUNT]) THEN ('Fresh') END) END) END) END) END AS  [STATUS]
		FROM(
			SELECT pd.PCP_Project AS [PROJECT], pd.PCP_ID AS [JOB CODE], pd.PCP_File AS [FILE NAME], COUNT(pd.PCP_Status) AS [TASK COUNT], 
			(SELECT COUNT(cd.PCP_Status) FROM tbl_PCPDetail cd WHERE cd.PCP_Status=0 AND  pd.PCP_File=cd.PCP_File AND  pd.PCP_ID=cd.PCP_ID) AS [FRESH COUNT],
			(SELECT COUNT(cd.PCP_Status) FROM tbl_PCPDetail cd WHERE cd.PCP_Status=2 AND  pd.PCP_File=cd.PCP_File AND  pd.PCP_ID=cd.PCP_ID) AS [IN-PROCESS COUNT],
			(SELECT COUNT(cd.PCP_Status) FROM tbl_PCPDetail cd WHERE cd.PCP_Status=3 AND  pd.PCP_File=cd.PCP_File AND  pd.PCP_ID=cd.PCP_ID) AS [DONE COUNT],
			(SELECT COUNT(cd.PCP_Status) FROM tbl_PCPDetail cd WHERE cd.PCP_Status=1 AND  pd.PCP_File=cd.PCP_File AND  pd.PCP_ID=cd.PCP_ID) AS [HOLD COUNT]
			FROM tbl_PCPDetail pd
			INNER JOIN tbl_ProcessCodeHeader pch ON pd.PC_ProcessCode=pch.PC_ProcessCode AND pd.PCP_Project=pch.PIC_Project
			WHERE pch.PIC_UID='ZDQ'
			GROUP BY pd.PCP_Project, pd.PCP_ID, pd.PCP_File
		) WLResource
	) WorkLoadGraph
) Person
UNPIVOT (Value For Property In (/*[DONE], */[IN-PROCESS], [FRESH],[HOLD])) as tblPivot
ORDER BY tblPivot.Value DESC


/*WORKLOAD SUMMARY*/
SELECT [PROJECT] AS [PROJECT],
COUNT([STATUS]) AS [REGISTERED VOLUME],
SUM(CASE WHEN [STATUS]='Done' THEN 1 ELSE 0 END) AS  [COMPLETED VOLUME],
SUM(CASE WHEN [STATUS]='In-Process' THEN 1 ELSE 0 END) AS  [IN PROCESS],
SUM(CASE WHEN [STATUS]='Fresh' THEN 1 ELSE 0 END) AS  [FRESH],
SUM(CASE WHEN [STATUS]='Hold' THEN 1 ELSE 0 END) AS  [HOLD]
FROM (

	SELECT PROJECT, [JOB CODE], [FILE NAME],
	CASE WHEN ([IN-PROCESS COUNT]>=1 AND [HOLD COUNT]=0) THEN ('In-Process') ELSE (CASE WHEN ([HOLD COUNT]>=1 AND [IN-PROCESS COUNT]=0) THEN ('Hold') ELSE (CASE WHEN ([TASK COUNT]=[DONE COUNT]) THEN ('Done') ELSE (CASE WHEN ([DONE COUNT] != 0 AND [TASK COUNT]=([DONE COUNT]+[FRESH COUNT])) THEN ('In-Process') ELSE (CASE WHEN ([TASK COUNT]=[FRESH COUNT]) THEN ('Fresh') END) END) END) END) END AS  [STATUS]
	FROM(
		SELECT pd.PCP_Project AS [PROJECT], pd.PCP_ID AS [JOB CODE], pd.PCP_File AS [FILE NAME], COUNT(pd.PCP_Status) AS [TASK COUNT], 
		(SELECT COUNT(cd.PCP_Status) FROM tbl_PCPDetail cd WHERE cd.PCP_Status=0 AND  pd.PCP_File=cd.PCP_File AND  pd.PCP_ID=cd.PCP_ID) AS [FRESH COUNT],
		(SELECT COUNT(cd.PCP_Status) FROM tbl_PCPDetail cd WHERE cd.PCP_Status=2 AND  pd.PCP_File=cd.PCP_File AND  pd.PCP_ID=cd.PCP_ID) AS [IN-PROCESS COUNT],
		(SELECT COUNT(cd.PCP_Status) FROM tbl_PCPDetail cd WHERE cd.PCP_Status=3 AND  pd.PCP_File=cd.PCP_File AND  pd.PCP_ID=cd.PCP_ID) AS [DONE COUNT],
		(SELECT COUNT(cd.PCP_Status) FROM tbl_PCPDetail cd WHERE cd.PCP_Status=1 AND  pd.PCP_File=cd.PCP_File AND  pd.PCP_ID=cd.PCP_ID) AS [HOLD COUNT]
		FROM tbl_PCPDetail pd
		INNER JOIN tbl_ProcessCodeHeader pch ON pd.PC_ProcessCode=pch.PC_ProcessCode AND pd.PCP_Project=pch.PIC_Project
		WHERE pch.PIC_UID='LR3'
		GROUP BY pd.PCP_Project, pd.PCP_ID, pd.PCP_File
	) WLResource

)WLSummary
GROUP BY [PROJECT];

/*WORKLOAD SUMMARY BY PROJECT*/
SELECT [PROJECT] AS [PROJECT],
COUNT([STATUS]) AS [REGISTERED VOLUME],
SUM(CASE WHEN [STATUS]='Done' THEN 1 ELSE 0 END) AS  [COMPLETED VOLUME],
SUM(CASE WHEN [STATUS]='In-Process' THEN 1 ELSE 0 END) AS  [IN PROCESS],
SUM(CASE WHEN [STATUS]='Fresh' THEN 1 ELSE 0 END) AS  [FRESH],
SUM(CASE WHEN [STATUS]='Hold' THEN 1 ELSE 0 END) AS  [HOLD]
FROM (

	SELECT PROJECT, [JOB CODE], [FILE NAME],
	CASE WHEN ([IN-PROCESS COUNT]>=1 AND [HOLD COUNT]=0) THEN ('In-Process') ELSE (CASE WHEN ([HOLD COUNT]>=1 AND [IN-PROCESS COUNT]=0) THEN ('Hold') ELSE (CASE WHEN ([TASK COUNT]=[DONE COUNT]) THEN ('Done') ELSE (CASE WHEN ([DONE COUNT] != 0 AND [TASK COUNT]=([DONE COUNT]+[FRESH COUNT])) THEN ('In-Process') ELSE (CASE WHEN ([TASK COUNT]=[FRESH COUNT]) THEN ('Fresh') END) END) END) END) END AS  [STATUS]
	FROM(
		SELECT pd.PCP_Project AS [PROJECT], pd.PCP_ID AS [JOB CODE], pd.PCP_File AS [FILE NAME], COUNT(pd.PCP_Status) AS [TASK COUNT], 
		(SELECT COUNT(cd.PCP_Status) FROM tbl_PCPDetail cd WHERE cd.PCP_Status=0 AND  pd.PCP_File=cd.PCP_File AND  pd.PCP_ID=cd.PCP_ID) AS [FRESH COUNT],
		(SELECT COUNT(cd.PCP_Status) FROM tbl_PCPDetail cd WHERE cd.PCP_Status=2 AND  pd.PCP_File=cd.PCP_File AND  pd.PCP_ID=cd.PCP_ID) AS [IN-PROCESS COUNT],
		(SELECT COUNT(cd.PCP_Status) FROM tbl_PCPDetail cd WHERE cd.PCP_Status=3 AND  pd.PCP_File=cd.PCP_File AND  pd.PCP_ID=cd.PCP_ID) AS [DONE COUNT],
		(SELECT COUNT(cd.PCP_Status) FROM tbl_PCPDetail cd WHERE cd.PCP_Status=1 AND  pd.PCP_File=cd.PCP_File AND  pd.PCP_ID=cd.PCP_ID) AS [HOLD COUNT]
		FROM tbl_PCPDetail pd
		INNER JOIN tbl_ProcessCodeHeader pch ON pd.PC_ProcessCode=pch.PC_ProcessCode AND pd.PCP_Project=pch.PIC_Project
		WHERE pch.PIC_UID='ZDQ' AND pch.PIC_Project='APPEB'
		GROUP BY pd.PCP_Project, pd.PCP_ID, pd.PCP_File
	) WLResource

)WLSummary
GROUP BY [PROJECT];

/*WORKLOAD DATASET*/
SELECT PROJECT, [JOB CODE], [SHIPMENT], [FILE NAME], [TASK COUNT], [FRESH COUNT], [IN-PROCESS COUNT], [DONE COUNT], [HOLD COUNT],
	CASE WHEN ([IN-PROCESS COUNT]>=1 AND [HOLD COUNT]=0) THEN ('In-Process') ELSE (CASE WHEN ([HOLD COUNT]>=1 AND [IN-PROCESS COUNT]=0) THEN ('Hold') ELSE (CASE WHEN ([TASK COUNT]=[DONE COUNT]) THEN ('Done') ELSE (CASE WHEN ([DONE COUNT] != 0 AND [TASK COUNT]=([DONE COUNT]+[FRESH COUNT])) THEN ('In-Process') ELSE (CASE WHEN ([TASK COUNT]=[FRESH COUNT]) THEN ('Fresh') END) END) END) END) END AS  [STATUS]
	FROM(
		SELECT pd.PCP_Project AS [PROJECT], pd.PCP_ID AS [JOB CODE], ph.PCP_Shipment AS [SHIPMENT], pd.PCP_File AS [FILE NAME], COUNT(pd.PCP_Status) AS [TASK COUNT], 
		(SELECT COUNT(cd.PCP_Status) FROM tbl_PCPDetail cd WHERE cd.PCP_Status=0 AND  pd.PCP_File=cd.PCP_File AND  pd.PCP_ID=cd.PCP_ID) AS [FRESH COUNT],
		(SELECT COUNT(cd.PCP_Status) FROM tbl_PCPDetail cd WHERE cd.PCP_Status=2 AND  pd.PCP_File=cd.PCP_File AND  pd.PCP_ID=cd.PCP_ID) AS [IN-PROCESS COUNT],
		(SELECT COUNT(cd.PCP_Status) FROM tbl_PCPDetail cd WHERE cd.PCP_Status=3 AND  pd.PCP_File=cd.PCP_File AND  pd.PCP_ID=cd.PCP_ID) AS [DONE COUNT],
		(SELECT COUNT(cd.PCP_Status) FROM tbl_PCPDetail cd WHERE cd.PCP_Status=1 AND  pd.PCP_File=cd.PCP_File AND  pd.PCP_ID=cd.PCP_ID) AS [HOLD COUNT]
		FROM tbl_PCPDetail pd
		INNER JOIN tbl_ProcessCodeHeader pch ON pd.PC_ProcessCode=pch.PC_ProcessCode AND pd.PCP_Project=pch.PIC_Project
		INNER JOIN tbl_PCPHeader ph ON pd.PCP_ID=ph.PCP_ID
		WHERE pch.PIC_UID='ZDQ'
		GROUP BY pd.PCP_Project, pd.PCP_ID, ph.PCP_Shipment, pd.PCP_File
	)WLResource

/*WORKLOAD DATASET*/
SELECT * 
FROM (
SELECT [CREATED DATE], PROJECT, [JOB CODE], [SHIPMENT], [FILE NAME], [TASK COUNT], [FRESH COUNT] AS [FRESH TASKS], [IN-PROCESS COUNT] AS [IN-PROCESS TASKS], [DONE COUNT] AS [DONE TASKS], [HOLD COUNT] AS [HOLD TASKS],
	CASE WHEN ([IN-PROCESS COUNT]>=1 AND [HOLD COUNT]=0) THEN ('In-Process') ELSE (CASE WHEN ([HOLD COUNT]>=1 AND [IN-PROCESS COUNT]=0) THEN ('Hold') ELSE (CASE WHEN ([TASK COUNT]=[DONE COUNT]) THEN ('Done') ELSE (CASE WHEN ([DONE COUNT] != 0 AND [TASK COUNT]=([DONE COUNT]+[FRESH COUNT])) THEN ('In-Process') ELSE (CASE WHEN ([TASK COUNT]=[FRESH COUNT]) THEN ('Fresh') END) END) END) END) END AS  [STATUS]
	FROM(
		SELECT MIN(CONVERT(Date, pd.PCP_StartDate)) AS [CREATED DATE],pd.PCP_Project AS [PROJECT], pd.PCP_ID AS [JOB CODE], ph.PCP_Shipment AS [SHIPMENT], pd.PCP_File AS [FILE NAME], COUNT(pd.PCP_Status) AS [TASK COUNT], 
		(SELECT COUNT(cd.PCP_Status) FROM tbl_PCPDetail cd WHERE cd.PCP_Status=0 AND  pd.PCP_File=cd.PCP_File AND  pd.PCP_ID=cd.PCP_ID) AS [FRESH COUNT],
		(SELECT COUNT(cd.PCP_Status) FROM tbl_PCPDetail cd WHERE cd.PCP_Status=2 AND  pd.PCP_File=cd.PCP_File AND  pd.PCP_ID=cd.PCP_ID) AS [IN-PROCESS COUNT],
		(SELECT COUNT(cd.PCP_Status) FROM tbl_PCPDetail cd WHERE cd.PCP_Status=3 AND  pd.PCP_File=cd.PCP_File AND  pd.PCP_ID=cd.PCP_ID) AS [DONE COUNT],
		(SELECT COUNT(cd.PCP_Status) FROM tbl_PCPDetail cd WHERE cd.PCP_Status=1 AND  pd.PCP_File=cd.PCP_File AND  pd.PCP_ID=cd.PCP_ID) AS [HOLD COUNT]
		FROM tbl_PCPDetail pd
		INNER JOIN tbl_ProcessCodeHeader pch ON pd.PC_ProcessCode=pch.PC_ProcessCode AND pd.PCP_Project=pch.PIC_Project
		INNER JOIN tbl_PCPHeader ph ON pd.PCP_ID=ph.PCP_ID
		WHERE pch.PIC_UID='ZDQ' AND pd.PCP_Project='APPEB'
		GROUP BY pd.PCP_Project, pd.PCP_ID, ph.PCP_Shipment, pd.PCP_File
	)WLResource
)WLDataSet
WHERE [STATUS]='Done'
ORDER BY [CREATED DATE] DESC


/*WORKLOAD DATASET PIC AND PCP CODE*/

SELECT pd.PCP_Project AS [PROJECT]
, pd.PCP_ID AS [JOB CODE]
, ph.PCP_Shipment AS [SHIPMENT]
, pd.PCP_File AS [FILE NAME]
, pd.PCP_FileSize AS [SIZE]
, pd.Task_UOM AS [UOM]
, pd.Task_Quota AS [QUOTA]
, pd.PC_ProcessCode AS [ITEM CODE]
, pd.Task_ID AS [TASK CODE]
, td.Task_Description AS [DESCRIPTION]
, CASE WHEN (pd.PCP_Status=0) THEN ('Fresh') ELSE (CASE WHEN (pd.PCP_Status=1) THEN ('Hold') ELSE (CASE WHEN (pd.PCP_Status=2) THEN ('In-Process') ELSE (CASE WHEN (pd.PCP_Status=3) THEN ('Done') END) END) END) END AS  [STATUS]
, pd.PCP_StartDate AS [CREATED DATE]
, pd.PCP_EndDate AS [ENDED DATE]
, trd.TR_UID AS [USER ID]
FROM tbl_PCPDetail pd
INNER JOIN tbl_ProcessCodeHeader pch ON pd.PC_ProcessCode=pch.PC_ProcessCode AND pd.PCP_Project=pch.PIC_Project
INNER JOIN tbl_PCPHeader ph ON pd.PCP_ID=ph.PCP_ID
INNER JOIN tbl_TaskDetail td ON td.PIC_Project=pd.PCP_Project AND td.PC_ProcessCode=pd.PC_ProcessCode AND td.Task_ID=pd.Task_ID
LEFT OUTER JOIN tbl_TaskRecordDetail trd ON trd.PCP_ID=pd.PCP_ID AND trd.Task_ID=pd.Task_ID 
WHERE pch.PIC_UID='ZDQ' AND pd.PCP_ID='TNI0518DA1282'
GROUP BY 
pd.PCP_Project
, pd.PCP_ID
, ph.PCP_Shipment
, pd.PCP_File
, pd.PCP_FileSize
, pd.Task_UOM
, pd.Task_Quota
, pd.PC_ProcessCode
, pd.Task_ID
, td.Task_Description
, pd.PCP_Status
, pd.PCP_StartDate
, pd.PCP_EndDate
, trd.TR_UID

