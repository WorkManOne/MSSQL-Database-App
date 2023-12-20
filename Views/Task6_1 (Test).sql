SELECT * FROM Recipe_Products_View
SELECT * FROM Recipe_Products_View_Encr

SELECT * FROM UserViewedRecipe
SELECT * FROM UserViewedRecipe_Encr

SELECT * FROM RecipeFullInfo
SELECT * FROM RecipeFullInfo_Encr

exec sp_helptext 'UserViewedRecipe'
exec sp_helptext 'UserViewedRecipe_Encr'

exec sp_helptext 'RecipeFullInfo'
exec sp_helptext 'RecipeFullInfo_Encr'

exec sp_helptext 'Recipe_Products_View'
exec sp_helptext 'Recipe_Products_View_Encr'

DROP VIEW Recipe_Products_View  
DROP VIEW Recipe_Products_View_Encr

DROP VIEW UserViewedRecipe
DROP VIEW UserViewedRecipe_Encr

DROP VIEW RecipeFullInfo
DROP VIEW RecipeFullInfo_Encr
