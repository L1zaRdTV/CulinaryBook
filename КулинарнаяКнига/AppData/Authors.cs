using System;
using System.Collections.Generic;

namespace КулинарнаяКнига.AppData
{
    public partial class Authors
    {
        public Authors()
        {
            Recipes = new HashSet<Recipes>();
        }

        public int AuthorID { get; set; }
        public string AuthorName { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public DateTime? ByDay { get; set; }
        public int? Stoge { get; set; }
        public string Email { get; set; }
        public string Telefon { get; set; }

        public virtual ICollection<Recipes> Recipes { get; set; }
    }
}
