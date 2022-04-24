using BrokerPremium.Core.Models;
using Microsoft.AspNetCore.Identity;

namespace BrokerPremium.Core.Contracts
{
    public interface IUserService
    {
        Task<IEnumerable<UserListViewModel>> GetUsers();

        //Task<UserEditViewModel> GetUserForEdit(string id);

        //Task<bool> UpdateUser(UserEditViewModel model);

        Task<IdentityUser> GetUserById(string id);
    }
}
