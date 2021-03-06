USE [master]
GO
/****** Object:  Database [RecipeBook]    Script Date: 4.10.2021 12:21:03 ******/
CREATE DATABASE [RecipeBook]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ReciepeBook', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\ReciepeBook.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ReciepeBook_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\ReciepeBook_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [RecipeBook] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [RecipeBook].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [RecipeBook] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [RecipeBook] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [RecipeBook] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [RecipeBook] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [RecipeBook] SET ARITHABORT OFF 
GO
ALTER DATABASE [RecipeBook] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [RecipeBook] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [RecipeBook] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [RecipeBook] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [RecipeBook] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [RecipeBook] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [RecipeBook] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [RecipeBook] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [RecipeBook] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [RecipeBook] SET  DISABLE_BROKER 
GO
ALTER DATABASE [RecipeBook] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [RecipeBook] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [RecipeBook] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [RecipeBook] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [RecipeBook] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [RecipeBook] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [RecipeBook] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [RecipeBook] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [RecipeBook] SET  MULTI_USER 
GO
ALTER DATABASE [RecipeBook] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [RecipeBook] SET DB_CHAINING OFF 
GO
ALTER DATABASE [RecipeBook] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [RecipeBook] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [RecipeBook] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [RecipeBook] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [RecipeBook] SET QUERY_STORE = OFF
GO
USE [RecipeBook]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 4.10.2021 12:21:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Directions]    Script Date: 4.10.2021 12:21:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Directions](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RecipeDirection] [nvarchar](max) NOT NULL,
	[DirectionQueue] [int] NOT NULL,
	[RecipeId] [int] NOT NULL,
 CONSTRAINT [PK_Directions] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Infos]    Script Date: 4.10.2021 12:21:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Infos](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Time] [nvarchar](20) NOT NULL,
	[Difficulties] [nvarchar](5) NOT NULL,
	[Servings] [int] NOT NULL,
	[RecipeId] [int] NOT NULL,
 CONSTRAINT [PK_Infos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ingredients]    Script Date: 4.10.2021 12:21:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ingredients](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RecipeIngredients] [nvarchar](50) NOT NULL,
	[Quantity] [nvarchar](20) NOT NULL,
	[RecipeId] [int] NOT NULL,
 CONSTRAINT [PK_Ingredients] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OperationClaims]    Script Date: 4.10.2021 12:21:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OperationClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_OperationClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Recipes]    Script Date: 4.10.2021 12:21:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Recipes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](50) NOT NULL,
	[Image] [nvarchar](50) NULL,
	[Slug] [nvarchar](50) NULL,
	[CategoryId] [int] NOT NULL,
	[Popularity] [int] NOT NULL,
 CONSTRAINT [PK_Recips] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserOperationClaims]    Script Date: 4.10.2021 12:21:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserOperationClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[OperationClaimId] [int] NOT NULL,
 CONSTRAINT [PK_UserOperationClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 4.10.2021 12:21:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[Email] [varchar](50) NOT NULL,
	[PasswordSalt] [varbinary](500) NOT NULL,
	[PasswordHash] [varbinary](500) NOT NULL,
	[Status] [bit] NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Categories] ON 

INSERT [dbo].[Categories] ([Id], [Title]) VALUES (1, N'Breakfast')
INSERT [dbo].[Categories] ([Id], [Title]) VALUES (2, N'Lunch')
INSERT [dbo].[Categories] ([Id], [Title]) VALUES (3, N'Beverages')
INSERT [dbo].[Categories] ([Id], [Title]) VALUES (4, N'Appetizers')
INSERT [dbo].[Categories] ([Id], [Title]) VALUES (5, N'Soups')
INSERT [dbo].[Categories] ([Id], [Title]) VALUES (6, N'Salads')
INSERT [dbo].[Categories] ([Id], [Title]) VALUES (7, N'Main dishes: Beef')
INSERT [dbo].[Categories] ([Id], [Title]) VALUES (8, N'Main dishes: Poultry')
INSERT [dbo].[Categories] ([Id], [Title]) VALUES (9, N'Main dishes: Pork')
INSERT [dbo].[Categories] ([Id], [Title]) VALUES (10, N'Main dishes: Seafood')
INSERT [dbo].[Categories] ([Id], [Title]) VALUES (11, N'Main dishes: Vegetarian')
INSERT [dbo].[Categories] ([Id], [Title]) VALUES (12, N'Side dishes: Vegetables')
INSERT [dbo].[Categories] ([Id], [Title]) VALUES (13, N'Side dishes: Other')
INSERT [dbo].[Categories] ([Id], [Title]) VALUES (14, N'Desserts')
INSERT [dbo].[Categories] ([Id], [Title]) VALUES (15, N'Canning / Freezing')
INSERT [dbo].[Categories] ([Id], [Title]) VALUES (16, N'Breads')
SET IDENTITY_INSERT [dbo].[Categories] OFF
GO
SET IDENTITY_INSERT [dbo].[Directions] ON 

INSERT [dbo].[Directions] ([Id], [RecipeDirection], [DirectionQueue], [RecipeId]) VALUES (3, N'First of all,mix tamarind,kashmiri chilly powder and turmeric powder in a cup of water and keep it aside.', 1, 3)
INSERT [dbo].[Directions] ([Id], [RecipeDirection], [DirectionQueue], [RecipeId]) VALUES (4, N'In a pan,heat oil and add fenugreek to it, and saute the mix by adding the pearl onions , garlic cloves,ginger.', 2, 3)
INSERT [dbo].[Directions] ([Id], [RecipeDirection], [DirectionQueue], [RecipeId]) VALUES (5, N'To this mix add the tomato and also the cleaned sardines(mathi) along with required salt .', 3, 3)
INSERT [dbo].[Directions] ([Id], [RecipeDirection], [DirectionQueue], [RecipeId]) VALUES (6, N'Add the spicy mix which prepared in the first step and boil it.', 4, 3)
INSERT [dbo].[Directions] ([Id], [RecipeDirection], [DirectionQueue], [RecipeId]) VALUES (7, N'When the gravy gets thickened,add the curry leaves and take out of flame.', 5, 3)
INSERT [dbo].[Directions] ([Id], [RecipeDirection], [DirectionQueue], [RecipeId]) VALUES (8, N'In a small vessel,crush green chillies,pearl onions in coconut oil.', 6, 3)
INSERT [dbo].[Directions] ([Id], [RecipeDirection], [DirectionQueue], [RecipeId]) VALUES (9, N'Mix this with curry well. And its ready to serve.', 7, 3)
INSERT [dbo].[Directions] ([Id], [RecipeDirection], [DirectionQueue], [RecipeId]) VALUES (10, N'ts ready to serve.

08
', 8, 3)
SET IDENTITY_INSERT [dbo].[Directions] OFF
GO
SET IDENTITY_INSERT [dbo].[Infos] ON 

INSERT [dbo].[Infos] ([Id], [Time], [Difficulties], [Servings], [RecipeId]) VALUES (1, N'40M', N'3', 4, 3)
SET IDENTITY_INSERT [dbo].[Infos] OFF
GO
SET IDENTITY_INSERT [dbo].[Ingredients] ON 

INSERT [dbo].[Ingredients] ([Id], [RecipeIngredients], [Quantity], [RecipeId]) VALUES (1, N'Mathi (Sardines,Cleaned and Washed)', N'1/2 kgs', 3)
INSERT [dbo].[Ingredients] ([Id], [RecipeIngredients], [Quantity], [RecipeId]) VALUES (2, N'Fenu Greek', N'1/2 tps', 3)
INSERT [dbo].[Ingredients] ([Id], [RecipeIngredients], [Quantity], [RecipeId]) VALUES (3, N'Pearl Onions ', N'15 nos', 3)
INSERT [dbo].[Ingredients] ([Id], [RecipeIngredients], [Quantity], [RecipeId]) VALUES (4, N'Garlic Cloves ', N'6 nos', 3)
INSERT [dbo].[Ingredients] ([Id], [RecipeIngredients], [Quantity], [RecipeId]) VALUES (6, N'ginger', N'1 piece', 3)
INSERT [dbo].[Ingredients] ([Id], [RecipeIngredients], [Quantity], [RecipeId]) VALUES (7, N'urry leaves', N'1 spring', 3)
INSERT [dbo].[Ingredients] ([Id], [RecipeIngredients], [Quantity], [RecipeId]) VALUES (9, N'Tomato(sliced) ', N'1 nos', 3)
INSERT [dbo].[Ingredients] ([Id], [RecipeIngredients], [Quantity], [RecipeId]) VALUES (10, N'Salt some to taste ', N'1 tps ', 3)
INSERT [dbo].[Ingredients] ([Id], [RecipeIngredients], [Quantity], [RecipeId]) VALUES (11, N'Tamarind(Lemon Sized diluted in water) ', N'1 nos', 3)
INSERT [dbo].[Ingredients] ([Id], [RecipeIngredients], [Quantity], [RecipeId]) VALUES (12, N'water', N'1 cups', 3)
INSERT [dbo].[Ingredients] ([Id], [RecipeIngredients], [Quantity], [RecipeId]) VALUES (14, N'Kashmiri Chilly Powder', N'1 tbsp', 3)
INSERT [dbo].[Ingredients] ([Id], [RecipeIngredients], [Quantity], [RecipeId]) VALUES (15, N'turmeric powder ', N'1 1/4 tsp', 3)
INSERT [dbo].[Ingredients] ([Id], [RecipeIngredients], [Quantity], [RecipeId]) VALUES (16, N'green chillies', N'2-3 nos', 3)
INSERT [dbo].[Ingredients] ([Id], [RecipeIngredients], [Quantity], [RecipeId]) VALUES (17, N'Coconut Oil ', N'3 tbsp', 3)
SET IDENTITY_INSERT [dbo].[Ingredients] OFF
GO
SET IDENTITY_INSERT [dbo].[Recipes] ON 

INSERT [dbo].[Recipes] ([Id], [Title], [Image], [Slug], [CategoryId], [Popularity]) VALUES (3, N'Mathi Mulakitathu(Sardines in Spicy Curry)', N'Mathi_Mulakitathu.jpg', N'/recipes/Mathi_Mulakitathu.jpg', 1, 9)
SET IDENTITY_INSERT [dbo].[Recipes] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([Id], [FirstName], [LastName], [Email], [PasswordSalt], [PasswordHash], [Status]) VALUES (1, N'muhammed', N'akın', N'm.akin4990@gmail.com', 0x11C89F829C843359979C109CE36BACA772AE47F725D44A3D52262B8E4703A7118D6AE6A48A5CFC68FB63B61C638B4ADD392E6A6EAF39F8A7DF1CE23CBBB25C34EF19E3199417B19861476DC45EB3A695C426F6317D06ECF6CE08BC14D06A7E9B9FC3E3CFA0E2888BC9A3758417C19E5C0B88C6F82779A17E239CC0140E5AF204, 0x557F7414740BA72F03D102D34AEDCFE8759D13B744CAD550969C4B682C11C3795A67E7843E2B41E4236C0F4B751E2C08E1A6717787A2A4914A6351C869BE178E, 1)
INSERT [dbo].[Users] ([Id], [FirstName], [LastName], [Email], [PasswordSalt], [PasswordHash], [Status]) VALUES (2, N'serhat', N'sermet', N'serhatsermet@gmail.com', 0x75E49E73B94AD02077C8716FCA3A10FCB76AA361CF7157FD5A5D74CE1EDB68710F202C33C503A8570729CEDE3355077989BD1A558A2C6FB74CE8D3D4EB59BE0378C446B685F8B9AB99400B1163B78B99D9D7EFF886826235CE2258CC3A64F883E9244B2742308A303F2F6C0D42B1F639B09536BF1F2A5ADF63102B6A9B163257, 0x88A8538F002317E5B3FE584E701C0EA46873FF08FA2A66C9838E786E84C9A37BEC90F9AF14D1B62837643B4759D15D800C35AA273A2BF4C6E115BF50832CE1E4, 1)
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
ALTER TABLE [dbo].[Directions]  WITH CHECK ADD  CONSTRAINT [FK_Directions_Recips] FOREIGN KEY([RecipeId])
REFERENCES [dbo].[Recipes] ([Id])
GO
ALTER TABLE [dbo].[Directions] CHECK CONSTRAINT [FK_Directions_Recips]
GO
ALTER TABLE [dbo].[Infos]  WITH CHECK ADD  CONSTRAINT [FK_Infos_Recips] FOREIGN KEY([RecipeId])
REFERENCES [dbo].[Recipes] ([Id])
GO
ALTER TABLE [dbo].[Infos] CHECK CONSTRAINT [FK_Infos_Recips]
GO
ALTER TABLE [dbo].[Ingredients]  WITH CHECK ADD  CONSTRAINT [FK_Ingredients_Recips] FOREIGN KEY([RecipeId])
REFERENCES [dbo].[Recipes] ([Id])
GO
ALTER TABLE [dbo].[Ingredients] CHECK CONSTRAINT [FK_Ingredients_Recips]
GO
ALTER TABLE [dbo].[Recipes]  WITH CHECK ADD  CONSTRAINT [FK_Recips_Categories] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Categories] ([Id])
GO
ALTER TABLE [dbo].[Recipes] CHECK CONSTRAINT [FK_Recips_Categories]
GO
ALTER TABLE [dbo].[UserOperationClaims]  WITH CHECK ADD  CONSTRAINT [FK_UserOperationClaims_OperationClaims] FOREIGN KEY([OperationClaimId])
REFERENCES [dbo].[OperationClaims] ([Id])
GO
ALTER TABLE [dbo].[UserOperationClaims] CHECK CONSTRAINT [FK_UserOperationClaims_OperationClaims]
GO
ALTER TABLE [dbo].[UserOperationClaims]  WITH CHECK ADD  CONSTRAINT [FK_UserOperationClaims_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[UserOperationClaims] CHECK CONSTRAINT [FK_UserOperationClaims_Users]
GO
USE [master]
GO
ALTER DATABASE [RecipeBook] SET  READ_WRITE 
GO
