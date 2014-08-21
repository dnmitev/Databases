SELECT e.FirstName + ' ' + e.LastName as [Full Name], e.Salary
FROM [TelerikAcademy].[dbo].[Employees] e
WHERE e.Salary > 50000
ORDER BY e.Salary DESC;