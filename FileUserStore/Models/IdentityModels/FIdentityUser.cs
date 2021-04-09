using FileUserStore.Models.EventModels.UserEvents;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileUserStore.Models.IdentityModels
{
    public sealed class FIdentityUser<TKey> : IdentityUser<TKey> where TKey : IEquatable<TKey>
    {
        private readonly ConcurrentQueue<AbstractUserEventModel<TKey>> _commandQueue;
        public FIdentityUser()
        {
        }

        public FIdentityUser(string userName) : base(userName)
        {
        }

        public IEnumerable<AbstractUserEventModel<TKey>> SaveChange()
        {
            while (!_commandQueue.IsEmpty)
            {
                if (_commandQueue.TryDequeue(out var command))
                {
                    yield return command;

                }
            }
        }

        public void EventHandler(AbstractUserEventModel<TKey> _event)
        { 
            
        }

        public override TKey Id { get => base.Id; set => throw new InvalidOperationException(); }
        public override string UserName { get => base.UserName; set => base.UserName = value; }
        public override string NormalizedUserName { get => base.NormalizedUserName; set => base.NormalizedUserName = value; }
        public override string Email { get => base.Email; set => base.Email = value; }
        public override string NormalizedEmail { get => base.NormalizedEmail; set => base.NormalizedEmail = value; }
        public override bool EmailConfirmed { get => base.EmailConfirmed; set => base.EmailConfirmed = value; }
        public override string PasswordHash { get => base.PasswordHash; set => base.PasswordHash = value; }
        public override string SecurityStamp { get => base.SecurityStamp; set => base.SecurityStamp = value; }
        public override string ConcurrencyStamp { get => base.ConcurrencyStamp; set => base.ConcurrencyStamp = value; }
        public override string PhoneNumber { get => base.PhoneNumber; set => base.PhoneNumber = value; }
        public override bool PhoneNumberConfirmed { get => base.PhoneNumberConfirmed; set => base.PhoneNumberConfirmed = value; }
        public override bool TwoFactorEnabled { get => base.TwoFactorEnabled; set => base.TwoFactorEnabled = value; }
        public override DateTimeOffset? LockoutEnd { get => base.LockoutEnd; set => base.LockoutEnd = value; }
        public override bool LockoutEnabled { get => base.LockoutEnabled; set => base.LockoutEnabled = value; }
        public override int AccessFailedCount { get => base.AccessFailedCount; set => base.AccessFailedCount = value; }
    }
}
