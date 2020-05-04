DELETE FROM Users
DELETE FROM Rentals
DELETE FROM RentalItems
DELETE FROM CategoryBooks
DELETE FROM Categories
DELETE FROM Books
DELETE FROM BookCopies

SET IDENTITY_INSERT [dbo].[Users] ON
INSERT INTO [dbo].[Users] ([UserId], [UserName], [Password], [FullName], [Email], [Role], [BirthDate]) VALUES (1, N'admin', N'admin', N'Administrator', N'admin@test.com', 0, NULL)
INSERT INTO [dbo].[Users] ([UserId], [UserName], [Password], [FullName], [Email], [Role], [BirthDate]) VALUES (2, N'admin', N'admin', N'Administrator', N'admin@test.com', 0, NULL)
INSERT INTO [dbo].[Users] ([UserId], [UserName], [Password], [FullName], [Email], [Role], [BirthDate]) VALUES (3, N'ben', N'ben', N'Benoît Penelle', N'ben@test.com', 2, N'1968-10-01 00:00:00')
INSERT INTO [dbo].[Users] ([UserId], [UserName], [Password], [FullName], [Email], [Role], [BirthDate]) VALUES (4, N'bruno', N'bruno', N'Bruno Lacroix', N'bruno@test.com', 1, NULL)
SET IDENTITY_INSERT [dbo].[Users] OFF

SET IDENTITY_INSERT [dbo].[Rentals] ON
INSERT INTO [dbo].[Rentals] ([RentalId], [RentalDate], [User_UserId]) VALUES (1, NULL, 3)
SET IDENTITY_INSERT [dbo].[Rentals] OFF

SET IDENTITY_INSERT [dbo].[RentalItems] ON
INSERT INTO [dbo].[RentalItems] ([RentalItemId], [ReturnDate], [BookCopy_BookCopyId], [Rental_RentalId]) VALUES (1, NULL, 1, 1)
INSERT INTO [dbo].[RentalItems] ([RentalItemId], [ReturnDate], [BookCopy_BookCopyId], [Rental_RentalId]) VALUES (2, NULL, 2, 1)
SET IDENTITY_INSERT [dbo].[RentalItems] OFF

INSERT INTO [dbo].[CategoryBooks] ([Category_CategoryId], [Book_BookId]) VALUES (5, 1)
INSERT INTO [dbo].[CategoryBooks] ([Category_CategoryId], [Book_BookId]) VALUES (2, 2)
INSERT INTO [dbo].[CategoryBooks] ([Category_CategoryId], [Book_BookId]) VALUES (3, 2)
INSERT INTO [dbo].[CategoryBooks] ([Category_CategoryId], [Book_BookId]) VALUES (3, 3)
INSERT INTO [dbo].[CategoryBooks] ([Category_CategoryId], [Book_BookId]) VALUES (4, 3)

SET IDENTITY_INSERT [dbo].[Categories] ON
INSERT INTO [dbo].[Categories] ([CategoryId], [Name]) VALUES (1, N'Informatique')
INSERT INTO [dbo].[Categories] ([CategoryId], [Name]) VALUES (2, N'Science Fiction')
INSERT INTO [dbo].[Categories] ([CategoryId], [Name]) VALUES (3, N'Roman')
INSERT INTO [dbo].[Categories] ([CategoryId], [Name]) VALUES (4, N'Littérature')
INSERT INTO [dbo].[Categories] ([CategoryId], [Name]) VALUES (5, N'Essai')
SET IDENTITY_INSERT [dbo].[Categories] OFF

SET IDENTITY_INSERT [dbo].[Books] ON
INSERT INTO [dbo].[Books] ([BookId], [Isbn], [Author], [Title], [Editor], [PicturePath]) VALUES (1, N'123', N'Duchmol', N'Java for Dummies', N'EPFC', N'123.jpg')
INSERT INTO [dbo].[Books] ([BookId], [Isbn], [Author], [Title], [Editor], [PicturePath]) VALUES (2, N'456', N'Tolkien', N'Le Seigneur des Anneaux', N'Bourgeois', N'456.jpg')
INSERT INTO [dbo].[Books] ([BookId], [Isbn], [Author], [Title], [Editor], [PicturePath]) VALUES (3, N'789', N'Victor Hugo', N'Les misérables', N'XO', N'789.jpg')
SET IDENTITY_INSERT [dbo].[Books] OFF

SET IDENTITY_INSERT [dbo].[BookCopies] ON
INSERT INTO [dbo].[BookCopies] ([BookCopyId], [AcquisitionDate], [Book_BookId]) VALUES (1, N'2019-05-10 14:46:55', 1)
INSERT INTO [dbo].[BookCopies] ([BookCopyId], [AcquisitionDate], [Book_BookId]) VALUES (2, N'2019-05-10 14:46:55', 2)
INSERT INTO [dbo].[BookCopies] ([BookCopyId], [AcquisitionDate], [Book_BookId]) VALUES (3, N'2019-05-10 14:46:55', NULL)
INSERT INTO [dbo].[BookCopies] ([BookCopyId], [AcquisitionDate], [Book_BookId]) VALUES (4, N'2018-12-31 17:30:00', 3)
INSERT INTO [dbo].[BookCopies] ([BookCopyId], [AcquisitionDate], [Book_BookId]) VALUES (5, N'2018-12-31 17:30:00', 3)
INSERT INTO [dbo].[BookCopies] ([BookCopyId], [AcquisitionDate], [Book_BookId]) VALUES (6, N'2018-12-31 17:30:00', 3)
SET IDENTITY_INSERT [dbo].[BookCopies] OFF

