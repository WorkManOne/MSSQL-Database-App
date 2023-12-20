CREATE TRIGGER howMuchViewed_upd
ON ViewedBy FOR INSERT
AS 
DECLARE @idRecViewed INT
IF @@ROWCOUNT=1
BEGIN
	IF NOT EXISTS (
		SELECT * FROM inserted
		WHERE inserted.recipeViewed_id = ANY(SELECT id
											 FROM RecipeViewed))
	BEGIN
		RAISERROR('ОТКАТ: Пользователь попытался просмотреть несуществующий рецепт',16,10)
		ROLLBACK TRAN
	END

	BEGIN
	SELECT @idRecViewed = recipeViewed_id
	FROM inserted

	UPDATE RecipeViewed
	SET howMuch=howMuch+1
	WHERE id=@idRecViewed
	END

END

DROP TRIGGER howMuchViewed_upd