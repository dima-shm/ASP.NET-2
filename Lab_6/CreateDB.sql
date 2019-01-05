CREATE DATABASE WSSDA;

USE WSSDA;

CREATE TABLE [Student] (
	[id] int IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[name] nvarchar(50) NOT NULL
);

CREATE TABLE [Note] (
	[id] int IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[subject] nvarchar(50) NOT NULL,
	[note] int NOT NULL,
	[studentId] int NOT NULL,
	CONSTRAINT [FK_Student] FOREIGN KEY([studentId]) REFERENCES Student([id])
);

SET IDENTITY_INSERT [dbo].[Student] ON 
INSERT [dbo].[Student] ([id], [name]) VALUES (1, N'������ ����')
INSERT [dbo].[Student] ([id], [name]) VALUES (2, N'������ ����')
INSERT [dbo].[Student] ([id], [name]) VALUES (3, N'������� �����')
SET IDENTITY_INSERT [dbo].[Student] OFF

SET IDENTITY_INSERT [dbo].[Note] ON 
INSERT [dbo].[Note] ([id], [subject], [note], [studentId]) VALUES (1, N'���', 8, 1)
INSERT [dbo].[Note] ([id], [subject], [note], [studentId]) VALUES (2, N'���������', 7, 1)
INSERT [dbo].[Note] ([id], [subject], [note], [studentId]) VALUES (3, N'�������������� ��', 9, 1)
INSERT [dbo].[Note] ([id], [subject], [note], [studentId]) VALUES (4, N'���', 7, 2)
INSERT [dbo].[Note] ([id], [subject], [note], [studentId]) VALUES (5, N'���������', 6, 2)
INSERT [dbo].[Note] ([id], [subject], [note], [studentId]) VALUES (6, N'�������������� ��', 9, 2)
INSERT [dbo].[Note] ([id], [subject], [note], [studentId]) VALUES (7, N'���', 6, 3)
INSERT [dbo].[Note] ([id], [subject], [note], [studentId]) VALUES (8, N'���������', 9, 3)
INSERT [dbo].[Note] ([id], [subject], [note], [studentId]) VALUES (9, N'�������������� ��', 6, 3)
SET IDENTITY_INSERT [dbo].[Note] OFF