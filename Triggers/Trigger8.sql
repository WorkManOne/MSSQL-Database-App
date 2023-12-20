CREATE TRIGGER CreateRecipeEnv_AFTins
ON Recipe
AFTER INSERT
AS
BEGIN
	INSERT INTO RecipeViewed (recipe_id, howMuch)  
	SELECT id, 0 FROM inserted
	UPDATE Users
	SET amountPublished = amountPublished + 1
	WHERE id = ANY(SELECT publishedBy_id FROM inserted)
END
DROP TRIGGER CreateRecipeEnv_AFTins