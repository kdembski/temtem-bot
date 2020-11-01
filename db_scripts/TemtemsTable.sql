USE [Temtem]
GO

/****** Object:  Table [dbo].[Temtems]    Script Date: 01.11.2020 15:27:17 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Temtems](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](63) NOT NULL,
	[Number] [varchar](4) NULL,
	[Trait1ID] [int] NULL,
	[Trait2ID] [int] NULL,
	[Type1ID] [int] NULL,
	[Type2ID] [int] NULL,
	[Image] [varchar](max) NULL,
	[LumaImage] [varchar](max) NULL,
	[PreEvolutionID] [int] NULL,
	[EvolutionID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[Temtems]  WITH CHECK ADD FOREIGN KEY([EvolutionID])
REFERENCES [dbo].[Temtems] ([ID])
GO

ALTER TABLE [dbo].[Temtems]  WITH CHECK ADD FOREIGN KEY([PreEvolutionID])
REFERENCES [dbo].[Temtems] ([ID])
GO

ALTER TABLE [dbo].[Temtems]  WITH CHECK ADD FOREIGN KEY([Trait1ID])
REFERENCES [dbo].[Traits] ([ID])
GO

ALTER TABLE [dbo].[Temtems]  WITH CHECK ADD FOREIGN KEY([Trait2ID])
REFERENCES [dbo].[Traits] ([ID])
GO

ALTER TABLE [dbo].[Temtems]  WITH CHECK ADD FOREIGN KEY([Type1ID])
REFERENCES [dbo].[Types] ([ID])
GO

ALTER TABLE [dbo].[Temtems]  WITH CHECK ADD FOREIGN KEY([Type2ID])
REFERENCES [dbo].[Types] ([ID])
GO

