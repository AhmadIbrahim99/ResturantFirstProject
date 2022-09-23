USE [ResturantDB]
GO

/****** Object:  Table [dbo].[Orders]    Script Date: 9/23/2022 4:08:58 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Orders](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[OrderName] [varchar](255) NOT NULL,
	[IdResturantMenu] [int] NOT NULL,
	[IdCustomer] [int] NOT NULL,
	[CreatedAt] [date] NULL,
	[UpdatedAt] [date] NULL,
	[Archived] [bit] NOT NULL,
	[TotalPrice] [float] NOT NULL,
	[Quantity] [int] NOT NULL,
 CONSTRAINT [PK__Orders__3214EC073F3CF70A] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Orders] ADD  CONSTRAINT [DF__Orders__CreatedA__30F848ED]  DEFAULT (getdate()) FOR [CreatedAt]
GO

ALTER TABLE [dbo].[Orders] ADD  CONSTRAINT [DF__Orders__Archived__31EC6D26]  DEFAULT ((0)) FOR [Archived]
GO

ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK__Orders__IdCustom__33D4B598] FOREIGN KEY([IdCustomer])
REFERENCES [dbo].[Customers] ([Id])
GO

ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK__Orders__IdCustom__33D4B598]
GO

ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK__Orders__IdRestur__32E0915F] FOREIGN KEY([IdResturantMenu])
REFERENCES [dbo].[RestaurantMenus] ([Id])
GO

ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK__Orders__IdRestur__32E0915F]
GO

