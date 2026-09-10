/*
 MDB622 FA2 Practical Project
 Database: KhayelitshaLibraryDB
 SQL Server / LocalDB
*/

IF DB_ID(N'KhayelitshaLibraryDB') IS NULL
BEGIN
    CREATE DATABASE KhayelitshaLibraryDB;
END
GO

USE KhayelitshaLibraryDB;
GO

-- Drop objects in dependency order when rebuilding the database.
IF OBJECT_ID('dbo.Loan', 'U') IS NOT NULL DROP TABLE dbo.Loan;
IF OBJECT_ID('dbo.BookCopy', 'U') IS NOT NULL DROP TABLE dbo.BookCopy;
IF OBJECT_ID('dbo.BookTitle', 'U') IS NOT NULL DROP TABLE dbo.BookTitle;
IF OBJECT_ID('dbo.Staff', 'U') IS NOT NULL DROP TABLE dbo.Staff;
IF OBJECT_ID('dbo.Member', 'U') IS NOT NULL DROP TABLE dbo.Member;
GO

CREATE TABLE dbo.Member
(
    MemberID INT IDENTITY(1,1) NOT NULL
        CONSTRAINT PK_Member PRIMARY KEY,
    FullName NVARCHAR(100) NOT NULL,
    Address NVARCHAR(250) NOT NULL,
    Phone NVARCHAR(20) NOT NULL,
    JoinDate DATE NOT NULL
);
GO

CREATE TABLE dbo.BookTitle
(
    BookTitleID INT IDENTITY(1,1) NOT NULL
        CONSTRAINT PK_BookTitle PRIMARY KEY,
    Title NVARCHAR(200) NOT NULL,
    Author NVARCHAR(150) NOT NULL,
    ISBN NVARCHAR(20) NULL,
    PublishedYear INT NULL,
    CONSTRAINT CK_BookTitle_PublishedYear
        CHECK (PublishedYear IS NULL OR PublishedYear BETWEEN 1000 AND YEAR(GETDATE()))
);
GO

CREATE TABLE dbo.BookCopy
(
    CopyID INT IDENTITY(1,1) NOT NULL
        CONSTRAINT PK_BookCopy PRIMARY KEY,
    BookTitleID INT NOT NULL,
    Status NVARCHAR(20) NOT NULL
        CONSTRAINT DF_BookCopy_Status DEFAULT N'Available',
    CONSTRAINT FK_BookCopy_BookTitle
        FOREIGN KEY (BookTitleID) REFERENCES dbo.BookTitle(BookTitleID),
    CONSTRAINT CK_BookCopy_Status
        CHECK (Status IN (N'Available', N'On Loan', N'Lost', N'Damaged'))
);
GO

CREATE TABLE dbo.Staff
(
    StaffID INT IDENTITY(1,1) NOT NULL
        CONSTRAINT PK_Staff PRIMARY KEY,
    FullName NVARCHAR(100) NOT NULL,
    Phone NVARCHAR(20) NULL
);
GO

CREATE TABLE dbo.Loan
(
    LoanID INT IDENTITY(1,1) NOT NULL
        CONSTRAINT PK_Loan PRIMARY KEY,
    MemberID INT NOT NULL,
    CopyID INT NOT NULL,
    StaffID INT NOT NULL,
    LoanDate DATE NOT NULL,
    DueDate DATE NOT NULL,
    ReturnDate DATE NULL,
    CONSTRAINT FK_Loan_Member
        FOREIGN KEY (MemberID) REFERENCES dbo.Member(MemberID),
    CONSTRAINT FK_Loan_BookCopy
        FOREIGN KEY (CopyID) REFERENCES dbo.BookCopy(CopyID),
    CONSTRAINT FK_Loan_Staff
        FOREIGN KEY (StaffID) REFERENCES dbo.Staff(StaffID),
    CONSTRAINT CK_Loan_Dates
        CHECK (DueDate >= LoanDate AND (ReturnDate IS NULL OR ReturnDate >= LoanDate))
);
GO

-- A copy can have many historical loans, but only one active loan.
CREATE UNIQUE INDEX UX_Loan_ActiveCopy
ON dbo.Loan(CopyID)
WHERE ReturnDate IS NULL;
GO

INSERT INTO dbo.Member (FullName, Address, Phone, JoinDate)
VALUES
(N'Nomsa Mbeki', N'12 Khaya Street, Khayelitsha', N'0712345678', '2026-01-15'),
(N'Peter Daniels', N'8 Spine Road, Khayelitsha', N'0723456789', '2026-02-03'),
(N'Ayanda Ndlovu', N'21 Site C, Khayelitsha', N'0734567890', '2026-02-20'),
(N'Lebo Jacobs', N'5 Mew Way, Khayelitsha', N'0745678901', '2026-03-10'),
(N'Sipho Dlamini', N'44 Mandela Park, Khayelitsha', N'0756789012', '2026-04-01');
GO

INSERT INTO dbo.BookTitle (Title, Author, ISBN, PublishedYear)
VALUES
(N'To Kill a Mockingbird', N'Harper Lee', N'9780061120084', 1960),
(N'1984', N'George Orwell', N'9780451524935', 1949),
(N'The Alchemist', N'Paulo Coelho', N'9780062315007', 1988),
(N'Long Walk to Freedom', N'Nelson Mandela', N'9780316548182', 1994),
(N'The Hobbit', N'J.R.R. Tolkien', N'9780547928227', 1937);
GO

INSERT INTO dbo.BookCopy (BookTitleID, Status)
VALUES
(1, N'Available'),
(1, N'Available'),
(2, N'On Loan'),
(2, N'Available'),
(3, N'Available'),
(4, N'On Loan'),
(5, N'Available'),
(5, N'Available');
GO

INSERT INTO dbo.Staff (FullName, Phone)
VALUES
(N'Thandiwe Mokoena', N'0761111111'),
(N'James Petersen', N'0762222222'),
(N'Zanele Khumalo', N'0763333333');
GO

-- Five sample loan records: a mixture of returned and active/overdue loans.
INSERT INTO dbo.Loan (MemberID, CopyID, StaffID, LoanDate, DueDate, ReturnDate)
VALUES
(1, 1, 1, '2026-07-01', '2026-07-15', '2026-07-12'),
(2, 2, 2, '2026-07-10', '2026-07-24', '2026-07-22'),
(3, 3, 1, '2026-08-01', '2026-08-15', NULL),
(4, 6, 3, '2026-08-20', '2026-09-03', NULL),
(5, 7, 2, '2026-08-25', '2026-09-08', '2026-09-05');
GO

-- Example queries required by the assessment.
-- Overdue loans:
SELECT l.LoanID, m.FullName AS MemberName, bt.Title AS BookTitle,
       l.DueDate
FROM dbo.Loan AS l
JOIN dbo.Member AS m ON m.MemberID = l.MemberID
JOIN dbo.BookCopy AS bc ON bc.CopyID = l.CopyID
JOIN dbo.BookTitle AS bt ON bt.BookTitleID = bc.BookTitleID
WHERE l.ReturnDate IS NULL
  AND l.DueDate < CAST(GETDATE() AS DATE)
ORDER BY l.DueDate;
GO

-- Number of loans per member:
SELECT m.MemberID, m.FullName, COUNT(l.LoanID) AS LoanCount
FROM dbo.Member AS m
LEFT JOIN dbo.Loan AS l ON l.MemberID = m.MemberID
GROUP BY m.MemberID, m.FullName
ORDER BY LoanCount DESC, m.FullName;
GO
