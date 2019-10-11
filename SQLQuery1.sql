CREATE TABLE Game(
ID int IDENTITY(1,1) PRIMARY KEY NOT NULL,
Title varchar(255) NOT NULL,
ReleaseDate datetime2(7) NOT NULL,
Genre varchar(255) NULL,
Price decimal(18,2) NOT NULL


);