CREATE TRIGGER DeleteProductCount
ON Product_count
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

	DELETE FROM Products_Recipes
	WHERE product_count_id = @i

	DELETE FROM Product_count WHERE id = @i
	FETCH NEXT FROM CUR INTO @i
END

CLOSE CUR
DEALLOCATE CUR

DROP TRIGGER DeleteProductCount