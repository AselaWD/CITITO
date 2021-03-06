/****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP (1000) uh.[P_UID] [UID]
	  ,uh.[P_Name] [Name]
	  ,CONCAT('[', ud.M_UID, '] ', mh.M_Name) [MANAGER]
	  ,CONCAT('[',ud.PIC_UID,'] ' ,pd.PIC_Name) [PIC] 
      ,uh.[PTR_Resources] [RES ID]
  FROM [CITITO].[dbo].[tbl_UserManagementHeader] uh
	   INNER JOIN tbl_UserManagementDetail ud ON ud.P_UID=uh.P_UID
	   INNER JOIN [tbl_PICDetail] pd On pd.PIC_UID=ud.PIC_UID
	   INNER JOIN [tbl_ManagerHeader] mh ON mh.M_UID=ud.M_UID
  WHERE uh.PTR_Resources IS NULL AND uh.P_Availability=1 AND ud.PIC_UID!='7AO'
  GROUP BY uh.[P_UID]
	  ,ud.M_UID
	  ,mh.M_Name
	  ,ud.PIC_UID
	  ,pd.PIC_Name
      ,uh.[P_Name]
      ,uh.[PTR_Resources]