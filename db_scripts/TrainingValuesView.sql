USE [Temtem]
GO

/****** Object:  View [dbo].[TrainingValuesView]    Script Date: 01.11.2020 15:29:28 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

create view [dbo].[TrainingValuesView] AS
SELECT Temtems.Name, TrainingValues.HP, TrainingValues.STA, TrainingValues.SPD, TrainingValues.ATK, TrainingValues.DEF, TrainingValues.SPATK, TrainingValues.SPDEF FROM Temtems
LEFT JOIN TrainingValues ON Temtems.ID = TrainingValues.TemID
GO

