DECLARE @mUID varchar(30);
DECLARE @mTaskOut datetime;
DECLARE @mTaskIn datetime;
DECLARE @mActualTaskOut datetime;
DECLARE @mActualTaskIn datetime;

SET @mUID='XT8';
SET @mActualTaskIn= '2018-07-19 17:15:12.303';
SET @mActualTaskOut='2018-07-20 09:04:29.000';

SET @mTaskIn= '2018-07-19 17:15:12.303';
SET @mTaskOut='2018-07-20 09:04:29.000';

--COUNT
SELECT 
		COUNT(d.TR_UID) AS [RECORD_COUNT]
	FROM 
		tbl_TaskRecordDetail d 
		INNER JOIN tbl_TaskRecordHeader h ON d.TR_ID = h.TR_ID
	WHERE
		d.TR_UID = @mUID 
		AND (d.TR_ActualTaskIn BETWEEN CONVERT(DATE, @mActualTaskIn) AND DATEADD(day, 1, CONVERT(DATE, @mActualTaskOut)));

--/*VALIDATION*/

WITH CTE AS (
SELECT TOP(999999999999999999)
			rownum = ROW_NUMBER() OVER (ORDER BY d.TR_ActualTaskIn ASC),
			d.TR_UID, 
			ams.FIRSTLOGIN,
			d.TR_ActualTaskIn, 
			d.TR_OutDate, 
			ams.LASTLOGOUT

		FROM 
			tbl_TaskRecordDetail d 
			INNER JOIN tbl_TaskRecordHeader h ON d.TR_ID = h.TR_ID
			INNER JOIN tbl_UserLILO ams ON ams.UID = d.TR_UID AND ams.DATE=CONVERT(DATE, d.TR_ActualTaskIn)
		WHERE 
			d.TR_UID = @mUID 
			AND 
			(d.TR_ActualTaskIn BETWEEN CONVERT(DATE, @mActualTaskIn) AND DATEADD(day, 1, CONVERT(DATE, @mActualTaskOut)))
	ORDER BY d.TR_ActualTaskIn ASC
)
SELECT
	CTE.rownum ID,
	CTE.TR_UID [UID],
	CTE.FIRSTLOGIN,
	prev.TR_OutDate [PrevioustaskOut],
	CTE.TR_ActualTaskIn [A_TaskIn],
	CTE.TR_OutDate [A_TaskOut],
	nex.TR_ActualTaskIn [NexttaskedIn],
	CTE.LASTLOGOUT
FROM CTE
LEFT JOIN CTE prev ON prev.rownum = CTE.rownum - 1
LEFT JOIN CTE nex ON nex.rownum = CTE.rownum + 1
ORDER BY CTE.rownum ASC

;
	WITH CTE AS (
	SELECT TOP(999999999999999999)
				rownum = ROW_NUMBER() OVER (ORDER BY d.TR_ActualTaskIn ASC),
				d.TR_UID, 
				ams.FIRSTLOGIN,
				d.TR_ActualTaskIn, 
				d.TR_OutDate, 
				ams.LASTLOGOUT
			FROM 
				tbl_TaskRecordDetail d 
				INNER JOIN tbl_TaskRecordHeader h ON d.TR_ID = h.TR_ID
				INNER JOIN tbl_UserLILO ams ON ams.UID = d.TR_UID AND ams.DATE=CONVERT(DATE, d.TR_ActualTaskIn)
			WHERE 
				d.TR_UID = @mUID 
				AND 
				(d.TR_ActualTaskIn BETWEEN CONVERT(DATE, @mActualTaskIn) AND DATEADD(day, 1, CONVERT(DATE, @mActualTaskOut)))
		ORDER BY d.TR_ActualTaskIn ASC
	)
	
	SELECT
	CTE.rownum ID,
	CTE.TR_UID [UID],
	CTE.FIRSTLOGIN,
	prev.TR_OutDate [PrevioustaskOut],
	CTE.TR_ActualTaskIn [A_TaskIn],
	CTE.TR_OutDate [A_TaskOut],
	nex.TR_ActualTaskIn [NexttaskedIn],
	CTE.LASTLOGOUT
	FROM CTE
	LEFT JOIN CTE prev ON prev.rownum = CTE.rownum - 1
	LEFT JOIN CTE nex ON nex.rownum = CTE.rownum + 1

	/* Check Modified Logout Exceed Next Login */
	WHERE 
	nex.TR_ActualTaskIn IS NULL AND DATEADD(ms, -DATEPART(ms, CTE.LASTLOGOUT), CTE.LASTLOGOUT) < @mTaskOut
	ORDER BY CTE.rownum ASC
GO


