CREATE TABLE Product_Test (
		id int IDENTITY(1,1) NOT NULL CONSTRAINT PK_Product_Test PRIMARY KEY, 
		name varchar(200) NOT NULL,
		costForHundred real NOT NULL,
		caloriesForHundred real NOT NULL
);

declare @n int = 1;
while (@n < 100000)
begin
    insert into Product_Test (name, costForHundred, caloriesForHundred)
    select 'ProductName' + cast(@n as nvarchar(10)), RAND() * 100 , RAND() * 1000;
    set @n = @n + 1;
end

