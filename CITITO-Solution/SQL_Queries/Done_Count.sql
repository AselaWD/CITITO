--/* Done titles */ 
--SELECT COUNT(#) AS [Done Count]
--FROM(
--SELECT ROW_NUMBER() OVER(ORDER BY pd.PCP_ID ASC) AS [#], pdtl.ProjectName AS [PROJECT], pd.PCP_ID AS [JOB CODE], ph.PCP_Shipment AS [SHIPMENT/BATCH], pd.PCP_File AS [FILENAME]
--FROM tbl_PCPDetail pd
--INNER JOIN tbl_PCPHeader ph ON pd.PC_ProcessCode=ph.PC_ProcessCode AND pd.PCP_ID=ph.PCP_ID
--INNER JOIN tbl_ProjectDetail pdtl ON pdtl.ProjectName=pd.PCP_Project
--INNER JOIN tbl_ProcessCodeHeader pch ON pd.PC_ProcessCode=pch.PC_ProcessCode AND pdtl.ProjectName=pch.PIC_Project
--WHERE pd.PCP_Status=3 AND pdtl.PIC_UID='ZDQ'
--GROUP BY pdtl.ProjectName, pd.PCP_ID, ph.PCP_Shipment, pd.PCP_File
--) DoneCount;





	SELECT [Done].*, [Pending].* FROM [Done],[Pending]
		 

		SELECT COUNT ([Done]) FROM (SELECT ROW_NUMBER() OVER(ORDER BY pd.PCP_ID ASC) AS [Done], pdtl.ProjectName AS [PROJECT], pd.PCP_ID AS [JOB CODE], ph.PCP_Shipment AS [SHIPMENT/BATCH], pd.PCP_File AS [FILENAME]
			FROM tbl_PCPDetail pd
			INNER JOIN tbl_PCPHeader ph ON pd.PC_ProcessCode=ph.PC_ProcessCode AND pd.PCP_ID=ph.PCP_ID
			INNER JOIN tbl_ProjectDetail pdtl ON pdtl.ProjectName=pd.PCP_Project
			INNER JOIN tbl_ProcessCodeHeader pch ON pd.PC_ProcessCode=pch.PC_ProcessCode AND pdtl.ProjectName=pch.PIC_Project
			WHERE pd.PCP_Status=3 AND pdtl.PIC_UID='ZDQ'
			GROUP BY pdtl.ProjectName, pd.PCP_ID, ph.PCP_Shipment, pd.PCP_File
			)AS [Done];
		
	



			SELECT COUNT([Pending]) FROM (SELECT ROW_NUMBER() OVER(ORDER BY pd.PCP_ID ASC) AS [Pending], pdtl.ProjectName AS [PROJECT], pd.PCP_ID AS [JOB CODE], ph.PCP_Shipment AS [SHIPMENT/BATCH], pd.PCP_File AS [FILENAME]
			FROM tbl_PCPDetail pd
			INNER JOIN tbl_PCPHeader ph ON pd.PC_ProcessCode=ph.PC_ProcessCode AND pd.PCP_ID=ph.PCP_ID
			INNER JOIN tbl_ProjectDetail pdtl ON pdtl.ProjectName=pd.PCP_Project
			INNER JOIN tbl_ProcessCodeHeader pch ON pd.PC_ProcessCode=pch.PC_ProcessCode AND pdtl.ProjectName=pch.PIC_Project
			WHERE pd.PCP_Status=2 AND pdtl.PIC_UID='ZDQ'
			GROUP BY pdtl.ProjectName, pd.PCP_ID, ph.PCP_Shipment, pd.PCP_File
			)AS [Pending];


	 
