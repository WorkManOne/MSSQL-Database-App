CREATE TABLE Product_Test (
		id int NOT NULL, 
		name varchar(200) NOT NULL,
		costForHundred real NOT NULL,
		caloriesForHundred real NOT NULL
);

CREATE TABLE Users_Test (
	id int NOT NULL, 
	name varchar(200) NOT NULL,
	registeredAt date NOT NULL,
	amountPublished int NOT NULL,
	pass varchar(200) NOT NULL
);

declare @n int = 1;
while (@n < 100000)
begin
    insert into Product_Test (id, name, costForHundred, caloriesForHundred)
    select @n, 'ProductName' + cast(@n as nvarchar(10)), RAND() * 100 , RAND() * 1000;
	insert into Users_Test (id, name, registeredAt, amountPublished, pass)
    select @n, 'Username' + cast(@n as nvarchar(10)), dateadd(day, -RAND() * 1000, Getdate()), RAND() * 100, cast(@n as nvarchar(10));
    set @n = @n + 1;
end



