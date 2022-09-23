USE [ResturantDB]
GO

/****** Object:  Table [dbo].[Customers]    Script Date: 9/23/2022 4:08:39 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Customers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Archived] [bit] NOT NULL,
	[CreatedAt] [date] NULL,
	[UpdatedAt] [date] NULL,
	[FirstName] [varchar](255) NOT NULL,
	[LastName] [varchar](255) NOT NULL,
 CONSTRAINT [PK__Customer__3214EC078F7F76C4] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Customers] ADD  CONSTRAINT [DF__Customers__Archi__2D27B809]  DEFAULT ((0)) FOR [Archived]
GO

ALTER TABLE [dbo].[Customers] ADD  CONSTRAINT [DF__Customers__Creat__2E1BDC42]  DEFAULT (getdate()) FOR [CreatedAt]
GO

