using FileUserStore.Helpers.Exceptions;
using FileUserStore.Models.CommandModels.UserCommands;
using FileUserStore.Models.EventModels.UserEvents;
using FileUserStore.Models.IdentityModels;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FileUserStore.Services.Implementations
{
    public class FUserStore : IFUserStore
    {
        private bool disposedValue;
        private readonly IFileService _fileService;
        private readonly ConcurrentDictionary<Guid, Models.IdentityModels.IdentityUser> _user;
        private readonly ConcurrentDictionary<string, Models.IdentityModels.IdentityUser> _usernames;
        private readonly ConcurrentQueue<AbstractUserCommandsModel> _userCommands;

        public FUserStore(IFileService fileService)
        {
            _fileService = fileService ?? throw new ArgumentNullException(nameof(fileService));
        }

        public Task<IdentityResult> CreateAsync(Models.IdentityModels.IdentityUser user, CancellationToken cancellationToken)
        {
            if (_user.TryAdd(user.Id, null))
            {
                while (_userCommands.TryDequeue(out var result))
                {
                    _userCommands.Enqueue(result);
                }
                return Task.FromResult(IdentityResult.Success);
            }
            throw new UserIdNotUniqueException();
        }

        public Task<IdentityResult> DeleteAsync(Models.IdentityModels.IdentityUser user, CancellationToken cancellationToken)
        {
            _userCommands.Enqueue(new DeleteUserCommandModel { UserId = user.Id });
            return Task.FromResult(IdentityResult.Success);
        }

        public Task<Models.IdentityModels.IdentityUser> FindByIdAsync(string userId, CancellationToken cancellationToken)
        {
            if (_user.TryGetValue(Guid.Parse(userId), out var user))
            {
                return Task.FromResult(user);
            }
            throw new UserIdNotValidException();
        }

        public Task<Models.IdentityModels.IdentityUser> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetNormalizedUserNameAsync(Models.IdentityModels.IdentityUser user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetUserIdAsync(Models.IdentityModels.IdentityUser user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.Id.ToString());
        }

        public Task<string> GetUserNameAsync(Models.IdentityModels.IdentityUser user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task SetNormalizedUserNameAsync(Models.IdentityModels.IdentityUser user, string normalizedName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task SetUserNameAsync(Models.IdentityModels.IdentityUser user, string userName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IdentityResult> UpdateAsync(Models.IdentityModels.IdentityUser user, CancellationToken cancellationToken)
        {
            return Task.FromResult(IdentityResult.Success);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~FUserStore()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        public async Task HandleEvent(AbstractUserEventModel input)
        {
            if (input is UserCreatedEventModel ucem)
            {
                await UserCreatedEventHandlerAsync(ucem);
            }
            else if (input is UserDeletedEventModel udem)
            {
                await UserDeletedEventHandlerAsync(udem);
            }
            else
            {
                if (_user.TryGetValue(input.Id, out var user))
                {
                    await user.EventHandler(input);
                }
                else
                {
                    throw new UserIdNotValidException();
                }
            }
        }

        private Task UserCreatedEventHandlerAsync(UserCreatedEventModel input)
        {
            Models.IdentityModels.IdentityUser user = new(input.Id, _userCommands);
            if (!_user.TryAdd(input.Id, user))
            {
                throw new UserIdNotUniqueException();
            }
            return Task.CompletedTask;
        }

        private Task UserDeletedEventHandlerAsync(UserDeletedEventModel input)
        {
            if (!_user.TryRemove(input.Id, out _))
            {
                throw new UserIdNotValidException();
            }

            return Task.CompletedTask;
        }


    } 
}
