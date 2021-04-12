using FileUserStore.Helpers.Extentions;
using FileUserStore.Models.EventModels.UserEvents;
using FileUserStore.Models.IdentityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileUserStore.Helpers.EventHandlers.UserEventHandler
{
    public static class UserEmailEventHandlers
    {
        public static IdentityUser EmailChangedEventHandler(this IdentityUser input, EmailChangedEventModel _event)
        {
            return input.Email == _event.EmailAddress ? input : input with { Email = _event.EmailAddress, IsEmailVerified = false, Version = _event.EventId };
        }

        public static IdentityUser EmailVerifiedEventHandler(this IdentityUser input, EmailVerifiedEventModel _event)
        {
            return input.Email == _event.EmailAddress ? input with { IsEmailVerified = true, Version = _event.EventId } : throw new EmailVerificationException();
        }
    }
}
