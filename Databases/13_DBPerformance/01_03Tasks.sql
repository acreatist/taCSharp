-- 1: Create a table in SQL Server with 10 000 000 log entries (date + text). Search in the table by date range. 
--	Check the speed (without caching).

DECLARE @Counter int = 0
WHILE (@Counter < 1000000)
BEGIN
	DECLARE @Date datetime
	SET @Date = DATEADD(month, CONVERT(varbinary, newid()) % (50 * 12), getdate())
	INSERT INTO LogsDates VALUES(@Date, 'test' +  CONVERT(nvarchar(100), @Counter))
	SELECT @Date, 'test' FROM LogsDates
	SET @Counter = @Counter + 1
END
-- It got to somewhere, 3 times non-responding..

CHECKPOINT; DBCC DROPCLEANBUFFERS;
SELECT LogDate FROM LogsDates
WHERE LogDate BETWEEN '1900' AND '2100'
 
-- 2: Add an index to speed-up the search by date. Test the search speed (after cleaning the cache).
CREATE INDEX IDX_LogsDates_LogDate ON LogsDates(LogDate)
 
CHECKPOINT; DBCC DROPCLEANBUFFERS; -- Empty the SQL Server cache

SELECT * FROM LogsDates
WHERE LogDate BETWEEN '1900' AND '2100'

-- 3: Add a full text index for the text column. Try to search with and without the full-text index and compare the speed.

-- letting this go.. a lot of other homeworks need to be done.
CREATE FULLTEXT CATALOG LogsDatesFullText
WITH ACCENT_SENSITIVITY = OFF

CREATE FULLTEXT INDEX ON LogsDates(LogText)
KEY INDEX PK_LogText
ON LogsDatesFullText
WITH CHANGE_TRACKING AUTO

SELECT * FROM LogsDates
WHERE LogText LIKE '%test%'

-- empty indexes
CHECKPOINT; DBCC DROPCLEANBUFFERS;

SELECT * FROM LogsDates
WHERE LogText LIKE '%test%'

