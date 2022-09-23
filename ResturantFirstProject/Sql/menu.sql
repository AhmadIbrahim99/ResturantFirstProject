USE [ResturantDB]
GO

/****** Object:  Table [dbo].[RestaurantMenus]    Script Date: 9/23/2022 4:08:06 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[RestaurantMenus](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[mealName] [varchar](255) NOT NULL,
	[Archived] [bit] NOT NULL,
	[CreatedAt] [date] NULL,
	[UpdatedAt] [date] NULL,
	[PricieInNIS] [float] NOT NULL,
	[PriceInUsd] [float] NOT NULL,
	[Quantity] [int] NOT NULL,
	[IdRestaurant] [int] NOT NULL,
 CONSTRAINT [PK__Restaura__3214EC07D213A314] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[RestaurantMenus] ADD  CONSTRAINT [DF__Restauran__Archi__286302EC]  DEFAULT ((0)) FOR [Archived]
GO

ALTER TABLE [dbo].[RestaurantMenus] ADD  CONSTRAINT [DF__Restauran__Creat__29572725]  DEFAULT (getdate()) FOR [CreatedAt]
GO

ALTER TABLE [dbo].[RestaurantMenus]  WITH CHECK ADD  CONSTRAINT [FK__Restauran__IdRes__2A4B4B5E] FOREIGN KEY([IdRestaurant])
REFERENCES [dbo].[Restaurants] ([Id])
GO

ALTER TABLE [dbo].[RestaurantMenus] CHECK CONSTRAINT [FK__Restauran__IdRes__2A4B4B5E]
GO

