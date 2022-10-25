namespace FamilyDinnerRedux.Models
{
    public class RecipeIngredientsModel
    {
        public int RecipeId { get; set; }
        public int IngredientID { get; set; }
        public virtual RecipeModel Recipe { get; set; }
        public virtual IngredientModel Ingredient { get; set; }
    }
}
