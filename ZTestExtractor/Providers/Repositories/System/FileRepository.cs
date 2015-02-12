using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZTestExtractor.Core.Models.General;

namespace ZTestExtractor.Data.Repositories.System
{
    public class FileRepository
    {
        public Result SaveModelToFile<TModel>(TModel modelToSave, string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
            {
                throw new ArgumentNullException("fileName");
            }

            var result = new Result();

            string data = JsonConvert.SerializeObject(modelToSave);

            try
            {
                var fullFileName = GetPath() + fileName;
                File.WriteAllText(fullFileName, data);
            }
            catch(UnauthorizedAccessException)
            {
                result.Messages.Add("Can not save file, permission denied!");
                return result;
            }
            catch(Exception)
            {
                result.Messages.Add("An unknown error occurred, please try again later...");
                return result;
            }

            result.Messages.Add("Configuration successfully saved!");
            result.IsSuccess = true;

            return result;
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
                data = File.ReadAllText(GetPath() + fileName);
            }
            catch (FileNotFoundException)
            {
                return null;
            }

            return JsonConvert.DeserializeObject<TModel>(data);
        }

        public void DeleteFile(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
            {
                throw new ArgumentNullException("fileName");
            }

            string fullFileName = GetPath() + fileName;

            if(File.Exists(fullFileName))
            {
                File.Delete(fullFileName);
            }
        }

        private string GetPath()
        {
            var path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\ZTestExtractor\\";

            if(!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            return path;
        }
    }
}
