using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileUserStore.Models.CommandModels.UserCommands
{
    public record UpdateSecurityStampCommand<TKey> : AbstractUserCommandsModel<TKey> where TKey : IEquatable<TKey>
    {
        public string SecurityStamp { get; init; }
    }
}
