namespace КулинарнаяКнига.AppData
{
    public partial class Reviews
    {
        public int ReviewsID { get; set; }
        public int RecipeID { get; set; }
        public string ReviewText { get; set; }
        public string Rating { get; set; }

        public virtual Recipes Recipe { get; set; }
    }
}
