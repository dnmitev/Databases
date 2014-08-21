SELECT e.FirstName + ' ' + e.LastName as [Full Name]
FROM [TelerikAcademy].[dbo].[Employees] e
where e.ManagerID IS NULL;