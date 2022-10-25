namespace FamilyDinnerRedux.Models
{
    public class RecipeModel
    {
        public int RecipeId { get; set; }
        public string RecipeName { get; set; }
        public string RecipeDirections { get; set; }
        public virtual ICollection<RecipeIngredientsModel> RecipeIngredients { get; set; }
    }
}
