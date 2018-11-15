----SELECT pd.PCP_Project, td.TR_Shipment, td.TR_File, th.PCP_ID, td.Task_ID +' - '+ tsd.Task_Description AS [Task Code], td.TR_InDate  
----FROM tbl_PCPDetail pd INNER JOIN tbl_TaskRecordHeader th ON pd.PCP_ID = th.PCP_ID 
----INNER JOIN tbl_TaskRecordDetail td ON td.TR_ID = th.TR_ID 
----INNER JOIN tbl_TaskDetail tsd ON tsd.Task_ID = td.Task_ID  AND tsd.PC_ProcessCode = pd.PC_ProcessCode 
----WHERE td.TR_UID = '5CW' AND pd.PCP_Status = '2' AND td.TR_TaskStatus = '1' 
----GROUP BY pd.PCP_Project, td.TR_Shipment, td.TR_File, th.PCP_ID, td.Task_ID + ' - ' + tsd.Task_Description, td.TR_InDate

----SELECT MIN(d.TR_InDate) 
----FROM tbl_TaskRecordDetail d 
----INNER JOIN tbl_TaskRecordHeader h ON d.TR_ID = h.TR_ID 
----WHERE h.PCP_ID = 'TNI1217DA153' AND d.Task_ID = 'TNI_DA2' AND d.TR_Status = '2' AND d.TR_Apporval = '4' AND d.TR_File = 'AAAAA'


----UPDATE tbl_TaskRecordDetail
----SET TR_InDate=(TR_OutDate-TR_Hours/24)
----WHERE TR_ID='5CWTNI9'

----SELECT * 
----FROM tbl_TaskRecordDetail
----WHERE TR_Status=3
----ORDER BY TR_Index

----SELECT *
----FROM tbl_PCPDetail
----WHERE PCP_File='AAAAA'

----DELETE FROM tbl_TaskRecordDetail
----WHERE TR_File='AAAAA'


SELECT TaskDetail.Task_Description, SUM(d.TR_Productivity)
FROM  tbl_TaskRecordDetail d
INNER JOIN tbl_PCPDetail PCPDetail ON PCPDetail.PCP_ID=d.PCP_ID AND d.Task_ID=PCPDetail.Task_ID
INNER JOIN tbl_TaskDetail TaskDetail ON TaskDetail.Task_ID=PCPDetail.Task_ID AND TaskDetail.PC_ProcessCode=PCPDetail.PC_ProcessCode
WHERE d.TR_PIC = 'ZDQ' AND TR_Status='3' AND d.TR_Apporval='2'
GROUP BY TaskDetail.Task_Description

SELECT *
FROM tbl_PCPDetail
WHERE PCP_ID ='TNI0118DA161'


--SELECT MIN(d.TR_InDate) 
--FROM tbl_TaskRecordDetail d 
--INNER JOIN tbl_TaskRecordHeader h ON d.TR_ID = h.TR_ID 
--WHERE h.PCP_ID = 'TNI0118DA177' AND d.Task_ID = 'TNI_DA1' AND d.TR_Status = '2' AND d.TR_Apporval = '4' AND d.TR_File = '9780310091271'

--SELECT *
--FROM tbl_PCPDetail
--WHERE PCP_File='9780310091271'


--DELETE FROM [CITITO].[dbo].[tbl_PCPHeader]
--WHERE [PCP_ID]='WKG1217653'



--SELECT *
--FROM tbl_UserManagementDetail
--WHERE PIC_UID='36W'

--DELETE FROM tbl_UserManagementDetail
--WHERE PIC_UID='36W' AND P_Project='CHVMA'

--SELECT *
--FROM tbl_IDLEDetail d
--INNER JOIN tbl_IDLEHeader h ON d.IDLE_ID=h.IDLE_ID
--WHERE d.IDLE_PIC='36W'

--DELETE FROM tbl_IDLEDetail
--WHERE IDLE_PIC='36W' AND IDLE_ID='IE9040118IDLE1'

--DELETE FROM tbl_IDLEHeader
--WHERE IDLE_PIC='36W' AND IDLE_ID='IE9040118IDLE1'

--SELECT *
--FROM tbl_ProjectDetail
--WHERE ProjectName='MSIXMQA'

--DELETE FROM tbl_ProjectDetail
--WHERE ProjectName='MSIXMQA'

--SELECT *
--FROM tbl_UserManagementDetail
--WHERE P_Project='IECSC'

--DELETE FROM tbl_UserManagementDetail
--WHERE P_Project='IECSC'


--DELETE FROM tbl_TaskRecordHeader
--WHERE PCP_ID='APP1217EF14'

--UPDATE tbl_PCPDetail SET PCP_Status=0
--WHERE PCP_ID='APP1217EF14'

--SELECT *
--FROM tbl_ProcessCodeHeader
--WHERE PIC_UID='36W' AND PIC_Project='CHVMA'

--DELETE FROM tbl_ProcessCodeHeader
--WHERE PIC_UID='36W' AND PIC_Project='CHVMA'

--DELETE FROM tbl_ProjectDetail
--WHERE PIC_UID='36W' AND ProjectName='WKGRF'


--SELECT * 
--FROM tbl_PCPHeader
--WHERE PC_ProcessCode ='1211111'

--DELETE FROM tbl_PCPHeader
--WHERE PC_ProcessCode ='1211111'



