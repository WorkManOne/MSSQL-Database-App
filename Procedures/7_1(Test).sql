EXEC showProductsOf 1

EXEC viewsByUser 2

EXEC countRecByGroups

DECLARE @OutputResult INT;
EXEC @OutputResult = isRespected 1
IF @OutputResult = 1
BEGIN
    PRINT 'Recipe is respected.';
END
ELSE
BEGIN
    PRINT 'Recipe is not respected.';
END

EXEC findProblematic

INSERT Product_count
   (calories, amount, cost, product_id)  
VALUES  
   (512, 0, 100, 1),
   (310, 0, 60, 1),
   (135, 0, 67, 2);