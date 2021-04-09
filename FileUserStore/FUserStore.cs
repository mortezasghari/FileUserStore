using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FileUserStore
{
    public class FUserStore<TUser, TKey, TUserClaim, TUserLogin, TUserToken>
        : UserStoreBase<TUser, TKey, TUserClaim, TUserLogin, TUserToken>
        where TUser : IdentityUser<TKey>
        where TKey : IEquatable<TKey>
        where TUserClaim : IdentityUserClaim<TKey>, new()
        where TUserLogin : IdentityUserLogin<TKey>, new()
        where TUserToken : IdentityUserToken<TKey>, new()
    {
        public FUserStore(IdentityErrorDescriber describer) : base(describer)
        {
        }

        #region Public Methods
        public override IQueryable<TUser> Users => throw new NotImplementedException();

        public override Task AddClaimsAsync(TUser user, IEnumerable<Claim> claims, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public override Task AddLoginAsync(TUser user, UserLoginInfo login, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public override Task<IdentityResult> CreateAsync(TUser user, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public override Task<IdentityResult> DeleteAsync(TUser user, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public override Task<TUser> FindByEmailAsync(string normalizedEmail, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public override Task<TUser> FindByIdAsync(string userId, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public override Task<TUser> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public override Task<IList<Claim>> GetClaimsAsync(TUser user, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public override Task<IList<UserLoginInfo>> GetLoginsAsync(TUser user, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public override Task<IList<TUser>> GetUsersForClaimAsync(Claim claim, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public override Task RemoveClaimsAsync(TUser user, IEnumerable<Claim> claims, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public override Task RemoveLoginAsync(TUser user, string loginProvider, string providerKey, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public override Task ReplaceClaimAsync(TUser user, Claim claim, Claim newClaim, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public override Task<IdentityResult> UpdateAsync(TUser user, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        protected override Task AddUserTokenAsync(TUserToken token)
        {
            throw new NotImplementedException();
        }

        protected override Task<TUserToken> FindTokenAsync(TUser user, string loginProvider, string name, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        protected override Task<TUser> FindUserAsync(TKey userId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        protected override Task<TUserLogin> FindUserLoginAsync(TKey userId, string loginProvider, string providerKey, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        protected override Task<TUserLogin> FindUserLoginAsync(string loginProvider, string providerKey, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        protected override Task RemoveUserTokenAsync(TUserToken token)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
