/****** Object:  Table [dbo].[Article]    Script Date: 10/17/2017 10:30:41 PM ******/
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
/****** Object:  Table [dbo].[ArticleKind]    Script Date: 10/17/2017 10:30:41 PM ******/
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
/****** Object:  Table [dbo].[Comment]    Script Date: 10/17/2017 10:30:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Comment](
	[Id] [int] IDENTITY(0,1) NOT NULL,
	[DateCreate] [datetime] NULL,
	[Content] [nvarchar](max) NULL,
	[Kind] [nvarchar](50) NOT NULL,
	[UserId] [int] NOT NULL,
	[PlaceId] [int] NULL,
	[EventId] [int] NULL,
 CONSTRAINT [PK__Comment__3214EC07D87D645C] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Credential]    Script Date: 10/17/2017 10:30:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Credential](
	[UserGroupId] [varchar](50) NOT NULL,
	[RoleId] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Credential] PRIMARY KEY CLUSTERED 
(
	[UserGroupId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Event]    Script Date: 10/17/2017 10:30:41 PM ******/
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
/****** Object:  Table [dbo].[EventKind]    Script Date: 10/17/2017 10:30:41 PM ******/
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
/****** Object:  Table [dbo].[FeedBack]    Script Date: 10/17/2017 10:30:41 PM ******/
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
/****** Object:  Table [dbo].[Image]    Script Date: 10/17/2017 10:30:41 PM ******/
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
/****** Object:  Table [dbo].[ImageKind]    Script Date: 10/17/2017 10:30:41 PM ******/
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
/****** Object:  Table [dbo].[Place]    Script Date: 10/17/2017 10:30:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Place](
	[Id] [int] IDENTITY(0,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[Longitude] [float] NOT NULL,
	[Latitude] [float] NOT NULL,
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
	[Definition] [nvarchar](max) NULL,
	[MinPrice] [float] NULL,
	[MaxPrice] [float] NULL,
 CONSTRAINT [PK__Place__3214EC07827B697D] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PlaceKind]    Script Date: 10/17/2017 10:30:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PlaceKind](
	[Id] [int] IDENTITY(0,1) NOT NULL,
	[DateCreate] [datetime] NULL DEFAULT (getdate()),
	[Description] [nvarchar](max) NULL,
	[Kind] [nvarchar](40) NOT NULL,
	[Priority] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Role]    Script Date: 10/17/2017 10:30:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Role](
	[Id] [varchar](50) NOT NULL,
	[Name] [nvarchar](50) NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TripBook]    Script Date: 10/17/2017 10:30:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TripBook](
	[Id] [int] IDENTITY(0,1) NOT NULL,
	[DateCreate] [datetime] NULL,
	[UserId] [int] NOT NULL,
	[isTraveled] [bit] NULL,
	[isRemoved] [bit] NULL,
	[FeedBackId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TripBookHasPlace]    Script Date: 10/17/2017 10:30:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TripBookHasPlace](
	[Id] [int] IDENTITY(0,1) NOT NULL,
	[DateCreate] [datetime] NULL,
	[TripBookId] [int] NOT NULL,
	[PlaceId] [int] NOT NULL,
	[isTraveled] [bit] NULL,
	[isRemoved] [bit] NULL,
	[Vendor] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UserGroup]    Script Date: 10/17/2017 10:30:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[UserGroup](
	[Id] [varchar](50) NOT NULL,
	[Name] [nvarchar](10) NULL,
 CONSTRAINT [PK_UserGroup] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Users]    Script Date: 10/17/2017 10:30:41 PM ******/
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
	[GroupId] [varchar](50) NULL CONSTRAINT [DF_Users_GroupId]  DEFAULT ('MEMBER'),
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[Article] ADD  DEFAULT (getdate()) FOR [DateCreate]
GO
ALTER TABLE [dbo].[Article] ADD  DEFAULT (getdate()) FOR [DateUpdate]
GO
ALTER TABLE [dbo].[ArticleKind] ADD  DEFAULT (getdate()) FOR [DateCreate]
GO
ALTER TABLE [dbo].[Comment] ADD  CONSTRAINT [DF__Comment__DateCre__4AB81AF0]  DEFAULT (getdate()) FOR [DateCreate]
GO
ALTER TABLE [dbo].[FeedBack] ADD  DEFAULT (getdate()) FOR [DateCreate]
GO
ALTER TABLE [dbo].[TripBook] ADD  DEFAULT (getdate()) FOR [DateCreate]
GO
ALTER TABLE [dbo].[TripBook] ADD  DEFAULT ((0)) FOR [isTraveled]
GO
ALTER TABLE [dbo].[TripBook] ADD  DEFAULT ((0)) FOR [isRemoved]
GO
ALTER TABLE [dbo].[TripBookHasPlace] ADD  DEFAULT (getdate()) FOR [DateCreate]
GO
ALTER TABLE [dbo].[TripBookHasPlace] ADD  DEFAULT ((0)) FOR [isTraveled]
GO
ALTER TABLE [dbo].[TripBookHasPlace] ADD  DEFAULT ((0)) FOR [isRemoved]
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
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Comment] CHECK CONSTRAINT [FK_Comment_Users]
GO
ALTER TABLE [dbo].[Event]  WITH CHECK ADD  CONSTRAINT [FK_Event_EventKind] FOREIGN KEY([EventKindId])
REFERENCES [dbo].[EventKind] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Event] CHECK CONSTRAINT [FK_Event_EventKind]
GO
ALTER TABLE [dbo].[Event]  WITH CHECK ADD  CONSTRAINT [FK_Event_Place] FOREIGN KEY([PlaceId])
REFERENCES [dbo].[Place] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Event] CHECK CONSTRAINT [FK_Event_Place]
GO
ALTER TABLE [dbo].[Image]  WITH CHECK ADD  CONSTRAINT [FK_Image_ImageKind] FOREIGN KEY([ImageKindId])
REFERENCES [dbo].[ImageKind] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Image] CHECK CONSTRAINT [FK_Image_ImageKind]
GO
ALTER TABLE [dbo].[Place]  WITH CHECK ADD  CONSTRAINT [FK_Place_PlaceKind] FOREIGN KEY([PlaceKindId])
REFERENCES [dbo].[PlaceKind] ([Id])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Place] CHECK CONSTRAINT [FK_Place_PlaceKind]
GO
ALTER TABLE [dbo].[Place]  WITH CHECK ADD  CONSTRAINT [FK_Place_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Place] CHECK CONSTRAINT [FK_Place_Users]
GO
ALTER TABLE [dbo].[TripBookHasPlace]  WITH CHECK ADD  CONSTRAINT [FK_TripBookHasPlace_Place] FOREIGN KEY([PlaceId])
REFERENCES [dbo].[Place] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TripBookHasPlace] CHECK CONSTRAINT [FK_TripBookHasPlace_Place]
GO
ALTER TABLE [dbo].[TripBookHasPlace]  WITH CHECK ADD  CONSTRAINT [FK_TripBookHasPlace_TripBook] FOREIGN KEY([TripBookId])
REFERENCES [dbo].[TripBook] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
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
