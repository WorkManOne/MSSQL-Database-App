CREATE TRIGGER country_del
ON Country
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
	UPDATE Recipe
	SET country_id = 1
	WHERE id = @i
	FETCH NEXT FROM CUR INTO @i
END

CLOSE CUR
DEALLOCATE CUR

DROP TRIGGER productCountCLR_del