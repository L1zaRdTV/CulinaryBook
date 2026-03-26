namespace КулинарнаяКнига.AppData
{
    public partial class CookingSteps
    {
        public int StepID { get; set; }
        public int RecipeID { get; set; }
        public int? StepNumber { get; set; }
        public string StepDescription { get; set; }

        public virtual Recipes Recipe { get; set; }
    }
}
