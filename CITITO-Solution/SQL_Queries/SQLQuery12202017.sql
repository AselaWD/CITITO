--SELECT d.PCPD_Index AS [#], h.PCP_ID AS[Job Code], h.PCP_Shipment AS [Shipment], h.PC_ProcessCode AS [Process Code], d.Task_ID AS [Task Code], d.PCP_File AS [File Name], d.PCP_FileSize AS [File Size], d.PCP_Status AS [Job Status], d.PCP_StartDate As [Created Date/Time], d.PCP_EndDate AS [Done Date/Time] 
--FROM tbl_PCPHeader h INNER JOIN tbl_PCPDetail d ON h.PCP_ID = d.PCP_ID 
--WHERE d.PCP_CreatorUID = '9CR' ORDER BY d.PCPD_Index

--SELECT RIGHT(MAX(PCP_ID) , LEN(MAX(PCP_ID)) -9) FROM tbl_PCPDetail 
--WHERE (PCP_Project='TNIDA' AND PCPD_Index=(SELECT MAX(PCPD_Index) FROM tbl_PCPDetail))

--DELETE FROM tbl_PCPDetail
--WHERE PCP_Project='TNIDA' AND PCP_StartDate='2017-12-20 10:11:23.883';

--SELECt *
--FROM tbl_PCPDetail


--DELETE FROM tbl_PCPHeader
--WHERE PCP_Shipment='HCCP_096' AND PC_ProcessCode='TNIDACAK';

--SELECt *
--FROM tbl_PCPHeader

--SELECT Task_Quota FROM tbl_TaskDetail WHERE Task_ID='TNI_DA8' AND PC_ProcessCode='TNIDACAK'

--SELECT Task_UOM FROM tbl_TaskDetail WHERE Task_ID='TNI_DA8' AND PC_ProcessCode='TNIDACAK'

--SELECT PC_ProcessCode FROM tbl_PCPDetail WHERE PCP_ID='APP1217EF1' GROUP BY PC_ProcessCode


--SELECT p.Task_ID, t.Task_Description 
--FROM tbl_PCPDetail p 
--INNER JOIN tbl_TaskDetail t ON p.Task_ID = t.Task_ID AND p.PC_ProcessCode=t.PC_ProcessCode
--WHERE p.PCP_ID = 'TNI1217DA90' AND p.PCP_Status = '2'

--SELECT *
--FROM tbl_PCPDetail
--WHERE PCP_File='9781418586379'

--UPDATE tbl_PCPDetail SET PCP_EndDate=null, PCP_Status=0
--WHERE PCP_File='9781418586379'
