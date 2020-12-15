
PRAGMA foreign_keys = ON;

BEGIN TRANSACTION;

CREATE TABLE Photographer(
    id INTEGER PRIMARY KEY AUTOINCREMENT,
    name TEXT NOT NULL,
    surename TEXT NOT NULL,
    addess TEXT NOT NULL,
    city TEXT NOT NULL,
    postalcode INT NOT NULL,
    telephone INT NOT NULL
);

CREATE TABLE Application(
    id INTEGER PRIMARY KEY AUTOINCREMENT,
    date TEXT NOT NULL,
    equimentDescription TEXT NOT NULL,
    resume TEXT NOT NULL,
    photographerId INT REFERENCES Fotografo (id)
);

COMMIT;
