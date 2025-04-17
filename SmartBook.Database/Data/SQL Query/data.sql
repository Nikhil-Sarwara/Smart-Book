-- Connect to your SmartBookDb database in Azure Data Studio

-- Delete all data from the linking tables first to avoid foreign key constraint violations
DELETE FROM BookAuthors;
DELETE FROM BookGenres;
DELETE FROM Loans;
DELETE FROM ReadingProgresses;
DELETE FROM Reviews;

-- Delete all data from the main tables
DELETE FROM Books;
DELETE FROM Authors;
DELETE FROM Publishers;
DELETE FROM Genres;
DELETE FROM Users;

-- Insert dummy data into the Authors table (AuthorId is likely auto-incrementing)
INSERT INTO Authors (Name, Biography) VALUES
('Jane Doe', 'A renowned author of mystery novels.'),
('John Smith', 'A prolific writer of science fiction.'),
('Alice Brown', 'An award-winning historical fiction author.'),
('Bob Green', 'A popular thriller writer.');

-- Insert dummy data into the Publishers table (PublisherId is likely auto-incrementing)
INSERT INTO Publishers (Name, Location) VALUES
('Penguin Random House', 'New York, USA'),
('HarperCollins', 'London, UK'),
('Simon & Schuster', 'New York, USA');

-- Insert dummy data into the Genres table (GenreId is likely auto-incrementing)
INSERT INTO Genres (Name, Description) VALUES
('Mystery', 'Fiction involving a crime or secret that needs to be solved.'),
('Science Fiction', 'Fiction based on imagined future scientific or technological advances.'),
('Historical Fiction', 'Fiction set in the past, often incorporating real historical figures or events.'),
('Thriller', 'Fiction with a suspenseful plot that keeps the reader on the edge of their seat.');

-- Insert dummy data into the Books table (BookId and PublisherId are likely auto-incrementing and foreign key respectively)
INSERT INTO Books (Title, ISBN, PublicationDate, PublisherId)
SELECT 'The Secret of the Hidden Key', '978-1234567890', '2023-05-15', (SELECT PublisherId FROM Publishers WHERE Name = 'Penguin Random House') UNION ALL
SELECT 'Echoes of the Cosmos', '978-0987654321', '2024-01-20', (SELECT PublisherId FROM Publishers WHERE Name = 'HarperCollins') UNION ALL
SELECT 'The Queen''s Gambit', '978-1122334455', '2022-11-01', (SELECT PublisherId FROM Publishers WHERE Name = 'Penguin Random House') UNION ALL
SELECT 'Nightfall', '978-5544332211', '2024-08-10', (SELECT PublisherId FROM Publishers WHERE Name = 'Simon & Schuster') UNION ALL
SELECT 'Whispers in the Wind', '978-9988776655', '2023-03-25', (SELECT PublisherId FROM Publishers WHERE Name = 'HarperCollins');

-- Insert dummy data into the Users table (UserId is likely auto-incrementing)
-- Note: In a real application, you would typically hash passwords.
INSERT INTO Users (Username, Email, Password, Name, RegistrationDate) VALUES
('johndoe', 'john.doe@example.com', 'password123', 'John Doe', '2024-04-01'),
('alicesmith', 'alice.smith@example.com', 'securepass', 'Alice Smith', '2024-04-05'),
('bobthebuilder', 'bob.builder@example.com', 'buildit', 'Bob Builder', '2024-04-10');

-- Insert data into the BookAuthors linking table (BookId and AuthorId are foreign keys, BookAuthorId is likely auto-incrementing)
INSERT INTO BookAuthors (BookId, AuthorId)
SELECT b.BookId, a.AuthorId FROM Books b CROSS JOIN Authors a WHERE b.Title = 'The Secret of the Hidden Key' AND a.Name IN ('Jane Doe', 'Alice Brown') UNION ALL
SELECT b.BookId, a.AuthorId FROM Books b CROSS JOIN Authors a WHERE b.Title = 'Echoes of the Cosmos' AND a.Name = 'John Smith' UNION ALL
SELECT b.BookId, a.AuthorId FROM Books b CROSS JOIN Authors a WHERE b.Title = 'The Queen''s Gambit' AND a.Name = 'Alice Brown' UNION ALL
SELECT b.BookId, a.AuthorId FROM Books b CROSS JOIN Authors a WHERE b.Title = 'Nightfall' AND a.Name = 'Bob Green' UNION ALL
SELECT b.BookId, a.AuthorId FROM Books b CROSS JOIN Authors a WHERE b.Title = 'Whispers in the Wind' AND a.Name = 'Jane Doe';

-- Insert data into the BookGenres linking table (BookId and GenreId are foreign keys, BookGenreId is likely auto-incrementing)
INSERT INTO BookGenres (BookId, GenreId)
SELECT b.BookId, g.GenreId FROM Books b CROSS JOIN Genres g WHERE b.Title = 'The Secret of the Hidden Key' AND g.Name = 'Mystery' UNION ALL
SELECT b.BookId, g.GenreId FROM Books b CROSS JOIN Genres g WHERE b.Title = 'Echoes of the Cosmos' AND g.Name = 'Science Fiction' UNION ALL
SELECT b.BookId, g.GenreId FROM Books b CROSS JOIN Genres g WHERE b.Title = 'The Queen''s Gambit' AND g.Name = 'Historical Fiction' UNION ALL
SELECT b.BookId, g.GenreId FROM Books b CROSS JOIN Genres g WHERE b.Title = 'Nightfall' AND g.Name = 'Thriller' UNION ALL
SELECT b.BookId, g.GenreId FROM Books b CROSS JOIN Genres g WHERE b.Title = 'Whispers in the Wind' AND g.Name IN ('Mystery', 'Historical Fiction');

-- Insert data into the Loans table (LoanId, UserId, BookId are likely auto-incrementing and foreign keys)
INSERT INTO Loans (UserId, BookId, BorrowDate, DueDate, ReturnDate)
SELECT (SELECT UserId FROM Users WHERE Username = 'johndoe'), (SELECT BookId FROM Books WHERE Title = 'The Secret of the Hidden Key'), '2025-04-17', '2025-04-30', NULL UNION ALL
SELECT (SELECT UserId FROM Users WHERE Username = 'alicesmith'), (SELECT BookId FROM Books WHERE Title = 'The Queen''s Gambit'), '2025-04-16', '2025-04-29', NULL;

-- Insert data into the ReadingProgresses table (ProgressId, UserId, BookId are likely auto-incrementing and foreign keys)
INSERT INTO ReadingProgresses (UserId, BookId, CurrentPage, PercentageCompleted)
SELECT (SELECT UserId FROM Users WHERE Username = 'johndoe'), (SELECT BookId FROM Books WHERE Title = 'The Secret of the Hidden Key'), 150, 0.50 UNION ALL
SELECT (SELECT UserId FROM Users WHERE Username = 'bobthebuilder'), (SELECT BookId FROM Books WHERE Title = 'Echoes of the Cosmos'), 50, 0.25;

-- Insert data into the Reviews table (ReviewId, UserId, BookId are likely auto-incrementing and foreign keys)
INSERT INTO Reviews (UserId, BookId, Rating, Comment, ReviewDate)
SELECT (SELECT UserId FROM Users WHERE Username = 'johndoe'), (SELECT BookId FROM Books WHERE Title = 'The Secret of the Hidden Key'), 4, 'Enjoyed the mystery and suspense!', GETDATE() UNION ALL
SELECT (SELECT UserId FROM Users WHERE Username = 'alicesmith'), (SELECT BookId FROM Books WHERE Title = 'The Queen''s Gambit'), 5, 'A captivating historical fiction novel.', GETDATE();