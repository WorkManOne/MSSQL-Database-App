CREATE TRIGGER productCountUPD_upd
ON Product
INSTEAD OF UPDATE
AS
DECLARE @i INT, @calo REAL, @cst REAL
DECLARE CUR CURSOR FOR
SELECT id, caloriesForHundred, costForHundred
FROM inserted
OPEN CUR
FETCH NEXT FROM CUR INTO @i, @calo, @cst

WHILE @@FETCH_STATUS=0

BEGIN
	IF NOT EXISTS (SELECT * FROM Product_count WHERE product_id = @i)
		UPDATE Product
		SET caloriesForHundred = @calo, costForHundred = @cst
		WHERE id = @i
	ELSE
	BEGIN
		UPDATE Product_count 
		SET calories = amount / 100 * @calo, cost = amount / 100 * @cst
		WHERE product_id = @i
		UPDATE Product
		SET caloriesForHundred = @calo, costForHundred = @cst
		WHERE id = @i
		RAISERROR ('Изменена таблица расчетов продукта',1,10)
	END
FETCH NEXT FROM CUR INTO @i, @calo, @cst
END

CLOSE CUR
DEALLOCATE CUR

DROP TRIGGER productCountUPD_upd