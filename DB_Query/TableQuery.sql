DROP TABLE IF EXISTS Users;
CREATE TABLE Users (
    Id INT PRIMARY KEY,
    FullName NVARCHAR(100),
    Email NVARCHAR(100),
    Role NVARCHAR(50)
);

-- Contoh data
INSERT INTO Users (Id, FullName, Email, Role) VALUES
(1, 'Alice Johnson', 'alice@example.com', 'Admin'),
(2, 'Bob Smith', 'bob@example.com', 'User'),
(3, 'Charlie Brown', 'charlie@example.com', 'Manager'),
(4, 'Diana Prince', 'diana@example.com', 'Editor'),
(5, 'Ethan Hunt', 'ethan@example.com', 'User');

-- Stored Procedure pakai CTE
-- DROP PROCEDURE IF EXISTS GetUsers;

EXEC GetUsers;
