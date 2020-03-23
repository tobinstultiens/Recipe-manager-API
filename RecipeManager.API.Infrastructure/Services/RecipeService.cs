using RecipeManager.API.Persistence.EntityFramework;

namespace RecipeManager.API.Infrastructure.Services
{
    public class RecipeService
    {
        private UnitOfWork _unitOfWork;

        public RecipeService(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void CreateRecipe()
        {

        }
    }
}