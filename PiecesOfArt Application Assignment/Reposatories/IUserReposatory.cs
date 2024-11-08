using PiecesOfArt_Application_Assignment.Models;

namespace PiecesOfArt_Application_Assignment.Reposatories
{
    public interface IUserReposatory
    {
        public List<User> GetAllUsers();
        User GetUserById(int id);
        void AddUser(User user);
        void UpdateUser(User user);
        void DeleteUser(User user);
        PieceOfArt GetPieceOfArtByTitle(string title); 
        LoyaltyCard GetLoyaltyCardByName(string name); 
    }
}
