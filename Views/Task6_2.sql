CREATE VIEW thisYearSeasons
AS   
	SELECT Season.id, Season.name, Season.dateStart, Season.dateEnd
FROM Season
WHERE DATEPART (YEAR, dateEnd) = DATEPART (YEAR, GETDATE()) OR DATEPART (YEAR, dateStart) = DATEPART (YEAR, GETDATE())
WITH CHECK OPTION
GO

SELECT * FROM thisYearSeasons;

INSERT INTO thisYearSeasons
    VALUES ('День рождения Керила', '27.03.2023', '27.05.2023');

INSERT INTO thisYearSeasons
    VALUES ('Тыквенный спас', '27.11.2022', '27.01.2023');

INSERT INTO thisYearSeasons
    VALUES ('Первое сентября 2022', '01.09.2022', '02.09.2022');

SELECT * FROM thisYearSeasons

DELETE FROM thisYearSeasons

DROP VIEW thisYearSeasons