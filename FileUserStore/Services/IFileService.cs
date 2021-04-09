using FileUserStore.Models.EventModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileUserStore.Services
{
    public interface IFileService : IObservable<AbstractEventModel>
    {
        IAsyncEnumerable<AbstractEventModel> ReadEventsAsync(string filename);
        Task WriteLineAsync(string filename, IEnumerable<AbstractEventModel> input);
    }
}
