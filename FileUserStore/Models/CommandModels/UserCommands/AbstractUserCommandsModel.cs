using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileUserStore.Models.CommandModels.UserCommands
{
    public abstract record AbstractUserCommandsModel : AbstractCommandModel 
    {
        public Guid UserId { get; init; }
    }
}
