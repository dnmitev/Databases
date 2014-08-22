SELECT *
FROM [TelerikAcademy].[dbo].[Employees] e 
	INNER JOIN [TelerikAcademy].[dbo].[Departments] d
		ON e.DepartmentID = d.DepartmentID 
			AND d.Name IN ('Sales', 'Finance')
			AND YEAR(e.HireDate) BETWEEN 1995 AND 2004;