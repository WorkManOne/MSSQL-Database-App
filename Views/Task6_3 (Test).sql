SELECT * FROM All_RecipesOfUser

CREATE UNIQUE CLUSTERED INDEX RecipesOfUser_index
   ON All_RecipesOfUser (RecipeId);

SELECT * FROM All_RecipesOfUser
WITH (NOEXPAND)

DROP INDEX RecipesOfUser_index ON All_RecipesOfUser
DROP VIEW All_RecipesOfUser