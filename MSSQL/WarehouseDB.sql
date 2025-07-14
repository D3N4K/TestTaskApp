USE [WarehouseDB]
GO
/****** Object:  Table [dbo].[BoxTable]    Script Date: 14.07.2025 6:35:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BoxTable](
	[id_box] [int] NOT NULL,
	[width_box] [float] NULL,
	[height_box] [float] NULL,
	[deep_box] [float] NULL,
	[weight_box] [float] NULL,
	[date_production] [date] NULL,
	[id_pal] [int] NULL,
 CONSTRAINT [PK__BoxTable__D50736E5D48467C0] PRIMARY KEY CLUSTERED 
(
	[id_box] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PalletTable]    Script Date: 14.07.2025 6:35:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PalletTable](
	[id_pal] [int] NOT NULL,
	[width_pal] [float] NULL,
	[height_pal] [float] NULL,
	[deep_pal] [float] NULL,
	[weight_pal] [float] NULL,
PRIMARY KEY CLUSTERED 
(
	[id_pal] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[BoxTable] ([id_box], [width_box], [height_box], [deep_box], [weight_box], [date_production], [id_pal]) VALUES (1, 95, 15, 95, 50, CAST(N'2025-06-15' AS Date), 1)
GO
INSERT [dbo].[BoxTable] ([id_box], [width_box], [height_box], [deep_box], [weight_box], [date_production], [id_pal]) VALUES (2, 50, 10, 50, 10, CAST(N'2025-07-01' AS Date), 2)
GO
INSERT [dbo].[BoxTable] ([id_box], [width_box], [height_box], [deep_box], [weight_box], [date_production], [id_pal]) VALUES (3, 40, 10, 35, 15, CAST(N'2025-07-07' AS Date), 2)
GO
INSERT [dbo].[BoxTable] ([id_box], [width_box], [height_box], [deep_box], [weight_box], [date_production], [id_pal]) VALUES (4, 30, 7, 25, 5, CAST(N'2025-06-01' AS Date), 4)
GO
INSERT [dbo].[BoxTable] ([id_box], [width_box], [height_box], [deep_box], [weight_box], [date_production], [id_pal]) VALUES (5, 100, 10, 70, 30, CAST(N'2025-05-25' AS Date), 5)
GO
INSERT [dbo].[PalletTable] ([id_pal], [width_pal], [height_pal], [deep_pal], [weight_pal]) VALUES (1, 100, 20, 100, 80)
GO
INSERT [dbo].[PalletTable] ([id_pal], [width_pal], [height_pal], [deep_pal], [weight_pal]) VALUES (2, 120, 20, 120, 55)
GO
INSERT [dbo].[PalletTable] ([id_pal], [width_pal], [height_pal], [deep_pal], [weight_pal]) VALUES (3, 90, 15, 80, 30)
GO
INSERT [dbo].[PalletTable] ([id_pal], [width_pal], [height_pal], [deep_pal], [weight_pal]) VALUES (4, 100, 15, 90, 35)
GO
INSERT [dbo].[PalletTable] ([id_pal], [width_pal], [height_pal], [deep_pal], [weight_pal]) VALUES (5, 100, 20, 110, 60)
GO
ALTER TABLE [dbo].[BoxTable]  WITH CHECK ADD  CONSTRAINT [FK__BoxTable__id_pal__38996AB5] FOREIGN KEY([id_pal])
REFERENCES [dbo].[PalletTable] ([id_pal])
GO
ALTER TABLE [dbo].[BoxTable] CHECK CONSTRAINT [FK__BoxTable__id_pal__38996AB5]
GO
/****** Object:  StoredProcedure [dbo].[GetBoxesInPallet]    Script Date: 14.07.2025 6:35:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[GetBoxesInPallet]
@id_pal int
as
select * from [dbo].[BoxTable]
where id_pal = @id_pal
GO
/****** Object:  StoredProcedure [dbo].[GetCountRowPallet]    Script Date: 14.07.2025 6:35:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[GetCountRowPallet]
as
select count(*) 'Колличество паллет'
from [dbo].[PalletTable]
GO
/****** Object:  StoredProcedure [dbo].[GetPalletById]    Script Date: 14.07.2025 6:35:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[GetPalletById]
@id_pal int
as
select * from PalletTable
where id_pal = @id_pal
GO
