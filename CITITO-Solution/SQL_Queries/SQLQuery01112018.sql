----SELECT d.PCPD_Index AS [#], h.PCP_ID AS[Job Code], h.PCP_Shipment AS [Shipment], h.PC_ProcessCode AS [Process Code], d.Task_ID AS [Task Code], d.PCP_File AS [File Name], d.PCP_FileSize AS [File Size], d.PCP_Status AS [Job Status], d.PCP_StartDate As [Created Date/Time], d.PCP_EndDate AS [Done Date/Time], d.PCP_CreatorUID AS [DCD User] 
----FROM tbl_PCPHeader h INNER JOIN tbl_PCPDetail d ON h.PCP_ID = d.PCP_ID 
----INNER JOIN tbl_ManagerDetail u ON u.M_Project = d.PCP_Project AND u.M_UID = '9CR' ORDER BY d.PCPD_Index

----SELECT d.PCP_CreatorUID FROM tbl_PCPHeader h 
----INNER JOIN tbl_PCPDetail d ON h.PCP_ID = d.PCP_ID 
----INNER JOIN tbl_ManagerDetail u ON u.M_Project = d.PCP_Project AND u.M_UID = '9CR' GROUP BY d.PCP_CreatorUID ORDER BY d.PCP_CreatorUID

----SELECT d.PCPD_Index AS [#], h.PCP_ID AS[Job Code], h.PCP_Shipment AS [Shipment], h.PC_ProcessCode AS [Process Code], d.Task_ID AS [Task Code], d.PCP_File AS [File Name], d.PCP_FileSize AS [File Size], d.PCP_Status AS [Job Status], d.PCP_StartDate As [Created Date/Time], d.PCP_EndDate AS [Done Date/Time], d.PCP_CreatorUID AS [DCD User] 
----FROM tbl_PCPHeader h 
----INNER JOIN tbl_PCPDetail d ON h.PCP_ID = d.PCP_ID 
----INNER JOIN tbl_ManagerDetail u ON u.M_Project = d.PCP_Project AND u.M_UID = '9CR' 
----WHERE h.PCP_ID LIKE '" + mJobCode + "%' OR h.PCP_ID LIKE '%" + mJobCode + "' ORDER BY d.PCPD_Index


----SELECT d.PCPD_Index AS [#], h.PCP_ID AS[Job Code], h.PCP_Shipment AS [Shipment], h.PC_ProcessCode AS [Process Code], d.Task_ID AS [Task Code], d.PCP_File AS [File Name], d.PCP_FileSize AS [File Size], d.PCP_Status AS [Job Status], d.PCP_StartDate As [Created Date/Time], d.PCP_EndDate AS [Done Date/Time], d.PCP_CreatorUID AS [DCD User] 
----FROM tbl_PCPHeader h 
----INNER JOIN tbl_PCPDetail d ON h.PCP_ID = d.PCP_ID 
----INNER JOIN tbl_ManagerDetail u ON u.M_Project = d.PCP_Project AND u.M_UID = '"+ mUID + "' 
----WHERE h.PCP_Shipment LIKE '" + mShipment + "%' OR h.PCP_Shipment LIKE '%" + mShipment + "' ORDER BY d.PCPD_Index


----SELECT d.PCPD_Index AS [#], h.PCP_ID AS[Job Code], h.PCP_Shipment AS [Shipment], h.PC_ProcessCode AS [Process Code], d.Task_ID AS [Task Code], d.PCP_File AS [File Name], d.PCP_FileSize AS [File Size], d.PCP_Status AS [Job Status], d.PCP_StartDate As [Created Date/Time], d.PCP_EndDate AS [Done Date/Time], d.PCP_CreatorUID AS [DCD User] 
----FROM tbl_PCPHeader h 
----INNER JOIN tbl_PCPDetail d ON h.PCP_ID = d.PCP_ID 
----INNER JOIN tbl_ManagerDetail u ON u.M_Project = d.PCP_Project AND u.M_UID = '"+ mUID + "' 
----WHERE h.PC_ProcessCode LIKE '" + mProcessCode + "%' OR h.PC_ProcessCode LIKE '%" + mProcessCode + "' ORDER BY d.PCPD_Index

----SELECT d.PCPD_Index AS [#], h.PCP_ID AS[Job Code], h.PCP_Shipment AS [Shipment], h.PC_ProcessCode AS [Process Code], d.Task_ID AS [Task Code], d.PCP_File AS [File Name], d.PCP_FileSize AS [File Size], d.PCP_Status AS [Job Status], d.PCP_StartDate As [Created Date/Time], d.PCP_EndDate AS [Done Date/Time], d.PCP_CreatorUID AS [DCD User] 
----FROM tbl_PCPHeader h 
----INNER JOIN tbl_PCPDetail d ON h.PCP_ID = d.PCP_ID 
----INNER JOIN tbl_ManagerDetail u ON u.M_Project = d.PCP_Project AND u.M_UID = '"+ mUID +"' 
----WHERE d.Task_ID LIKE '" + mTaskCode + "%' OR d.Task_ID LIKE '%" + mTaskCode + "' ORDER BY d.PCPD_Index


----SELECT d.PCPD_Index AS [#], h.PCP_ID AS[Job Code], h.PCP_Shipment AS [Shipment], h.PC_ProcessCode AS [Process Code], d.Task_ID AS [Task Code], d.PCP_File AS [File Name], d.PCP_FileSize AS [File Size], d.PCP_Status AS [Job Status], d.PCP_StartDate As [Created Date/Time], d.PCP_EndDate AS [Done Date/Time], d.PCP_CreatorUID AS [DCD User] 
----FROM tbl_PCPHeader h 
----INNER JOIN tbl_PCPDetail d ON h.PCP_ID = d.PCP_ID 
----INNER JOIN tbl_UserManagementDetail u ON u.P_Project = d.PCP_Project AND u.P_UID = '" + mUID + "' WHERE d.PCP_CreatorUID LIKE '" + mDCDUID + "%' OR d.PCP_CreatorUID LIKE '%" + mDCDUID + "' ORDER BY d.PCPD_Index

----SELECT s.M_Project 
----FROM tbl_ManagerHeader f 
----INNER JOIN tbl_ManagerDetail s ON f.M_UID = s.M_UID WHERE s.M_UID = '" + mUID + "' AND s.M_Project_Availability = 'Active'

----SELECt *
----FROM tbl_ManagerDetail
----WHERE M_UID='JO7'

----SELECt *
----FROM tbl_ManagerHeader
----WHERE M_UID='JO7'

--SELECT h.TR_UID, p.PCP_Project, p.PCP_Status
--FROM tbl_TaskRecordHeader h
--INNER JOIN tbl_TaskRecordDetail d ON d.TR_ID=h.TR_ID
--INNER JOIN tbl_PCPDetail p ON p.PCP_File=d.TR_File AND d.Task_ID=p.Task_ID
--WHERE d.TR_InDate BETWEEN '01/10/2018 00:00:00' AND '01/10/2018 23:59:59'
--GROUP BY h.TR_UID, p.PCP_Project, p.PCP_Status

--SELECT d.IDLE_UID
--FROM tbl_IDLEDetail d
--WHERE d.IDLE_InDate BETWEEN '01/10/2018 00:00:00' AND '01/10/2018 23:59:59'

--SELECT d.TR_UID
--FROM tbl_TaskRecordDetail d
--WHERE d.TR_InDate BETWEEN '01/10/2018 00:00:00' AND '01/10/2018 23:59:59' AND d.TR_Status=3




