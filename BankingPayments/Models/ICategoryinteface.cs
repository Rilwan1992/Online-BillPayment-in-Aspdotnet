namespace BankingPayments.Models
{
    public interface ICategoryinteface
    {
       
        CategoryModel GetCategories(int CategoryId);
        IEnumerable<CategoryModel> GetAllCategories();
        CategoryModel Add(CategoryModel category);
        CategoryModel Update(CategoryModel category);
        CategoryModel Delete(int CategoryId);
    }
}
