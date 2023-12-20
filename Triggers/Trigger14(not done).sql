CREATE TRIGGER productDeletedRecalcRecipe_del
ON Products_Recipes
AFTER INSERT
AS
DECLARE @i INT, @prC_id INT
DECLARE CURrecalc CURSOR FOR
SELECT id, product_count_id
FROM deleted
OPEN CURrecalc
FETCH NEXT FROM CURrecalc INTO @i, @prC_id

WHILE @@FETCH_STATUS=0

BEGIN
	UPDATE Recipe
	SET caloriesInAll = caloriesInAll - (SELECT calories FROM Product_count WHERE id = @prC_id),
		moneyCostMain = moneyCostMain - (SELECT cost FROM Product_count WHERE id = @prC_id)
	WHERE id = ANY(SELECT recipe_id FROM Products_Recipes WHERE id = @i)
FETCH NEXT FROM CURrecalc INTO @i, @prC_id
END

CLOSE CURrecalc
DEALLOCATE CURrecalc

DROP TRIGGER productDeletedRecalcRecipe_del