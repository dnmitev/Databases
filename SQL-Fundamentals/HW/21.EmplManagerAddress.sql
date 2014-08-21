SELECT e.FirstName + ' ' + e.LastName AS [Employee],
	   m.FirstName + ' ' + m.LastName AS [Manager],
	   a.AddressText
FROM [TelerikAcademy].[dbo].[Employees] e
	INNER JOIN [TelerikAcademy].[dbo].[Employees] m
		ON e.ManagerID = m.EmployeeID
	INNER JOIN [TelerikAcademy].[dbo].[Addresses] a
		ON e.AddressID = a.AddressID;