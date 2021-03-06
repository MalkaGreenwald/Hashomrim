USE [master]
GO
/****** Object:  Database [HashomrimProject]    Script Date: 13/11/2019 21:17:27 ******/
CREATE DATABASE [HashomrimProject] ON  PRIMARY 
( NAME = N'HashomrimProject', FILENAME = N'D:\SQL-DATA\HashomrimProject.mdf' , SIZE = 2304KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'HashomrimProject_log', FILENAME = N'D:\SQL-DATA\HashomrimProject_log.LDF' , SIZE = 3520KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [HashomrimProject] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [HashomrimProject].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [HashomrimProject] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [HashomrimProject] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [HashomrimProject] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [HashomrimProject] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [HashomrimProject] SET ARITHABORT OFF 
GO
ALTER DATABASE [HashomrimProject] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [HashomrimProject] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [HashomrimProject] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [HashomrimProject] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [HashomrimProject] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [HashomrimProject] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [HashomrimProject] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [HashomrimProject] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [HashomrimProject] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [HashomrimProject] SET  ENABLE_BROKER 
GO
ALTER DATABASE [HashomrimProject] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [HashomrimProject] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [HashomrimProject] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [HashomrimProject] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [HashomrimProject] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [HashomrimProject] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [HashomrimProject] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [HashomrimProject] SET RECOVERY FULL 
GO
ALTER DATABASE [HashomrimProject] SET  MULTI_USER 
GO
ALTER DATABASE [HashomrimProject] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [HashomrimProject] SET DB_CHAINING OFF 
GO
EXEC sys.sp_db_vardecimal_storage_format N'HashomrimProject', N'ON'
GO
USE [HashomrimProject]
GO
/****** Object:  User [students\hitmachut]    Script Date: 13/11/2019 21:17:27 ******/
CREATE USER [students\hitmachut] FOR LOGIN [STUDENTS\hitmachut] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [students\hitmachut]
GO
ALTER ROLE [db_accessadmin] ADD MEMBER [students\hitmachut]
GO
ALTER ROLE [db_securityadmin] ADD MEMBER [students\hitmachut]
GO
ALTER ROLE [db_ddladmin] ADD MEMBER [students\hitmachut]
GO
ALTER ROLE [db_backupoperator] ADD MEMBER [students\hitmachut]
GO
ALTER ROLE [db_datareader] ADD MEMBER [students\hitmachut]
GO
ALTER ROLE [db_datawriter] ADD MEMBER [students\hitmachut]
GO
ALTER ROLE [db_denydatareader] ADD MEMBER [students\hitmachut]
GO
ALTER ROLE [db_denydatawriter] ADD MEMBER [students\hitmachut]
GO
/****** Object:  Table [dbo].[Callling]    Script Date: 13/11/2019 21:17:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Callling](
	[callingCode] [int] IDENTITY(1,1) NOT NULL,
	[eventCodeId] [int] NOT NULL,
	[callingDate] [datetime] NOT NULL,
 CONSTRAINT [PK_Callling_1] PRIMARY KEY CLUSTERED 
(
	[callingCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DetailsValunteer]    Script Date: 13/11/2019 21:17:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DetailsValunteer](
	[statusValunteerId] [int] NOT NULL,
	[silencingRingingUntilDate] [datetime] NOT NULL,
	[silencingRingingFronDate] [datetime] NULL,
	[id] [int] IDENTITY(1,1) NOT NULL,
	[radius] [int] NULL,
 CONSTRAINT [PK_DetailsValunteer] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EventName]    Script Date: 13/11/2019 21:17:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EventName](
	[eventNameId] [int] IDENTITY(1,1) NOT NULL,
	[discribeEventName] [nvarchar](50) NULL,
 CONSTRAINT [PK_EventName] PRIMARY KEY CLUSTERED 
(
	[eventNameId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Events]    Script Date: 13/11/2019 21:17:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Events](
	[eventCode] [int] IDENTITY(1,1) NOT NULL,
	[eventNameId] [int] NULL,
	[eventDescription] [nvarchar](50) NULL,
	[heightPointAddress] [float] NOT NULL,
	[widthPointAddress] [float] NOT NULL,
	[startCallingDate] [datetime] NOT NULL,
	[eventStatusId] [int] NOT NULL,
	[stringAddress] [nvarchar](50) NULL,
	[city] [int] NULL,
 CONSTRAINT [PK_Events] PRIMARY KEY CLUSTERED 
(
	[eventCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EventStatus]    Script Date: 13/11/2019 21:17:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EventStatus](
	[eventStatusId] [int] IDENTITY(1,1) NOT NULL,
	[discribeEventStatus] [nvarchar](50) NULL,
 CONSTRAINT [PK_EventStatus] PRIMARY KEY CLUSTERED 
(
	[eventStatusId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FreindlyEvent]    Script Date: 13/11/2019 21:17:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FreindlyEvent](
	[freindlyCode] [int] IDENTITY(1,1) NOT NULL,
	[freindlyDescription] [nvarchar](50) NULL,
	[heightPointAddress] [float] NULL,
	[widthPointAddress] [float] NULL,
	[hour] [time](7) NULL,
	[countValunteer] [int] NULL,
	[date] [datetime] NULL,
	[city] [int] NULL,
	[addressFreindlyEvent] [nvarchar](50) NULL,
 CONSTRAINT [PK_FreindlyEvent] PRIMARY KEY CLUSTERED 
(
	[freindlyCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GoogleMap]    Script Date: 13/11/2019 21:17:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GoogleMap](
	[num] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HistoryStatusValunteer]    Script Date: 13/11/2019 21:17:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HistoryStatusValunteer](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[statusValunteerId] [int] NOT NULL,
	[silencingRingingUntilDate] [datetime] NOT NULL,
	[silencingRingingFromDate] [datetime] NOT NULL,
	[volunteerId] [int] NULL,
 CONSTRAINT [PK_HistoryStatusValunteer] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Mokdan]    Script Date: 13/11/2019 21:17:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Mokdan](
	[idMokdan] [int] IDENTITY(1,1) NOT NULL,
	[userName] [nvarchar](50) NULL,
	[password] [varchar](50) NULL,
 CONSTRAINT [PK_Mokdan] PRIMARY KEY CLUSTERED 
(
	[idMokdan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PersonalSituation]    Script Date: 13/11/2019 21:17:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PersonalSituation](
	[personalSituationId] [int] IDENTITY(1,1) NOT NULL,
	[discribe] [nvarchar](50) NULL,
 CONSTRAINT [PK_PersonalSituation] PRIMARY KEY CLUSTERED 
(
	[personalSituationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StatusValunteer]    Script Date: 13/11/2019 21:17:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StatusValunteer](
	[statusValunteerId] [int] IDENTITY(1,1) NOT NULL,
	[discribeStatusValunteer] [nvarchar](50) NULL,
 CONSTRAINT [PK_StatusValunteer] PRIMARY KEY CLUSTERED 
(
	[statusValunteerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Valunteer]    Script Date: 13/11/2019 21:17:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Valunteer](
	[tz] [nvarchar](50) NOT NULL,
	[firstName] [nvarchar](50) NOT NULL,
	[lastName] [nvarchar](50) NOT NULL,
	[phone] [nvarchar](50) NOT NULL,
	[cityId] [int] NULL,
	[hieghtPointAddress] [float] NULL,
	[personalSituationId] [int] NULL,
	[widthPointAddress] [float] NULL,
	[volunteerDetailId] [int] NULL,
	[id] [int] IDENTITY(1,1) NOT NULL,
	[addressVolunteer] [nvarchar](50) NULL,
 CONSTRAINT [PK_Valunteer] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ValunteerEvent]    Script Date: 13/11/2019 21:17:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ValunteerEvent](
	[valunteerId] [int] NOT NULL,
	[eventCodeId] [int] NOT NULL,
	[valunteerStatusInEventId] [int] NULL,
	[dateGetEvent] [datetime] NULL,
	[id] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_ValunteerEvent] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ValunteerStatusInEvent]    Script Date: 13/11/2019 21:17:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ValunteerStatusInEvent](
	[valunteerStatusInEventId] [int] IDENTITY(1,1) NOT NULL,
	[discribeValunteerStatusInEvent] [nvarchar](50) NULL,
 CONSTRAINT [PK_ValunteerStatusInEvent] PRIMARY KEY CLUSTERED 
(
	[valunteerStatusInEventId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[DetailsValunteer] ON 

INSERT [dbo].[DetailsValunteer] ([statusValunteerId], [silencingRingingUntilDate], [silencingRingingFronDate], [id], [radius]) VALUES (3, CAST(N'5000-12-11T00:00:00.000' AS DateTime), CAST(N'2000-02-03T00:00:00.000' AS DateTime), 1, NULL)
INSERT [dbo].[DetailsValunteer] ([statusValunteerId], [silencingRingingUntilDate], [silencingRingingFronDate], [id], [radius]) VALUES (1, CAST(N'2019-09-03T19:02:15.913' AS DateTime), CAST(N'2019-09-03T19:01:15.490' AS DateTime), 4, NULL)
INSERT [dbo].[DetailsValunteer] ([statusValunteerId], [silencingRingingUntilDate], [silencingRingingFronDate], [id], [radius]) VALUES (1, CAST(N'2000-02-03T00:00:00.000' AS DateTime), CAST(N'2000-02-03T00:00:00.000' AS DateTime), 5, NULL)
INSERT [dbo].[DetailsValunteer] ([statusValunteerId], [silencingRingingUntilDate], [silencingRingingFronDate], [id], [radius]) VALUES (1, CAST(N'2000-02-03T00:00:00.000' AS DateTime), CAST(N'2000-02-03T00:00:00.000' AS DateTime), 8, NULL)
INSERT [dbo].[DetailsValunteer] ([statusValunteerId], [silencingRingingUntilDate], [silencingRingingFronDate], [id], [radius]) VALUES (1, CAST(N'2019-10-29T19:41:03.073' AS DateTime), CAST(N'2019-10-29T19:41:02.513' AS DateTime), 14, NULL)
INSERT [dbo].[DetailsValunteer] ([statusValunteerId], [silencingRingingUntilDate], [silencingRingingFronDate], [id], [radius]) VALUES (1, CAST(N'2019-10-29T20:12:58.010' AS DateTime), CAST(N'2019-10-29T20:12:24.297' AS DateTime), 15, NULL)
INSERT [dbo].[DetailsValunteer] ([statusValunteerId], [silencingRingingUntilDate], [silencingRingingFronDate], [id], [radius]) VALUES (1, CAST(N'2019-11-05T20:29:34.703' AS DateTime), CAST(N'2019-11-05T20:29:34.703' AS DateTime), 16, NULL)
SET IDENTITY_INSERT [dbo].[DetailsValunteer] OFF
SET IDENTITY_INSERT [dbo].[EventName] ON 

INSERT [dbo].[EventName] ([eventNameId], [discribeEventName]) VALUES (1, N'פריצה')
INSERT [dbo].[EventName] ([eventNameId], [discribeEventName]) VALUES (2, N'מקרה פשע')
INSERT [dbo].[EventName] ([eventNameId], [discribeEventName]) VALUES (3, N'התעללות')
INSERT [dbo].[EventName] ([eventNameId], [discribeEventName]) VALUES (4, N'ללא שם')
SET IDENTITY_INSERT [dbo].[EventName] OFF
SET IDENTITY_INSERT [dbo].[Events] ON 

INSERT [dbo].[Events] ([eventCode], [eventNameId], [eventDescription], [heightPointAddress], [widthPointAddress], [startCallingDate], [eventStatusId], [stringAddress], [city]) VALUES (17, 1, N'פריצת אופניים', 1, 1, CAST(N'2019-10-29T21:18:33.633' AS DateTime), 1, N'הרצל ', NULL)
INSERT [dbo].[Events] ([eventCode], [eventNameId], [eventDescription], [heightPointAddress], [widthPointAddress], [startCallingDate], [eventStatusId], [stringAddress], [city]) VALUES (35, 1, N'פריצת חנות', 1, 1, CAST(N'2019-02-02T00:00:00.000' AS DateTime), 1, N'בן גוריון', NULL)
INSERT [dbo].[Events] ([eventCode], [eventNameId], [eventDescription], [heightPointAddress], [widthPointAddress], [startCallingDate], [eventStatusId], [stringAddress], [city]) VALUES (39, 2, N'חפץ חשוד', 2, 2, CAST(N'2019-03-02T00:00:00.000' AS DateTime), 2, N'הרצל', NULL)
INSERT [dbo].[Events] ([eventCode], [eventNameId], [eventDescription], [heightPointAddress], [widthPointAddress], [startCallingDate], [eventStatusId], [stringAddress], [city]) VALUES (41, 2, N'חפץ חשוד', 2, 2, CAST(N'2019-06-20T00:00:00.000' AS DateTime), 2, N'בן גוריון', NULL)
INSERT [dbo].[Events] ([eventCode], [eventNameId], [eventDescription], [heightPointAddress], [widthPointAddress], [startCallingDate], [eventStatusId], [stringAddress], [city]) VALUES (42, 2, N'kjhgf', 0, 0, CAST(N'2019-10-29T20:17:23.147' AS DateTime), 1, N'lkja', NULL)
SET IDENTITY_INSERT [dbo].[Events] OFF
SET IDENTITY_INSERT [dbo].[EventStatus] ON 

INSERT [dbo].[EventStatus] ([eventStatusId], [discribeEventStatus]) VALUES (1, N'פתוח')
INSERT [dbo].[EventStatus] ([eventStatusId], [discribeEventStatus]) VALUES (2, N'הוזנק')
INSERT [dbo].[EventStatus] ([eventStatusId], [discribeEventStatus]) VALUES (3, N'מבוטל')
INSERT [dbo].[EventStatus] ([eventStatusId], [discribeEventStatus]) VALUES (4, N'הסתיים')
SET IDENTITY_INSERT [dbo].[EventStatus] OFF
SET IDENTITY_INSERT [dbo].[FreindlyEvent] ON 

INSERT [dbo].[FreindlyEvent] ([freindlyCode], [freindlyDescription], [heightPointAddress], [widthPointAddress], [hour], [countValunteer], [date], [city], [addressFreindlyEvent]) VALUES (1, N'מסיבת סיום', 20, 30, CAST(N'23:00:00' AS Time), 6, CAST(N'1999-02-01T00:00:00.000' AS DateTime), NULL, NULL)
INSERT [dbo].[FreindlyEvent] ([freindlyCode], [freindlyDescription], [heightPointAddress], [widthPointAddress], [hour], [countValunteer], [date], [city], [addressFreindlyEvent]) VALUES (2, N'מסיבת חנוכה', 10, 10, CAST(N'07:00:00' AS Time), 2, CAST(N'1999-09-04T00:00:00.000' AS DateTime), NULL, NULL)
INSERT [dbo].[FreindlyEvent] ([freindlyCode], [freindlyDescription], [heightPointAddress], [widthPointAddress], [hour], [countValunteer], [date], [city], [addressFreindlyEvent]) VALUES (3, N'מחנה', 50, 20, CAST(N'03:00:00' AS Time), 1, CAST(N'2000-05-02T00:00:00.000' AS DateTime), NULL, NULL)
SET IDENTITY_INSERT [dbo].[FreindlyEvent] OFF
SET IDENTITY_INSERT [dbo].[HistoryStatusValunteer] ON 

INSERT [dbo].[HistoryStatusValunteer] ([id], [statusValunteerId], [silencingRingingUntilDate], [silencingRingingFromDate], [volunteerId]) VALUES (17, 2, CAST(N'2019-07-08T16:32:33.197' AS DateTime), CAST(N'2019-07-08T16:32:27.647' AS DateTime), 4)
INSERT [dbo].[HistoryStatusValunteer] ([id], [statusValunteerId], [silencingRingingUntilDate], [silencingRingingFromDate], [volunteerId]) VALUES (18, 2, CAST(N'2019-07-08T16:38:54.897' AS DateTime), CAST(N'2019-07-08T16:38:51.573' AS DateTime), 4)
INSERT [dbo].[HistoryStatusValunteer] ([id], [statusValunteerId], [silencingRingingUntilDate], [silencingRingingFromDate], [volunteerId]) VALUES (19, 2, CAST(N'2019-07-08T16:39:39.230' AS DateTime), CAST(N'2019-07-08T16:39:36.993' AS DateTime), 4)
INSERT [dbo].[HistoryStatusValunteer] ([id], [statusValunteerId], [silencingRingingUntilDate], [silencingRingingFromDate], [volunteerId]) VALUES (20, 2, CAST(N'2019-07-08T16:41:58.190' AS DateTime), CAST(N'2019-07-08T16:41:57.260' AS DateTime), 4)
INSERT [dbo].[HistoryStatusValunteer] ([id], [statusValunteerId], [silencingRingingUntilDate], [silencingRingingFromDate], [volunteerId]) VALUES (21, 2, CAST(N'2019-07-08T16:41:59.280' AS DateTime), CAST(N'2019-07-08T16:41:58.897' AS DateTime), 4)
INSERT [dbo].[HistoryStatusValunteer] ([id], [statusValunteerId], [silencingRingingUntilDate], [silencingRingingFromDate], [volunteerId]) VALUES (22, 2, CAST(N'2019-07-08T16:42:00.147' AS DateTime), CAST(N'2019-07-08T16:41:59.787' AS DateTime), 4)
INSERT [dbo].[HistoryStatusValunteer] ([id], [statusValunteerId], [silencingRingingUntilDate], [silencingRingingFromDate], [volunteerId]) VALUES (23, 2, CAST(N'2019-07-08T16:42:02.337' AS DateTime), CAST(N'2019-07-08T16:42:00.537' AS DateTime), 4)
INSERT [dbo].[HistoryStatusValunteer] ([id], [statusValunteerId], [silencingRingingUntilDate], [silencingRingingFromDate], [volunteerId]) VALUES (24, 2, CAST(N'2019-08-06T19:13:46.217' AS DateTime), CAST(N'2019-08-06T19:13:39.597' AS DateTime), 4)
INSERT [dbo].[HistoryStatusValunteer] ([id], [statusValunteerId], [silencingRingingUntilDate], [silencingRingingFromDate], [volunteerId]) VALUES (25, 2, CAST(N'2019-08-06T20:03:02.600' AS DateTime), CAST(N'2019-08-06T20:02:56.217' AS DateTime), 4)
INSERT [dbo].[HistoryStatusValunteer] ([id], [statusValunteerId], [silencingRingingUntilDate], [silencingRingingFromDate], [volunteerId]) VALUES (26, 2, CAST(N'2019-08-06T20:04:07.907' AS DateTime), CAST(N'2019-08-06T20:04:04.133' AS DateTime), 4)
INSERT [dbo].[HistoryStatusValunteer] ([id], [statusValunteerId], [silencingRingingUntilDate], [silencingRingingFromDate], [volunteerId]) VALUES (27, 2, CAST(N'2019-08-06T20:05:09.257' AS DateTime), CAST(N'2019-08-06T20:04:08.463' AS DateTime), 4)
INSERT [dbo].[HistoryStatusValunteer] ([id], [statusValunteerId], [silencingRingingUntilDate], [silencingRingingFromDate], [volunteerId]) VALUES (28, 2, CAST(N'2019-08-06T21:00:05.837' AS DateTime), CAST(N'2019-08-06T20:59:05.687' AS DateTime), 4)
INSERT [dbo].[HistoryStatusValunteer] ([id], [statusValunteerId], [silencingRingingUntilDate], [silencingRingingFromDate], [volunteerId]) VALUES (29, 2, CAST(N'2019-08-06T21:01:12.290' AS DateTime), CAST(N'2019-08-06T21:00:35.003' AS DateTime), 4)
INSERT [dbo].[HistoryStatusValunteer] ([id], [statusValunteerId], [silencingRingingUntilDate], [silencingRingingFromDate], [volunteerId]) VALUES (30, 2, CAST(N'2019-08-06T21:01:15.510' AS DateTime), CAST(N'2019-08-06T21:01:07.807' AS DateTime), 4)
INSERT [dbo].[HistoryStatusValunteer] ([id], [statusValunteerId], [silencingRingingUntilDate], [silencingRingingFromDate], [volunteerId]) VALUES (31, 2, CAST(N'2019-08-06T21:01:16.463' AS DateTime), CAST(N'2019-08-06T21:01:14.920' AS DateTime), 4)
INSERT [dbo].[HistoryStatusValunteer] ([id], [statusValunteerId], [silencingRingingUntilDate], [silencingRingingFromDate], [volunteerId]) VALUES (32, 2, CAST(N'2019-08-06T21:02:17.267' AS DateTime), CAST(N'2019-08-06T21:01:15.980' AS DateTime), 4)
INSERT [dbo].[HistoryStatusValunteer] ([id], [statusValunteerId], [silencingRingingUntilDate], [silencingRingingFromDate], [volunteerId]) VALUES (33, 2, CAST(N'2019-08-06T21:03:44.453' AS DateTime), CAST(N'2019-08-06T21:01:17.120' AS DateTime), 4)
INSERT [dbo].[HistoryStatusValunteer] ([id], [statusValunteerId], [silencingRingingUntilDate], [silencingRingingFromDate], [volunteerId]) VALUES (34, 2, CAST(N'2019-08-07T20:30:57.023' AS DateTime), CAST(N'2019-08-06T21:02:44.307' AS DateTime), 4)
INSERT [dbo].[HistoryStatusValunteer] ([id], [statusValunteerId], [silencingRingingUntilDate], [silencingRingingFromDate], [volunteerId]) VALUES (35, 2, CAST(N'2019-08-07T20:32:05.493' AS DateTime), CAST(N'2019-08-07T20:29:56.813' AS DateTime), 4)
INSERT [dbo].[HistoryStatusValunteer] ([id], [statusValunteerId], [silencingRingingUntilDate], [silencingRingingFromDate], [volunteerId]) VALUES (36, 2, CAST(N'2019-08-07T20:42:18.620' AS DateTime), CAST(N'2019-08-07T20:32:02.827' AS DateTime), 4)
INSERT [dbo].[HistoryStatusValunteer] ([id], [statusValunteerId], [silencingRingingUntilDate], [silencingRingingFromDate], [volunteerId]) VALUES (37, 2, CAST(N'2019-08-07T20:42:20.397' AS DateTime), CAST(N'2019-08-07T20:42:17.487' AS DateTime), 4)
INSERT [dbo].[HistoryStatusValunteer] ([id], [statusValunteerId], [silencingRingingUntilDate], [silencingRingingFromDate], [volunteerId]) VALUES (38, 2, CAST(N'2019-08-07T21:03:17.363' AS DateTime), CAST(N'2019-08-07T20:42:19.553' AS DateTime), 4)
INSERT [dbo].[HistoryStatusValunteer] ([id], [statusValunteerId], [silencingRingingUntilDate], [silencingRingingFromDate], [volunteerId]) VALUES (39, 2, CAST(N'2019-08-07T21:08:59.267' AS DateTime), CAST(N'2019-08-07T20:42:23.763' AS DateTime), 4)
INSERT [dbo].[HistoryStatusValunteer] ([id], [statusValunteerId], [silencingRingingUntilDate], [silencingRingingFromDate], [volunteerId]) VALUES (40, 2, CAST(N'2019-08-07T21:10:09.220' AS DateTime), CAST(N'2019-08-07T21:02:17.160' AS DateTime), 4)
INSERT [dbo].[HistoryStatusValunteer] ([id], [statusValunteerId], [silencingRingingUntilDate], [silencingRingingFromDate], [volunteerId]) VALUES (41, 2, CAST(N'2019-08-07T21:12:25.837' AS DateTime), CAST(N'2019-08-07T21:07:59.123' AS DateTime), 4)
INSERT [dbo].[HistoryStatusValunteer] ([id], [statusValunteerId], [silencingRingingUntilDate], [silencingRingingFromDate], [volunteerId]) VALUES (42, 2, CAST(N'2019-08-07T21:15:07.460' AS DateTime), CAST(N'2019-08-07T21:09:08.253' AS DateTime), 4)
INSERT [dbo].[HistoryStatusValunteer] ([id], [statusValunteerId], [silencingRingingUntilDate], [silencingRingingFromDate], [volunteerId]) VALUES (43, 2, CAST(N'2019-08-07T21:17:21.413' AS DateTime), CAST(N'2019-08-07T21:11:25.707' AS DateTime), 4)
INSERT [dbo].[HistoryStatusValunteer] ([id], [statusValunteerId], [silencingRingingUntilDate], [silencingRingingFromDate], [volunteerId]) VALUES (44, 2, CAST(N'2019-09-03T19:02:15.913' AS DateTime), CAST(N'2019-08-07T21:12:35.070' AS DateTime), 4)
INSERT [dbo].[HistoryStatusValunteer] ([id], [statusValunteerId], [silencingRingingUntilDate], [silencingRingingFromDate], [volunteerId]) VALUES (45, 2, CAST(N'2019-08-08T21:14:07.310' AS DateTime), CAST(N'2019-08-07T21:14:07.310' AS DateTime), 4)
INSERT [dbo].[HistoryStatusValunteer] ([id], [statusValunteerId], [silencingRingingUntilDate], [silencingRingingFromDate], [volunteerId]) VALUES (46, 2, CAST(N'2019-08-08T21:16:21.257' AS DateTime), CAST(N'2019-08-07T21:16:21.257' AS DateTime), 4)
INSERT [dbo].[HistoryStatusValunteer] ([id], [statusValunteerId], [silencingRingingUntilDate], [silencingRingingFromDate], [volunteerId]) VALUES (47, 2, CAST(N'2019-08-08T21:18:18.617' AS DateTime), CAST(N'2019-08-07T21:18:18.617' AS DateTime), 4)
INSERT [dbo].[HistoryStatusValunteer] ([id], [statusValunteerId], [silencingRingingUntilDate], [silencingRingingFromDate], [volunteerId]) VALUES (48, 2, CAST(N'2019-09-04T19:01:15.437' AS DateTime), CAST(N'2019-09-03T19:01:15.437' AS DateTime), 4)
INSERT [dbo].[HistoryStatusValunteer] ([id], [statusValunteerId], [silencingRingingUntilDate], [silencingRingingFromDate], [volunteerId]) VALUES (49, 2, CAST(N'2019-10-29T20:12:58.010' AS DateTime), CAST(N'2019-10-29T20:05:45.267' AS DateTime), 10)
INSERT [dbo].[HistoryStatusValunteer] ([id], [statusValunteerId], [silencingRingingUntilDate], [silencingRingingFromDate], [volunteerId]) VALUES (50, 2, CAST(N'2019-10-30T20:12:24.247' AS DateTime), CAST(N'2019-10-29T20:12:24.247' AS DateTime), 10)
SET IDENTITY_INSERT [dbo].[HistoryStatusValunteer] OFF
SET IDENTITY_INSERT [dbo].[Mokdan] ON 

INSERT [dbo].[Mokdan] ([idMokdan], [userName], [password]) VALUES (4, N'aaa', N'111')
INSERT [dbo].[Mokdan] ([idMokdan], [userName], [password]) VALUES (5, N'ccc', N'111')
INSERT [dbo].[Mokdan] ([idMokdan], [userName], [password]) VALUES (6, N'ccc', N'111')
INSERT [dbo].[Mokdan] ([idMokdan], [userName], [password]) VALUES (7, N'ccc', N'111')
INSERT [dbo].[Mokdan] ([idMokdan], [userName], [password]) VALUES (8, N'ccc', N'111')
INSERT [dbo].[Mokdan] ([idMokdan], [userName], [password]) VALUES (9, N'ccc', N'111')
INSERT [dbo].[Mokdan] ([idMokdan], [userName], [password]) VALUES (10, N'ccc', N'111')
SET IDENTITY_INSERT [dbo].[Mokdan] OFF
SET IDENTITY_INSERT [dbo].[PersonalSituation] ON 

INSERT [dbo].[PersonalSituation] ([personalSituationId], [discribe]) VALUES (1, N'רווק')
INSERT [dbo].[PersonalSituation] ([personalSituationId], [discribe]) VALUES (2, N'נשוי')
INSERT [dbo].[PersonalSituation] ([personalSituationId], [discribe]) VALUES (3, N'אלמן')
INSERT [dbo].[PersonalSituation] ([personalSituationId], [discribe]) VALUES (4, N'גרוש')
SET IDENTITY_INSERT [dbo].[PersonalSituation] OFF
SET IDENTITY_INSERT [dbo].[StatusValunteer] ON 

INSERT [dbo].[StatusValunteer] ([statusValunteerId], [discribeStatusValunteer]) VALUES (1, N'פעיל')
INSERT [dbo].[StatusValunteer] ([statusValunteerId], [discribeStatusValunteer]) VALUES (2, N'לא פעיל')
INSERT [dbo].[StatusValunteer] ([statusValunteerId], [discribeStatusValunteer]) VALUES (3, N'מושהה')
SET IDENTITY_INSERT [dbo].[StatusValunteer] OFF
SET IDENTITY_INSERT [dbo].[Valunteer] ON 

INSERT [dbo].[Valunteer] ([tz], [firstName], [lastName], [phone], [cityId], [hieghtPointAddress], [personalSituationId], [widthPointAddress], [volunteerDetailId], [id], [addressVolunteer]) VALUES (N'1', N'שימי', N'זילברשלג', N'1', 6, 6, 1, NULL, 4, 4, NULL)
INSERT [dbo].[Valunteer] ([tz], [firstName], [lastName], [phone], [cityId], [hieghtPointAddress], [personalSituationId], [widthPointAddress], [volunteerDetailId], [id], [addressVolunteer]) VALUES (N'2', N'רחל', N'כהן', N'2', 1, NULL, 2, NULL, 5, 5, NULL)
INSERT [dbo].[Valunteer] ([tz], [firstName], [lastName], [phone], [cityId], [hieghtPointAddress], [personalSituationId], [widthPointAddress], [volunteerDetailId], [id], [addressVolunteer]) VALUES (N'3', N'ריקי', N'קולפ', N'527199724', 1, NULL, 1, NULL, 8, 6, NULL)
INSERT [dbo].[Valunteer] ([tz], [firstName], [lastName], [phone], [cityId], [hieghtPointAddress], [personalSituationId], [widthPointAddress], [volunteerDetailId], [id], [addressVolunteer]) VALUES (N'4', N'הודיה', N'סימונובסקי', N'58987845', 1, NULL, 1, NULL, NULL, 7, NULL)
INSERT [dbo].[Valunteer] ([tz], [firstName], [lastName], [phone], [cityId], [hieghtPointAddress], [personalSituationId], [widthPointAddress], [volunteerDetailId], [id], [addressVolunteer]) VALUES (N'5', N'דוד', N'יזדי', N'523654122', 1, NULL, 1, NULL, NULL, 8, NULL)
INSERT [dbo].[Valunteer] ([tz], [firstName], [lastName], [phone], [cityId], [hieghtPointAddress], [personalSituationId], [widthPointAddress], [volunteerDetailId], [id], [addressVolunteer]) VALUES (N'67655645', N'fghf', N'fdgfh', N'65757657657', NULL, NULL, 3, NULL, NULL, 9, NULL)
INSERT [dbo].[Valunteer] ([tz], [firstName], [lastName], [phone], [cityId], [hieghtPointAddress], [personalSituationId], [widthPointAddress], [volunteerDetailId], [id], [addressVolunteer]) VALUES (N'5464565456', N'gtyutygu', N'fgyf', N'564596784964', NULL, NULL, 2, NULL, 15, 10, NULL)
INSERT [dbo].[Valunteer] ([tz], [firstName], [lastName], [phone], [cityId], [hieghtPointAddress], [personalSituationId], [widthPointAddress], [volunteerDetailId], [id], [addressVolunteer]) VALUES (N'2354', N'dss', N'dfeds', N'546', NULL, NULL, 1, NULL, 16, 11, NULL)
SET IDENTITY_INSERT [dbo].[Valunteer] OFF
SET IDENTITY_INSERT [dbo].[ValunteerEvent] ON 

INSERT [dbo].[ValunteerEvent] ([valunteerId], [eventCodeId], [valunteerStatusInEventId], [dateGetEvent], [id]) VALUES (1, 17, 2, CAST(N'2019-08-07T20:47:50.457' AS DateTime), 1)
INSERT [dbo].[ValunteerEvent] ([valunteerId], [eventCodeId], [valunteerStatusInEventId], [dateGetEvent], [id]) VALUES (1, 35, 2, CAST(N'2019-08-07T20:49:19.717' AS DateTime), 2)
INSERT [dbo].[ValunteerEvent] ([valunteerId], [eventCodeId], [valunteerStatusInEventId], [dateGetEvent], [id]) VALUES (1, 39, 2, CAST(N'2019-08-07T20:48:49.177' AS DateTime), 3)
INSERT [dbo].[ValunteerEvent] ([valunteerId], [eventCodeId], [valunteerStatusInEventId], [dateGetEvent], [id]) VALUES (9, 17, 2, CAST(N'2019-10-29T19:41:41.380' AS DateTime), 4)
INSERT [dbo].[ValunteerEvent] ([valunteerId], [eventCodeId], [valunteerStatusInEventId], [dateGetEvent], [id]) VALUES (10, 17, 2, CAST(N'2019-10-29T19:48:44.150' AS DateTime), 5)
INSERT [dbo].[ValunteerEvent] ([valunteerId], [eventCodeId], [valunteerStatusInEventId], [dateGetEvent], [id]) VALUES (10, 35, 2, CAST(N'2019-10-29T20:12:52.347' AS DateTime), 6)
SET IDENTITY_INSERT [dbo].[ValunteerEvent] OFF
SET IDENTITY_INSERT [dbo].[ValunteerStatusInEvent] ON 

INSERT [dbo].[ValunteerStatusInEvent] ([valunteerStatusInEventId], [discribeValunteerStatusInEvent]) VALUES (1, N'קיבל קריאה')
INSERT [dbo].[ValunteerStatusInEvent] ([valunteerStatusInEventId], [discribeValunteerStatusInEvent]) VALUES (2, N'יצא לאירוע')
INSERT [dbo].[ValunteerStatusInEvent] ([valunteerStatusInEventId], [discribeValunteerStatusInEvent]) VALUES (3, N'לא יצא לאירוע')
INSERT [dbo].[ValunteerStatusInEvent] ([valunteerStatusInEventId], [discribeValunteerStatusInEvent]) VALUES (4, N'לא קיבל קריאה')
SET IDENTITY_INSERT [dbo].[ValunteerStatusInEvent] OFF
ALTER TABLE [dbo].[DetailsValunteer] ADD  CONSTRAINT [DF_DetailsValunteer_statusValunteerId]  DEFAULT ((3)) FOR [statusValunteerId]
GO
ALTER TABLE [dbo].[Events] ADD  CONSTRAINT [DF_Events_eventNameId]  DEFAULT ('ארוע ללא שם') FOR [eventNameId]
GO
ALTER TABLE [dbo].[Callling]  WITH CHECK ADD  CONSTRAINT [FK_Callling_Events] FOREIGN KEY([eventCodeId])
REFERENCES [dbo].[Events] ([eventCode])
GO
ALTER TABLE [dbo].[Callling] CHECK CONSTRAINT [FK_Callling_Events]
GO
ALTER TABLE [dbo].[DetailsValunteer]  WITH CHECK ADD  CONSTRAINT [FK_DetailsValunteer_StatusValunteer] FOREIGN KEY([statusValunteerId])
REFERENCES [dbo].[StatusValunteer] ([statusValunteerId])
GO
ALTER TABLE [dbo].[DetailsValunteer] CHECK CONSTRAINT [FK_DetailsValunteer_StatusValunteer]
GO
ALTER TABLE [dbo].[Events]  WITH CHECK ADD  CONSTRAINT [FK_Events_EventName] FOREIGN KEY([eventNameId])
REFERENCES [dbo].[EventName] ([eventNameId])
GO
ALTER TABLE [dbo].[Events] CHECK CONSTRAINT [FK_Events_EventName]
GO
ALTER TABLE [dbo].[Events]  WITH CHECK ADD  CONSTRAINT [FK_Events_EventStatus] FOREIGN KEY([eventStatusId])
REFERENCES [dbo].[EventStatus] ([eventStatusId])
GO
ALTER TABLE [dbo].[Events] CHECK CONSTRAINT [FK_Events_EventStatus]
GO
ALTER TABLE [dbo].[HistoryStatusValunteer]  WITH CHECK ADD  CONSTRAINT [FK_HistoryStatusValunteer_Valunteer] FOREIGN KEY([volunteerId])
REFERENCES [dbo].[Valunteer] ([id])
GO
ALTER TABLE [dbo].[HistoryStatusValunteer] CHECK CONSTRAINT [FK_HistoryStatusValunteer_Valunteer]
GO
ALTER TABLE [dbo].[Valunteer]  WITH CHECK ADD  CONSTRAINT [FK_Valunteer_DetailsValunteer] FOREIGN KEY([volunteerDetailId])
REFERENCES [dbo].[DetailsValunteer] ([id])
GO
ALTER TABLE [dbo].[Valunteer] CHECK CONSTRAINT [FK_Valunteer_DetailsValunteer]
GO
ALTER TABLE [dbo].[Valunteer]  WITH CHECK ADD  CONSTRAINT [FK_Valunteer_PersonalSituation] FOREIGN KEY([personalSituationId])
REFERENCES [dbo].[PersonalSituation] ([personalSituationId])
GO
ALTER TABLE [dbo].[Valunteer] CHECK CONSTRAINT [FK_Valunteer_PersonalSituation]
GO
ALTER TABLE [dbo].[ValunteerEvent]  WITH CHECK ADD  CONSTRAINT [FK_ValunteerEvent_Events] FOREIGN KEY([eventCodeId])
REFERENCES [dbo].[Events] ([eventCode])
GO
ALTER TABLE [dbo].[ValunteerEvent] CHECK CONSTRAINT [FK_ValunteerEvent_Events]
GO
ALTER TABLE [dbo].[ValunteerEvent]  WITH CHECK ADD  CONSTRAINT [FK_ValunteerEvent_ValunteerStatusInEvent] FOREIGN KEY([valunteerStatusInEventId])
REFERENCES [dbo].[ValunteerStatusInEvent] ([valunteerStatusInEventId])
GO
ALTER TABLE [dbo].[ValunteerEvent] CHECK CONSTRAINT [FK_ValunteerEvent_ValunteerStatusInEvent]
GO
USE [master]
GO
ALTER DATABASE [HashomrimProject] SET  READ_WRITE 
GO
