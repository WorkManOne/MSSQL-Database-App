SET NUMERIC_ROUNDABORT OFF;
SET ANSI_PADDING, 
ANSI_WARNINGS,
CONCAT_NULL_YIELDS_NULL, 
ARITHABORT, 
QUOTED_IDENTIFIER, 
ANSI_NULLS ON;

GO

CREATE VIEW All_RecipesOfUser  
WITH SCHEMABINDING 
AS  
SELECT dbo.Users.id, dbo.Users.name, dbo.Recipe.id AS RecipeId, dbo.Recipe.name AS RecipeName, dbo.Recipe.caloriesInAll, dbo.Recipe.moneyCostMain, dbo.Recipe.season_id  
FROM  dbo.Recipe INNER JOIN  
         dbo.Users ON dbo.Recipe.publishedBy_id = dbo.Users.id
