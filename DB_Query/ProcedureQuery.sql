
-- Stored Procedure pakai CTE
CREATE PROCEDURE GetUsers
AS
BEGIN
    WITH UserCTE AS (
        SELECT Id, FullName, Email, Role FROM Users
    )
    SELECT * FROM UserCTE;
END;
