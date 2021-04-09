using FileUserStore.Models.EventModels;
using FileUserStore.Models.EventModels.UserEvents;
using FileUserStore.Models.IdentityModels;
using FileUserStore.Services;
using System;
using System.Collections.Concurrent;

namespace FileUserStore
{
    public class FUserStore<TKey> : IObserver<AbstractEventModel>
        where TKey : IEquatable<TKey>
    {
        private readonly IFileService _fileservice;
        private readonly ConcurrentDictionary<TKey, FIdentityUser<TKey>> _user;



        public void OnCompleted()
        {
            throw new NotImplementedException();
        }

        public void OnError(Exception error)
        {
            throw new NotImplementedException();
        }

        public void OnNext(AbstractEventModel value)
        {
            if (value is AbstractUserEventModel auem)
            {

            }
        }
    }
}
