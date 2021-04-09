using System;

namespace FileUserStore.Models.EventModels.UserEvents
{
    public abstract record AbstractUserEventModel<TKey> : AbstractEventModel where TKey : IEquatable<TKey>
    {
        public TKey Id { get; set; }
    }
}
