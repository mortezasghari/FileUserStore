using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileUserStore.Models.EventModels
{
    public abstract record AbstractEventModel
    {
        public Guid EventId { get; init; }
        public DateTime TimeStamp { get; init; }
    }
}
