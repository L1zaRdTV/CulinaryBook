using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace КулинарнаяКнига.AppData
{
    public sealed class RecipeQueryService
    {
        private readonly CulinaryBookEntities _db;

        public RecipeQueryService(CulinaryBookEntities db)
        {
            _db = db;
        }

        public List<Recipes> GetRecipesWithAllData()
        {
            return _db.Recipes
                .Include(x => x.Author)
                .Include(x => x.Category)
                .Include(x => x.CookingSteps)
                .Include(x => x.RecipeImages)
                .Include(x => x.RecipeIngredients.Select(i => i.Indredients))
                .Include(x => x.RecipeTags.Select(t => t.Tag))
                .ToList();
        }
    }
}
