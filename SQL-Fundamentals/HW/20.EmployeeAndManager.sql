SELECT e.FirstName + ' ' + e.LastName AS [Employee],
   m.FirstName + ' ' + m.LastName AS [Manager]
FROM [TelerikAcademy].[dbo].[Employees] e,
	[TelerikAcademy].[dbo].[Employees] m
WHERE e.ManagerID = m.EmployeeID;