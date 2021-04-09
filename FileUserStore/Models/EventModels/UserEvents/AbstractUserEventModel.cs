﻿using System;

namespace FileUserStore.Models.EventModels.UserEvents
{
    public abstract record AbstractUserEventModel: AbstractEventModel 
    {
        public Guid Id { get; set; }
    }
}
