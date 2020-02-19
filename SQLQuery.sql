CREATE DATABASE R3ME
GO

USE R3ME
GO

-- Account: Admin, Candidate
-- Subject: Toán, Lý, Hóa,....
-- Question: 
CREATE TABLE Account (
	UserName NVARCHAR(100) PRIMARY KEY,
	DisplayName NVARCHAR(500) NOT NULL DEFAULT N'Chưa đặt tên',
	Password NVARCHAR(100) NOT NULL,
	Type INT NOT NULL DEFAULT 0, -- 0: Candidate, 1: Admin
	TotalAns INT NOT NULL DEFAULT 0,
	CorrectAns INT NOT NULL DEFAULT 0,
	WrongAns AS TotalAns - CorrectAns,
	Point AS (
	CASE
		WHEN TotalAns = 0 THEN 0
		WHEN TotalAns - CorrectAns < 0 THEN 0
		ELSE (CorrectAns*100.0)/TotalAns
	END
	),
	Ranking AS CAST ( 
	CASE 
		WHEN TotalAns = 0 THEN N'Chưa tham gia xếp hạng'
		WHEN TotalAns - CorrectAns < 0 THEN N'HOW CAN YOU DO THAT ?!'
		WHEN (CorrectAns*100.0)/TotalAns BETWEEN 99 AND 100 THEN N'Pro Player'
		WHEN (CorrectAns*100.0)/TotalAns BETWEEN 95 AND 99 THEN N'Thách Đấu'
		WHEN (CorrectAns*100.0)/TotalAns BETWEEN 90 AND 95 THEN N'Cao Thủ'
		WHEN (CorrectAns*100.0)/TotalAns BETWEEN 80 AND 90 THEN N'Kim Cương'
		WHEN (CorrectAns*100.0)/TotalAns BETWEEN 70 AND 80 THEN N'Bạch Kim'
		WHEN (CorrectAns*100.0)/TotalAns BETWEEN 60 AND 70 THEN N'Vàng'
		WHEN (CorrectAns*100.0)/TotalAns BETWEEN 50 AND 60 THEN N'Bạc'
		WHEN (CorrectAns*100.0)/TotalAns BETWEEN 40 AND 50 THEN N'Đồng'
		ELSE N'Giấy'
	END AS NVARCHAR(100)
	)
)
GO

CREATE TABLE Subject (
	id INT IDENTITY(1,1) PRIMARY KEY,
	Name NVARCHAR(100) NOT NULL DEFAULT N'Môn học chưa đặt tên'
)
GO

CREATE TABLE Question (
	id INT IDENTITY(1,1) PRIMARY KEY,
	idSubject INT NOT NULL,
	Content NVARCHAR(1000) NOT NULL DEFAULT N'Chưa có nội dung',
	ContentA NVARCHAR(500) NOT NULL DEFAULT N'Chưa có nội dung',
	ContentB NVARCHAR(500) NOT NULL DEFAULT N'Chưa có nội dung',
	ContentC NVARCHAR(500) NOT NULL DEFAULT N'Chưa có nội dung',
	ContentD NVARCHAR(500) NOT NULL DEFAULT N'Chưa có nội dung',
	Answer CHAR NOT NULL DEFAULT 'A',

	FOREIGN KEY (idSubject) REFERENCES dbo.Subject(id)
)
GO

CREATE TABLE Exam (
	id INT IDENTITY(1,1) PRIMARY KEY,
	idQues INT NOT NULL,
	AnswerIN CHAR(1) NOT NULL DEFAULT 'X',
	isCorrect INT NOT NULL DEFAULT 0,
)
GO

-- ======================================= INITIALIZE =======================================
INSERT INTO dbo.Account
(
    UserName,
    DisplayName,
    Password,
    Type,
    TotalAns,
    CorrectAns
)
VALUES
(   N'R3ME1', -- UserName - nvarchar(100)
    N'ADMIN Cường', -- DisplayName - nvarchar(100)
    N'6b86b273ff34fce19d6b804eff5a3f5747ada4eaa22f1d49c01e52ddb7875b4b', -- Password - nvarchar(40)
    1,   -- Type - int
    1000000,   -- TotalAns - int
    1000000    -- CorrectAns - int
    )
GO

INSERT INTO dbo.Account
(
    UserName,
    DisplayName,
    Password,
    Type,
    TotalAns,
    CorrectAns
)
VALUES
(   N'TestCandidate', -- UserName - nvarchar(100)
    N'Thí Sinh Test', -- DisplayName - nvarchar(100)
    N'6b86b273ff34fce19d6b804eff5a3f5747ada4eaa22f1d49c01e52ddb7875b4b', -- Password - nvarchar(40)
    0,   -- Type - int
    20,   -- TotalAns - int
    15    -- CorrectAns - int
    )
GO

INSERT INTO dbo.Subject
(
    Name
)
VALUES
(N'Toán' -- Name - nvarchar(100)
    )
GO
    
INSERT INTO dbo.Subject
(
    Name
)
VALUES
(N'Lý' -- Name - nvarchar(100)
    )
GO

INSERT INTO dbo.Subject
(
    Name
)
VALUES
(N'Hóa' -- Name - nvarchar(100)
    )
GO

DECLARE @i INT = 1
WHILE @i <= 10
BEGIN
	INSERT INTO dbo.Question
	(
	    idSubject,
	    Content
	)
	VALUES
	(   1,   -- idSubject - int
	    N'Nội dung Câu ' + CAST(@i AS NVARCHAR(100))-- Content - nvarchar(4000)
	    )
	SET @i = @i + 1
END
GO
-- ===================================================== WORKS =====================================================
CREATE PROC UserSP_Login 
@UserName NVARCHAR(100), @Password NVARCHAR(100)
AS
BEGIN
	SELECT * FROM dbo.Account WHERE UserName = @UserName AND Password = @Password
END
GO

CREATE PROC UserSP_GetAccountByUserName
@username NVARCHAR(100)
AS
BEGIN
	SELECT * FROM dbo.Account WHERE UserName = @username
END
GO

CREATE PROC UserSP_UpdateAccountInfo 
@username NVARCHAR(100), @displayName NVARCHAR(500), @password NVARCHAR(100), @newPass NVARCHAR(100) 
AS
BEGIN
	DECLARE @isRightPass INT = 0
	SELECT @isRightPass = COUNT(*) FROM dbo.Account WHERE UserName = @username AND Password = @password

	IF (@isRightPass = 1)
	BEGIN
		IF (@newPass = NULL OR @newpass = '')
		BEGIN
			UPDATE dbo.Account SET DisplayName = @displayName WHERE UserName = @username
		END
        ELSE 
			UPDATE dbo.Account SET DisplayName = @displayName, Password = @newPass WHERE UserName = @username
	END
END
GO

CREATE PROC UserSP_AddAccountByAdmin
@username NVARCHAR(100), @displayName NVARCHAR(500), @password NVARCHAR(100), @type INT, @totalAns INT, @correctAns INT
AS
BEGIN
	INSERT INTO dbo.Account
	(
	    UserName,
	    DisplayName,
	    Password,
	    Type,
	    TotalAns,
	    CorrectAns
	)
	VALUES
	(   @username, -- UserName - nvarchar(100)
	    @displayName, -- DisplayName - nvarchar(500)
	    @password, -- Password - nvarchar(40)
	    @type,   -- Type - int
	    @totalAns,   -- TotalAns - int
	    @correctAns    -- Correct - int
	    )
END
GO

CREATE PROC UserSP_RegisterAccount
@UserName NVARCHAR(100), @DisplayName NVARCHAR(500), @Password NVARCHAR(100)
AS
BEGIN
	INSERT INTO dbo.Account
	(
	    UserName,
	    DisplayName,
	    Password,
	    Type,
	    TotalAns,
	    CorrectAns
	)
	VALUES
	(   @UserName, -- UserName - nvarchar(100)
	    @DisplayName, -- DisplayName - nvarchar(500)
	    @Password, -- Password - nvarchar(40)
	    0,   -- Type - int
	    0,   -- TotalAns - int
	    0    -- CorrectAns - int
	    )
END
GO

CREATE PROC UserSP_AddQues
@idSubject INT, @content NVARCHAR(1000), @contentA NVARCHAR(500), @contentB NVARCHAR(500), @contentC NVARCHAR(500), @contentD NVARCHAR(500), @answer CHAR(1)
AS
BEGIN
	INSERT INTO dbo.Question
	(
	    idSubject,
	    Content,
	    ContentA,
	    ContentB,
	    ContentC,
	    ContentD,
	    Answer
	)
	VALUES
	(   @idSubject,   -- idSubject - int
	    @content, -- Content - nvarchar(1000)
	    @contentA, -- ContentA - nvarchar(500)
	    @contentB, -- ContentB - nvarchar(500)
	    @contentC, -- ContentC - nvarchar(500)
	    @contentD, -- ContentD - nvarchar(500)
	    @answer   -- Answer - char(1)
	    )
END
GO

CREATE PROC UserSP_ImportQuesData
@subjectName NVARCHAR(100), @contentImp NVARCHAR(1000), @contentAImp NVARCHAR(500), @contentBImp NVARCHAR(500), @contentCImp NVARCHAR(500), @contentDImp NVARCHAR(500), @answerImp CHAR(1)
AS
BEGIN
	DECLARE @idSubjectCheck INT
	SELECT @idSubjectCheck = id FROM dbo.Subject WHERE Name = @subjectName
	IF (@idSubjectCheck > 0)
	BEGIN
		EXEC dbo.UserSP_AddQues @idSubject = @idSubjectCheck,  -- int
		                        @content = @contentImp,  -- nvarchar(1000)
		                        @contentA = @contentAImp, -- nvarchar(500)
		                        @contentB = @contentBImp, -- nvarchar(500)
		                        @contentC = @contentCImp, -- nvarchar(500)
		                        @contentD = @contentDImp, -- nvarchar(500)
		                        @answer = @answerImp     -- char(1)
	END
    ELSE 
	BEGIN
		INSERT INTO dbo.Subject
		(
		    Name
		)
		VALUES
		(@subjectName -- Name - nvarchar(100)
		    )

		SELECT @idSubjectCheck = id FROM dbo.Subject WHERE Name = @subjectName

		EXEC dbo.UserSP_AddQues @idSubject = @idSubjectCheck,  -- int
		                        @content = @contentImp,  -- nvarchar(1000)
		                        @contentA = @contentAImp, -- nvarchar(500)
		                        @contentB = @contentBImp, -- nvarchar(500)
		                        @contentC = @contentCImp, -- nvarchar(500)
		                        @contentD = @contentDImp, -- nvarchar(500)
		                        @answer = @answerImp     -- char(1)
    END
END
GO

CREATE PROC UserSP_CreateExam
@numQues INT, @idSubject INT
AS
BEGIN
	DECLARE @existNumQues INT
	SELECT @existNumQues = COUNT(*) FROM dbo.Exam

	DECLARE @maxNumQues INT
	SELECT @maxNumQues = COUNT(*) FROM dbo.Question WHERE idSubject = @idSubject

	IF (@existNumQues + @numQues > @maxNumQues)
	BEGIN
		RETURN -1
	END

	DECLARE @i INT = 0
	WHILE (@i < @numQues)
	BEGIN
		DECLARE @randIDQues INT 
		SELECT TOP 1 @randIDQues = id FROM dbo.Question WHERE idSubject = @idSubject
		ORDER BY NEWID()

		IF NOT EXISTS (SELECT * FROM dbo.Exam WHERE idQues = @randIDQues)
        BEGIN
			INSERT INTO dbo.Exam (idQues) VALUES ( @randIDQues )
			SET @i = @i + 1
		END
	END
END
GO

CREATE PROC UserSP_ChoseAnswer
@id INT, @answer CHAR(1)
AS
BEGIN
	DECLARE @correct INT 
	SELECT @correct = COUNT(*) FROM dbo.Question AS q JOIN dbo.Exam AS e
	ON e.id = @id AND e.idQues = q.id AND q.Answer = @answer

	UPDATE dbo.Exam SET isCorrect = @correct, AnswerIN = @answer WHERE id = @id
END
GO

CREATE PROC UserSP_DoneExam
AS
BEGIN
	DELETE dbo.Exam
	DBCC CHECKIDENT(Exam, RESEED, 0)
END
GO

CREATE PROC UserSP_UpdateAccountExamed
@username NVARCHAR(100), @totalAns INT, @correctAns INT 
AS
BEGIN
	UPDATE dbo.Account SET TotalAns = TotalAns + @totalAns, CorrectAns = CorrectAns + @correctAns WHERE UserName = @username
END
GO

SELECT * FROM dbo.Exam

SELECT * FROM dbo.Question
GO

CREATE PROC UserSP_DeleteSubject
@idSubject INT
AS
BEGIN
	DELETE dbo.Question WHERE idSubject = @idSubject
	DELETE dbo.Subject WHERE id = @idSubject
END
GO

CREATE PROC UserSP_ResetPassword
@userName NVARCHAR(100)
AS
BEGIN
	UPDATE dbo.Account SET Password = N'6b86b273ff34fce19d6b804eff5a3f5747ada4eaa22f1d49c01e52ddb7875b4b' WHERE UserName = @userName
END
GO
