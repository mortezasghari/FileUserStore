using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileUserStore.Models.EventModels.UserEvents
{
    public record EmailVerifiedEventModel : AbstractUserEventModel
    {
        public string EmailAddress { get; init; }
    }
}
