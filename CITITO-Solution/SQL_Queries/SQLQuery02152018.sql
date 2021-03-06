/****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP (1000) [P_Index]
      ,[P_UID]
      ,[P_Name]
      ,[P_Password]
      ,[P_AccessLevel]
      ,[P_Availability]
      ,[P_Activate_Date]
      ,[P_Inactivate_Date]
      ,[P_Shift]
  FROM [CITITO].[dbo].[tbl_UserManagementHeaderTemp]

update [tbl_UserManagementHeaderTemp]
set P_Shift = B.[Shift]
from [tbl_UserManagementHeaderTemp] A
inner
join tbl_ShiftTemp B
on A.P_UID = B.UserID