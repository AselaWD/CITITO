CREATE PROC Dboard_WorkLoad_FreshTitles @mPIC nvarchar(30) 

AS 
/* Fresh titles */ 
SELECT pd.PCP_Project AS [PROJECT], pd.PCP_ID AS [JOB CODE], ph.PCP_Shipment AS [SHIPMENT/BATCH]
FROM tbl_PCPDetail pd
INNER JOIN tbl_PCPHeader ph ON pd.PC_ProcessCode=ph.PC_ProcessCode AND pd.PCP_ID=ph.PCP_ID
INNER JOIN tbl_ProcessCodeHeader pch ON pd.PC_ProcessCode=pch.PC_ProcessCode AND pd.PCP_Project=pch.PIC_Project
WHERE PCP_Status=0 AND pch.PIC_UID=@mPIC
GROUP BY pd.PCP_Project, pd.PCP_ID, ph.PCP_Shipment
GO

CREATE PROC Dboard_WorkLoad_FreshTitlesDetails @mPIC nvarchar(30), @mProject nvarchar(100), @mJobCode nvarchar(200), @mShipment nvarchar(1000)

AS 
/* Fresh title details */ 
SELECT pd.PCP_Project AS [PROJECT], pd.PCP_ID AS [JOB CODE], ph.PCP_Shipment AS [SHIPMENT], pd.PCP_File AS [FILE NAME], pd.PCP_FileSize AS [FILE SIZE], pd.PCP_Status AS [STATUS], pd.Task_UOM AS [UOM], pd.Task_Quota AS [QUOTA]/*, pd.PCP_StartDate AS [JOB CREATED DATE], pd.PCP_EndDate AS [JOB ENDED DATE] */, pd.PCP_CreatorUID [DCD UID], pd.PC_ProcessCode AS [ITEM CODE], pd.Task_ID AS [TASK CODE], td.Task_Description AS [DESCRIPTION]
FROM tbl_PCPDetail pd
INNER JOIN tbl_PCPHeader ph ON pd.PC_ProcessCode=ph.PC_ProcessCode AND pd.PCP_ID=ph.PCP_ID
INNER JOIN tbl_ProcessCodeHeader pch ON pd.PC_ProcessCode=pch.PC_ProcessCode AND pd.PCP_Project=pch.PIC_Project
INNER JOIN tbl_TaskDetail td ON pd.PC_ProcessCode=td.PC_ProcessCode AND pd.PCP_Project=td.PIC_Project AND td.Task_ID=pd.Task_ID
WHERE PCP_Status=0 AND pch.PIC_UID=@mPIC AND pd.PCP_Project=@mProject AND  pd.PCP_ID=@mJobCode AND ph.PCP_Shipment=@mShipment
GO

CREATE PROC Dboard_WorkLoad_FreshTitlesDataSet @mPIC nvarchar(30) 

AS 
/* Fresh titles Data Set*/
SELECT pd.PCP_Project AS [PROJECT], pd.PCP_ID AS [JOB CODE], ph.PCP_Shipment AS [SHIPMENT], pd.PCP_File AS [FILE NAME], pd.PCP_FileSize AS [FILE SIZE], pd.PCP_Status AS [STATUS], pd.Task_UOM AS [UOM], pd.Task_Quota AS [QUOTA]/*, pd.PCP_StartDate AS [JOB CREATED DATE], pd.PCP_EndDate AS [JOB ENDED DATE] */, pd.PCP_CreatorUID [DCD UID], pd.PC_ProcessCode AS [ITEM CODE], pd.Task_ID AS [TASK CODE], td.Task_Description AS [DESCRIPTION]
FROM tbl_PCPDetail pd
INNER JOIN tbl_PCPHeader ph ON pd.PC_ProcessCode=ph.PC_ProcessCode AND pd.PCP_ID=ph.PCP_ID
INNER JOIN tbl_ProcessCodeHeader pch ON pd.PC_ProcessCode=pch.PC_ProcessCode AND pd.PCP_Project=pch.PIC_Project
INNER JOIN tbl_TaskDetail td ON pd.PC_ProcessCode=td.PC_ProcessCode AND pd.PCP_Project=td.PIC_Project AND td.Task_ID=pd.Task_ID
WHERE PCP_Status=0 AND pch.PIC_UID=@mPIC
GO

