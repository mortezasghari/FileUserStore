using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileUserStore.Models.CommandModels.UserCommands
{
    public record LockAccountCommand : AbstractUserCommandsModel
    {
        public TimeSpan? Duration { get; init; }
    }
}
