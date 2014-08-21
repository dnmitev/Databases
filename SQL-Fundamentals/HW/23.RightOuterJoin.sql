SELECT e.LastName AS [Employee], m.LastName AS [Manager]
FROM [TelerikAcademy].[dbo].[Employees] e 
	RIGHT OUTER JOIN [TelerikAcademy].[dbo].[Employees] m 
		ON e.EmployeeID = m.ManagerID