USE [Habanero]
GO

/****** Object:  Table [dbo].[State]    Script Date: 3/11/2016 7:10:04 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[State](
	[StateId] [int] IDENTITY(1,1) NOT NULL,
	[Abbreviation] [char](2) NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[IsPrimaryState] [bit] NOT NULL,
 CONSTRAINT [PK_State] PRIMARY KEY CLUSTERED 
(
	[StateId] ASC
)
) 

GO


