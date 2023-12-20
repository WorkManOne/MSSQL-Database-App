SELECT * 
FROM Product_Test FULL JOIN Product
ON Product_Test.id = Product.id;


CREATE CLUSTERED INDEX Product_index_id
ON Product_Test (id)

SELECT * 
FROM Product_Test FULL JOIN Product
ON Product_Test.id = Product.id;

Drop index Product_index_id on Product_Test
