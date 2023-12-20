CREATE TRIGGER productCountRecalc_ins
ON Product_count
AFTER INSERT
AS
DECLARE @i INT
DECLARE CURrecalc CURSOR FOR
SELECT id
FROM inserted
OPEN CURrecalc
FETCH NEXT FROM CURrecalc INTO @i

WHILE @@FETCH_STATUS=0

BEGIN
	UPDATE Product_count
	SET calories = (SELECT caloriesForHundred FROM Product WHERE product_id = id ) * amount / 100, cost = (SELECT costForHundred FROM Product WHERE product_id = id ) * amount / 100
	WHERE id = @i
FETCH NEXT FROM CURrecalc INTO @i
END

CLOSE CURrecalc
DEALLOCATE CURrecalc

DROP TRIGGER productCountRecalc_ins