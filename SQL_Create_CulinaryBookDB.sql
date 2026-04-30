CREATE DATABASE CulinaryBookDB;
GO

USE CulinaryBookDB;
GO

CREATE TABLE Authors
(
    AuthorID INT IDENTITY PRIMARY KEY,
    AuthorName NVARCHAR(100) NOT NULL,
    Login NVARCHAR(50) NOT NULL UNIQUE,
    [Password] NVARCHAR(50) NOT NULL,
    ByDay DATE NULL,
    Stoge FLOAT NULL,
    Email NVARCHAR(100) NULL,
    Telefon NVARCHAR(30) NULL
);

CREATE TABLE Categories
(
    CategoryID INT IDENTITY PRIMARY KEY,
    CategoryName NVARCHAR(100) NOT NULL UNIQUE
);

CREATE TABLE Recipes
(
    RecipeID INT IDENTITY PRIMARY KEY,
    RecipeName NVARCHAR(200) NOT NULL,
    [Description] NVARCHAR(MAX) NULL,
    CategoryID INT NOT NULL,
    AuthorID INT NOT NULL,
    CookingTime INT NULL,
    [image] NVARCHAR(255) NULL,
    FOREIGN KEY (CategoryID) REFERENCES Categories (CategoryID),
    FOREIGN KEY (AuthorID) REFERENCES Authors (AuthorID)
);

CREATE TABLE RecipeImages
(
    ImageID INT IDENTITY PRIMARY KEY,
    RecipeID INT NOT NULL,
    ImagePath NVARCHAR(255) NOT NULL,
    FOREIGN KEY (RecipeID) REFERENCES Recipes (RecipeID)
);

CREATE TABLE CookingSteps
(
    StepID INT IDENTITY PRIMARY KEY,
    RecipeID INT NOT NULL,
    StepNumber INT NOT NULL,
    StepDescription NVARCHAR(MAX) NOT NULL,
    FOREIGN KEY (RecipeID) REFERENCES Recipes (RecipeID)
);

CREATE TABLE Indredients
(
    IndredientID INT IDENTITY PRIMARY KEY,
    IngredientName NVARCHAR(100) NOT NULL UNIQUE
);

CREATE TABLE RecipeIngredients
(
    RecipeIngredientID INT IDENTITY PRIMARY KEY,
    RecipeID INT NOT NULL,
    IngredientID INT NOT NULL,
    Quantity NVARCHAR(50) NULL,
    FOREIGN KEY (RecipeID) REFERENCES Recipes (RecipeID),
    FOREIGN KEY (IngredientID) REFERENCES Indredients (IndredientID),
    CONSTRAINT UQ_RecipeIngredient UNIQUE (RecipeID, IngredientID)
);

CREATE TABLE Tags
(
    TagID INT IDENTITY PRIMARY KEY,
    TagName NVARCHAR(100) NOT NULL UNIQUE
);

CREATE TABLE RecipeTags
(
    RecipeTagID INT IDENTITY PRIMARY KEY,
    RecipeID INT NOT NULL,
    TagID INT NOT NULL,
    FOREIGN KEY (RecipeID) REFERENCES Recipes (RecipeID),
    FOREIGN KEY (TagID) REFERENCES Tags (TagID),
    CONSTRAINT UQ_RecipeTag UNIQUE (RecipeID, TagID)
);

CREATE TABLE Reviews
(
    ReviewsID INT IDENTITY PRIMARY KEY,
    RecipeID INT NOT NULL,
    ReviewText NVARCHAR(500) NOT NULL,
    Rating NVARCHAR(10) NOT NULL,
    FOREIGN KEY (RecipeID) REFERENCES Recipes (RecipeID)
);

CREATE TABLE LikeRecipes
(
    id INT IDENTITY PRIMARY KEY,
    idAuthor INT NOT NULL,
    idRecipes INT NOT NULL,
    FOREIGN KEY (idAuthor) REFERENCES Authors (AuthorID),
    FOREIGN KEY (idRecipes) REFERENCES Recipes (RecipeID),
    CONSTRAINT UQ_LikeRecipes UNIQUE (idAuthor, idRecipes)
);
GO

INSERT INTO Authors (AuthorName, Login, [Password], ByDay, Stoge, Email, Telefon)
VALUES
(N'Ирина Смирнова', N'irina', N'12345', '1995-07-04', 5, N'irina@cookbook.ru', N'+79990001122'),
(N'Алексей Ковалев', N'alex', N'12345', '1990-11-15', 8, N'alex@cookbook.ru', N'+79990002233'),
(N'Мария Орлова', N'maria', N'12345', '1998-03-23', 3, N'maria@cookbook.ru', N'+79990003344'),
(N'Ольга Лисина', N'olga', N'12345', '1992-01-18', 7, N'olga@cookbook.ru', N'+79990004455'),
(N'Дмитрий Громов', N'dima', N'12345', '1988-09-02', 10, N'dima@cookbook.ru', N'+79990005566');

INSERT INTO Categories (CategoryName)
VALUES
(N'Завтраки'),
(N'Супы'),
(N'Горячие блюда'),
(N'Паста и лапша'),
(N'Десерты'),
(N'Салаты'),
(N'Выпечка'),
(N'Напитки');

INSERT INTO Indredients (IngredientName)
VALUES
(N'Яйца'), (N'Молоко'), (N'Мука'), (N'Соль'), (N'Сахар'), (N'Куриное филе'),
(N'Гречка'), (N'Макароны'), (N'Сливочное масло'), (N'Творог'), (N'Помидоры'),
(N'Огурцы'), (N'Лук'), (N'Морковь'), (N'Картофель'), (N'Сыр'), (N'Сметана'),
(N'Рис'), (N'Шампиньоны'), (N'Чеснок'), (N'Болгарский перец'), (N'Какао'),
(N'Банан'), (N'Яблоки'), (N'Корица'), (N'Сливки'), (N'Лимон'), (N'Мёд');

INSERT INTO Tags (TagName)
VALUES
(N'Быстро'), (N'ПП'), (N'Без мяса'), (N'Сытно'), (N'На каждый день'),
(N'Праздничное'), (N'Для детей'), (N'Просто');

INSERT INTO Recipes (RecipeName, [Description], CategoryID, AuthorID, CookingTime, [image])
VALUES
(N'Омлет с сыром', N'Быстрый и сытный омлет на завтрак.', 1, 1, 15, N'Images\\eggs.jpg'),
(N'Гречка с курицей', N'Полезный ужин с куриным филе и овощами.', 3, 2, 40, N'Images\\grech.jpg'),
(N'Паста в сливочном соусе', N'Нежная паста с сыром и сливочным соусом.', 4, 2, 30, N'Images\\pasta.jpg'),
(N'Сырники', N'Классические сырники из творога.', 5, 3, 25, N'Images\\tvor.jpg'),
(N'Овощной салат', N'Легкий салат из свежих овощей.', 6, 1, 10, N'Images\\zavtrak.jpg'),
(N'Куриный суп', N'Домашний суп с курицей и овощами.', 2, 4, 50, N'Images\\kur.jpg'),
(N'Картофельное пюре', N'Нежный гарнир к любому мясу или рыбе.', 3, 5, 35, N'Images\\empty.png'),
(N'Рис с овощами', N'Простой и яркий гарнир.', 3, 1, 30, N'Images\\empty.png'),
(N'Грибная паста', N'Паста с шампиньонами в сливочном соусе.', 4, 4, 35, N'Images\\macs.jpg'),
(N'Блины на молоке', N'Тонкие блины для сладких и солёных начинок.', 1, 3, 25, N'Images\\blin.jpg'),
(N'Шарлотка с яблоками', N'Классический яблочный пирог.', 7, 2, 60, N'Images\\empty.png'),
(N'Творожная запеканка', N'Нежная запеканка к чаю.', 5, 5, 45, N'Images\\empty.png'),
(N'Салат с курицей', N'Салат с овощами и обжаренным куриным филе.', 6, 4, 20, N'Images\\kurinigolen.jpg'),
(N'Какао', N'Тёплый шоколадный напиток.', 8, 1, 10, N'Images\\empty.png'),
(N'Лимонад домашний', N'Освежающий напиток с лимоном и мёдом.', 8, 3, 15, N'Images\\empty.png');

INSERT INTO RecipeImages (RecipeID, ImagePath)
SELECT RecipeID, [image] FROM Recipes;

INSERT INTO RecipeIngredients (RecipeID, IngredientID, Quantity)
VALUES
(1, 1, N'3 шт'), (1, 2, N'60 мл'), (1, 16, N'40 г'), (1, 4, N'по вкусу'),
(2, 6, N'400 г'), (2, 7, N'200 г'), (2, 13, N'1 шт'), (2, 14, N'1 шт'), (2, 4, N'по вкусу'),
(3, 8, N'250 г'), (3, 9, N'40 г'), (3, 16, N'50 г'),
(4, 10, N'400 г'), (4, 1, N'1 шт'), (4, 3, N'4 ст.л.'),
(5, 11, N'2 шт'), (5, 12, N'2 шт'), (5, 17, N'2 ст.л.'),
(6, 6, N'300 г'), (6, 15, N'3 шт'), (6, 13, N'1 шт'), (6, 14, N'1 шт'),
(7, 15, N'600 г'), (7, 2, N'100 мл'), (7, 9, N'20 г'),
(8, 18, N'220 г'), (8, 21, N'1 шт'), (8, 13, N'1 шт'),
(9, 8, N'250 г'), (9, 19, N'200 г'), (9, 26, N'120 мл'), (9, 20, N'2 зубчика'),
(10, 1, N'2 шт'), (10, 2, N'500 мл'), (10, 3, N'200 г'),
(11, 24, N'3 шт'), (11, 3, N'180 г'), (11, 5, N'120 г'),
(12, 10, N'500 г'), (12, 1, N'2 шт'), (12, 5, N'80 г'),
(13, 6, N'250 г'), (13, 11, N'2 шт'), (13, 12, N'1 шт'),
(14, 2, N'300 мл'), (14, 22, N'1 ст.л.'), (14, 5, N'1 ст.л.'),
(15, 27, N'2 шт'), (15, 28, N'2 ст.л.'), (15, 2, N'500 мл');

INSERT INTO CookingSteps (RecipeID, StepNumber, StepDescription)
VALUES
(1, 1, N'Взбить яйца с молоком и солью.'), (1, 2, N'Обжарить и добавить сыр.'),
(2, 1, N'Обжарить курицу с луком и морковью.'), (2, 2, N'Добавить гречку и готовить под крышкой.'),
(3, 1, N'Отварить макароны.'), (3, 2, N'Смешать с соусом из масла и сыра.'),
(4, 1, N'Смешать ингредиенты и сформировать сырники.'), (4, 2, N'Обжарить до румяной корочки.'),
(5, 1, N'Нарезать овощи и заправить сметаной.'),
(6, 1, N'Сварить бульон и добавить нарезанные овощи.'),
(7, 1, N'Отварить картофель и размять с молоком и маслом.'),
(8, 1, N'Обжарить овощи, добавить рис и воду, довести до готовности.'),
(9, 1, N'Приготовить пасту и соединить с грибным сливочным соусом.'),
(10, 1, N'Смешать тесто и выпечь блины на сковороде.'),
(11, 1, N'Подготовить тесто и яблоки, выпекать 40 минут.'),
(12, 1, N'Смешать массу и запекать при 180°C 35 минут.'),
(13, 1, N'Обжарить курицу и смешать с нарезанными овощами.'),
(14, 1, N'Нагреть молоко с какао и сахаром, не доводя до кипения.'),
(15, 1, N'Смешать лимонный сок, воду и мёд, охладить.');

INSERT INTO RecipeTags (RecipeID, TagID)
VALUES
(1,1),(1,8),(2,4),(2,5),(3,4),(3,8),(4,7),(4,8),(5,2),(5,3),
(6,5),(7,8),(8,2),(8,3),(9,4),(10,6),(11,6),(12,7),(13,5),(14,7),(15,1);

INSERT INTO Reviews (RecipeID, ReviewText, Rating)
VALUES
(1, N'Очень быстро и вкусно, делаю перед работой.', N'5'),
(2, N'Сытное блюдо, всей семье понравилось.', N'5'),
(3, N'Соус получился нежный, добавил немного чеснока.', N'4'),
(4, N'Отличный рецепт сырников, не разваливаются.', N'5'),
(5, N'Простой салат на каждый день.', N'4'),
(6, N'Хороший домашний суп.', N'5'),
(10, N'Блины получились тонкие и эластичные.', N'5'),
(11, N'Шарлотка ароматная, с корицей вообще супер.', N'5'),
(14, N'Какао как в детстве.', N'5'),
(15, N'Идеально в жару.', N'5');

INSERT INTO LikeRecipes (idAuthor, idRecipes)
VALUES
(1, 2), (1, 4), (1, 11),
(2, 1), (2, 3), (2, 10),
(3, 5), (3, 6), (3, 15),
(4, 9), (4, 12),
(5, 7), (5, 13);
GO
