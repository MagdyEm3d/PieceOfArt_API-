using PiecesOfArt_Application_Assignment.Models;

namespace PiecesOfArt_Application_Assignment.Reposatories
{
    public interface ICategoryReposatory
    {
        void AddCategory(Category category);
        Category GetSecondCategory();
        void DeleteCategory(Category category);
        void SaveChanges();
    }
}
