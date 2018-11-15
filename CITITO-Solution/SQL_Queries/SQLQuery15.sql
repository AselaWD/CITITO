/****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP (1000) [ID]
      ,[USERID]
      ,[WORKDATE]
      ,[LOGIN]
      ,[LOGOUT]
      ,[LOGSTATUS]
      ,[SHIFT]
      ,[COMPUTERNAME]
      ,[LOGOUT_PC]
      ,[USERTYPE]
      ,[GATHERED]
      ,[EDITED]
      ,[ShiftID]
      ,[AppTypeID]
      ,[validlatestout]
  FROM [NTLILO].[dbo].[LILO]
  WHERE [WORKDATE] BETWEEN '2018-01-02 00:00:00' AND '2018-01-05 00:00:00' AND [USERID]='7AO'