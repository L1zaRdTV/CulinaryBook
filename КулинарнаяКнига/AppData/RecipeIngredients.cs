namespace КулинарнаяКнига.AppData
{
    public partial class RecipeIngredients
    {
        public int RecipeIngredientID { get; set; }
        public int RecipeID { get; set; }
        public int IngredientID { get; set; }
        public int? Quantity { get; set; }

        public virtual Indredients Indredients { get; set; }
        public virtual Recipes Recipe { get; set; }
    }
}
