using System.Collections.Generic;

namespace КулинарнаяКнига.AppData
{
    public partial class Indredients
    {
        public Indredients()
        {
            RecipeIngredients = new HashSet<RecipeIngredients>();
        }

        public int IndredientID { get; set; }
        public string IngredientName { get; set; }

        public virtual ICollection<RecipeIngredients> RecipeIngredients { get; set; }
    }
}
