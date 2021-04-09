using FileUserStore.Models.EventModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileUserStore.Services
{
    public interface IFileService
    {
        IAsyncEnumerable<AbstractEventModel> ReadEventsAsync(string filename);
        IAsyncEnumerable<AbstractEventModel> WriteLineAsync(string filename, IEnumerable<AbstractEventModel> input);
    }
}
