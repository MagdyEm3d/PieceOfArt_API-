using PiecesOfArt_Application_Assignment.ConnectionDbContext;
using PiecesOfArt_Application_Assignment.Models;
using System.Linq;

namespace PiecesOfArt_Application_Assignment.Reposatories
{
    public class CategoryRepository : ICategoryReposatory
    {
        private readonly ApplicationDbContext _context;

        public CategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AddCategory(Category category)
        {
            _context.Categories.Add(category);
        }

        public Category GetSecondCategory()
        {
            return _context.Categories.Skip(1).FirstOrDefault();
        }

        public void DeleteCategory(Category category)
        {
            _context.Categories.Remove(category);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
