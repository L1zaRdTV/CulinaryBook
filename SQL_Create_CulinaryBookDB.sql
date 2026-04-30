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
    BirthDay DATE NULL,
    Stage FLOAT NULL,
    Mail NVARCHAR(100) NULL,
    Number NVARCHAR(30) NULL
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
    [Image] NVARCHAR(50) NULL,
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

CREATE TABLE LikeRecipes
(
    id INT IDENTITY PRIMARY KEY,
    idAuthor INT NOT NULL,
    idRecipes INT NOT NULL,
    FOREIGN KEY (idAuthor) REFERENCES Authors (AuthorID),
    FOREIGN KEY (idRecipes) REFERENCES Recipes (RecipeID),
    CONSTRAINT UQ_LikeRecipes UNIQUE (idAuthor, idRecipes)
);

CREATE TABLE Ingredients
(
    IngredientID INT IDENTITY PRIMARY KEY,
    IngredientName NVARCHAR(100) NOT NULL UNIQUE
);

CREATE TABLE RecipeIngredients
(
    RecipeIngredientID INT IDENTITY PRIMARY KEY,
    RecipeID INT NOT NULL,
    IngredientID INT NOT NULL,
    Quantity NVARCHAR(50) NULL,
    FOREIGN KEY (RecipeID) REFERENCES Recipes (RecipeID),
    FOREIGN KEY (IngredientID) REFERENCES Ingredients (IngredientID),
    CONSTRAINT UQ_RecipeIngredient UNIQUE (RecipeID, IngredientID)
);
GO

INSERT INTO Authors (AuthorName, Login, [Password], BirthDay, Stage, Mail, Number)
VALUES
(N'Ирина Смирнова', N'irina', N'12345', '1995-07-04', 5, N'irina@cookbook.ru', N'+79990001122'),
(N'Алексей Ковалев', N'alex', N'12345', '1990-11-15', 8, N'alex@cookbook.ru', N'+79990002233'),
(N'Мария Орлова', N'maria', N'12345', '1998-03-23', 3, N'maria@cookbook.ru', N'+79990003344');

INSERT INTO Categories (CategoryName)
VALUES
(N'Завтраки'),
(N'Супы'),
(N'Горячие блюда'),
(N'Паста и лапша'),
(N'Десерты'),
(N'Салаты');

INSERT INTO Ingredients (IngredientName)
VALUES
(N'Яйца'), (N'Молоко'), (N'Мука'), (N'Соль'), (N'Сахар'), (N'Куриное филе'),
(N'Гречка'), (N'Макароны'), (N'Сливочное масло'), (N'Творог'), (N'Помидоры'),
(N'Огурцы'), (N'Лук'), (N'Морковь'), (N'Картофель'), (N'Сыр'), (N'Сметана');

INSERT INTO Recipes (RecipeName, [Description], CategoryID, AuthorID, CookingTime, [Image])
VALUES
(N'Омлет с сыром', N'Быстрый и сытный омлет на завтрак.', 1, 1, 15, N'Images\\eggs.jpg'),
(N'Гречка с курицей', N'Полезный ужин с куриным филе и овощами.', 3, 2, 40, N'Images\\grech.jpg'),
(N'Паста в сливочном соусе', N'Нежная паста с сыром и сливочным соусом.', 4, 2, 30, N'Images\\pasta.jpg'),
(N'Сырники', N'Классические сырники из творога.', 5, 3, 25, N'Images\\tvor.jpg'),
(N'Овощной салат', N'Легкий салат из свежих овощей.', 6, 1, 10, N'Images\\zavtrak.jpg');

INSERT INTO RecipeImages (RecipeID, ImagePath)
VALUES
(1, N'Images\\eggs.jpg'),
(2, N'Images\\grech.jpg'),
(3, N'Images\\pasta.jpg'),
(4, N'Images\\tvor.jpg'),
(5, N'Images\\zavtrak.jpg');

INSERT INTO RecipeIngredients (RecipeID, IngredientID, Quantity)
VALUES
(1, 1, N'3 шт'), (1, 2, N'60 мл'), (1, 16, N'40 г'), (1, 4, N'по вкусу'),
(2, 6, N'400 г'), (2, 7, N'200 г'), (2, 13, N'1 шт'), (2, 14, N'1 шт'), (2, 4, N'по вкусу'),
(3, 8, N'250 г'), (3, 9, N'40 г'), (3, 16, N'50 г'), (3, 4, N'по вкусу'),
(4, 10, N'400 г'), (4, 1, N'1 шт'), (4, 3, N'4 ст.л.'), (4, 5, N'2 ст.л.'),
(5, 11, N'2 шт'), (5, 12, N'2 шт'), (5, 17, N'2 ст.л.'), (5, 4, N'по вкусу');

INSERT INTO CookingSteps (RecipeID, StepNumber, StepDescription)
VALUES
(1, 1, N'Взбить яйца с молоком и солью.'),
(1, 2, N'Вылить смесь на разогретую сковороду.'),
(1, 3, N'Добавить тертый сыр и довести до готовности.'),
(2, 1, N'Обжарить лук и морковь, добавить курицу.'),
(2, 2, N'Промыть гречку и добавить к курице с водой.'),
(2, 3, N'Тушить под крышкой до готовности 25 минут.'),
(3, 1, N'Отварить макароны до состояния al dente.'),
(3, 2, N'Растопить масло и добавить немного воды от пасты.'),
(3, 3, N'Смешать пасту с соусом и сыром.'),
(4, 1, N'Смешать творог, яйцо, сахар и муку.'),
(4, 2, N'Сформировать сырники и обжарить с двух сторон.'),
(5, 1, N'Нарезать овощи кубиками.'),
(5, 2, N'Заправить сметаной и посолить по вкусу.');

INSERT INTO LikeRecipes (idAuthor, idRecipes)
VALUES
(1, 2), (1, 4), (2, 1), (2, 3), (3, 5);
GO
