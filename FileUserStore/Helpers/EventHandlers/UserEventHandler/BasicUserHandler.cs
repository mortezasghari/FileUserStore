using FileUserStore.Models.EventModels.UserEvents;
using FileUserStore.Models.IdentityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileUserStore.Helpers.EventHandlers.UserEventHandler
{
    public static class BasicUserHandler
    {
        public static IdentityUser UsernameChangedEventHandler(this IdentityUser user, UserNameChangedEventModel _event)
        {
            return user with { Username = _event.Username, Version = _event.EventId };
        }

        public static IdentityUser PasswordChangedEventHandler(this IdentityUser user, PasswordChangedEventModel _event)
        {
            return user with { PasswordHash = _event.PasswordHash, Version = _event.EventId };
        }
    }
}
