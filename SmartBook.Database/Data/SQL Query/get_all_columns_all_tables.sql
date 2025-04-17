-- Connect to your SmartBookDb database in Azure Data Studio

-- Query to get the columns of all tables in the database
SELECT
    TABLE_NAME,
    COLUMN_NAME,
    ORDINAL_POSITION,
    DATA_TYPE,
    IS_NULLABLE
FROM
    INFORMATION_SCHEMA.COLUMNS
WHERE
    TABLE_SCHEMA = 'dbo' -- Assuming your tables are in the 'dbo' schema
ORDER BY
    TABLE_NAME,
    ORDINAL_POSITION;