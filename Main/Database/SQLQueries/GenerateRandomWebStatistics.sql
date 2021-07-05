USE [no_data_DuoDatabase_version-1.3.5]
GO

DECLARE @Dt datetime
DECLARE @Dt2 datetime
DECLARE @a float
DECLARE @b int
DECLARE @c float
DECLARE @d int
DECLARE @e float
DECLARE @f int
DECLARE @x int

SELECT @Dt = '2021-04-14'
SELECT @Dt2 = '2021-07-05'
SELECT @a = 0.06	
SELECT @b = 1	
SELECT @c = 0.04
SELECT @d = 1
SELECT @e = 0.02
SELECT @f = 1
SELECT @x = 5

--Please note: This code can only be run once
WHILE @Dt <= @Dt2
	BEGIN
		INSERT INTO WebsiteStatistics VALUES
											(
												@Dt,
												@a*POWER(@x,2) + @b*@x*RAND() + 10,
												@c*POWER(@x,2) + @d*@x*RAND(),
												@e*POWER(@x,2) + @f*@x*RAND()
											)

		SELECT @Dt = DATEADD(day, 1, @Dt)
		SELECT @x = @x + 1
	END

SELECT @x
	