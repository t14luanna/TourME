USE [master]
GO
/****** Object:  Database [TourMe]    Script Date: 10/10/2017 12:14:59 AM ******/
CREATE DATABASE [TourMe]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'TourMe', FILENAME = N'I:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\TourMe.mdf' , SIZE = 3264KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'TourMe_log', FILENAME = N'I:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\TourMe_log.ldf' , SIZE = 1088KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [TourMe] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [TourMe].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [TourMe] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [TourMe] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [TourMe] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [TourMe] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [TourMe] SET ARITHABORT OFF 
GO
ALTER DATABASE [TourMe] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [TourMe] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [TourMe] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [TourMe] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [TourMe] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [TourMe] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [TourMe] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [TourMe] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [TourMe] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [TourMe] SET  ENABLE_BROKER 
GO
ALTER DATABASE [TourMe] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [TourMe] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [TourMe] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [TourMe] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [TourMe] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [TourMe] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [TourMe] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [TourMe] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [TourMe] SET  MULTI_USER 
GO
ALTER DATABASE [TourMe] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [TourMe] SET DB_CHAINING OFF 
GO
ALTER DATABASE [TourMe] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [TourMe] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [TourMe] SET DELAYED_DURABILITY = DISABLED 
GO
USE [TourMe]
GO
/****** Object:  Table [dbo].[Article]    Script Date: 10/10/2017 12:14:59 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Article](
	[Id] [int] IDENTITY(0,1) NOT NULL,
	[Title] [nvarchar](max) NOT NULL,
	[Content] [nvarchar](max) NULL,
	[DateCreate] [datetime] NULL,
	[DateUpdate] [datetime] NOT NULL,
	[ArticleKindId] [int] NOT NULL,
	[OwnId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ArticleKind]    Script Date: 10/10/2017 12:14:59 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ArticleKind](
	[Id] [int] IDENTITY(0,1) NOT NULL,
	[DateCreate] [datetime] NULL,
	[Description] [nvarchar](max) NULL,
	[Kind] [nvarchar](40) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Comment]    Script Date: 10/10/2017 12:14:59 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Comment](
	[Id] [int] IDENTITY(0,1) NOT NULL,
	[DateCreate] [datetime] NULL,
	[Content] [nvarchar](max) NULL,
	[Kind] [nvarchar](40) NOT NULL,
	[UserId] [int] NOT NULL,
	[PlaceId] [int] NULL,
	[EventId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Event]    Script Date: 10/10/2017 12:14:59 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Event](
	[Id] [int] IDENTITY(0,1) NOT NULL,
	[Title] [nvarchar](max) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[Url] [nvarchar](150) NOT NULL,
	[DateCreate] [datetime] NULL CONSTRAINT [DF__Event__DateCreat__412EB0B6]  DEFAULT (getdate()),
	[DateStart] [datetime] NOT NULL CONSTRAINT [DF__Event__DateStart__4222D4EF]  DEFAULT (getdate()),
	[DateEnd] [datetime] NOT NULL CONSTRAINT [DF__Event__DateEnd__4316F928]  DEFAULT (getdate()),
	[EventKindId] [int] NOT NULL,
	[PlaceId] [int] NOT NULL,
 CONSTRAINT [PK__Event__3214EC0797FF5B29] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[EventKind]    Script Date: 10/10/2017 12:14:59 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EventKind](
	[Id] [int] IDENTITY(0,1) NOT NULL,
	[DateCreate] [datetime] NULL DEFAULT (getdate()),
	[Description] [nvarchar](max) NULL,
	[Kind] [nvarchar](40) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[FeedBack]    Script Date: 10/10/2017 12:14:59 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FeedBack](
	[Id] [int] IDENTITY(0,1) NOT NULL,
	[DateCreate] [datetime] NULL,
	[UserId] [int] NOT NULL,
	[Content] [nvarchar](max) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Hotel]    Script Date: 10/10/2017 12:14:59 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Hotel](
	[PlaceId] [int] NULL,
	[Name] [nvarchar](max) NULL,
	[HotelScaleId] [int] NULL,
	[MinPrice] [float] NOT NULL,
	[MaxPrice] [float] NOT NULL,
	[Star] [int] NULL,
	[Id] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_Hotel] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[HotelScale]    Script Date: 10/10/2017 12:14:59 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HotelScale](
	[Id] [int] IDENTITY(0,1) NOT NULL,
	[Scale] [nvarchar](50) NULL,
	[SameScaleId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Image]    Script Date: 10/10/2017 12:14:59 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Image](
	[Id] [int] IDENTITY(0,1) NOT NULL,
	[Url] [nvarchar](150) NOT NULL,
	[DateCreate] [datetime] NULL DEFAULT (getdate()),
	[Description] [nvarchar](max) NULL,
	[ImageKindId] [int] NOT NULL,
	[OwnId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ImageKind]    Script Date: 10/10/2017 12:14:59 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ImageKind](
	[Id] [int] IDENTITY(0,1) NOT NULL,
	[DateCreate] [datetime] NULL DEFAULT (getdate()),
	[Description] [nvarchar](max) NULL,
	[Kind] [nvarchar](40) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Place]    Script Date: 10/10/2017 12:14:59 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Place](
	[Id] [int] IDENTITY(0,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[Longitude] [nvarchar](max) NOT NULL,
	[Latitude] [varchar](max) NOT NULL,
	[ZoomSize] [nvarchar](50) NULL,
	[Address] [nvarchar](max) NOT NULL,
	[ServeStatus] [int] NOT NULL,
	[PlaceKindId] [int] NOT NULL,
	[RootPlaceId] [int] NOT NULL CONSTRAINT [DF_Place_RootPlaceId]  DEFAULT ((0)),
	[TimeOpen] [int] NULL,
	[TimeClose] [int] NULL,
	[RatingStar] [int] NOT NULL CONSTRAINT [DF__Place__RatingSta__21B6055D]  DEFAULT ((0)),
	[NofSearch] [int] NULL CONSTRAINT [DF__Place__NofSearch__22AA2996]  DEFAULT ((0)),
	[Poppular] [int] NULL CONSTRAINT [DF__Place__Poppular__239E4DCF]  DEFAULT ((0)),
	[Facebook] [nvarchar](max) NULL,
	[Instagram] [nvarchar](max) NULL,
	[PageUrl] [nvarchar](max) NULL,
	[UserId] [int] NULL,
	[PhoneNumber] [nvarchar](100) NULL,
	[DateCreate] [datetime] NULL CONSTRAINT [DF_Place_DateCreate]  DEFAULT (getdate()),
	[LastConfirm] [datetime] NULL CONSTRAINT [DF_Place_LastCofirm]  DEFAULT (getdate()),
	[isEnable] [bit] NULL CONSTRAINT [DF_Place_isEnable]  DEFAULT ((0)),
 CONSTRAINT [PK__Place__3214EC07827B697D] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PlaceKind]    Script Date: 10/10/2017 12:14:59 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PlaceKind](
	[Id] [int] IDENTITY(0,1) NOT NULL,
	[DateCreate] [datetime] NULL DEFAULT (getdate()),
	[Description] [nvarchar](max) NULL,
	[Kind] [nvarchar](40) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Restaurant]    Script Date: 10/10/2017 12:14:59 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Restaurant](
	[PlaceId] [int] NULL,
	[Name] [nvarchar](max) NULL,
	[RestaurantScaleId] [int] NULL,
	[MinPrice] [float] NOT NULL,
	[MaxPrice] [float] NOT NULL,
	[Star] [int] NULL,
	[Id] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_Restaurant] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[RestaurantScale]    Script Date: 10/10/2017 12:14:59 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RestaurantScale](
	[Id] [int] IDENTITY(0,1) NOT NULL,
	[Scale] [nvarchar](50) NULL,
	[SameScaleId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Tag]    Script Date: 10/10/2017 12:14:59 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tag](
	[Id] [int] IDENTITY(0,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TagUsage]    Script Date: 10/10/2017 12:14:59 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TagUsage](
	[Id] [int] IDENTITY(0,1) NOT NULL,
	[TagId] [int] NOT NULL,
	[PlaceId] [int] NULL,
	[EventId] [int] NULL,
 CONSTRAINT [PK_TagUsage] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TripBook]    Script Date: 10/10/2017 12:14:59 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TripBook](
	[Id] [int] IDENTITY(0,1) NOT NULL,
	[DateCreate] [datetime] NULL DEFAULT (getdate()),
	[UserId] [int] NOT NULL,
	[isTraveled] [bit] NULL DEFAULT ((0)),
	[isRemoved] [bit] NULL DEFAULT ((0)),
	[FeedBackId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TripBookHasPlace]    Script Date: 10/10/2017 12:14:59 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TripBookHasPlace](
	[Id] [int] IDENTITY(0,1) NOT NULL,
	[DateCreate] [datetime] NULL DEFAULT (getdate()),
	[TripBookId] [int] NOT NULL,
	[PlaceId] [int] NOT NULL,
	[isTraveled] [bit] NULL DEFAULT ((0)),
	[isRemoved] [bit] NULL DEFAULT ((0)),
	[Vendor] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Users]    Script Date: 10/10/2017 12:14:59 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(0,1) NOT NULL,
	[DateCreate] [datetime] NULL DEFAULT (getdate()),
	[DateUpdate] [datetime] NULL DEFAULT (getdate()),
	[Username] [varchar](50) NOT NULL,
	[Password] [varchar](50) NOT NULL,
	[ImageId] [int] NOT NULL,
	[Email] [nvarchar](max) NULL,
	[isEnable] [bit] NULL,
	[Role] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Index [IX_TagUsage]    Script Date: 10/10/2017 12:14:59 AM ******/
CREATE NONCLUSTERED INDEX [IX_TagUsage] ON [dbo].[TagUsage]
(
	[TagId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Article] ADD  DEFAULT (getdate()) FOR [DateCreate]
GO
ALTER TABLE [dbo].[Article] ADD  DEFAULT (getdate()) FOR [DateUpdate]
GO
ALTER TABLE [dbo].[ArticleKind] ADD  DEFAULT (getdate()) FOR [DateCreate]
GO
ALTER TABLE [dbo].[Comment] ADD  DEFAULT (getdate()) FOR [DateCreate]
GO
ALTER TABLE [dbo].[FeedBack] ADD  DEFAULT (getdate()) FOR [DateCreate]
GO
ALTER TABLE [dbo].[Article]  WITH CHECK ADD  CONSTRAINT [FK_Article_ArticleKind] FOREIGN KEY([ArticleKindId])
REFERENCES [dbo].[ArticleKind] ([Id])
GO
ALTER TABLE [dbo].[Article] CHECK CONSTRAINT [FK_Article_ArticleKind]
GO
ALTER TABLE [dbo].[Comment]  WITH CHECK ADD  CONSTRAINT [FK_Comment_Event] FOREIGN KEY([EventId])
REFERENCES [dbo].[Event] ([Id])
GO
ALTER TABLE [dbo].[Comment] CHECK CONSTRAINT [FK_Comment_Event]
GO
ALTER TABLE [dbo].[Comment]  WITH CHECK ADD  CONSTRAINT [FK_Comment_Place] FOREIGN KEY([PlaceId])
REFERENCES [dbo].[Place] ([Id])
GO
ALTER TABLE [dbo].[Comment] CHECK CONSTRAINT [FK_Comment_Place]
GO
ALTER TABLE [dbo].[Comment]  WITH CHECK ADD  CONSTRAINT [FK_Comment_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[Comment] CHECK CONSTRAINT [FK_Comment_Users]
GO
ALTER TABLE [dbo].[Event]  WITH CHECK ADD  CONSTRAINT [FK_Event_EventKind] FOREIGN KEY([EventKindId])
REFERENCES [dbo].[EventKind] ([Id])
GO
ALTER TABLE [dbo].[Event] CHECK CONSTRAINT [FK_Event_EventKind]
GO
ALTER TABLE [dbo].[Event]  WITH CHECK ADD  CONSTRAINT [FK_Event_Place] FOREIGN KEY([PlaceId])
REFERENCES [dbo].[Place] ([Id])
GO
ALTER TABLE [dbo].[Event] CHECK CONSTRAINT [FK_Event_Place]
GO
ALTER TABLE [dbo].[Hotel]  WITH CHECK ADD  CONSTRAINT [FK_Hotel_HotelScale] FOREIGN KEY([HotelScaleId])
REFERENCES [dbo].[HotelScale] ([Id])
GO
ALTER TABLE [dbo].[Hotel] CHECK CONSTRAINT [FK_Hotel_HotelScale]
GO
ALTER TABLE [dbo].[Hotel]  WITH CHECK ADD  CONSTRAINT [FK_Hotel_Place] FOREIGN KEY([PlaceId])
REFERENCES [dbo].[Place] ([Id])
GO
ALTER TABLE [dbo].[Hotel] CHECK CONSTRAINT [FK_Hotel_Place]
GO
ALTER TABLE [dbo].[HotelScale]  WITH CHECK ADD  CONSTRAINT [FK_HotelScale_HotelScale] FOREIGN KEY([SameScaleId])
REFERENCES [dbo].[HotelScale] ([Id])
GO
ALTER TABLE [dbo].[HotelScale] CHECK CONSTRAINT [FK_HotelScale_HotelScale]
GO
ALTER TABLE [dbo].[Image]  WITH CHECK ADD  CONSTRAINT [FK_Image_ImageKind] FOREIGN KEY([ImageKindId])
REFERENCES [dbo].[ImageKind] ([Id])
GO
ALTER TABLE [dbo].[Image] CHECK CONSTRAINT [FK_Image_ImageKind]
GO
ALTER TABLE [dbo].[Place]  WITH CHECK ADD  CONSTRAINT [FK_Place_PlaceKind] FOREIGN KEY([PlaceKindId])
REFERENCES [dbo].[PlaceKind] ([Id])
GO
ALTER TABLE [dbo].[Place] CHECK CONSTRAINT [FK_Place_PlaceKind]
GO
ALTER TABLE [dbo].[Place]  WITH CHECK ADD  CONSTRAINT [FK_Place_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[Place] CHECK CONSTRAINT [FK_Place_Users]
GO
ALTER TABLE [dbo].[Restaurant]  WITH CHECK ADD  CONSTRAINT [FK_Restaurant_Place] FOREIGN KEY([PlaceId])
REFERENCES [dbo].[Place] ([Id])
GO
ALTER TABLE [dbo].[Restaurant] CHECK CONSTRAINT [FK_Restaurant_Place]
GO
ALTER TABLE [dbo].[Restaurant]  WITH CHECK ADD  CONSTRAINT [FK_Restaurant_RestaurantScale] FOREIGN KEY([RestaurantScaleId])
REFERENCES [dbo].[RestaurantScale] ([Id])
GO
ALTER TABLE [dbo].[Restaurant] CHECK CONSTRAINT [FK_Restaurant_RestaurantScale]
GO
ALTER TABLE [dbo].[RestaurantScale]  WITH CHECK ADD  CONSTRAINT [FK_RestaurantScale_RestaurantScale] FOREIGN KEY([SameScaleId])
REFERENCES [dbo].[RestaurantScale] ([Id])
GO
ALTER TABLE [dbo].[RestaurantScale] CHECK CONSTRAINT [FK_RestaurantScale_RestaurantScale]
GO
ALTER TABLE [dbo].[TagUsage]  WITH CHECK ADD  CONSTRAINT [FK_TagUsage_Event] FOREIGN KEY([EventId])
REFERENCES [dbo].[Event] ([Id])
GO
ALTER TABLE [dbo].[TagUsage] CHECK CONSTRAINT [FK_TagUsage_Event]
GO
ALTER TABLE [dbo].[TagUsage]  WITH CHECK ADD  CONSTRAINT [FK_TagUsage_Place] FOREIGN KEY([PlaceId])
REFERENCES [dbo].[Place] ([Id])
GO
ALTER TABLE [dbo].[TagUsage] CHECK CONSTRAINT [FK_TagUsage_Place]
GO
ALTER TABLE [dbo].[TagUsage]  WITH CHECK ADD  CONSTRAINT [FK_TagUsage_Tag] FOREIGN KEY([TagId])
REFERENCES [dbo].[Tag] ([Id])
GO
ALTER TABLE [dbo].[TagUsage] CHECK CONSTRAINT [FK_TagUsage_Tag]
GO
ALTER TABLE [dbo].[TripBookHasPlace]  WITH CHECK ADD  CONSTRAINT [FK_TripBookHasPlace_Place] FOREIGN KEY([PlaceId])
REFERENCES [dbo].[Place] ([Id])
GO
ALTER TABLE [dbo].[TripBookHasPlace] CHECK CONSTRAINT [FK_TripBookHasPlace_Place]
GO
ALTER TABLE [dbo].[TripBookHasPlace]  WITH CHECK ADD  CONSTRAINT [FK_TripBookHasPlace_TripBook] FOREIGN KEY([TripBookId])
REFERENCES [dbo].[TripBook] ([Id])
GO
ALTER TABLE [dbo].[TripBookHasPlace] CHECK CONSTRAINT [FK_TripBookHasPlace_TripBook]
GO
ALTER TABLE [dbo].[Place]  WITH CHECK ADD  CONSTRAINT [CK__Place__RatingSta__20C1E124] CHECK  (([RatingStar]=(5) OR [RatingStar]=(4) OR [RatingStar]=(3) OR [RatingStar]=(2) OR [RatingStar]=(1) OR [RatingStar]=(0)))
GO
ALTER TABLE [dbo].[Place] CHECK CONSTRAINT [CK__Place__RatingSta__20C1E124]
GO
ALTER TABLE [dbo].[Place]  WITH CHECK ADD  CONSTRAINT [CK__Place__ServeStat__1DE57479] CHECK  (([ServeStatus]=(4) OR [ServeStatus]=(3) OR [ServeStatus]=(2) OR [ServeStatus]=(1) OR [ServeStatus]=(0)))
GO
ALTER TABLE [dbo].[Place] CHECK CONSTRAINT [CK__Place__ServeStat__1DE57479]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD CHECK  (([Role]=(4) OR [Role]=(3) OR [Role]=(2) OR [Role]=(1) OR [Role]=(0)))
GO
USE [master]
GO
ALTER DATABASE [TourMe] SET  READ_WRITE 
GO
