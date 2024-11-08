using PiecesOfArt_Application_Assignment.ConnectionDbContext;
using PiecesOfArt_Application_Assignment.Models;
using System.Linq;

namespace PiecesOfArt_Application_Assignment.Reposatories
{
    public class LoyaltyCardRepository : ILoyaltCardReposatoy
    {
        private readonly ApplicationDbContext _context;

        public LoyaltyCardRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AddLoyaltyCard(LoyaltyCard loyaltyCard)
        {
            _context.loyaltyCards.Add(loyaltyCard);
        }

        public LoyaltyCard GetSecondLoyaltyCard()
        {
            return _context.loyaltyCards.Skip(1).FirstOrDefault();
        }

        public void DeleteLoyaltyCard(LoyaltyCard loyaltyCard)
        {
            _context.loyaltyCards.Remove(loyaltyCard);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
