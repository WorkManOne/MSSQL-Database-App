CREATE TABLE Recipe (
	id int IDENTITY(1,1) NOT NULL CONSTRAINT PK_Recipe PRIMARY KEY, 
	name varchar(200) NOT NULL,
	country_id integer NOT NULL,
	caloriesInAll real NOT NULL,
	description text NOT NULL,
	moneyCostMain real NOT NULL,
	moneyCostOther real NOT NULL,
	costConverter_id integer NOT NULL,
	season_id integer NOT NULL,
	publishedDate date NOT NULL,
	publishedBy_id integer NOT NULL,
	group_id integer NOT NULL
)
GO
CREATE TABLE Country (
	id int IDENTITY(1,1) NOT NULL CONSTRAINT PK_Country PRIMARY KEY, 
	name varchar(200) NOT NULL,
	primaryNation text NOT NULL

)
GO
CREATE TABLE Product_count (
	id int IDENTITY(1,1) NOT NULL CONSTRAINT PK_Product_count PRIMARY KEY, 
	product_id integer NOT NULL,
	amount real NOT NULL,
	cost real NOT NULL,
	calories real NOT NULL
)
GO
CREATE TABLE Product (
	id int IDENTITY(1,1) NOT NULL CONSTRAINT PK_Product PRIMARY KEY, 
	name varchar(200) NOT NULL,
	costForHundred real NOT NULL,
	caloriesForHundred real NOT NULL
)
GO
CREATE TABLE Users (
	id int IDENTITY(1,1) NOT NULL CONSTRAINT PK_Users PRIMARY KEY,
	name varchar(200) NOT NULL CONSTRAINT,
	registeredAt date NOT NULL,
	amountPublished integer NOT NULL,
	pass varchar(200) NOT NULL
)
GO
CREATE TABLE Products_Recipes (
	id int IDENTITY(1,1) NOT NULL CONSTRAINT PK_Products_Recipes PRIMARY KEY, 
	recipe_id integer NOT NULL,
	product_count_id integer NOT NULL
)
GO
CREATE TABLE Groups (
	id int IDENTITY(1,1) NOT NULL CONSTRAINT PK_Groups PRIMARY KEY, 
	name varchar(200) NOT NULL,
	priority real NOT NULL
)
GO
CREATE TABLE Season (
	id int IDENTITY(1,1) NOT NULL CONSTRAINT PK_Season PRIMARY KEY, 
	name varchar(200) NOT NULL,
	dateStart date NOT NULL,
	dateEnd date NOT NULL
)
GO
CREATE TABLE CostConverter (
	id int IDENTITY(1,1) NOT NULL CONSTRAINT PK_CostConverter PRIMARY KEY, 
	valMain real NOT NULL,
	valOther real NOT NULL
)
GO
CREATE TABLE RecipeViewed (
	id int IDENTITY(1,1) NOT NULL CONSTRAINT PK_RecipeViewed PRIMARY KEY, 
	recipe_id integer NOT NULL,
	howMuch integer NOT NULL,
)
GO
CREATE TABLE ViewedBy (
	id int IDENTITY(1,1) NOT NULL CONSTRAINT PK_ViewedBy PRIMARY KEY, 
	user_id integer NOT NULL,
	recipeViewed_id integer NOT NULL,
	dateViewed date NOT NULL
)
GO
ALTER TABLE Recipe WITH CHECK ADD CONSTRAINT Recipe_fk0 FOREIGN KEY (country_id) REFERENCES Country(id)
ON UPDATE CASCADE
GO
ALTER TABLE Recipe CHECK CONSTRAINT Recipe_fk0
GO
ALTER TABLE Recipe WITH CHECK ADD CONSTRAINT Recipe_fk1 FOREIGN KEY (CostConverter_id) REFERENCES CostConverter(id)
ON UPDATE CASCADE
GO
ALTER TABLE Recipe CHECK CONSTRAINT Recipe_fk1
GO
ALTER TABLE Recipe WITH CHECK ADD CONSTRAINT Recipe_fk2 FOREIGN KEY (season_id) REFERENCES Season(id)
ON UPDATE CASCADE
GO
ALTER TABLE Recipe CHECK CONSTRAINT Recipe_fk2
GO
ALTER TABLE Recipe WITH CHECK ADD CONSTRAINT Recipe_fk3 FOREIGN KEY (publishedBy_id) REFERENCES Users(id)
ON UPDATE CASCADE
GO
ALTER TABLE Recipe CHECK CONSTRAINT Recipe_fk3
GO
ALTER TABLE Recipe WITH CHECK ADD CONSTRAINT Recipe_fk4 FOREIGN KEY (group_id) REFERENCES Groups(id)
ON UPDATE CASCADE
GO
ALTER TABLE Recipe CHECK CONSTRAINT Recipe_fk4
GO


ALTER TABLE Product_count WITH CHECK ADD CONSTRAINT Product_count_fk0 FOREIGN KEY (product_id) REFERENCES Product(id)
ON UPDATE CASCADE
GO
ALTER TABLE Product_count CHECK CONSTRAINT Product_count_fk0
GO



ALTER TABLE Products_Recipes WITH CHECK ADD CONSTRAINT Products_Recipes_fk0 FOREIGN KEY (recipe_id) REFERENCES Recipe(id)
ON UPDATE CASCADE
GO
ALTER TABLE Products_Recipes CHECK CONSTRAINT Products_Recipes_fk0
GO
ALTER TABLE Products_Recipes WITH CHECK ADD CONSTRAINT Products_Recipes_fk1 FOREIGN KEY (product_count_id) REFERENCES Product_count(id)
ON UPDATE CASCADE
GO
ALTER TABLE Products_Recipes CHECK CONSTRAINT Products_Recipes_fk1
GO




ALTER TABLE RecipeViewed WITH CHECK ADD CONSTRAINT RecipeViewed_fk0 FOREIGN KEY (recipe_id) REFERENCES Recipe(id)
ON UPDATE CASCADE
GO
ALTER TABLE RecipeViewed CHECK CONSTRAINT RecipeViewed_fk0
GO

ALTER TABLE ViewedBy WITH CHECK ADD CONSTRAINT ViewedBy_fk0 FOREIGN KEY (user_id) REFERENCES Users(id)
ON UPDATE CASCADE
GO
ALTER TABLE ViewedBy CHECK CONSTRAINT ViewedBy_fk0
GO
ALTER TABLE ViewedBy WITH CHECK ADD CONSTRAINT ViewedBy_fk1 FOREIGN KEY (recipeViewed_id) REFERENCES RecipeViewed(id)
ON UPDATE NO ACTION
GO
ALTER TABLE ViewedBy CHECK CONSTRAINT ViewedBy_fk1
GO

