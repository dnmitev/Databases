SELECT e.FirstName + ' ' + e.LastName AS [Full Name]
FROM [TelerikAcademy].[dbo].[Employees] e
WHERE e.LastName LIKE '%ei%';