SELECT 
			ON.[ID], 
			ON.[ORDER_ID], 
			ON.[NOTE], 
			ON.[CREATED_DATE] 
FROM [ORDER_NOTES] 
			ON 
	INNER JOIN [ORDERS] O 
			ON 
			ON.[ORDER_ID] = O.[ID] 
WHERE 
			ON.[IsDeleted] = 0 
	AND O.[IsDeleted] = 0 
	AND 
			ON.[ID] = @PRM_ORDER_NOTES_ID 
	AND O.[ID] = @PRM_ORDERS_ID 
ORDER BY 
			ON.[ID] 