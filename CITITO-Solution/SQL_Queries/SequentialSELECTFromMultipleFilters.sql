DECLARE @mPIC varchar(1000);
DECLARE @mProject varchar(2000);
DECLARE @mShipment varchar(2000);
DECLARE @mFileName varchar(2000);
DECLARE @mStatus varchar(2000);
DECLARE @mWhere varchar(2000);



SET @mPIC='ZDQ';
SET @mProject='APPEB'; --APPEB
SET @mShipment=''; --GMMEB05152018
SET @mFileName=''; --GMM0518EB28_4
SET @mStatus=''; --Done
SET @mWhere='';

IF ISNULL(@mProject,'') = ''
    SET @mProject = ''
ELSE
	SET @mProject = ' AND pd.PCP_Project='''+ @mProject +'''';

PRINT @mProject
--IF ISNULL(@mShipment,'') = ''
--	SET @mShipment = ''
--ELSE
--    SET @mShipment = ' AND ph.PCP_Shipment=''' + @mShipment + '''';

--IF ISNULL(@mFileName,'') = ''
--	SET @mFileName = ''
--ELSE
--    SET @mFileName = ' AND pd.PCP_File="''' + @mFileName + '''';

--IF ISNULL(@mStatus,'') = ''
--    SET @mStatus = ''
--ELSE
--	IF @mStatus='Fresh'
--		SET @mStatus = ' [STATUS]=''Fresh''';
--	IF @mStatus='In-Process'
--		SET @mStatus = ' [STATUS]=''In-Process''';
--	IF @mStatus='Done'
--		SET @mStatus = ' [STATUS]=''Done''';
--	IF @mStatus='Hold'
--		SET @mStatus = ' [STATUS]=''Hold''';

--IF ISNULL(@mWhere,'') = ''
--    SET @mWhere = ''
--ELSE
--	SET @mWhere = ' WHERE ';


SELECT *  FROM(
SELECT[CREATED DATE], PROJECT, [JOB CODE], [SHIPMENT], [FILE NAME], [TASK COUNT], [FRESH COUNT] AS[FRESH TASKS], [IN - PROCESS COUNT] AS[IN - PROCESS TASKS], [DONE COUNT] AS[DONE TASKS], [HOLD COUNT] AS[HOLD TASKS],
	CASE WHEN([IN - PROCESS COUNT] >= 1 AND[HOLD COUNT] = 0) THEN('In-Process') ELSE(CASE WHEN([HOLD COUNT] >= 1 AND[IN - PROCESS COUNT] = 0) THEN('Hold') ELSE(CASE WHEN([TASK COUNT] =[DONE COUNT]) THEN('Done') ELSE(CASE WHEN([DONE COUNT] != 0 AND[TASK COUNT] = ([DONE COUNT] +[FRESH COUNT])) THEN('In-Process') ELSE(CASE WHEN([TASK COUNT] =[FRESH COUNT]) THEN('Fresh') END) END) END) END) END AS[STATUS]
	 FROM(
	  SELECT MIN(CONVERT(Date, pd.PCP_StartDate)) AS[CREATED DATE], pd.PCP_Project AS[PROJECT], pd.PCP_ID AS[JOB CODE], ph.PCP_Shipment AS[SHIPMENT], pd.PCP_File AS[FILE NAME], COUNT(pd.PCP_Status) AS[TASK COUNT],
	  (SELECT COUNT(cd.PCP_Status) FROM tbl_PCPDetail cd WHERE cd.PCP_Status = 0 AND  pd.PCP_File = cd.PCP_File AND  pd.PCP_ID = cd.PCP_ID) AS[FRESH COUNT],
	  (SELECT COUNT(cd.PCP_Status) FROM tbl_PCPDetail cd WHERE cd.PCP_Status = 2 AND pd.PCP_File = cd.PCP_File AND pd.PCP_ID = cd.PCP_ID) AS[IN - PROCESS COUNT],
	  (SELECT COUNT(cd.PCP_Status) FROM tbl_PCPDetail cd WHERE cd.PCP_Status = 3 AND pd.PCP_File = cd.PCP_File AND pd.PCP_ID = cd.PCP_ID) AS[DONE COUNT],
	  (SELECT COUNT(cd.PCP_Status) FROM tbl_PCPDetail cd WHERE cd.PCP_Status = 1 AND pd.PCP_File = cd.PCP_File AND pd.PCP_ID = cd.PCP_ID) AS[HOLD COUNT]
	  FROM tbl_PCPDetail pd
	  INNER JOIN tbl_ProcessCodeHeader pch ON pd.PC_ProcessCode = pch.PC_ProcessCode AND pd.PCP_Project = pch.PIC_Project
	  INNER JOIN tbl_PCPHeader ph ON pd.PCP_ID = ph.PCP_ID
	  WHERE pch.PIC_UID = @mPIC + @mProject
	  GROUP BY pd.PCP_Project, pd.PCP_ID, ph.PCP_Shipment, pd.PCP_File
	  )WLResource
) WLDataSet
ORDER BY[CREATED DATE] DESC;