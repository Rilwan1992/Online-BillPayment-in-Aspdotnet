
namespace BankingPayments.Models
{
    public class DbCategory : ICategoryinteface
    {
      
        private readonly ApplicationDbContext context;

        public DbCategory(ApplicationDbContext context)
        {
            this.context = context;
        }
        public CategoryModel Add (CategoryModel categoryModel)
        {
            context.Category.Add(categoryModel);
            context.SaveChanges();
            return categoryModel;
        }
        public CategoryModel Delete(int CategoryId)
        {
            CategoryModel categoryModel = context.Category.Find(CategoryId);
            if (categoryModel != null)
            {
                context.Category.Remove(categoryModel);
                context.SaveChanges();
            }
            return categoryModel;
        }

        public IEnumerable<CategoryModel> GetAllCategories()
        {
            return context.Category;

        }

        public CategoryModel GetCategories(int CategoryId)
        {
            return context.Category.Find(CategoryId);
        }

        public CategoryModel Update(CategoryModel Model)
        {
            var cat = context.Category.Attach(Model);
            cat.State=Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return Model;
        }

    }
}
