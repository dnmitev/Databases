SELECT t.Name, t.Color, t.Price
FROM Toys t
	INNER JOIN ToysCategories tc
		ON t.Id = tc.ToyId
			INNER JOIN Categories c
				ON tc.CategoryId = c.Id
WHERE c.Name = 'boys'
