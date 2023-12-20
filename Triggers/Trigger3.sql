CREATE TRIGGER productCountCLR_del
ON Product
INSTEAD OF DELETE
AS
DECLARE @i INT
DECLARE CUR CURSOR FOR
SELECT id
FROM deleted
OPEN CUR
FETCH NEXT FROM CUR INTO @i

WHILE @@FETCH_STATUS=0

BEGIN
IF NOT EXISTS (SELECT * FROM Products_Recipes WHERE product_count_id = ANY(SELECT id FROM Product_count WHERE product_id = @i))
BEGIN
	IF NOT EXISTS (SELECT * FROM Product_count WHERE product_id = @i)
		DELETE FROM Product WHERE id = @i
	ELSE
	BEGIN
		DELETE FROM Product_count WHERE product_id = @i
		DELETE FROM Product WHERE id = @i
		RAISERROR ('Изменена таблица расчетов продукта',1,10)
	END
END
ELSE
BEGIN
	DELETE FROM Products_Recipes WHERE product_count_id = ANY(SELECT id FROM Product_count WHERE product_id = @i)
	DELETE FROM Product_count WHERE product_id = @i
	DELETE FROM Product WHERE id = @i
	RAISERROR ('Изменены таблицы связки рецепта с продуктом, расчетов продукта',2,10)
END
FETCH NEXT FROM CUR INTO @i
END

CLOSE CUR
DEALLOCATE CUR

DROP TRIGGER productCountCLR_del