CREATE TRIGGER productCountRecalc_upd
ON Product_count
AFTER UPDATE
AS
DECLARE @i INT
DECLARE CUR CURSOR FOR
SELECT id
FROM inserted
OPEN CUR
FETCH NEXT FROM CUR INTO @i

WHILE @@FETCH_STATUS=0

BEGIN
	UPDATE Product_count
	SET calories = (SELECT caloriesForHundred FROM Product WHERE product_id = id ) * amount / 100, cost = (SELECT costForHundred FROM Product WHERE product_id = id ) * amount / 100
	WHERE id = @i
FETCH NEXT FROM CUR INTO @i
END

CLOSE CUR
DEALLOCATE CUR

DROP TRIGGER productCountRecalc_upd