USE [idp]
GO
/****** Object:  Schema [cp]    Script Date: 09/01/2015 15:42:10 ******/
IF NOT EXISTS (SELECT * FROM sys.schemas WHERE name = N'cp')
EXEC sys.sp_executesql N'CREATE SCHEMA [cp] AUTHORIZATION [dbo]'
GO
/****** Object:  Table [cp].[PaymentTransactionLog]    Script Date: 09/01/2015 15:42:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[cp].[PaymentTransactionLog]') AND type in (N'U'))
BEGIN
CREATE TABLE [cp].[PaymentTransactionLog](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TransactionId] [varchar](50) NOT NULL,
	[Message] [varchar](500) NOT NULL,
	[CreateUser] [varchar](10) NOT NULL,
	[CreateDate] [datetime2](7) NOT NULL,
	[ModifiedUser] [varchar](10) NOT NULL,
	[ModifiedDate] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_PaymentTransactionLog] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING ON
GO
/****** Object:  Table [cp].[ChargeTransfer]    Script Date: 09/01/2015 15:42:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[cp].[ChargeTransfer]') AND type in (N'U'))
BEGIN
CREATE TABLE [cp].[ChargeTransfer](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TransactionId] [varchar](50) NOT NULL,
	[TransferDate] [datetime2](7) NOT NULL,
	[TransferState] [varchar](20) NOT NULL,
	[CreateUser] [varchar](10) NOT NULL,
	[CreateDate] [datetime2](7) NOT NULL,
	[ModifiedUser] [varchar](10) NOT NULL,
	[ModifiedDate] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_ChargeTransfer] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING ON
GO
/****** Object:  Table [cp].[Charge]    Script Date: 09/01/2015 15:42:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[cp].[Charge]') AND type in (N'U'))
BEGIN
CREATE TABLE [cp].[Charge](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TransactionId] [varchar](50) NOT NULL,
	[ChargeCurrency] [varchar](10) NOT NULL,
	[ChargeAmount] [int] NOT NULL,
	[CreateUser] [varchar](10) NOT NULL,
	[CreateDate] [datetime2](7) NOT NULL,
	[ModifiedUser] [varchar](10) NOT NULL,
	[ModifiedDate] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Charge] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING ON
GO
/****** Object:  Table [cp].[CaptureTransfer]    Script Date: 09/01/2015 15:42:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[cp].[CaptureTransfer]') AND type in (N'U'))
BEGIN
CREATE TABLE [cp].[CaptureTransfer](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TransactionId] [varchar](50) NOT NULL,
	[TransferDate] [datetime2](7) NOT NULL,
	[TransferState] [varchar](20) NOT NULL,
	[CreateUser] [varchar](10) NOT NULL,
	[CreateDate] [datetime2](7) NOT NULL,
	[ModifiedUser] [varchar](10) NOT NULL,
	[ModifiedDate] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_CaptureTransfer] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING ON
GO
/****** Object:  Table [cp].[Capture]    Script Date: 09/01/2015 15:42:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[cp].[Capture]') AND type in (N'U'))
BEGIN
CREATE TABLE [cp].[Capture](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TransactionId] [varchar](50) NOT NULL,
	[Currency] [varchar](10) NOT NULL,
	[Amount] [int] NOT NULL,
	[CreateUser] [varchar](10) NOT NULL,
	[CreateDate] [datetime2](7) NOT NULL,
	[ModifiedUser] [varchar](10) NOT NULL,
	[ModifiedDate] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Capture] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING ON
GO
/****** Object:  Table [cp].[Authorization]    Script Date: 09/01/2015 15:42:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[cp].[Authorization]') AND type in (N'U'))
BEGIN
CREATE TABLE [cp].[Authorization](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TransactionId] [varchar](50) NOT NULL,
	[Account] [varchar](50) NOT NULL,
	[Currency] [varchar](10) NOT NULL,
	[Amount] [int] NOT NULL,
	[CreateUser] [varchar](10) NOT NULL,
	[CreateDate] [datetime2](7) NOT NULL,
	[ModifiedUser] [varchar](10) NOT NULL,
	[ModifiedDate] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Authorization] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING ON
GO
