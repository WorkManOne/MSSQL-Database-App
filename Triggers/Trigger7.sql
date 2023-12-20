CREATE TRIGGER publishedRecipeCount_del
ON Recipe
AFTER DELETE
AS
BEGIN
	UPDATE Users
	SET amountPublished = amountPublished - 1
	WHERE id = ANY(SELECT publishedBy_id FROM deleted)
END

DROP TRIGGER publishedRecipeCount_del