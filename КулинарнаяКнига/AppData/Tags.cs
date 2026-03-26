using System.Collections.Generic;

namespace КулинарнаяКнига.AppData
{
    public partial class Tags
    {
        public Tags()
        {
            RecipeTags = new HashSet<RecipeTags>();
        }

        public int TagID { get; set; }
        public string TagName { get; set; }

        public virtual ICollection<RecipeTags> RecipeTags { get; set; }
    }
}
