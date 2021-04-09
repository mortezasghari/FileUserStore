using FileUserStore.Helpers.Extentions;
using FileUserStore.Models.EventModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileUserStore.Services.Implementations
{
    public class FileService : IFileService
    {
        private readonly string _folder;
        public FileService(string folder)
        {
            _folder = folder;
        }

        public async IAsyncEnumerable<AbstractEventModel> ReadEventsAsync(string filename)
        {
            using (StreamReader sr = new StreamReader(CreateFilename(filename)))
            {
                string str;
                while ((str = await sr.ReadLineAsync())!= null)
                {
                    yield return str.ParseEvent();
                }
            }
        }

        public async IAsyncEnumerable<AbstractEventModel> WriteLineAsync(string filename, IEnumerable<AbstractEventModel> input)
        {
            using (StreamWriter sw = new StreamWriter(CreateFilename(filename), append: true))
            {
                foreach (var item in input)
                {
                    await sw.WriteLineAsync(item.SerilizeEvent());
                    yield return item;
                } 
            }
        }

        private string CreateFilename(string filename)
        {
            throw new NotImplementedException();
        }

    }
}
