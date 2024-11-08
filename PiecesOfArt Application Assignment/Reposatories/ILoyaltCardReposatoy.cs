using PiecesOfArt_Application_Assignment.Models;

namespace PiecesOfArt_Application_Assignment.Reposatories
{
    public interface ILoyaltCardReposatoy
    {
        void AddLoyaltyCard(LoyaltyCard loyaltyCard);
        LoyaltyCard GetSecondLoyaltyCard();
        void DeleteLoyaltyCard(LoyaltyCard loyaltyCard);
        void SaveChanges();
    }
}
