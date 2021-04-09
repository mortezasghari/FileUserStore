using FileUserStore.Helpers.EventBuses;
using FileUserStore.Helpers.Extentions;
using FileUserStore.Models.EventModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace FileUserStore.Services.Implementations
{
    public class FileService : IFileService
    {
        private readonly string _folder;
        private readonly List<IObserver<AbstractEventModel>> _observers = new List<IObserver<AbstractEventModel>>();
        public FileService(string folder)
        {
            _folder = folder;
        }

        public async IAsyncEnumerable<AbstractEventModel> ReadEventsAsync(string filename)
        {
            using (StreamReader sr = new StreamReader(CreateFilename(filename)))
            {
                string str;
                while ((str = await sr.ReadLineAsync()) != null)
                {
                    yield return str.ParseEvent();
                }
            }
        }
        public IDisposable Subscribe(IObserver<AbstractEventModel> observer)
        {
            
                if (!_observers.Contains(observer))
                    _observers.Add(observer);
                return new Unsubscriber<AbstractEventModel>(_observers, observer);
            
        }
        public async Task WriteLineAsync(string filename, IEnumerable<AbstractEventModel> input)
        {
            using (StreamWriter sw = new StreamWriter(CreateFilename(filename), append: true))
            {
                foreach (AbstractEventModel item in input)
                {
                    await sw.WriteLineAsync(item.SerilizeEvent());
                    NewEvent(item);
                }
            }
        }
        private string CreateFilename(string filename)
        {
            throw new NotImplementedException();
        }
        private void NewEvent(AbstractEventModel input)
        {
            Parallel.ForEach(_observers, observer =>
            {
                observer.OnNext(input);
            });
        }
    }
}
