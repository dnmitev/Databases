USE [Company]
GO

SELECT d.Name, COUNT(e.Id) AS [Count]
FROM Departments d
	INNER JOIN Employees e
		ON d.Id = e.DepartmentId
GROUP BY d.Name
ORDER BY [Count]