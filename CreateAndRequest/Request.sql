--------------------1-------------------------------------------
SELECT product_id, name, costForHundred, caloriesForHundred, cost, calories
FROM Product_count INNER JOIN Product
    ON (Product_count.product_id = Product.id)

SELECT Recipe.name, Season.name, season_id, description
FROM Season FULL JOIN Recipe
    ON (Season.id = Recipe.season_id)

SELECT product_id, name, costForHundred, caloriesForHundred, cost, calories
FROM Product_count RIGHT JOIN Product
    ON (Product_count.product_id = Product.id)

SELECT Recipe.name, Product.name, costForHundred, caloriesForHundred, cost, calories
FROM Product LEFT JOIN Product_count
	ON (Product_count.product_id = Product.id)  
			LEFT JOIN Products_Recipes
    ON (Products_Recipes.product_count_id = Product_count.id)
			LEFT JOIN Recipe
	ON (Products_Recipes.recipe_id = Recipe.id)
			
SELECT Recipe.name, costConverter_id, moneyCostMain, moneyCostOther, valMain, valOther
FROM Recipe CROSS JOIN CostConverter
---------------------2----------------------------
SELECT Recipe.name, Season.name, season_id, description
FROM Season FULL JOIN Recipe
    ON (Season.id = Recipe.season_id)
WHERE EXISTS (SELECT 1 FROM Recipe WHERE Recipe.season_id = Season.id);

SELECT *
FROM Product_count
WHERE product_id IN (2)

SELECT * 
FROM Users
WHERE amountPublished >= ALL (SELECT amountPublished FROM Users)

SELECT * 
FROM Users
WHERE amountPublished >= SOME (SELECT amountPublished FROM Users)

SELECT * 
FROM Recipe 
WHERE publishedDate BETWEEN '20.01.2020' AND '20.01.2023'

SELECT *
FROM Recipe
WHERE name LIKE 'быстрые%'
--------------------------3-------------------------
SELECT Recipe.name,
CASE
    WHEN Groups.priority BETWEEN 1 AND 5 THEN 'Важно'
    WHEN Groups.priority BETWEEN 5 AND 10 THEN 'Не важно'
END AS Importancy
FROM Recipe JOIN Groups ON Recipe.group_id = Groups.id
-------------------------4(5)--------------------------
SELECT *,
CONVERT(INT, SUBSTRING(pass, 1, 3)) AS INTed
FROM Users

SELECT *,
CAST(SUBSTRING(pass, 1, 3) AS INT) AS INTed
FROM Users

SELECT *,
CONVERT(DECIMAL, valOther) AS INTed
FROM CostConverter

SELECT *,
CAST(valOther AS DECIMAL) AS INTed
FROM CostConverter

SELECT *,
REPLACE (pass, '123', 'onetwothree') as passNew
FROM Users

SELECT ISNULL (Recipe.name, 'Season not binded') AS name, Season.name, ISNULL (season_id, -1) AS season_id, ISNULL (description, 'Season not binded') AS description
FROM Season FULL JOIN Recipe
    ON (Season.id = Recipe.season_id)

SELECT howMuch, CHOOSE (ROW_NUMBER() OVER (ORDER BY howMuch DESC), 'Первый', 'Второй','Третий')
FROM RecipeViewed

SELECT Recipe.name, Groups.priority,
COALESCE (NULLIF(Recipe.name, 'быстрые шкварки2'), 
IIF (Groups.priority BETWEEN 1 AND 5, 'Важно','Не важно')) AS Result
FROM Recipe JOIN Groups ON Recipe.group_id = Groups.id
------------------6----------------------------
SELECT name, DATEPART(YEAR, publishedDate) as publishedYear
FROM Recipe

SELECT name, DATEDIFF(DAY, publishedDate, GetDate()) as dayDiff
FROM Recipe

SELECT name, publishedDate, DATEADD(DAY, 365, publishedDate) as newDate
FROM Recipe
-------------------7------------------------
SELECT AVG (howMuch) AS AverageViews
FROM RecipeViewed

SELECT MIN (howMuch) AS MinimumViews
FROM RecipeViewed

SELECT MAX (howMuch) AS MaximumViews
FROM RecipeViewed

SELECT SUM (howMuch) AS SumViews
FROM RecipeViewed

SELECT name, SUM(cost) AS TotalCost, SUM(calories) AS TotalCalories
FROM Product_count INNER JOIN Product
    ON (Product_count.product_id = Product.id)
GROUP BY name
HAVING SUM(cost) < 300

SELECT name, SUM(cost) AS TotalCost, SUM(calories) AS TotalCalories
FROM Product_count INNER JOIN Product
    ON (Product_count.product_id = Product.id)
GROUP BY name
HAVING SUM(cost) < 150