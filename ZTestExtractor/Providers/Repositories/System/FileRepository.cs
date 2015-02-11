using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZTestExtractor.Repositories.System
{
    public class FileRepository
    {
        public void SaveModelToFile<TModel>(TModel modelToSave, string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
            {
                throw new ArgumentNullException("fileName");
            }

            string data = JsonConvert.SerializeObject(modelToSave);

            File.WriteAllText(fileName, data);
        }

        public TModel LoadModelFromFile<TModel>(string fileName)
            where TModel : class
        {
            if (string.IsNullOrEmpty(fileName))
            {
                throw new ArgumentNullException("fileName");
            }

            string data = string.Empty;

            try
            {
                data = File.ReadAllText(fileName);
            }
            catch (FileNotFoundException)
            {
                return null;
            }

            return JsonConvert.DeserializeObject<TModel>(data);
        }
    }
}
