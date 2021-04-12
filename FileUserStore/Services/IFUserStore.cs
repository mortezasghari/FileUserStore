using FileUserStore.Models.EventModels.UserEvents;
using FileUserStore.Models.IdentityModels;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileUserStore.Services
{
    public interface IFUserStore : IUserStore<Models.IdentityModels.IdentityUser>
    {
        Task HandleEvent(AbstractUserEventModel input);
    }
}
