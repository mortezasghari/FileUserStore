using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileUserStore.Models.CommandModels.UserCommands
{
    public abstract record AbstractUserCommandsModel<TKey> : AbstractCommandModel where TKey : IEquatable<TKey>
    {
        public TKey UserId { get; init; }
    }
}
