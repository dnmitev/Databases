SELECT e.FirstName + ' ' + e.LastName AS [Full Name]
FROM [TelerikAcademy].[dbo].[Employees] e
WHERE e.FirstName LIKE 'SA%';