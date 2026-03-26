namespace КулинарнаяКнига.AppData
{
    public partial class RecipeTags
    {
        public int RecipeTagID { get; set; }
        public int RecipeID { get; set; }
        public int TagID { get; set; }

        public virtual Recipes Recipe { get; set; }
        public virtual Tags Tag { get; set; }
    }
}
