using System.ComponentModel.DataAnnotations;

namespace FamilyDinnerRedux.Models
{
    public class IngredientModel
    {
        [Key]
        public int IngredientId { get; set; }
        public string IngredientName { get; set; }

        public virtual ICollection<RecipeIngredientsModel> RecipeIngredients { get; set; }
    }
}
