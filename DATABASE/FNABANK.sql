USE [FNABANK]
GO
/****** Object:  Table [dbo].[Bireysel]    Script Date: 3.11.2022 01:33:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bireysel](
	[bireyselDogumTar] [date] NOT NULL,
	[bireyselTCKimlikNo] [char](11) NOT NULL,
	[musteriID] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Hesap]    Script Date: 3.11.2022 01:33:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Hesap](
	[hesapID] [varchar](25) NOT NULL,
	[musteriID] [int] NOT NULL,
	[bakiye] [int] NOT NULL,
 CONSTRAINT [PK_Hesap] PRIMARY KEY CLUSTERED 
(
	[hesapID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Kurumsal]    Script Date: 3.11.2022 01:33:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Kurumsal](
	[kurumsalFirmaAdi] [varchar](50) NOT NULL,
	[kurumsalVergiNo] [int] NOT NULL,
	[musteriID] [int] NOT NULL,
	[kurumsalKredi] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Musteri]    Script Date: 3.11.2022 01:33:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Musteri](
	[musteriID] [int] NOT NULL,
	[musteriAdı] [varchar](50) NOT NULL,
	[musteriSoyadı] [varchar](50) NOT NULL,
	[musteriMail] [varchar](50) NOT NULL,
	[musteriTel] [char](13) NOT NULL,
	[musteriHesapID] [char](25) NOT NULL,
 CONSTRAINT [PK_Musteri] PRIMARY KEY CLUSTERED 
(
	[musteriID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Bireysel]  WITH CHECK ADD  CONSTRAINT [FK_Bireysel_Musteri] FOREIGN KEY([musteriID])
REFERENCES [dbo].[Musteri] ([musteriID])
GO
ALTER TABLE [dbo].[Bireysel] CHECK CONSTRAINT [FK_Bireysel_Musteri]
GO
ALTER TABLE [dbo].[Hesap]  WITH CHECK ADD  CONSTRAINT [FK_Hesap_Musteri] FOREIGN KEY([musteriID])
REFERENCES [dbo].[Musteri] ([musteriID])
GO
ALTER TABLE [dbo].[Hesap] CHECK CONSTRAINT [FK_Hesap_Musteri]
GO
ALTER TABLE [dbo].[Kurumsal]  WITH CHECK ADD  CONSTRAINT [FK_Kurumsal_Musteri] FOREIGN KEY([musteriID])
REFERENCES [dbo].[Musteri] ([musteriID])
GO
ALTER TABLE [dbo].[Kurumsal] CHECK CONSTRAINT [FK_Kurumsal_Musteri]
GO
