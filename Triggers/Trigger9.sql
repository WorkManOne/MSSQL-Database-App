CREATE TRIGGER DeleteRecipeEnv_del
ON Recipe
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
	DECLARE @delProductCountIds TABLE (id INT)

	INSERT @delProductCountIds (id)
	SELECT product_count_id
	FROM Products_Recipes
	WHERE recipe_id = @i

	DELETE FROM Products_Recipes
	WHERE recipe_id = @i

	DELETE FROM Product_count
	WHERE id = ANY(SELECT id FROM @delProductCountIds)

	DELETE FROM ViewedBy
	WHERE recipeViewed_id = @i

	DELETE FROM RecipeViewed
	WHERE recipe_id = @i
	
	DELETE FROM Recipe
	WHERE id = @i

	FETCH NEXT FROM CUR INTO @i
END

CLOSE CUR
DEALLOCATE CUR

DROP TRIGGER DeleteRecipeEnv_del
