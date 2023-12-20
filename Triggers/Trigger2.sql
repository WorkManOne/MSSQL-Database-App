CREATE TRIGGER CreateRecipeEnv_ins
ON Recipe
INSTEAD OF INSERT
AS
DECLARE @InsertedIds TABLE (id INT);
DECLARE @nm VARCHAR (200), @ctr INT, 
		@calo REAL, @desc VARCHAR (8000), @cstMn REAL, 
		@cstOt REAL, @conv INT, @ssn INt, 
		@pDate DATE, @byId INT, @grp INT
DECLARE CUR CURSOR FOR
SELECT name, country_id, caloriesInAll, description, 
   moneyCostMain, moneyCostOther, costConverter_id, 
   season_id, publishedDate, publishedBy_id, group_id
FROM inserted
OPEN CUR
FETCH NEXT FROM CUR INTO
@nm, @ctr, 
@calo, @desc, @cstMn, 
@cstOt, @conv, @ssn, 
@pDate, @byId, @grp

WHILE @@FETCH_STATUS=0

BEGIN
	IF NOT EXISTS (SELECT * FROM Users WHERE id = @byId)
		RAISERROR('РЕЦЕПТ НЕ ДОБАВЛЕН: Указанного в рецепте пользователя не существует', 16, 10)
	ELSE
	IF NOT EXISTS (SELECT * FROM Country WHERE id = @ctr)
		RAISERROR('РЕЦЕПТ НЕ ДОБАВЛЕН: Указанной в рецепте страны не существует', 16, 10)
	ELSE
	IF NOT EXISTS (SELECT * FROM CostConverter WHERE id = @conv)
		RAISERROR('РЕЦЕПТ НЕ ДОБАВЛЕН: Указанной в рецепте сторонней валюты не существует', 16, 10)
	ELSE
	IF NOT EXISTS (SELECT * FROM Season WHERE id = @ssn)
		RAISERROR('РЕЦЕПТ НЕ ДОБАВЛЕН: Указанного в рецепте сезона не существует', 16, 10)
	ELSE
	IF NOT EXISTS (SELECT * FROM Groups WHERE id = @grp)
		RAISERROR('РЕЦЕПТ НЕ ДОБАВЛЕН: Указанного в рецепте сезона не существует', 16, 10)
	ELSE
	IF (@cstOt <> @cstMn * (SELECT valOther FROM CostConverter WHERE id = @conv))
	BEGIN
		RAISERROR('РЕЦЕПТ БУДЕТ ИЗМЕНЕН: Указана неправильная цена в сторонней валюте', 5, 1)
		INSERT Recipe (name, country_id, caloriesInAll, description, 
		moneyCostMain, moneyCostOther, costConverter_id, 
		season_id, publishedDate, publishedBy_id, group_id) 
		OUTPUT inserted.id INTO @InsertedIds
		VALUES 
		(@nm, @ctr, 
		 @calo, @desc, @cstMn, 
		 @cstMn * (SELECT valOther FROM CostConverter WHERE id = @conv), @conv, @ssn, 
		 @pDate, @byId, @grp)
	END
	ELSE
	BEGIN
		INSERT Recipe (name, country_id, caloriesInAll, description, 
		moneyCostMain, moneyCostOther, costConverter_id, 
		season_id, publishedDate, publishedBy_id, group_id) 
		OUTPUT inserted.id INTO @InsertedIds
		VALUES 
		(@nm, @ctr, 
		 @calo, @desc, @cstMn, 
		 @cstOt, @conv, @ssn, 
		 @pDate, @byId, @grp)

		
	END
	FETCH NEXT FROM CUR INTO
	@nm, @ctr, 
	@calo, @desc, @cstMn, 
	@cstOt, @conv, @ssn, 
	@pDate, @byId, @grp
END

CLOSE CUR
DEALLOCATE CUR
SELECT id FROM @InsertedIds;

DROP TRIGGER CreateRecipeEnv_ins
