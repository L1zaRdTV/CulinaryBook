using System.Data.Entity;

namespace КулинарнаяКнига.AppData
{
    public partial class CulinaryBookEntities : DbContext
    {
        public CulinaryBookEntities()
            : base("name=CulinaryBookEntities")
        {
            Configuration.LazyLoadingEnabled = false;
        }

        public virtual DbSet<Authors> Authors { get; set; }
        public virtual DbSet<Categories> Categories { get; set; }
        public virtual DbSet<Recipes> Recipes { get; set; }
        public virtual DbSet<CookingSteps> CookingSteps { get; set; }
        public virtual DbSet<RecipeImages> RecipeImages { get; set; }
        public virtual DbSet<Indredients> Indredients { get; set; }
        public virtual DbSet<RecipeIngredients> RecipeIngredients { get; set; }
        public virtual DbSet<Tags> Tags { get; set; }
        public virtual DbSet<RecipeTags> RecipeTags { get; set; }
        public virtual DbSet<Reviews> Reviews { get; set; }
        public virtual DbSet<LikeRecipes> LikeRecipes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Authors>()
                .ToTable("Authors")
                .HasKey(x => x.AuthorID);

            modelBuilder.Entity<Authors>()
                .Property(x => x.AuthorID)
                .HasColumnName("AuthorID");
            modelBuilder.Entity<Authors>()
                .Property(x => x.AuthorName)
                .HasColumnName("AuthorName");
            modelBuilder.Entity<Authors>()
                .Property(x => x.Login)
                .HasColumnName("Login");
            modelBuilder.Entity<Authors>()
                .Property(x => x.Password)
                .HasColumnName("Password");
            modelBuilder.Entity<Authors>()
                .Property(x => x.ByDay)
                .HasColumnName("ByDay");
            modelBuilder.Entity<Authors>()
                .Property(x => x.Stoge)
                .HasColumnName("Stoge");
            modelBuilder.Entity<Authors>()
                .Property(x => x.Email)
                .HasColumnName("Email");
            modelBuilder.Entity<Authors>()
                .Property(x => x.Telefon)
                .HasColumnName("Telefon");

            modelBuilder.Entity<Categories>()
                .ToTable("Categories")
                .HasKey(x => x.CategoryID);

            modelBuilder.Entity<Categories>()
                .Property(x => x.CategoryID)
                .HasColumnName("CategoryID");
            modelBuilder.Entity<Categories>()
                .Property(x => x.CategoryName)
                .HasColumnName("CategoryName");

            modelBuilder.Entity<Recipes>()
                .ToTable("Recipes")
                .HasKey(x => x.RecipeID);

            modelBuilder.Entity<Recipes>()
                .Property(x => x.RecipeID)
                .HasColumnName("RecipeID");
            modelBuilder.Entity<Recipes>()
                .Property(x => x.RecipeName)
                .HasColumnName("RecipeName");
            modelBuilder.Entity<Recipes>()
                .Property(x => x.Description)
                .HasColumnName("Description");
            modelBuilder.Entity<Recipes>()
                .Property(x => x.CategoryID)
                .HasColumnName("CategoryID");
            modelBuilder.Entity<Recipes>()
                .Property(x => x.AuthorID)
                .HasColumnName("AuthorID");
            modelBuilder.Entity<Recipes>()
                .Property(x => x.CookingTime)
                .HasColumnName("CookingTime");
            modelBuilder.Entity<Recipes>()
                .Property(x => x.image)
                .HasColumnName("image");

            modelBuilder.Entity<CookingSteps>()
                .ToTable("CookingSteps")
                .HasKey(x => x.StepID);

            modelBuilder.Entity<CookingSteps>()
                .Property(x => x.StepID)
                .HasColumnName("StepID");
            modelBuilder.Entity<CookingSteps>()
                .Property(x => x.RecipeID)
                .HasColumnName("RecipeID");
            modelBuilder.Entity<CookingSteps>()
                .Property(x => x.StepNumber)
                .HasColumnName("StepNumber");
            modelBuilder.Entity<CookingSteps>()
                .Property(x => x.StepDescription)
                .HasColumnName("StepDescription");

            modelBuilder.Entity<RecipeImages>()
                .ToTable("RecipeImages")
                .HasKey(x => x.ImageID);

            modelBuilder.Entity<RecipeImages>()
                .Property(x => x.ImageID)
                .HasColumnName("ImageID");
            modelBuilder.Entity<RecipeImages>()
                .Property(x => x.RecipeID)
                .HasColumnName("RecipeID");
            modelBuilder.Entity<RecipeImages>()
                .Property(x => x.ImagePath)
                .HasColumnName("ImagePath");

            modelBuilder.Entity<Indredients>()
                .ToTable("Indredients")
                .HasKey(x => x.IndredientID);

            modelBuilder.Entity<Indredients>()
                .Property(x => x.IndredientID)
                .HasColumnName("IndredientID");
            modelBuilder.Entity<Indredients>()
                .Property(x => x.IngredientName)
                .HasColumnName("IngredientName");

            modelBuilder.Entity<RecipeIngredients>()
                .ToTable("RecipeIngredients")
                .HasKey(x => x.RecipeIngredientID);

            modelBuilder.Entity<RecipeIngredients>()
                .Property(x => x.RecipeIngredientID)
                .HasColumnName("RecipeIngredientID");
            modelBuilder.Entity<RecipeIngredients>()
                .Property(x => x.RecipeID)
                .HasColumnName("RecipeID");
            modelBuilder.Entity<RecipeIngredients>()
                .Property(x => x.IngredientID)
                .HasColumnName("IngredientID");
            modelBuilder.Entity<RecipeIngredients>()
                .Property(x => x.Quantity)
                .HasColumnName("Quantity");

            modelBuilder.Entity<Tags>()
                .ToTable("Tags")
                .HasKey(x => x.TagID);

            modelBuilder.Entity<Tags>()
                .Property(x => x.TagID)
                .HasColumnName("TagID");
            modelBuilder.Entity<Tags>()
                .Property(x => x.TagName)
                .HasColumnName("TagName");

            modelBuilder.Entity<RecipeTags>()
                .ToTable("RecipeTags")
                .HasKey(x => x.RecipeTagID);

            modelBuilder.Entity<RecipeTags>()
                .Property(x => x.RecipeTagID)
                .HasColumnName("RecipeTagID");
            modelBuilder.Entity<RecipeTags>()
                .Property(x => x.RecipeID)
                .HasColumnName("RecipeID");
            modelBuilder.Entity<RecipeTags>()
                .Property(x => x.TagID)
                .HasColumnName("TagID");

            modelBuilder.Entity<Reviews>()
                .ToTable("Reviews")
                .HasKey(x => x.ReviewsID);

            modelBuilder.Entity<Reviews>()
                .Property(x => x.ReviewsID)
                .HasColumnName("ReviewsID");
            modelBuilder.Entity<Reviews>()
                .Property(x => x.RecipeID)
                .HasColumnName("RecipeID");
            modelBuilder.Entity<Reviews>()
                .Property(x => x.ReviewText)
                .HasColumnName("ReviewText");
            modelBuilder.Entity<Reviews>()
                .Property(x => x.Rating)
                .HasColumnName("Rating");


            modelBuilder.Entity<LikeRecipes>()
                .ToTable("LikeRecipes")
                .HasKey(x => x.id);

            modelBuilder.Entity<LikeRecipes>()
                .Property(x => x.id)
                .HasColumnName("id");
            modelBuilder.Entity<LikeRecipes>()
                .Property(x => x.idAuthor)
                .HasColumnName("idAuthor");
            modelBuilder.Entity<LikeRecipes>()
                .Property(x => x.idRecipes)
                .HasColumnName("idRecipes");

            modelBuilder.Entity<Recipes>()
                .HasRequired(x => x.Author)
                .WithMany(x => x.Recipes)
                .HasForeignKey(x => x.AuthorID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Recipes>()
                .HasRequired(x => x.Category)
                .WithMany(x => x.Recipes)
                .HasForeignKey(x => x.CategoryID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CookingSteps>()
                .HasRequired(x => x.Recipe)
                .WithMany(x => x.CookingSteps)
                .HasForeignKey(x => x.RecipeID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<RecipeImages>()
                .HasRequired(x => x.Recipe)
                .WithMany(x => x.RecipeImages)
                .HasForeignKey(x => x.RecipeID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<RecipeIngredients>()
                .HasRequired(x => x.Recipe)
                .WithMany(x => x.RecipeIngredients)
                .HasForeignKey(x => x.RecipeID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<RecipeIngredients>()
                .HasRequired(x => x.Indredients)
                .WithMany(x => x.RecipeIngredients)
                .HasForeignKey(x => x.IngredientID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<RecipeTags>()
                .HasRequired(x => x.Recipe)
                .WithMany(x => x.RecipeTags)
                .HasForeignKey(x => x.RecipeID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<RecipeTags>()
                .HasRequired(x => x.Tag)
                .WithMany(x => x.RecipeTags)
                .HasForeignKey(x => x.TagID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Reviews>()
                .HasRequired(x => x.Recipe)
                .WithMany(x => x.Reviews)
                .HasForeignKey(x => x.RecipeID)
                .WillCascadeOnDelete(false);
        }
    }
}
