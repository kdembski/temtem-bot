USE [Temtem]
GO

/****** Object:  View [dbo].[TemtemSimpleView]    Script Date: 01.11.2020 15:28:55 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE VIEW [dbo].[TemtemSimpleView] AS
SELECT Temtems.ID, Temtems.Name, Temtems.Number, Temtems.Image, C.Name AS 'Name1', C.Icon AS 'Type1', D.Name AS 'Name2', D.Icon AS 'Type2' FROM Temtems
JOIN BaseStats ON Temtems.ID = BaseStats.TemID
JOIN Types C ON Temtems.Type1ID = C.ID
JOIN Types D ON Temtems.Type2ID = D.ID

GO

