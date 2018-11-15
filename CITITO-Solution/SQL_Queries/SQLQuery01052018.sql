/****** UERS Shift by updated sdate  ******/
SELECT LiloInfo.[ID] 
	,EmpInf.[USERID]
      ,EmpInf.[SHIFT]
      ,EmpInf.[STATCODE]    
      ,EmpInf.[DATE_UPDATED]
	  ,LiloInfo.[LOGIN]
      ,LiloInfo.[LOGOUT]
	  ,ShitDes.[NT_LILO_SHIFT_DISCRIPTION]
  FROM [MCD_ONLINE].[dbo].[EMPLOYEE_INFO] EmpInf
  INNER JOIN HR_SHIFT_DETAILS ShitDes ON EmpInf.[SHIFT]=ShitDes.[NT_LILO_SHIFT_CODE]
  INNER JOIN [NTLILO].[dbo].[LILO] LiloInfo ON EmpInf.[USERID]=LiloInfo.[USERID] AND LiloInfo.[WORKDATE]=EmpInf.[DATE_UPDATED]
  WHERE EmpInf.[DATE_UPDATED] BETWEEN '2018-01-02 00:00:00' AND '2018-01-05 00:00:00' AND EmpInf.USERID='7AO'