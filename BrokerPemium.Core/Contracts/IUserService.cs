using BrokerPremium.Core.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
