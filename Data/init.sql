-- =========================
-- CLIENTS TABLE
-- =========================
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Clients')
BEGIN
    CREATE TABLE Clients (
        Id INT PRIMARY KEY IDENTITY(1,1),
        FirstName NVARCHAR(50) NOT NULL,
        LastName NVARCHAR(50) NOT NULL,
        Phone NVARCHAR(20) NOT NULL,
        Email NVARCHAR(100) NOT NULL
    );
END

-- =========================
-- COMPUTERS TABLE
-- =========================
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Computers')
BEGIN
    CREATE TABLE Computers (
        Id INT PRIMARY KEY IDENTITY(1,1),
        PcNumber NVARCHAR(20) NOT NULL,
        Status NVARCHAR(20) NOT NULL DEFAULT 'Available', 
        Specifications NVARCHAR(200) NULL
    );
END

-- =========================
-- GAMES TABLE
-- =========================
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Games')
BEGIN
    CREATE TABLE Games (
        Id INT PRIMARY KEY IDENTITY(1,1),
        Name NVARCHAR(100) NOT NULL,
        Genre NVARCHAR(50) NOT NULL
    );
END

-- =========================
-- SESSIONS TABLE
-- =========================
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Sessions')
BEGIN
    CREATE TABLE Sessions (
        Id INT PRIMARY KEY IDENTITY(1,1),
        ClientId INT NOT NULL,
        ComputerId INT NOT NULL,
        StartTime DATETIME NOT NULL DEFAULT GETDATE(),
        EndTime DATETIME NULL,

        FOREIGN KEY (ClientId) REFERENCES Clients(Id),
        FOREIGN KEY (ComputerId) REFERENCES Computers(Id)
    );
END

-- =========================
-- SESSION GAMES TABLE
-- =========================
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'SessionGames')
BEGIN
    CREATE TABLE SessionGames (
        Id INT PRIMARY KEY IDENTITY(1,1),
        SessionId INT NOT NULL,
        GameId INT NOT NULL,

        FOREIGN KEY (SessionId) REFERENCES Sessions(Id),
        FOREIGN KEY (GameId) REFERENCES Games(Id)
    );
END

-- =========================
-- PAYMENTS TABLE
-- =========================
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Payments')
BEGIN
    CREATE TABLE Payments (
        Id INT PRIMARY KEY IDENTITY(1,1),
        SessionId INT NOT NULL,
        Amount DECIMAL(10,2) NOT NULL,
        PaymentMethod NVARCHAR(20) NOT NULL,
        PaymentDate DATETIME NOT NULL DEFAULT GETDATE(),

        FOREIGN KEY (SessionId) REFERENCES Sessions(Id)
    );
END