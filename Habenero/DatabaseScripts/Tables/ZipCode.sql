USE [Habanero]
GO

/****** Object:  Table [dbo].[ZipCode]    Script Date: 3/11/2016 7:10:21 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ZipCode](
	[ZipCodeId] [int] IDENTITY(1,1) NOT NULL,
	[City] [varchar](100) NULL,
	[StateId] [int] NOT NULL,
	[Zip] [varchar] (10)NOT NULL,
	[County] [nvarchar](max) NULL,
	[AreaCode] [varchar](50) NULL,
	[Fips] [nvarchar](50) NULL,
	[TimeZone] [nvarchar](50) NULL,
	[ObservesDST] [bit] NULL,
	[Latitude] [nvarchar](50) NULL,
	[Longitude] [nvarchar](50) NULL,
 CONSTRAINT [PK_ZipCode] PRIMARY KEY CLUSTERED 
(
	[ZipCodeId] ASC
)
) 

GO

ALTER TABLE [dbo].[ZipCode]  WITH CHECK ADD  CONSTRAINT [FK_State_ZipCode] FOREIGN KEY([StateId])
REFERENCES [dbo].[State] ([StateId])
GO

ALTER TABLE [dbo].[ZipCode] CHECK CONSTRAINT [FK_State_ZipCode]
GO


