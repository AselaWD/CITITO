/****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP (1000) [ID]
      ,[UID]
      ,[DATE]
      ,[FIRSTLOGIN]
      ,[LASTLOGOUT]
  FROM [CITITO].[dbo].[tbl_UserLILO]
  WHERE UID='XT8' AND DATE='2018-07-19 00:00:00'
  -- ACTUAL Logout is 2018-07-19 06:00:03.000