SELECT name, pass, DATEPART (DAY, registeredAt)
FROM Users_Test
WHERE registeredAt < '2023-01-01'

CREATE NONCLUSTERED INDEX User_Registered ON Users_Test (registeredAt) INCLUDE (name, pass)
WHERE registeredAt < '2023-01-01'

SELECT name, pass, DATEPART (DAY, registeredAt)
FROM Users_Test
WHERE registeredAt < '2023-01-01'

DROP INDEX User_Registered ON Users_Test