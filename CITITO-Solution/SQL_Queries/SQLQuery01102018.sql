--SELECT d.PCP_File 
--FROM tbl_PCPHeader h 
--INNER JOIN tbl_PCPDetail d ON d.PCP_ID = h.PCP_ID 
--INNER JOIN tbl_ManagerDetail m ON m.M_Project = d.PCP_Project
--WHERE m.M_UID = '7AS' AND m.M_Project_Availability = 'Active' AND d.PCP_Project = 'TNIDA' AND h.PCP_Shipment='' AND d.PCP_Status != '3' AND d.PCP_Status != '1' GROUP BY d.PCP_File

--SELECT *
--FROM tbl_UserManagementDetail ud
--INNER JOIN tbl_UserManagementHeader uh ON uh.P_UID=ud.P_UID
--WHERE uh.P_AccessLevel='DCD'


--SELECT *
--FROM  tbl_UserManagementHeader
--WHERE P_AccessLevel='DCD'

--SELECT s.M_UID 
--FROM tbl_ManagerHeader f 
--INNER JOIN tbl_ManagerDetail s ON f.M_UID = s.M_UID 
--WHERE s.PIC_UID = '7AO' AND f.M_AccessLevel='Immediate Manager' AND f.M_Availability = 1 GROUP BY s.M_UID

--SELECT M_UID,M_Name,M_Password,M_AccessLevel 
--FROM tbl_ManagerHeader WHERE M_UID='T5X'

--SELECT f.PIC_UID 
--FROM tbl_ManagerDetail f 
--WHERE f.M_UID = 'T5X'
--GROUP BY f.PIC_UID

--SELECT h.M_AccessLevel  
--FROM tbl_ManagerHeader h
--INNER JOIN tbl_ManagerDetail s ON h.M_UID = s.M_UID 
--WHERE s.M_UID='T5X' AND s.PIC_UID = '7AO' AND h.M_Availability=1 
--GROUP BY h.M_AccessLevel

--SELECT SysAccessLevel 
--FROM tbl_SysAccessLevel 
--EXCEPT
--SELECT SysAccessLevel 
--FROM tbl_SysAccessLevel 
--WHERE SysAccessLevel='"+ mCurrentAccess +"' OR (SysAccessLevel='Project In Charge' OR SysAccessLevel='Common User') ORDER BY SysAccessLevel

--SELECT *
--FROM tbl_ProjectDetail
--WHERE ProjectName='HMSJU'

--DELETE FROM tbl_ProjectDetail
--WHERE ProjectName='HMSJU'


--SELECT *
--FROM tbl_ManagerDetail
--WHERE M_Project='HMSJU'

--DELETE FROM tbl_ManagerDetail
--WHERE M_Project='HMSJU'

--SELECT *
--FROM tbl_UserManagementDetail
--WHERE P_Project='HMSJU'

--DELETE FROM tbl_UserManagementDetail
--WHERE P_Project='HMSJU'

--SELECT *
--FROM tbl_UserManagementHeader
--WHERE P_AccessLevel='DCD'

--SELECT *
--FROM tbl_UserManagementDetail
--WHERE P_UID='11Z'

--DELETE FROM tbl_UserManagementDetail
--WHERE P_UID='ZTP'

--DELETE FROM tbl_UserManagementHeader
--WHERE P_UID='ZTP'

--SELECT *
--FROM tbl_UserManagementHeader
--WHERE P_UID='11Z'


--/*
--11Z,HN0,HR4,JZ7,KU5,QW1,QX1,RN2,RP2,RW4,TV9,UQ8,VL6,VY8,XS4,YE3,ZAS,ZTP
--*/

--SELECT Null, P_UID, P_Project, P_Project_Availability, P_Activate_Date,P_Inactivate_Date,PIC_UID 
--FROM tbl_UserManagementDetail
--WHERE P_UID=''


--SELECT *
--FROM tbl_UserManagementHeader h
--INNER JOIN tbl_UserManagementDetail d ON d.P_UID=h.P_UID
--WHERE h.P_AccessLevel='DCD'

--SELECT *
--FROM tbl_ManagerHeader h
--INNER JOIN tbl_ManagerDetail d ON d.M_UID=h.M_UID
--WHERE h.M_AccessLevel='DCD'