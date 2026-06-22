USE [master]
GO
/****** Object:  Database [CulinaryBook]    Script Date: 05.02.2026 10:52:07 ******/
CREATE DATABASE [CulinaryBook]
GO
ALTER DATABASE [CulinaryBook] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CulinaryBook] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CulinaryBook] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CulinaryBook] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CulinaryBook] SET ARITHABORT OFF 
GO
ALTER DATABASE [CulinaryBook] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [CulinaryBook] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CulinaryBook] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CulinaryBook] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CulinaryBook] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CulinaryBook] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CulinaryBook] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CulinaryBook] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CulinaryBook] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CulinaryBook] SET  DISABLE_BROKER 
GO
ALTER DATABASE [CulinaryBook] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CulinaryBook] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CulinaryBook] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CulinaryBook] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CulinaryBook] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CulinaryBook] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [CulinaryBook] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CulinaryBook] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [CulinaryBook] SET  MULTI_USER 
GO
ALTER DATABASE [CulinaryBook] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CulinaryBook] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CulinaryBook] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CulinaryBook] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [CulinaryBook] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [CulinaryBook] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [CulinaryBook] SET QUERY_STORE = OFF
GO
USE [CulinaryBook]
GO
/****** Object:  Table [dbo].[Authors]    Script Date: 05.02.2026 10:52:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Authors](
	[AuthorID] [int] IDENTITY(1,1) NOT NULL,
	[AuthorName] [nvarchar](50) NULL,
	[Login] [nvarchar](50) NULL,
	[Password] [nvarchar](50) NULL,
	[ByDay] [date] NULL,
	[Stoge] [int] NULL,
	[Email] [nvarchar](50) NULL,
	[Telefon] [nvarchar](50) NULL,
 CONSTRAINT [PK_Authors] PRIMARY KEY CLUSTERED 
(
	[AuthorID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 05.02.2026 10:52:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[CategoryID] [int] IDENTITY(1,1) NOT NULL,
	[CategoryName] [nvarchar](50) NULL,
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[CategoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CookingSteps]    Script Date: 05.02.2026 10:52:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CookingSteps](
	[StepID] [int] IDENTITY(1,1) NOT NULL,
	[RecipeID] [int] NULL,
	[StepNumber] [int] NULL,
	[StepDescription] [nvarchar](50) NULL,
 CONSTRAINT [PK_CookingSteps] PRIMARY KEY CLUSTERED 
(
	[StepID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Indredients]    Script Date: 05.02.2026 10:52:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Indredients](
	[IndredientID] [int] IDENTITY(1,1) NOT NULL,
	[IngredientName] [nvarchar](50) NULL,
 CONSTRAINT [PK_Indredients] PRIMARY KEY CLUSTERED 
(
	[IndredientID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RecipeImages]    Script Date: 05.02.2026 10:52:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RecipeImages](
	[ImageID] [int] IDENTITY(1,1) NOT NULL,
	[RecipeID] [int] NULL,
	[ImagePath] [nvarchar](50) NULL,
 CONSTRAINT [PK_RecipeImages] PRIMARY KEY CLUSTERED 
(
	[ImageID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RecipeIngredients]    Script Date: 05.02.2026 10:52:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RecipeIngredients](
	[RecipeIngredientID] [int] IDENTITY(1,1) NOT NULL,
	[RecipeID] [int] NULL,
	[IngredientID] [int] NULL,
	[Quantity] [int] NULL,
 CONSTRAINT [PK_RecipeIngredients] PRIMARY KEY CLUSTERED 
(
	[RecipeIngredientID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Recipes]    Script Date: 05.02.2026 10:52:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Recipes](
	[RecipeID] [int] IDENTITY(1,1) NOT NULL,
	[RecipeName] [nvarchar](50) NULL,
	[Description] [nvarchar](max) NULL,
	[CategoryID] [int] NULL,
	[AuthorID] [int] NULL,
	[CookingTime] [int] NULL,
	[image] [nvarchar](50) NULL,
 CONSTRAINT [PK_Recipes] PRIMARY KEY CLUSTERED 
(
	[RecipeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RecipeTags]    Script Date: 05.02.2026 10:52:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RecipeTags](
	[RecipeTagID] [int] IDENTITY(1,1) NOT NULL,
	[RecipeID] [int] NULL,
	[TagID] [int] NULL,
 CONSTRAINT [PK_RecipeTags] PRIMARY KEY CLUSTERED 
(
	[RecipeTagID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Reviews]    Script Date: 05.02.2026 10:52:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reviews](
	[ReviewsID] [int] IDENTITY(1,1) NOT NULL,
	[RecipeID] [int] NULL,
	[ReviewText] [nvarchar](max) NULL,
	[Rating] [nvarchar](50) NULL,
 CONSTRAINT [PK_Reviews] PRIMARY KEY CLUSTERED 
(
	[ReviewsID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tags]    Script Date: 05.02.2026 10:52:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tags](
	[TagID] [int] IDENTITY(1,1) NOT NULL,
	[TagName] [nvarchar](50) NULL,
 CONSTRAINT [PK_Tags] PRIMARY KEY CLUSTERED 
(
	[TagID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Authors] ON 

INSERT [dbo].[Authors] ([AuthorID], [AuthorName], [Login], [Password], [ByDay], [Stoge], [Email], [Telefon]) VALUES (1, N'Ибрагим', N'Mura1', N'Banana', NULL, NULL, NULL, NULL)
INSERT [dbo].[Authors] ([AuthorID], [AuthorName], [Login], [Password], [ByDay], [Stoge], [Email], [Telefon]) VALUES (2, N'Гриша', N'Moroz', N'Pivo', NULL, NULL, NULL, NULL)
INSERT [dbo].[Authors] ([AuthorID], [AuthorName], [Login], [Password], [ByDay], [Stoge], [Email], [Telefon]) VALUES (3, N'Артемий', N'Art111', N'Murino', NULL, NULL, NULL, NULL)
INSERT [dbo].[Authors] ([AuthorID], [AuthorName], [Login], [Password], [ByDay], [Stoge], [Email], [Telefon]) VALUES (4, N'Илья', N'Filin', N'Hifir', NULL, NULL, NULL, NULL)
INSERT [dbo].[Authors] ([AuthorID], [AuthorName], [Login], [Password], [ByDay], [Stoge], [Email], [Telefon]) VALUES (5, N'Даня', N'Passat', N'Bipbip', NULL, NULL, NULL, NULL)
INSERT [dbo].[Authors] ([AuthorID], [AuthorName], [Login], [Password], [ByDay], [Stoge], [Email], [Telefon]) VALUES (6, N'Егор', N'Muhonkin', N'MihokG', NULL, NULL, NULL, NULL)
INSERT [dbo].[Authors] ([AuthorID], [AuthorName], [Login], [Password], [ByDay], [Stoge], [Email], [Telefon]) VALUES (7, N'Роман', N'Ramon', N'NikePro', NULL, NULL, NULL, NULL)
INSERT [dbo].[Authors] ([AuthorID], [AuthorName], [Login], [Password], [ByDay], [Stoge], [Email], [Telefon]) VALUES (8, N'Степан', N'Monstr', N'Snicers', NULL, NULL, NULL, NULL)
INSERT [dbo].[Authors] ([AuthorID], [AuthorName], [Login], [Password], [ByDay], [Stoge], [Email], [Telefon]) VALUES (9, N'Квази', N'KFS', N'Vkysno.', NULL, NULL, NULL, NULL)
INSERT [dbo].[Authors] ([AuthorID], [AuthorName], [Login], [Password], [ByDay], [Stoge], [Email], [Telefon]) VALUES (10, N'Игорь', N'IT', N'Credit', NULL, NULL, NULL, NULL)
INSERT [dbo].[Authors] ([AuthorID], [AuthorName], [Login], [Password], [ByDay], [Stoge], [Email], [Telefon]) VALUES (11, N'Антон', N'Soda', N'Soda1', CAST(N'2000-03-03' AS Date), 2323, N'Dolsass@mail.su', N'+790232323')
INSERT [dbo].[Authors] ([AuthorID], [AuthorName], [Login], [Password], [ByDay], [Stoge], [Email], [Telefon]) VALUES (1011, N'Гершин', N'Alooflad', N'Ыфв', CAST(N'2009-01-15' AS Date), 123, N'Emaskdasdhmail.ru', N'789788923')
INSERT [dbo].[Authors] ([AuthorID], [AuthorName], [Login], [Password], [ByDay], [Stoge], [Email], [Telefon]) VALUES (2011, N'Гирша', N'Dol', N'0111', CAST(N'2001-03-16' AS Date), 43, N'sdfsfdsfd', N'7868655')
SET IDENTITY_INSERT [dbo].[Authors] OFF
GO
SET IDENTITY_INSERT [dbo].[Categories] ON 

INSERT [dbo].[Categories] ([CategoryID], [CategoryName]) VALUES (1, N'Закуска')
INSERT [dbo].[Categories] ([CategoryID], [CategoryName]) VALUES (2, N'Салат')
INSERT [dbo].[Categories] ([CategoryID], [CategoryName]) VALUES (3, N'Суп')
INSERT [dbo].[Categories] ([CategoryID], [CategoryName]) VALUES (4, N'Второе блюдо')
INSERT [dbo].[Categories] ([CategoryID], [CategoryName]) VALUES (5, N'Гарнир')
INSERT [dbo].[Categories] ([CategoryID], [CategoryName]) VALUES (6, N'Блюдо из мяса')
INSERT [dbo].[Categories] ([CategoryID], [CategoryName]) VALUES (7, N'Блюдо из рыбы и морепродуктов')
INSERT [dbo].[Categories] ([CategoryID], [CategoryName]) VALUES (8, N'Блюдо из птицы')
INSERT [dbo].[Categories] ([CategoryID], [CategoryName]) VALUES (9, N'Десерт')
INSERT [dbo].[Categories] ([CategoryID], [CategoryName]) VALUES (10, N'Напиток')
SET IDENTITY_INSERT [dbo].[Categories] OFF
GO
SET IDENTITY_INSERT [dbo].[Indredients] ON 

INSERT [dbo].[Indredients] ([IndredientID], [IngredientName]) VALUES (1, N'Морковь')
INSERT [dbo].[Indredients] ([IndredientID], [IngredientName]) VALUES (2, N'Картошка')
INSERT [dbo].[Indredients] ([IndredientID], [IngredientName]) VALUES (3, N'Свекала')
INSERT [dbo].[Indredients] ([IndredientID], [IngredientName]) VALUES (4, N'Капуста')
INSERT [dbo].[Indredients] ([IndredientID], [IngredientName]) VALUES (5, N'Лук Репчетый')
INSERT [dbo].[Indredients] ([IndredientID], [IngredientName]) VALUES (6, N'Чеснок')
INSERT [dbo].[Indredients] ([IndredientID], [IngredientName]) VALUES (7, N'Тыква')
INSERT [dbo].[Indredients] ([IndredientID], [IngredientName]) VALUES (8, N'Огурци')
INSERT [dbo].[Indredients] ([IndredientID], [IngredientName]) VALUES (9, N'Помидоры')
INSERT [dbo].[Indredients] ([IndredientID], [IngredientName]) VALUES (10, N'Говядина')
INSERT [dbo].[Indredients] ([IndredientID], [IngredientName]) VALUES (11, N'Свинина')
INSERT [dbo].[Indredients] ([IndredientID], [IngredientName]) VALUES (12, N'Рыба')
INSERT [dbo].[Indredients] ([IndredientID], [IngredientName]) VALUES (13, N'Авокада')
SET IDENTITY_INSERT [dbo].[Indredients] OFF
GO
SET IDENTITY_INSERT [dbo].[Recipes] ON 

INSERT [dbo].[Recipes] ([RecipeID], [RecipeName], [Description], [CategoryID], [AuthorID], [CookingTime], [image]) VALUES (1, N'Рулетики с сыром и ветчиной', N'Тонкие полоски лаваша смазывают творожным сыром, чередуют ломтики ветчины и сыра, сворачивают в трубочки, фиксируют шпажкой. Можно добавить маслину или оливку внутри рулетика', 1, 6, 25, N'Rulet.png')
INSERT [dbo].[Recipes] ([RecipeID], [RecipeName], [Description], [CategoryID], [AuthorID], [CookingTime], [image]) VALUES (2, N'Борщ', N'Основные ингредиенты: говядина (лучше на косточке), картофель, лук, свёкла, морковь, сладкий перец, томаты в собственном соку, капуста. Для зажарки обжаривают лук, перец, морковь и свёклу, добавляют томаты. Мясо варят с луком и целой картофелиной, потом добавляют нарезанный картофель и зажарку', 3, 1, 120, N'Borh.ipg')
INSERT [dbo].[Recipes] ([RecipeID], [RecipeName], [Description], [CategoryID], [AuthorID], [CookingTime], [image]) VALUES (3, N'Стейк из свинины', N'Свинину обжаривают на сковороде, затем запекают в духовке. Можно добавить розмарин за минуту до готовности для аромата', 4, 9, 75, N'Steke.jpg')
INSERT [dbo].[Recipes] ([RecipeID], [RecipeName], [Description], [CategoryID], [AuthorID], [CookingTime], [image]) VALUES (4, N'Салат с курицей, ананасами и сыром', N'Варёная куриная грудка, яйца, твёрдый сыр и консервированные ананасы выкладываются слоями, смазываются майонезом', 2, 4, 30, N'Salate.jpg')
INSERT [dbo].[Recipes] ([RecipeID], [RecipeName], [Description], [CategoryID], [AuthorID], [CookingTime], [image]) VALUES (5, N'Пюре из картофеля', N'Отварной картофель разминают с добавлением сливочного масла, молока и соли.', 5, 2, 50, N'Pure.jpg')
INSERT [dbo].[Recipes] ([RecipeID], [RecipeName], [Description], [CategoryID], [AuthorID], [CookingTime], [image]) VALUES (6, N'Палтус со стручковой фасолью и помидорами', N'Палтус запекают с стручковой фасолью и помидорами, можно добавить немного оливкового масла и специй', 7, 10, 100, N'Paltus.jpg')
INSERT [dbo].[Recipes] ([RecipeID], [RecipeName], [Description], [CategoryID], [AuthorID], [CookingTime], [image]) VALUES (7, N'Куриные рулетики по-средиземноморски', N'Филе грудки цыплёнка сворачивают в рулетики с начинкой из вяленых томатов, оливок, моцареллы и чеснока, запекают в духовке', 8, 8, 80, N'Kurica.jpg')
INSERT [dbo].[Recipes] ([RecipeID], [RecipeName], [Description], [CategoryID], [AuthorID], [CookingTime], [image]) VALUES (8, N'Бефстроганов в апельсиновом соусе', N'Нежирную говядину нарезают полосками, тушат в соусе из апельсинового сока, соевого соуса, кунжутного масла, крахмала и апельсиновой цедры.', 6, 5, 50, N'Bestro.jpg')
INSERT [dbo].[Recipes] ([RecipeID], [RecipeName], [Description], [CategoryID], [AuthorID], [CookingTime], [image]) VALUES (9, N'Муссовый десерт', N'Нежный десерт на основе взбитых сливок или йогурта с добавлением фруктов, ягод или шоколада', 9, 3, 180, N'')
INSERT [dbo].[Recipes] ([RecipeID], [RecipeName], [Description], [CategoryID], [AuthorID], [CookingTime], [image]) VALUES (10, N'Безалкогольный пунш', N'Смешивают апельсиновый сок, протёртую с сахаром клюкву, вяленую клюкву, ломтики апельсина, имбирь и корицу. Прогревают 5–10 минут, не доводя до кипения, дают настояться', 10, 7, 45, N'Punsh.jpg')
INSERT [dbo].[Recipes] ([RecipeID], [RecipeName], [Description], [CategoryID], [AuthorID], [CookingTime], [image]) VALUES (1002, N'Вишнёвый сок', N'Вишнёвы свежевыжатый сок', 10, 4, 76, N'sad.jpg')
INSERT [dbo].[Recipes] ([RecipeID], [RecipeName], [Description], [CategoryID], [AuthorID], [CookingTime], [image]) VALUES (1003, N'Суп фасоль', N'ыфаываываываыва', 5, 5, 134, N'gdfsdf.jpg')
SET IDENTITY_INSERT [dbo].[Recipes] OFF
GO
ALTER TABLE [dbo].[CookingSteps]  WITH CHECK ADD  CONSTRAINT [FK_CookingSteps_Recipes] FOREIGN KEY([RecipeID])
REFERENCES [dbo].[Recipes] ([RecipeID])
GO
ALTER TABLE [dbo].[CookingSteps] CHECK CONSTRAINT [FK_CookingSteps_Recipes]
GO
ALTER TABLE [dbo].[RecipeImages]  WITH CHECK ADD  CONSTRAINT [FK_RecipeImages_Recipes] FOREIGN KEY([RecipeID])
REFERENCES [dbo].[Recipes] ([RecipeID])
GO
ALTER TABLE [dbo].[RecipeImages] CHECK CONSTRAINT [FK_RecipeImages_Recipes]
GO
ALTER TABLE [dbo].[RecipeIngredients]  WITH CHECK ADD  CONSTRAINT [FK_RecipeIngredients_Indredients] FOREIGN KEY([IngredientID])
REFERENCES [dbo].[Indredients] ([IndredientID])
GO
ALTER TABLE [dbo].[RecipeIngredients] CHECK CONSTRAINT [FK_RecipeIngredients_Indredients]
GO
ALTER TABLE [dbo].[RecipeIngredients]  WITH CHECK ADD  CONSTRAINT [FK_RecipeIngredients_Recipes] FOREIGN KEY([RecipeID])
REFERENCES [dbo].[Recipes] ([RecipeID])
GO
ALTER TABLE [dbo].[RecipeIngredients] CHECK CONSTRAINT [FK_RecipeIngredients_Recipes]
GO
ALTER TABLE [dbo].[Recipes]  WITH CHECK ADD  CONSTRAINT [FK_Recipes_Authors] FOREIGN KEY([AuthorID])
REFERENCES [dbo].[Authors] ([AuthorID])
GO
ALTER TABLE [dbo].[Recipes] CHECK CONSTRAINT [FK_Recipes_Authors]
GO
ALTER TABLE [dbo].[Recipes]  WITH CHECK ADD  CONSTRAINT [FK_Recipes_Categories] FOREIGN KEY([CategoryID])
REFERENCES [dbo].[Categories] ([CategoryID])
GO
ALTER TABLE [dbo].[Recipes] CHECK CONSTRAINT [FK_Recipes_Categories]
GO
ALTER TABLE [dbo].[RecipeTags]  WITH CHECK ADD  CONSTRAINT [FK_RecipeTags_Recipes] FOREIGN KEY([RecipeID])
REFERENCES [dbo].[Recipes] ([RecipeID])
GO
ALTER TABLE [dbo].[RecipeTags] CHECK CONSTRAINT [FK_RecipeTags_Recipes]
GO
ALTER TABLE [dbo].[RecipeTags]  WITH CHECK ADD  CONSTRAINT [FK_RecipeTags_Tags] FOREIGN KEY([TagID])
REFERENCES [dbo].[Tags] ([TagID])
GO
ALTER TABLE [dbo].[RecipeTags] CHECK CONSTRAINT [FK_RecipeTags_Tags]
GO
ALTER TABLE [dbo].[Reviews]  WITH CHECK ADD  CONSTRAINT [FK_Reviews_Recipes] FOREIGN KEY([RecipeID])
REFERENCES [dbo].[Recipes] ([RecipeID])
GO
ALTER TABLE [dbo].[Reviews] CHECK CONSTRAINT [FK_Reviews_Recipes]
GO
USE [master]
GO
ALTER DATABASE [CulinaryBook] SET  READ_WRITE 
GO
