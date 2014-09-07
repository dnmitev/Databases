SELECT m.Name,
(SELECT COUNT(*)
FROM Toys t
	INNER JOIN AgeRanges ar
		ON t.AgeRangeId = ar.Id
WHERE ar.MinimalAge >= 5 AND ar.MaximumAge <= 10 AND m.Id = t.ManufacturerId) as [Count]
FROM Manufacturers m
