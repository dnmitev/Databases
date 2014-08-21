SELECT e.FirstName + ' ' + e.LastName AS [Full Name], e.Salary
FROM [TelerikAcademy].[dbo].[Employees] e
WHERE e.Salary IN (25000, 14000, 12500, 23600);