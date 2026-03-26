using System;

namespace КулинарнаяКнига.AppData
{
    public partial class Recipes
    {
        public string CurrentPhoto
        {
            get
            {
                if (string.IsNullOrWhiteSpace(image))
                {
                    return @"/Images/empty.png";
                }

                return @"/Images/" + image;
            }
        }
    }
}
