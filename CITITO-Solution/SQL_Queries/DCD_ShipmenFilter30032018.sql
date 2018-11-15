SELECT h.PCP_Shipment
FROM tbl_PCPHeader h 
LEFT OUTER JOIN tbl_PCPDetail d ON d.PCP_ID = h.PCP_ID 
WHERE d.PCP_Project = 'IECSC' 
GROUP BY h.PCP_Shipment
ORDER BY 
CASE 
	WHEN LEFT(h.PCP_Shipment,1) LIKE '%[A-Za-z]%'
    THEN LEFT(h.PCP_Shipment,1) + RIGHT('0000000000'  + SUBSTRING(h.PCP_Shipment,2,LEN(h.PCP_Shipment) - 1), 9)
    ELSE RIGHT('0000000000' + h.PCP_Shipment, 10)
END 
DESC

	--MAX(h.PCP_Index) DESC

SELECT h.PCP_Shipment FROM tbl_PCPHeader h INNER JOIN tbl_PCPDetail d ON d.PCP_ID = h.PCP_ID WHERE d.PCP_Project = 'WKGLE' GROUP BY h.PCP_Shipment
