namespace КулинарнаяКнига.AppData
{
    public partial class RecipeImages
    {
        public int ImageID { get; set; }
        public int RecipeID { get; set; }
        public string ImagePath { get; set; }

        public virtual Recipes Recipe { get; set; }
    }
}
