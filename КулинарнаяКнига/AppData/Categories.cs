using System.Collections.Generic;

namespace КулинарнаяКнига.AppData
{
    public partial class Categories
    {
        public Categories()
        {
            Recipes = new HashSet<Recipes>();
        }

        public int CategoryID { get; set; }
        public string CategoryName { get; set; }

        public virtual ICollection<Recipes> Recipes { get; set; }
    }
}
