USE [Temtem]
GO

/****** Object:  View [dbo].[TemtemDetailsView]    Script Date: 01.11.2020 15:28:41 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

create view [dbo].[TemtemDetailsView] as
SELECT Temtems.ID, Temtems.Name, Temtems.Number, Temtems.Image, Temtems.LumaImage,
A.Name AS 'Trait1', B.Name AS 'Trait2',
C.Name AS 'Name1', C.Icon AS 'Type1', C.Defense as 'Defense1',
D.Name AS 'Name2', D.Icon AS 'Type2', D.Defense as 'Defense2',
BaseStats.HP, BaseStats.STA, BaseStats.SPD, BaseStats.ATK, BaseStats.DEF, BaseStats.SPATK, BaseStats.SPDEF,
E.Name AS 'PreEvolution', F.Name AS 'Evolution'
FROM Temtems
JOIN BaseStats ON Temtems.ID = BaseStats.TemID
JOIN Traits A ON Temtems.Trait1ID = A.ID
JOIN Traits B ON Temtems.Trait2ID = B.ID
JOIN Types C ON Temtems.Type1ID = C.ID
JOIN Types D ON Temtems.Type2ID = D.ID
left JOIN Temtems E ON Temtems.PreEvolutionID = E.ID
left JOIN Temtems F ON Temtems.EvolutionID = F.ID 
GO

