using System.ComponentModel.DataAnnotations;

namespace FamilyDinnerRedux.Models
{
    public class RecipeModel
    {
        [Key]
        public int RecipeId { get; set; }
        public string RecipeName { get; set; }
        public string RecipeDirections { get; set; }
        public virtual ICollection<RecipeIngredientsModel> RecipeIngredients { get; set; }
    }
}
