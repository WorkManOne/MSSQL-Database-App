INSERT Season  
   (name, dateStart, dateEnd)  
VALUES  
   ('Summer', '01.06.2001', '31.08.2001'),
   ('Autumn', '01.09.2001', '30.11.2001'), 
   ('Winter', '01.12.2001', '28.02.2001'),
   ('WinterViso', '01.12.2001', '29.02.2004'),
   ('Spring', '01.03.2001', '31.05.2001');

INSERT Product  
   (name, costForHundred, caloriesForHundred)  
VALUES  
   ('Mayonese', 33.5, 310.2),
   ('Ketchup', 21.8, 160.1), 
   ('Tomato', 11.0, 80.2),
   ('Lemon', 16.1, 50.9);

INSERT Country
   (name, primaryNation)  
VALUES  
   ('Russia', 'Russian'),
   ('USA', 'American');

INSERT Groups
   (name, priority)  
VALUES  
   ('Soup', 1),
   ('Hot drink', 10);

INSERT Users
   (name, registeredAt, amountPublished, pass)  
VALUES  
   ('Kirill', '23.06.23', 1, '123qwerty'),
   ('Semen', '21.01.21', 2, '123456qwe');

INSERT CostConverter
   (valMain, valOther)  
VALUES  
   (1.23, 0.73),
   (0.23, 8.73);

INSERT Product_count
   (calories, amount, cost, product_id)  
VALUES  
   (512, 275, 100, 1),
   (310, 132, 60, 1),
   (135, 90, 67, 2);

INSERT Recipe
   (name, country_id, caloriesInAll, description, 
   moneyCostMain, moneyCostOther, costConverter_id, 
   season_id, publishedDate, publishedBy_id, group_id)  
VALUES  
   ('луковый чай',1, 604, 'а ну давайте сюда продукты доставайте, бам, второй, 
   бам, луковый чай я тебя люблю, к черту пошел отсюда', 1500, 150, 1, 1, '27.03.2010', 1, 1),
   ('быстрые шкварки',2, 708, 'достали из холодильника положили шк шк шк круглящками накрошила водой залила че мне тут мучаться
   приятного аппетита не подавитесь', 2112.2, 1201.8, 2, 3, '20.01.2021', 2, 2),
   ('быстрые шкварки2',2, 708, 'холодильник положили шк шк шк круглящками че? приятно подавитесь', 2112.2, 1201.8, 2, 3, '20.01.2021', 2, 2);
   
INSERT Products_Recipes
   (recipe_id, product_count_id)  
VALUES  
   (1, 1),
   (1, 3),
   (2, 2);

INSERT RecipeViewed
   (recipe_id, howMuch)  
VALUES  
   (1, 333),
   (2, 212),
   (1, 1411),
   (2, 222),
   (1, 2),
   (2, 201);
   
INSERT ViewedBy
   (user_id, recipeViewed_id, dateViewed)
VALUES  
   (2, 2, '30.09.23'),
   (2, 1, '23.10.23'),
   (1, 1, '05.08.23');