CREATE PROC showProductsOf
@Rec_id INT
AS
SELECT Product_count.id, Product.id, name, costForHundred, caloriesForHundred, amount, cost, calories
FROM Product INNER JOIN Product_count
ON product_id = Product.id
WHERE Product_count.id = ANY(SELECT product_count_id FROM Products_Recipes WHERE recipe_id = @Rec_id)
GO

CREATE PROC productRecipeCreate
@Prod_id INT, @Rec_id INT, @amount REAL
AS
DECLARE @Last INT
BEGIN
	INSERT Product_count VALUES (@Prod_id, @amount, 0, 0)
	SET @Last = SCOPE_IDENTITY()
	INSERT Products_Recipes VALUES (@Rec_id, @Last)
END
GO

CREATE PROC viewsByUser
@Usr_id INT, @Rec_id INT = NULL
AS
IF @Rec_id IS NULL
	SELECT COUNT(id)
	FROM ViewedBy
	WHERE user_id = @Usr_id
ELSE
	SELECT COUNT(id)
	FROM ViewedBy
	WHERE user_id = @Usr_id AND recipeViewed_id = @Rec_id
GO

CREATE PROC countRecByGroups
AS
DECLARE @gid INT, @n VARCHAR(200), @cnt INT
DECLARE @tb TABLE (id INT, name VARCHAR(200), amount INT)
DECLARE CUR CURSOR FOR
SELECT id, name
FROM Groups
OPEN CUR
FETCH NEXT FROM CUR INTO @gid, @n
WHILE @@FETCH_STATUS=0
BEGIN
	SELECT @cnt = COUNT(id)
	FROM Recipe
	WHERE group_id = @gid
	
	INSERT @tb (id, name, amount)
	VALUES (@gid, @n, @cnt)

	FETCH NEXT FROM CUR INTO @gid, @n
END
SELECT * FROM @tb
CLOSE CUR
DEALLOCATE CUR
GO

CREATE PROC isRespected
@Rec_id INT
AS
IF
(SELECT Count(id)
FROM Users 
WHERE id = ANY(SELECT user_id FROM ViewedBy WHERE recipeViewed_id = @Rec_id) 
			AND amountPublished >= 10) 
/
(SELECT Count(id)
FROM Users 
WHERE id = ANY(SELECT user_id FROM ViewedBy WHERE recipeViewed_id = @Rec_id)) 
>= 0.5
	RETURN 1
ELSE
	RETURN 0
GO

CREATE PROCEDURE createCur
    @Cur CURSOR VARYING OUTPUT
AS
BEGIN
    SET NOCOUNT ON
    SET @Cur = CURSOR FOR
        SELECT id, product_id, amount, cost, calories
        FROM Product_count
    OPEN @Cur
END
GO

CREATE PROCEDURE findProblematic
AS
DECLARE @tb TABLE (id INT, product_id INT, amount REAL, cost REAL, calories REAL)
DECLARE @i INT, @pr INT, @am REAL, @c REAL, @cal REAL;
DECLARE @Cur1 CURSOR

EXEC createCur @Cur = @Cur1 OUTPUT

FETCH NEXT FROM @Cur1 INTO @i, @pr, @am, @c, @cal

WHILE (@@FETCH_STATUS = 0)
BEGIN
    IF @am < 1
	INSERT @tb (id, product_id, amount, cost, calories)
    VALUES (@i, @pr, @am, @c, @cal)
    FETCH NEXT FROM @Cur1 INTO @i, @pr, @am, @c, @cal
END
SELECT * FROM @tb
CLOSE @Cur1
DEALLOCATE @Cur1
GO

DROP PROC showProductsOf
DROP PROC viewsByUser
DROP PROC countRecByGroups
DROP PROC isRespected
DROP PROC createCur
DROP PROC findProblematic