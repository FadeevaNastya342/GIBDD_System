DROP TABLE IF EXISTS Drivers;
DROP TABLE IF EXISTS Fines;

CREATE TABLE Drivers (
    Id TEXT PRIMARY KEY,
    LastName TEXT NOT NULL,
    FirstName TEXT NOT NULL,
    Patronymic TEXT,
    PassportSeries TEXT,
    PassportNumber TEXT,
    RegCity TEXT,
    RegAddressFull TEXT,
    LiveCity TEXT,
    LiveAddressFull TEXT,
    Workplace TEXT,
    Position TEXT,
    Phone TEXT,
    Email TEXT,
    PhotoPath TEXT,
    Notes TEXT,
    LicenseNumber TEXT,
    LicenseIssueDate TEXT,
    LicenseExpiryDate TEXT,
    LicenseDepartmentCode TEXT,
    LicenseIssuePlace TEXT,
    Categories TEXT
);

CREATE TABLE Fines (
    Id TEXT PRIMARY KEY,
    DriverId TEXT,
    CarPlate TEXT,
    Amount REAL,
    ViolationDate TEXT,
    ViolationType TEXT,
    IsPaid INTEGER DEFAULT 0,
    FOREIGN KEY(DriverId) REFERENCES Drivers(Id)
);