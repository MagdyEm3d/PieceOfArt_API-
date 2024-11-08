using Microsoft.EntityFrameworkCore;
using PiecesOfArt_Application_Assignment.ConnectionDbContext;
using PiecesOfArt_Application_Assignment.Models;
using PiecesOfArt_Application_Assignment.Reposatories;
using System.Collections.Generic;
using System.Linq;

namespace PiecesOfArt_Application_Assignment.Repositories
{
    public class UserRepository : IUserReposatory
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        
        
        public List<User> GetAllUsers()
        {
            return _context.Users.Include(u => u.LoyaltyCard).ToList(); 
        }

        public User GetUserById(int id)
        {
            return _context.Users.Include(u => u.pieceOfArts).FirstOrDefault(u => u.UserId == id);
        }

        public void AddUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public void UpdateUser(User user)
        {
            _context.Users.Update(user);
            _context.SaveChanges();
        }

        public void DeleteUser(User user)
        {
            _context.Users.Remove(user);
            _context.SaveChanges();
        }
        public PieceOfArt GetPieceOfArtByTitle(string title)
        {
           
            return _context.pieceOfArts.FirstOrDefault(p => p.Title == title);
        }

        public LoyaltyCard GetLoyaltyCardByName(string name)
        {
            return _context.loyaltyCards.FirstOrDefault(l => l.LoyaltyCardName == name);
        }
    }
}
