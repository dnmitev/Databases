SELECT TOP 5 
		e.FirstName + ' ' + e.LastName as [Full Name], e.Salary
FROM [TelerikAcademy].[dbo].[Employees] e
ORDER BY e.Salary DESC;