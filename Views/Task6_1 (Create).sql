CREATE VIEW Recipe_Products_View
AS  
SELECT dbo.Recipe.id, dbo.Recipe.name, dbo.Products_Recipes.product_count_id, dbo.Product_count.product_id, dbo.Product.name AS ProductName, dbo.Product_count.amount, dbo.Product_count.cost, dbo.Product_count.calories  
FROM  dbo.Product INNER JOIN  
         dbo.Product_count ON dbo.Product.id = dbo.Product_count.product_id INNER JOIN  
         dbo.Products_Recipes ON dbo.Product_count.id = dbo.Products_Recipes.product_count_id INNER JOIN  
         dbo.Recipe ON dbo.Products_Recipes.recipe_id = dbo.Recipe.id
GO
		 
CREATE VIEW UserViewedRecipe  
AS  
SELECT dbo.ViewedBy.dateViewed, dbo.Users.id, dbo.Users.name AS userName, dbo.Recipe.id AS idRecipe, dbo.Recipe.name
FROM  dbo.Recipe INNER JOIN
         dbo.ViewedBy ON dbo.Recipe.id = dbo.ViewedBy.recipeViewed_id INNER JOIN
         dbo.Users ON dbo.ViewedBy.user_id = dbo.Users.id
GO

CREATE VIEW RecipeFullInfo  
AS  
SELECT dbo.Recipe.id, dbo.Recipe.name, dbo.Product.name AS ProductName, dbo.Groups.name AS GroupName, dbo.Country.name AS CountryName, dbo.Country.primaryNation AS nationName, dbo.Users.name AS UserName, dbo.Season.name AS SeasonName, dbo.RecipeViewed.howMuch  
FROM  dbo.Country INNER JOIN  
         dbo.Recipe ON dbo.Country.id = dbo.Recipe.country_id INNER JOIN  
         dbo.Groups ON dbo.Recipe.group_id = dbo.Groups.id INNER JOIN  
         dbo.RecipeViewed ON dbo.Recipe.id = dbo.RecipeViewed.recipe_id INNER JOIN  
         dbo.Season ON dbo.Recipe.season_id = dbo.Season.id INNER JOIN  
         dbo.Users ON dbo.Recipe.publishedBy_id = dbo.Users.id CROSS JOIN  
         dbo.Product  
GO

CREATE VIEW Recipe_Products_View_Encr
WITH ENCRYPTION
AS  
SELECT dbo.Recipe.id, dbo.Recipe.name, dbo.Products_Recipes.product_count_id, dbo.Product_count.product_id, dbo.Product.name AS ProductName, dbo.Product_count.amount, dbo.Product_count.cost, dbo.Product_count.calories  
FROM  dbo.Product INNER JOIN  
         dbo.Product_count ON dbo.Product.id = dbo.Product_count.product_id INNER JOIN  
         dbo.Products_Recipes ON dbo.Product_count.id = dbo.Products_Recipes.product_count_id INNER JOIN  
         dbo.Recipe ON dbo.Products_Recipes.recipe_id = dbo.Recipe.id 
GO

CREATE VIEW UserViewedRecipe_Encr
WITH ENCRYPTION 
AS  
SELECT dbo.Recipe.name, dbo.Users.name AS userName, dbo.ViewedBy.dateViewed, dbo.Users.id  
FROM  dbo.Recipe INNER JOIN  
         dbo.Users ON dbo.Recipe.publishedBy_id = dbo.Users.id INNER JOIN  
         dbo.ViewedBy ON dbo.Users.id = dbo.ViewedBy.user_id  
GO

CREATE VIEW RecipeFullInfo_Encr 
WITH ENCRYPTION
AS  
SELECT dbo.Recipe.name, dbo.Product.name AS ProductName, dbo.Groups.name AS GroupName, dbo.Country.name AS CountryName, dbo.Users.name AS UserName, dbo.Season.name AS SeasonName, dbo.RecipeViewed.howMuch  
FROM  dbo.Country INNER JOIN  
         dbo.Recipe ON dbo.Country.id = dbo.Recipe.country_id INNER JOIN  
         dbo.Groups ON dbo.Recipe.group_id = dbo.Groups.id INNER JOIN  
         dbo.RecipeViewed ON dbo.Recipe.id = dbo.RecipeViewed.recipe_id INNER JOIN  
         dbo.Season ON dbo.Recipe.season_id = dbo.Season.id INNER JOIN  
         dbo.Users ON dbo.Recipe.publishedBy_id = dbo.Users.id CROSS JOIN  
         dbo.Product  