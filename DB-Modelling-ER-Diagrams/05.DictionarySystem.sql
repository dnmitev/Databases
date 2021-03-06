USE [master]
GO
/****** Object:  Database [DictionarySystem]    Script Date: 21.8.2014 г. 20:15:37 ******/
CREATE DATABASE [DictionarySystem]
GO
ALTER DATABASE [DictionarySystem] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DictionarySystem].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DictionarySystem] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DictionarySystem] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DictionarySystem] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DictionarySystem] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DictionarySystem] SET ARITHABORT OFF 
GO
ALTER DATABASE [DictionarySystem] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [DictionarySystem] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [DictionarySystem] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DictionarySystem] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DictionarySystem] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DictionarySystem] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DictionarySystem] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DictionarySystem] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DictionarySystem] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DictionarySystem] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DictionarySystem] SET  DISABLE_BROKER 
GO
ALTER DATABASE [DictionarySystem] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DictionarySystem] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DictionarySystem] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DictionarySystem] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DictionarySystem] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DictionarySystem] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [DictionarySystem] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DictionarySystem] SET RECOVERY FULL 
GO
ALTER DATABASE [DictionarySystem] SET  MULTI_USER 
GO
ALTER DATABASE [DictionarySystem] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DictionarySystem] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DictionarySystem] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DictionarySystem] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
EXEC sys.sp_db_vardecimal_storage_format N'DictionarySystem', N'ON'
GO
USE [DictionarySystem]
GO
/****** Object:  Table [dbo].[Explanations]    Script Date: 21.8.2014 г. 20:15:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Explanations](
	[ID] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
	[Explanations] [text] NOT NULL,
	[LanguageID] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_Explanations] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[HypernymAndHyponyms]    Script Date: 21.8.2014 г. 20:15:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HypernymAndHyponyms](
	[HypernymID] [uniqueidentifier] NOT NULL,
	[HyponymID] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_HypernymAndHyponyms] PRIMARY KEY CLUSTERED 
(
	[HypernymID] ASC,
	[HyponymID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Languages]    Script Date: 21.8.2014 г. 20:15:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Languages](
	[ID] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
	[Language] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Languages] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PartsOfSpeech]    Script Date: 21.8.2014 г. 20:15:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PartsOfSpeech](
	[ID] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_PartsOfSpeech] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Synonyms]    Script Date: 21.8.2014 г. 20:15:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Synonyms](
	[WordID] [uniqueidentifier] NOT NULL,
	[SynonymID] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_Synonyms] PRIMARY KEY CLUSTERED 
(
	[WordID] ASC,
	[SynonymID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Translations]    Script Date: 21.8.2014 г. 20:15:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Translations](
	[WordID] [uniqueidentifier] NOT NULL,
	[TranslationID] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_Translations] PRIMARY KEY CLUSTERED 
(
	[WordID] ASC,
	[TranslationID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Words]    Script Date: 21.8.2014 г. 20:15:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Words](
	[ID] [uniqueidentifier] NOT NULL,
	[Spelling] [uniqueidentifier] NOT NULL,
	[LanguageID] [uniqueidentifier] NOT NULL,
	[PartOfSpeechID] [uniqueidentifier] NOT NULL,
	[ExplanationID] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_Words] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[Explanations] ADD  CONSTRAINT [DF_Explanations_ID]  DEFAULT (newid()) FOR [ID]
GO
ALTER TABLE [dbo].[Languages] ADD  CONSTRAINT [DF_Languages_ID]  DEFAULT (newid()) FOR [ID]
GO
ALTER TABLE [dbo].[PartsOfSpeech] ADD  CONSTRAINT [DF_PartsOfSpeech_ID]  DEFAULT (newid()) FOR [ID]
GO
ALTER TABLE [dbo].[Words] ADD  CONSTRAINT [DF_Words_ID]  DEFAULT (newid()) FOR [ID]
GO
ALTER TABLE [dbo].[Words] ADD  CONSTRAINT [DF_Words_LanguageID]  DEFAULT (newid()) FOR [LanguageID]
GO
ALTER TABLE [dbo].[Explanations]  WITH CHECK ADD  CONSTRAINT [FK_Explanations_Languages] FOREIGN KEY([LanguageID])
REFERENCES [dbo].[Languages] ([ID])
GO
ALTER TABLE [dbo].[Explanations] CHECK CONSTRAINT [FK_Explanations_Languages]
GO
ALTER TABLE [dbo].[HypernymAndHyponyms]  WITH CHECK ADD  CONSTRAINT [FK_HypernymAndHyponyms_Words] FOREIGN KEY([HypernymID])
REFERENCES [dbo].[Words] ([ID])
GO
ALTER TABLE [dbo].[HypernymAndHyponyms] CHECK CONSTRAINT [FK_HypernymAndHyponyms_Words]
GO
ALTER TABLE [dbo].[HypernymAndHyponyms]  WITH CHECK ADD  CONSTRAINT [FK_HypernymAndHyponyms_Words1] FOREIGN KEY([HyponymID])
REFERENCES [dbo].[Words] ([ID])
GO
ALTER TABLE [dbo].[HypernymAndHyponyms] CHECK CONSTRAINT [FK_HypernymAndHyponyms_Words1]
GO
ALTER TABLE [dbo].[Synonyms]  WITH CHECK ADD  CONSTRAINT [FK_Synonyms_Words] FOREIGN KEY([WordID])
REFERENCES [dbo].[Words] ([ID])
GO
ALTER TABLE [dbo].[Synonyms] CHECK CONSTRAINT [FK_Synonyms_Words]
GO
ALTER TABLE [dbo].[Synonyms]  WITH CHECK ADD  CONSTRAINT [FK_Synonyms_Words1] FOREIGN KEY([SynonymID])
REFERENCES [dbo].[Words] ([ID])
GO
ALTER TABLE [dbo].[Synonyms] CHECK CONSTRAINT [FK_Synonyms_Words1]
GO
ALTER TABLE [dbo].[Translations]  WITH CHECK ADD  CONSTRAINT [FK_Translations_Words] FOREIGN KEY([WordID])
REFERENCES [dbo].[Words] ([ID])
GO
ALTER TABLE [dbo].[Translations] CHECK CONSTRAINT [FK_Translations_Words]
GO
ALTER TABLE [dbo].[Translations]  WITH CHECK ADD  CONSTRAINT [FK_Translations_Words1] FOREIGN KEY([TranslationID])
REFERENCES [dbo].[Words] ([ID])
GO
ALTER TABLE [dbo].[Translations] CHECK CONSTRAINT [FK_Translations_Words1]
GO
ALTER TABLE [dbo].[Words]  WITH CHECK ADD  CONSTRAINT [FK_Words_Explanations] FOREIGN KEY([ExplanationID])
REFERENCES [dbo].[Explanations] ([ID])
GO
ALTER TABLE [dbo].[Words] CHECK CONSTRAINT [FK_Words_Explanations]
GO
ALTER TABLE [dbo].[Words]  WITH CHECK ADD  CONSTRAINT [FK_Words_Languages] FOREIGN KEY([LanguageID])
REFERENCES [dbo].[Languages] ([ID])
GO
ALTER TABLE [dbo].[Words] CHECK CONSTRAINT [FK_Words_Languages]
GO
ALTER TABLE [dbo].[Words]  WITH CHECK ADD  CONSTRAINT [FK_Words_PartsOfSpeech] FOREIGN KEY([PartOfSpeechID])
REFERENCES [dbo].[PartsOfSpeech] ([ID])
GO
ALTER TABLE [dbo].[Words] CHECK CONSTRAINT [FK_Words_PartsOfSpeech]
GO
USE [master]
GO
ALTER DATABASE [DictionarySystem] SET  READ_WRITE 
GO
