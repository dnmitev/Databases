SELECT e.FirstName + ' ' + e.LastName AS [Full Name], e.Salary
FROM [TelerikAcademy].[dbo].[Employees] e
WHERE e.Salary BETWEEN 20000 AND 30000;