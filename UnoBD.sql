DROP DATABASE IF EXISTS Uno;
CREATE DATABASE Uno;
USE Uno;

/* Entities Player & Game + Additional tables*/
CREATE TABLE Player (
	PlayerID INT NOT NULL AUTO_INCREMENT,
	Username VARCHAR(30) NOT NULL,
	Password VARCHAR(30),
	Points INT,
	GamesWon INT,
	PRIMARY KEY (PlayerID),
	UNIQUE (Username) -- Acts as a secondary key, so there won't be two iddentical usernames
);

CREATE TABLE Game (
	GameID INT NOT NULL AUTO_INCREMENT,
	GameDate VARCHAR(10),
	Duration INT,
	Winner VARCHAR(30),
	NumOfMoves INT,
	GameState VARCHAR(15), -- Not started , On-course, Ended
	PRIMARY KEY (GameID)
);

CREATE TABLE Cards (
	CardID INT NOT NULL AUTO_INCREMENT,
	CNumber INT,
	CColor VARCHAR(10) NOT NULL,
	CType VARCHAR(10) NOT NULL,
	CAction VARCHAR(10),
	PRIMARY KEY (CardID)
);

CREATE TABLE Deck (
	DeckID INT,
	GameID INT,
	PlayerID INT,
	CardID INT,
	PRIMARY KEY (GameID, PlayerID, CardID),
	FOREIGN KEY (GameID) REFERENCES Game(GameID),
	FOREIGN KEY (PlayerID) REFERENCES Player(PlayerID),
	FOREIGN KEY (CardID) REFERENCES Cards(CardID)
);

-- Insert data into Player table
INSERT INTO Player (PlayerID, Username, Password, Points, GamesWon)
VALUES
(1, 'Dani', 'Rodero', 15, 2),
(2, 'Ruben', 'Escalera', 12, 0),
(3, 'Erik', 'Medialdea', 18, 1),
(4, 'Sergio', 'Lopez', 20, 4);

-- Insert data into Game table
INSERT INTO Game (GameID, GameDate, Duration, Winner, NumOfMoves, GameState)
VALUES
(1, '09/09/2024', 30, 'Dani', 28, 'Ended'),
(2, '07/10/2024', 45, 'Erik', 65, 'Ended'),
(3, '07/10/2024', 14, 'Sergio', 23, 'Ended');

-- Insert data into Cards table
INSERT INTO Cards (CardID, CNumber, CColor, CType)
VALUES
(1, 1, 'Red', 'Number'),
(2, 7, 'Red', 'Number'),
(3, 6, 'Red', 'Number'),
(4, 5, 'Green', 'Number'),
(5, 8, 'Green', 'Number'),
(6, 3, 'Green', 'Number'),
(7, 11, 'Blue', 'Action'),
(8, 9, 'Blue', 'Number'),
(9, 13, 'Blue', 'Action'),
(10, 12, 'Blue', 'Action'),
(11, 10, 'Yellow', 'Action'),
(12, 2, 'Yellow', 'Number'),
(13, 1, 'Yellow', 'Number'),
(14, 13, 'Yellow', 'Action');

-- Insert data into Deck table
INSERT INTO Deck (DeckID, GameID, PlayerID, CardID)
VALUES
(0, 1, 1, 1),
(0, 1, 1, 2),
(0, 1, 1, 3),
(1, 2, 2, 4),
(1, 2, 2, 5),
(1, 2, 2, 6),
(2, 2, 2, 7),
(2, 1, 3, 8),
(2, 1, 3, 9);