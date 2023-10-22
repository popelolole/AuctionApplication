using AuctionApplication.Core;

namespace AuctionApplication.ViewModels
{
    public class UserVM
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public static UserVM FromUser(User user)
        {
            UserVM userVM = new UserVM() 
            { 
                Id = user.Id, 
                Name = user.Name, 
                Email = user.Email, 
                PhoneNumber = user.PhoneNumber 
            };
            return userVM;
        }
    }
}
