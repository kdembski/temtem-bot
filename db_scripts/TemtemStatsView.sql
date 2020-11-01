USE [Temtem]
GO

/****** Object:  View [dbo].[TemtemStatsView]    Script Date: 01.11.2020 15:29:11 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[TemtemStatsView] AS
SELECT Temtems.ID, Temtems.Name, Temtems.Number, A.Name AS 'Trait1', B.Name AS 'Trait2', C.Icon AS 'Type1', D.Icon AS 'Type2', BaseStats.HP, BaseStats.STA, BaseStats.SPD, BaseStats.ATK, BaseStats.DEF, BaseStats.SPATK, BaseStats.SPDEF FROM Temtems
JOIN BaseStats ON Temtems.ID = BaseStats.TemID
JOIN Traits A ON Temtems.Trait1ID = A.ID
JOIN Traits B ON Temtems.Trait2ID = B.ID
JOIN Types C ON Temtems.Type1ID = C.ID
JOIN Types D ON Temtems.Type2ID = D.ID

GO

