using FileUserStore.Models.CommandModels.UserCommands;
using FileUserStore.Models.EventModels.UserEvents;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FileUserStore.Models.IdentityModels
{
    public record IdentityUser
    {
        
        public Guid Id { get; init; }
        public Guid Version { get; init; }

        public string Phone { get; init; }
        public string Email { get; init; }
        public string Username { get; init; }
        public string PasswordHash { get; init; }
        public bool IsEmailVerified { get; init; }
        public bool IsPhoneVerified { get; init; }

        public static IdentityUser CreateNewUser()
        {
            return CreateNewUser(Guid.NewGuid());
        }

        public static IdentityUser CreateNewUser(Guid UserId)
        {
            return new IdentityUser { Id = UserId, Version = UserId };
        }
    }
}
