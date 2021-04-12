using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileUserStore.Models.EventModels.UserEvents
{
    public record UserNameChangedEventModel : AbstractUserEventModel
    {
        public string Username { get; init; }
    }
}
