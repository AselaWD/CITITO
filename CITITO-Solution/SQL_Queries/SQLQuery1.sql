/****** Script for SelectTopNRows command from SSMS  ******/
SELECT LITOInfo.[USERID]       ,LITOInfo.[WORKDATE]
      ,LITOInfo.[LOGIN], 
      ,LITOInfo.[LOGOUT]
      ,LITOInfo.[SHIFT]
      ,LITOInfo.[COMPUTERNAME]
      ,LITOInfo.[LOGOUT_PC]
      ,LITOInfo.[USERTYPE]
  FROM [NTLILO].[dbo].[LILO] LITOInfo
