-- =========================
-- CLIENTS (10 records)
-- =========================
INSERT INTO Clients (FirstName, LastName, Phone, Email)
VALUES
('John', 'Smith', '0711111111', 'john.smith@mail.com'),
('Emma', 'Johnson', '0711111112', 'emma.johnson@mail.com'),
('Michael', 'Brown', '0711111113', 'michael.brown@mail.com'),
('Sarah', 'Davis', '0711111114', 'sarah.davis@mail.com'),
('David', 'Wilson', '0711111115', 'david.wilson@mail.com'),
('Anna', 'Taylor', '0711111116', 'anna.taylor@mail.com'),
('Robert', 'Anderson', '0711111117', 'robert.anderson@mail.com'),
('Maria', 'Thomas', '0711111118', 'maria.thomas@mail.com'),
('James', 'Moore', '0711111119', 'james.moore@mail.com'),
('Laura', 'Martin', '0711111120', 'laura.martin@mail.com');

-- =========================
-- COMPUTERS (10 records)
-- =========================
INSERT INTO Computers (PcNumber, Status, Specifications)
VALUES
('PC-01', 'Available', 'i5, 16GB RAM, GTX 1660'),
('PC-02', 'Available', 'i7, 16GB RAM, RTX 2060'),
('PC-03', 'Occupied', 'i5, 8GB RAM, GTX 1050'),
('PC-04', 'Available', 'i9, 32GB RAM, RTX 3070'),
('PC-05', 'Available', 'i5, 16GB RAM, GTX 1660'),
('PC-06', 'Broken', 'i3, 8GB RAM'),
('PC-07', 'Available', 'i7, 16GB RAM, RTX 3060'),
('PC-08', 'Occupied', 'i5, 16GB RAM, GTX 1660'),
('PC-09', 'Available', 'i7, 32GB RAM, RTX 3080'),
('PC-10', 'Available', 'i5, 16GB RAM, GTX 1650');

-- =========================
-- GAMES (10 records)
-- =========================
INSERT INTO Games (Name, Genre)
VALUES
('Counter-Strike 2', 'FPS'),
('League of Legends', 'MOBA'),
('Dota 2', 'MOBA'),
('Valorant', 'FPS'),
('Minecraft', 'Sandbox'),
('Fortnite', 'Battle Royale'),
('GTA V', 'Open World'),
('FIFA 24', 'Sports'),
('Call of Duty', 'FPS'),
('PUBG', 'Battle Royale');

-- =========================
-- SESSIONS (10 records)
-- NOTE: ClientId and ComputerId must exist
-- =========================
INSERT INTO Sessions (ClientId, ComputerId, StartTime, EndTime)
VALUES
(1, 1, '2026-04-01 10:00', '2026-04-01 12:00'),
(2, 2, '2026-04-01 11:00', '2026-04-01 13:30'),
(3, 3, '2026-04-01 12:00', '2026-04-01 14:00'),
(4, 4, '2026-04-02 09:00', '2026-04-02 11:00'),
(5, 5, '2026-04-02 10:30', '2026-04-02 12:30'),
(6, 7, '2026-04-02 13:00', '2026-04-02 15:00'),
(7, 8, '2026-04-03 10:00', '2026-04-03 12:00'),
(8, 9, '2026-04-03 11:00', '2026-04-03 13:00'),
(9, 10, '2026-04-03 12:00', '2026-04-03 14:00'),
(10, 1, '2026-04-03 15:00', '2026-04-03 17:00');

-- =========================
-- SESSION GAMES (10 records)
-- =========================
INSERT INTO SessionGames (SessionId, GameId)
VALUES
(1, 1),
(2, 2),
(3, 3),
(4, 4),
(5, 5),
(6, 6),
(7, 7),
(8, 8),
(9, 9),
(10, 10);

-- =========================
-- PAYMENTS (10 records)
-- =========================
INSERT INTO Payments (SessionId, Amount, PaymentMethod, PaymentDate)
VALUES
(1, 10.00, 'Cash', '2026-04-01'),
(2, 15.50, 'Card', '2026-04-01'),
(3, 12.00, 'Cash', '2026-04-01'),
(4, 10.00, 'Cash', '2026-04-02'),
(5, 13.50, 'Card', '2026-04-02'),
(6, 14.00, 'Cash', '2026-04-02'),
(7, 11.00, 'Card', '2026-04-03'),
(8, 16.00, 'Cash', '2026-04-03'),
(9, 18.00, 'Card', '2026-04-03'),
(10, 20.00, 'Cash', '2026-04-03');