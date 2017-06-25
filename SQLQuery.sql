CREATE DATABASE Arkadium
GO

CREATE TABLE Countries(
  CountryId int NOT NULL IDENTITY,
  CountryShortName nvarchar(5) NOT NULL 
CONSTRAINT PK_Countries PRIMARY KEY(CountryId )
)
GO

CREATE TABLE Boxers(
  BoxerId int NOT NULL IDENTITY,
  BoxerName nvarchar(50) NOT NULL,
  CountryId int NOT NULL 
CONSTRAINT PK_Boxer PRIMARY KEY(BoxerId)
CONSTRAINT FK_Boxers_Country FOREIGN KEY (CountryID )  REFERENCES Countries (CountryId)
)
GO 



CREATE TABLE  Rounds(
  RoundId int NOT NULL IDENTITY,
  RoundName nvarchar(50) NOT NULL 
CONSTRAINT PK_Rounds PRIMARY KEY(RoundId)
)
GO



CREATE TABLE Matches(
  MatchId int NOT NULL IDENTITY,
  FirstBoxerId  int NOT NULL,
  SecondBoxerId  int NOT NULL,
  RoundId int NOT NULL 	
CONSTRAINT PK_Matches PRIMARY KEY (MatchId),
CONSTRAINT FK_MatchResult_Boxer1 FOREIGN KEY( FirstBoxerId )  REFERENCES Boxers(BoxerId )  ,
CONSTRAINT FK_MatchResult_Boxer2 FOREIGN KEY( SecondBoxerId )  REFERENCES Boxers(BoxerId )  ,
CONSTRAINT FK_Match_Round FOREIGN KEY (RoundID )  REFERENCES Rounds (RoundId)  
)
GO



CREATE TABLE MatchResults(
  MatchResultId int NOT NULL IDENTITY,
  BoxerId int NOT NULL,
  ResultName nvarchar(5) NOT NULL,
  MatchId int NOT	NULL
CONSTRAINT PK_MatchResults PRIMARY KEY (MatchResultId),
CONSTRAINT FK_MatchResult_Boxer FOREIGN KEY( BoxerId )  REFERENCES Boxers(BoxerId )  ,
CONSTRAINT FK_MatchResult_Match FOREIGN KEY( MatchId )  REFERENCES Matches(MatchId )  
)
GO


CREATE TABLE Results(
  ResultId int NOT NULL IDENTITY,
  BoxerName nvarchar(100) NOT NULL,
  ResultName nvarchar(10) NOT NULL,
  CountryID int NOT NULL,
  RoundID int NOT NULL
CONSTRAINT PK_Result PRIMARY KEY (ResultId) 
CONSTRAINT FK_Result_Country FOREIGN KEY (CountryID )  REFERENCES Countries (CountryId),
CONSTRAINT FK_Result_Round FOREIGN KEY (RoundID )  REFERENCES Rounds (RoundId )  
)
GO
;

-- Rounds
INSERT INTO dbo.Rounds( RoundName)  VALUES('Round of 32');
INSERT INTO dbo.Rounds( RoundName)  VALUES('Round of 16');
INSERT INTO dbo.Rounds( RoundName)  VALUES('Quarter-finals');
INSERT INTO dbo.Rounds( RoundName)  VALUES('Semi-finals');
INSERT INTO dbo.Rounds( RoundName)  VALUES('Final');

-- Countries
INSERT INTO dbo.Countries(CountryShortName)  VALUES('ARG');
INSERT INTO dbo.Countries(CountryShortName)  VALUES('AUT');
INSERT INTO dbo.Countries(CountryShortName)  VALUES('BEL');
INSERT INTO dbo.Countries(CountryShortName)  VALUES('BRA');
INSERT INTO dbo.Countries(CountryShortName)  VALUES('CAN');
INSERT INTO dbo.Countries(CountryShortName)  VALUES('CHI');
INSERT INTO dbo.Countries(CountryShortName)  VALUES('ESP');
INSERT INTO dbo.Countries(CountryShortName)  VALUES('FRA');
INSERT INTO dbo.Countries(CountryShortName)  VALUES('GBR');
INSERT INTO dbo.Countries(CountryShortName)  VALUES('IRI');
INSERT INTO dbo.Countries(CountryShortName)  VALUES('IRL');
INSERT INTO dbo.Countries(CountryShortName)  VALUES('ITA');
INSERT INTO dbo.Countries(CountryShortName)  VALUES('RSA');
INSERT INTO dbo.Countries(CountryShortName)  VALUES('SUI');
INSERT INTO dbo.Countries(CountryShortName)  VALUES('SWE');
INSERT INTO dbo.Countries(CountryShortName)  VALUES('URU');
INSERT INTO dbo.Countries(CountryShortName)  VALUES('USA');
 
--Boxers
INSERT INTO dbo.Boxers(BoxerName, CountryID   )  VALUES('Vicente dos Santos', 4 );
INSERT INTO dbo.Boxers(BoxerName, CountryID  )  VALUES('Adam Faul', 5);
INSERT INTO dbo.Boxers(BoxerName, CountryID  )  VALUES('Víctor Bignon', 6);
INSERT INTO dbo.Boxers(BoxerName, CountryID  )  VALUES('Gunnar Nilsson', 15 );
INSERT INTO dbo.Boxers(BoxerName, CountryID  )  VALUES('Mohamed Jamshid Abadi', 10);
INSERT INTO dbo.Boxers(BoxerName, CountryID  )  VALUES('Agustín Muñiz', 16);
INSERT INTO dbo.Boxers(BoxerName, CountryID  )  VALUES('Hans Müller',14 );
INSERT INTO dbo.Boxers(BoxerName, CountryID  )  VALUES('Karl Ameisbichler',2 );
INSERT INTO dbo.Boxers(BoxerName, CountryID  )  VALUES('Jack Gardner', 9);
INSERT INTO dbo.Boxers(BoxerName, CountryID  )  VALUES('Uber Baccilieri',12);
INSERT INTO dbo.Boxers(BoxerName, CountryID  )  VALUES('Gerry Ó Colmáin',11);
INSERT INTO dbo.Boxers(BoxerName, CountryID  )  VALUES('José Arturo Rubio',7);
INSERT INTO dbo.Boxers(BoxerName, CountryID )  VALUES('Rafael Iglesias',1);
INSERT INTO dbo.Boxers(BoxerName, CountryID )  VALUES('John Arthur',13);
INSERT INTO dbo.Boxers(BoxerName, CountryID  )  VALUES('James Galli',8);
INSERT INTO dbo.Boxers(BoxerName, CountryID  )  VALUES('Fernand Bothy',3 );
INSERT INTO dbo.Boxers(BoxerName, CountryID )  VALUES('Jay Lambert' ,17);



--Matches
INSERT INTO dbo.Matches(FirstBoxerId, SecondBoxerId , RoundId )  VALUES(17 ,1 ,1);
INSERT INTO dbo.Matches(FirstBoxerId , SecondBoxerId , RoundId )  VALUES(2 ,3 ,2);
INSERT INTO dbo.Matches(FirstBoxerId , SecondBoxerId , RoundId )  VALUES(4 ,5 ,2);
INSERT INTO dbo.Matches(FirstBoxerId , SecondBoxerId , RoundId )  VALUES(6 ,7 ,2);
INSERT INTO dbo.Matches(FirstBoxerId , SecondBoxerId , RoundId )  VALUES(8 ,9 ,2);
INSERT INTO dbo.Matches(FirstBoxerId , SecondBoxerId , RoundId )  VALUES(10 ,11 ,2);
INSERT INTO dbo.Matches(FirstBoxerId , SecondBoxerId , RoundId )  VALUES(12 ,13 ,2);
INSERT INTO dbo.Matches(FirstBoxerId , SecondBoxerId , RoundId )  VALUES(14 ,15 ,2);
INSERT INTO dbo.Matches(FirstBoxerId , SecondBoxerId , RoundId )  VALUES(16 ,17 ,2);
INSERT INTO dbo.Matches(FirstBoxerId , SecondBoxerId , RoundId )  VALUES(2 ,4 ,3);
INSERT INTO dbo.Matches(FirstBoxerId , SecondBoxerId , RoundId )  VALUES(7 ,9 ,3);
INSERT INTO dbo.Matches(FirstBoxerId , SecondBoxerId , RoundId )  VALUES(10 ,13 ,3);
INSERT INTO dbo.Matches(FirstBoxerId , SecondBoxerId , RoundId )  VALUES(14 ,17 ,3);
INSERT INTO dbo.Matches(FirstBoxerId , SecondBoxerId , RoundId )  VALUES(4 ,7 ,4);
INSERT INTO dbo.Matches(FirstBoxerId , SecondBoxerId , RoundId )  VALUES(13 ,14 ,4);
INSERT INTO dbo.Matches(FirstBoxerId , SecondBoxerId , RoundId )  VALUES(4 ,13 ,5);
INSERT INTO dbo.Matches(FirstBoxerId , SecondBoxerId , RoundId )  VALUES(7 ,14 ,5);

--Match Result
INSERT INTO dbo.MatchResults(BoxerId , ResultName , MatchId )  VALUES(17,'win',1);
INSERT INTO dbo.MatchResults(BoxerId , ResultName , MatchId )  VALUES(2,'win',2);
INSERT INTO dbo.MatchResults(BoxerId , ResultName , MatchId )  VALUES(4,'win',3);
INSERT INTO dbo.MatchResults(BoxerId , ResultName , MatchId )  VALUES(6,'lose',4);
INSERT INTO dbo.MatchResults(BoxerId , ResultName , MatchId )  VALUES(8,'lose',5);
INSERT INTO dbo.MatchResults(BoxerId , ResultName , MatchId )  VALUES(10,'win',6);
INSERT INTO dbo.MatchResults(BoxerId , ResultName , MatchId )  VALUES(12,'lose',7);
INSERT INTO dbo.MatchResults(BoxerId , ResultName , MatchId )  VALUES(14,'win',8);
INSERT INTO dbo.MatchResults(BoxerId , ResultName , MatchId )  VALUES(16,'lose',9);
INSERT INTO dbo.MatchResults(BoxerId , ResultName , MatchId )  VALUES(2,'lose',10);
INSERT INTO dbo.MatchResults(BoxerId , ResultName , MatchId )  VALUES(7,'win',11);
INSERT INTO dbo.MatchResults(BoxerId , ResultName , MatchId )  VALUES(10,'lose',12);
INSERT INTO dbo.MatchResults(BoxerId , ResultName , MatchId )  VALUES(14,'win',13);
INSERT INTO dbo.MatchResults(BoxerId , ResultName , MatchId )  VALUES(4,'win',14);
INSERT INTO dbo.MatchResults(BoxerId , ResultName , MatchId )  VALUES(13,'win',15);
INSERT INTO dbo.MatchResults(BoxerId , ResultName , MatchId )  VALUES(4,'lose',16);
INSERT INTO dbo.MatchResults(BoxerId , ResultName , MatchId )  VALUES(7,'lose',17);
INSERT INTO dbo.MatchResults(BoxerId , ResultName , MatchId )  VALUES(1,'lose',1);
INSERT INTO dbo.MatchResults(BoxerId , ResultName , MatchId )  VALUES(3,'lose',2);
INSERT INTO dbo.MatchResults(BoxerId , ResultName , MatchId )  VALUES(5,'lose',3);
INSERT INTO dbo.MatchResults(BoxerId , ResultName , MatchId )  VALUES(7,'win',4);
INSERT INTO dbo.MatchResults(BoxerId , ResultName , MatchId )  VALUES(9,'win',5);
INSERT INTO dbo.MatchResults(BoxerId , ResultName , MatchId )  VALUES(11,'lose',6);
INSERT INTO dbo.MatchResults(BoxerId , ResultName , MatchId )  VALUES(13,'win',7);
INSERT INTO dbo.MatchResults(BoxerId , ResultName , MatchId )  VALUES(15,'lose',8);
INSERT INTO dbo.MatchResults(BoxerId , ResultName , MatchId )  VALUES(17,'win',9);
INSERT INTO dbo.MatchResults(BoxerId , ResultName , MatchId )  VALUES(4,'win',10);
INSERT INTO dbo.MatchResults(BoxerId , ResultName , MatchId )  VALUES(9,'lose',11);
INSERT INTO dbo.MatchResults(BoxerId , ResultName , MatchId )  VALUES(13,'win',12);
INSERT INTO dbo.MatchResults(BoxerId , ResultName , MatchId )  VALUES(17,'lose',13);
INSERT INTO dbo.MatchResults(BoxerId , ResultName , MatchId )  VALUES(7,'lose',14);
INSERT INTO dbo.MatchResults(BoxerId , ResultName , MatchId )  VALUES(14,'lose',15);
INSERT INTO dbo.MatchResults(BoxerId , ResultName , MatchId )  VALUES(13,'win',16);
INSERT INTO dbo.MatchResults(BoxerId , ResultName , MatchId )  VALUES(14,'win',17);

-- Results (MainTable)
INSERT INTO dbo.Results (BoxerName , ResultName, CountryID , RoundID)  VALUES('Jay Lambert','win',17,1);
INSERT INTO dbo.Results (BoxerName , ResultName, CountryID , RoundID)  VALUES('Vicente dos Santos','lose',4,1);
INSERT INTO dbo.Results (BoxerName , ResultName, CountryID , RoundID)  VALUES('Adam Faul','win',5,2);
INSERT INTO dbo.Results (BoxerName , ResultName, CountryID , RoundID)  VALUES('Víctor Bignon','lose',6,2);
INSERT INTO dbo.Results (BoxerName , ResultName, CountryID , RoundID)  VALUES('Gunnar Nilsson','win',15,2);
INSERT INTO dbo.Results (BoxerName , ResultName, CountryID , RoundID)  VALUES('Mohamed Jamshid Abadi','lose',10,2);
INSERT INTO dbo.Results (BoxerName , ResultName, CountryID , RoundID)  VALUES('Agustín Muñiz','lose',16,2);
INSERT INTO dbo.Results (BoxerName , ResultName, CountryID , RoundID)  VALUES('Hans Müller','win',14,2);
INSERT INTO dbo.Results (BoxerName , ResultName, CountryID , RoundID)  VALUES('Karl Ameisbichler','lose',2,2);
INSERT INTO dbo.Results (BoxerName , ResultName, CountryID , RoundID)  VALUES('Jack Gardner','win',9,2);
INSERT INTO dbo.Results (BoxerName , ResultName, CountryID , RoundID)  VALUES('Uber Baccilieri','win',12,2);
INSERT INTO dbo.Results (BoxerName , ResultName, CountryID , RoundID)  VALUES('Gerry Ó Colmáin','lose',11,2);
INSERT INTO dbo.Results (BoxerName , ResultName, CountryID , RoundID)  VALUES('José Arturo Rubio','lose',7,2);
INSERT INTO dbo.Results (BoxerName , ResultName, CountryID , RoundID)  VALUES('Rafael Iglesias','win',1,2);
INSERT INTO dbo.Results (BoxerName , ResultName, CountryID , RoundID)  VALUES('John Arthur','win',13,2);
INSERT INTO dbo.Results (BoxerName , ResultName, CountryID , RoundID)  VALUES('James Galli','lose',8,2);
INSERT INTO dbo.Results (BoxerName , ResultName, CountryID , RoundID)  VALUES('Fernand Bothy','lose',3,2);
INSERT INTO dbo.Results (BoxerName , ResultName, CountryID , RoundID)  VALUES('Jay Lambert','win',17,2);
INSERT INTO dbo.Results (BoxerName , ResultName, CountryID , RoundID)  VALUES('Adam Faul','lose',5,3);
INSERT INTO dbo.Results (BoxerName , ResultName, CountryID , RoundID)  VALUES('Gunnar Nilsson','win',15,3);
INSERT INTO dbo.Results (BoxerName , ResultName, CountryID , RoundID)  VALUES('Hans Müller','win',14,3);
INSERT INTO dbo.Results (BoxerName , ResultName, CountryID , RoundID)  VALUES('Jack Gardner','lose',9,3);
INSERT INTO dbo.Results (BoxerName , ResultName, CountryID , RoundID)  VALUES('Uber Baccilieri','lose',12,3);
INSERT INTO dbo.Results (BoxerName , ResultName, CountryID , RoundID)  VALUES('Rafael Iglesias','win',1,3);
INSERT INTO dbo.Results (BoxerName , ResultName, CountryID , RoundID)  VALUES('John Arthur','win',13,3);
INSERT INTO dbo.Results (BoxerName , ResultName, CountryID , RoundID)  VALUES('Jay Lambert','lose',17,3);
INSERT INTO dbo.Results (BoxerName , ResultName, CountryID , RoundID)  VALUES('Gunnar Nilsson','win',15,4);
INSERT INTO dbo.Results (BoxerName , ResultName, CountryID , RoundID)  VALUES('Hans Müller','lose',14,4);
INSERT INTO dbo.Results (BoxerName , ResultName, CountryID , RoundID)  VALUES('Rafael Iglesias','win',1,4);
INSERT INTO dbo.Results (BoxerName , ResultName, CountryID , RoundID)  VALUES('John Arthur','lose',13,4);
INSERT INTO dbo.Results (BoxerName , ResultName, CountryID , RoundID)  VALUES('Gunnar Nilsson','lose',15,5);
INSERT INTO dbo.Results (BoxerName , ResultName, CountryID , RoundID)  VALUES('Rafael Iglesias','win',1,5);
INSERT INTO dbo.Results (BoxerName , ResultName, CountryID , RoundID)  VALUES('Hans Müller','lose',14,5);
INSERT INTO dbo.Results (BoxerName , ResultName, CountryID , RoundID)  VALUES('John Arthur','win',13,5);
 