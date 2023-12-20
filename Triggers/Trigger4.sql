CREATE TRIGGER CostCalc_upd
ON CostConverter
AFTER UPDATE
AS

DECLARE @i_n INT, @mn_n REAL, @ot_n REAL

DECLARE CUR CURSOR FOR
SELECT id, valMain, valOther
FROM inserted
OPEN CUR
FETCH NEXT FROM CUR INTO @i_n, @mn_n, @ot_n

WHILE @@FETCH_STATUS=0
BEGIN
	UPDATE Recipe
	SET moneyCostOther = moneyCostMain * @ot_n
	WHERE costConverter_id = @i_n
	FETCH NEXT FROM CUR INTO @i_n, @mn_n, @ot_n
END
CLOSE CUR
DEALLOCATE CUR

DROP TRIGGER CostCalc_upd