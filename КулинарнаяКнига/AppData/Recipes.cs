using System.Collections.Generic;

namespace КулинарнаяКнига.AppData
{
    public partial class Recipes
    {
        public Recipes()
        {
            CookingSteps = new HashSet<CookingSteps>();
            RecipeImages = new HashSet<RecipeImages>();
            RecipeIngredients = new HashSet<RecipeIngredients>();
            RecipeTags = new HashSet<RecipeTags>();
            Reviews = new HashSet<Reviews>();
        }

        public int RecipeID { get; set; }
        public string RecipeName { get; set; }
        public string Description { get; set; }
        public int CategoryID { get; set; }
        public int AuthorID { get; set; }
        public int? CookingTime { get; set; }
        public string image { get; set; }

        public virtual Authors Author { get; set; }
        public virtual Categories Category { get; set; }
        public virtual ICollection<CookingSteps> CookingSteps { get; set; }
        public virtual ICollection<RecipeImages> RecipeImages { get; set; }
        public virtual ICollection<RecipeIngredients> RecipeIngredients { get; set; }
        public virtual ICollection<RecipeTags> RecipeTags { get; set; }
        public virtual ICollection<Reviews> Reviews { get; set; }
    }
}
