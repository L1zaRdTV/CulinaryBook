using System;
using System.IO;

namespace КулинарнаяКнига.AppData
{
    public partial class Recipes
    {
        public string CurrentPhoto
        {
            get
            {
                if (!string.IsNullOrEmpty(image))
                {
                    string path = Path.Combine(
                        AppDomain.CurrentDomain.BaseDirectory,
                        "..\\..\\Images\\",
                        image);

                    if (File.Exists(path))
                    {
                        return path;
                    }
                }

                return "/Images/empty.png";
            }
        }
    }
}
