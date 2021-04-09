using FileUserStore.Models.CommandModels.UserCommands;
using FileUserStore.Models.EventModels.UserEvents;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FileUserStore.Models.IdentityModels
{
    public sealed class FIdentityUser : IdentityUser<Guid>
    {
        private readonly ConcurrentQueue<AbstractUserCommandsModel> _commandQueue;
        public FIdentityUser()
        {
            base.Id = Guid.NewGuid();
            _commandQueue = new ConcurrentQueue<AbstractUserCommandsModel>();
            _commandQueue.Enqueue(new CreateUserCommand { UserId = base.Id });
        }

        public FIdentityUser(string userName) : base(userName)
        {
            base.Id = Guid.NewGuid();
            _commandQueue = new ConcurrentQueue<AbstractUserCommandsModel>();
            _commandQueue.Enqueue(new CreateUserCommand { UserId = base.Id });
            _commandQueue.Enqueue(new ChangeUsernameCommand { UserId = base.Id, Username = base.UserName });
        }

        public FIdentityUser(Guid UserId, ConcurrentQueue<AbstractUserCommandsModel> commandQueue)
        {
            base.Id = UserId;
            _commandQueue = commandQueue;
        }

        public IEnumerable<AbstractUserCommandsModel> SaveChange()
        {
            while (!_commandQueue.IsEmpty)
            {
                if (_commandQueue.TryDequeue(out AbstractUserCommandsModel command))
                {
                    yield return command;

                }
            }
        }

        public void AddCommand(AbstractUserCommandsModel input)
        {
            _commandQueue?.Enqueue(input);
        }

        public Task EventHandler(AbstractUserEventModel _event)
        {
            throw new NotImplementedException();
        }

        #region Properties
        public override Guid Id
        {
            get => base.Id;
            set => throw new InvalidOperationException();
        }
        public override string UserName
        {
            get => base.UserName;
            set => _commandQueue.Enqueue(new ChangeUsernameCommand
            {
                UserId = base.Id,
                Username = value
            });
        }
        public override string NormalizedUserName
        {
            get => base.NormalizedUserName;
            set => throw new InvalidOperationException();
        }
        public override string Email
        {
            get => base.Email;
            set => _commandQueue.Enqueue(new ChangeEmailAddressCommand
            {
                UserId = base.Id,
                NewEmailAddress = value
            });
        }
        public override string NormalizedEmail
        {
            get => base.NormalizedEmail;
            set => throw new InvalidOperationException();
        }
        public override bool EmailConfirmed
        {
            get => base.EmailConfirmed;
            set
            {
                if (value)
                {
                    _commandQueue.Enqueue(new ConfirmEmailAddressCommand
                    {
                        UserId = base.Id
                    });
                }
            }
        }
        public override string PasswordHash
        {
            get => base.PasswordHash;
            set => _commandQueue.Enqueue(new ChangePasswordCommand
            {
                UserId = base.Id,
                PasswordHash = value
            });
        }
        public override string SecurityStamp
        {
            get => base.SecurityStamp;
            set => _commandQueue.Enqueue(new UpdateSecurityStampCommand
            {
                UserId = base.Id,
                SecurityStamp = value
            });
        }
        public override string ConcurrencyStamp
        {
            get => base.ConcurrencyStamp;
            set => throw new InvalidOperationException();
        }
        public override string PhoneNumber
        {
            get => base.PhoneNumber;
            set => _commandQueue.Enqueue(new ChangePhonenumberCommand { UserId = base.Id, Phonenumber = value });
        }
        public override bool PhoneNumberConfirmed
        {
            get => base.PhoneNumberConfirmed;
            set
            {
                if (value)
                {
                    _commandQueue.Enqueue(new ConfirmPhonenumberCommand
                    {
                        UserId = base.Id
                    });
                }
            }
        }

        public override bool TwoFactorEnabled
        {
            get => base.TwoFactorEnabled;
            set => _commandQueue.Enqueue(new EnableTwoFactorAuthenticationCommand
            {
                UserId = base.Id
            });
        }

        public override DateTimeOffset? LockoutEnd
        {
            get => base.LockoutEnd;
            set
            {
                if (value.HasValue)
                {
                    _commandQueue.Enqueue(new LockAccountCommand
                    {
                        UserId = base.Id,
                        Duration = value.Value - DateTimeOffset.Now
                    });
                }
            }

        }

        public override bool LockoutEnabled
        {
            get => base.LockoutEnd.HasValue ? base.LockoutEnd < DateTimeOffset.Now : false;
            set => throw new InvalidOperationException();
        }

        private int myVar;

        public int MyProperty
        {
            get => myVar;
            set => myVar = value;
        }




        public override int AccessFailedCount
        {
            get => base.AccessFailedCount;
            set => throw new InvalidOperationException();
        }
        #endregion

        
    }
}
