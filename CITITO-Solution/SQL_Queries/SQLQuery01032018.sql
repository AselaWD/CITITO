--SELECT d.PCPD_Index AS [#], h.PCP_ID AS[Job Code], h.PCP_Shipment AS [Shipment], h.PC_ProcessCode AS [Process Code], d.Task_ID AS [Task Code], d.PCP_File AS [File Name], d.PCP_FileSize AS [File Size], d.PCP_Status AS [Job Status], d.PCP_StartDate As [Created Date/Time], d.PCP_EndDate AS [Done Date/Time], d.PCP_CreatorUID AS [DCD User] 
--FROM tbl_PCPHeader h 
--INNER JOIN tbl_PCPDetail d ON h.PCP_ID = d.PCP_ID
--INNER JOIN tbl_UserManagementDetail u ON u.P_Project=d.PCP_Project AND u.P_UID = 'JZ7'
--ORDER BY d.PCPD_Index

SELECT d.PCPD_Index AS [#], h.PCP_ID AS[Job Code], h.PCP_Shipment AS [Shipment], h.PC_ProcessCode AS [Process Code], d.Task_ID AS [Task Code], d.PCP_File AS [File Name], d.PCP_FileSize AS [File Size], d.PCP_Status AS [Job Status], d.PCP_StartDate As [Created Date/Time], d.PCP_EndDate AS [Done Date/Time], d.PCP_CreatorUID AS [DCD User]
FROM tbl_PCPHeader h 
INNER JOIN tbl_PCPDetail d ON h.PCP_ID = d.PCP_ID
INNER JOIN tbl_UserManagementDetail u ON u.P_Project=d.PCP_Project AND u.P_UID = 'JZ7'
WHERE h.PCP_ID LIKE '" + mJobCode + "%' OR h.PCP_ID LIKE '%8' 
ORDER BY d.PCPD_Index

SELECT d.PCPD_Index AS [#], h.PCP_ID AS[Job Code], h.PCP_Shipment AS [Shipment], h.PC_ProcessCode AS [Process Code], d.Task_ID AS [Task Code], d.PCP_File AS [File Name], d.PCP_FileSize AS [File Size], d.PCP_Status AS [Job Status], d.PCP_StartDate As [Created Date/Time], d.PCP_EndDate AS [Done Date/Time], d.PCP_CreatorUID AS [DCD User]
FROM tbl_PCPHeader h 
INNER JOIN tbl_PCPDetail d ON h.PCP_ID = d.PCP_ID 
INNER JOIN tbl_UserManagementDetail u ON u.P_Project=d.PCP_Project AND u.P_UID = 'JZ7'
WHERE h.PCP_Shipment LIKE '" + mShipment + "%' OR h.PCP_Shipment LIKE '%" + mShipment + "' 
ORDER BY d.PCPD_Index

SELECT d.PCPD_Index AS [#], h.PCP_ID AS[Job Code], h.PCP_Shipment AS [Shipment], h.PC_ProcessCode AS [Process Code], d.Task_ID AS [Task Code], d.PCP_File AS [File Name], d.PCP_FileSize AS [File Size], d.PCP_Status AS [Job Status], d.PCP_StartDate As [Created Date/Time], d.PCP_EndDate AS [Done Date/Time], d.PCP_CreatorUID AS [DCD User]
FROM tbl_PCPHeader h 
INNER JOIN tbl_PCPDetail d ON h.PCP_ID = d.PCP_ID 
INNER JOIN tbl_UserManagementDetail u ON u.P_Project=d.PCP_Project AND u.P_UID = 'JZ7'
WHERE h.PC_ProcessCode LIKE '" + mProcessCode + "%' OR h.PC_ProcessCode LIKE '%" + mProcessCode + "' 
ORDER BY d.PCPD_Index

SELECT d.PCPD_Index AS [#], h.PCP_ID AS[Job Code], h.PCP_Shipment AS [Shipment], h.PC_ProcessCode AS [Process Code], d.Task_ID AS [Task Code], d.PCP_File AS [File Name], d.PCP_FileSize AS [File Size], d.PCP_Status AS [Job Status], d.PCP_StartDate As [Created Date/Time], d.PCP_EndDate AS [Done Date/Time], d.PCP_CreatorUID AS [DCD User]
FROM tbl_PCPHeader h INNER JOIN tbl_PCPDetail d ON h.PCP_ID = d.PCP_ID 
INNER JOIN tbl_UserManagementDetail u ON u.P_Project=d.PCP_Project AND u.P_UID = 'JZ7'
WHERE d.Task_ID LIKE '" + mTaskCode + "%' OR d.Task_ID LIKE '%" + mTaskCode + "' 
ORDER BY d.PCPD_Index


SELECT d.PCPD_Index AS [#], h.PCP_ID AS[Job Code], h.PCP_Shipment AS [Shipment], h.PC_ProcessCode AS [Process Code], d.Task_ID AS [Task Code], d.PCP_File AS [File Name], d.PCP_FileSize AS [File Size], d.PCP_Status AS [Job Status], d.PCP_StartDate As [Created Date/Time], d.PCP_EndDate AS [Done Date/Time], d.PCP_CreatorUID AS [DCD User]
FROM tbl_PCPHeader h INNER JOIN tbl_PCPDetail d ON h.PCP_ID = d.PCP_ID 
INNER JOIN tbl_UserManagementDetail u ON u.P_Project=d.PCP_Project AND u.P_UID = 'JZ7'
WHERE d.PCP_File LIKE '" + mFileName + "%' OR d.PCP_File LIKE '%" + mFileName + "' 
ORDER BY d.PCPD_Index

SELECT d.PCP_CreatorUID 
FROM tbl_PCPHeader h 
INNER JOIN tbl_PCPDetail d ON h.PCP_ID = d.PCP_ID 
INNER JOIN tbl_UserManagementDetail u ON u.P_Project = d.PCP_Project AND u.P_UID = 'JZ7' 
GROUP BY d.PCP_CreatorUID 
ORDER BY d.PCP_CreatorUID 