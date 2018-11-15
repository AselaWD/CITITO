BEGIN TRANSACTION;   
INSERT INTO tbl_ManagerDetail(M_UID,M_Project,M_Project_Availability,M_Activate_Date,PIC_UID) 
VALUES('JZ7','APPEC','Active','2017-11-10 09:32:00.357','ZDQ')
COMMIT TRANSACTION; 
/*
WITH CTE AS(
   SELECT M_UID AS [col1],M_Project AS [col2], M_Project_Availability AS [col3], M_Activate_Date AS [col4],PIC_UID AS [col6],
       RN = ROW_NUMBER()OVER(PARTITION BY M_UID ORDER BY M_UID)
   FROM tbl_ManagerDetail
)
DELETE FROM CTE WHERE RN > 1
*/

--SELECT M_Project 
--FROM tbl_ManagerDetail s 
--INNER JOIN tbl_ProjectDetail f ON s.M_Project=f.ProjectName
--WHERE s.PIC_UID = 'ZDQ' AND s.M_UID = '7AS' AND s.M_Project_Availability='Inactive' 
--GROUP BY s.M_Project
--EXCEPT 
--SELECT M_Project 
--FROM tbl_ManagerDetail s 
--WHERE s.PIC_UID = 'ZDQ' AND s.M_UID = '7AS' AND s.M_Project_Availability!='Active' 
--GROUP BY M_Project

/***/
SELECT ProjectName 
FROM tbl_ProjectDetail s 
WHERE s.PIC_UID = 'ZDQ'
GROUP BY ProjectName
EXCEPT 
SELECT M_Project FROM tbl_ManagerDetail s 
INNER JOIN tbl_ProjectDetail f ON s.M_Project = f.ProjectName 
WHERE s.PIC_UID = 'ZDQ' AND s.M_UID = '7AO' AND s.M_Project_Availability = 'Active' 
GROUP BY s.M_Project

/***/
SELECT ProjectName FROM tbl_ProjectDetail WHERE PIC_UID='YP5' ORDER BY ProjectName