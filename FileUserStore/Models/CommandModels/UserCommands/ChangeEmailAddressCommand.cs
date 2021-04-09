﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileUserStore.Models.CommandModels.UserCommands
{
    public record ChangeEmailAddressCommand<TKey> : AbstractUserCommandsModel<TKey> where TKey : IEquatable<TKey>
    {
        public string NewEmailAddress { get; init; }
    }
}
