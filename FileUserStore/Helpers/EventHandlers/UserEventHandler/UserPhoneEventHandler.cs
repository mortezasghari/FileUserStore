using FileUserStore.Helpers.Exceptions;
using FileUserStore.Models.EventModels.UserEvents;
using FileUserStore.Models.IdentityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileUserStore.Helpers.EventHandlers.UserEventHandler
{
    public static class UserPhoneEventHandler
    {
        public static IdentityUser UserPhonenumberChangedEventHandler(this IdentityUser input, UserPhonenumberChangedEventModel _event)
        {
            return input.Phone == _event.Phonenumber ? input : input with { Phone = _event.Phonenumber, IsPhoneVerified = false, Version = _event.EventId };
        }

        public static IdentityUser UserPhonenumberVerifiedEventHandler(this IdentityUser input, UserPhonenumberVerifiedEventModel _event)
        {
            return input.Phone == _event.Phonenumber ? input with { IsPhoneVerified = true, Version = _event.EventId } : throw new PhonenumberVerificationException();
        }
    }
}
