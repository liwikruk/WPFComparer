using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComparerNums2._0.Models;
using System.IO;
using Newtonsoft.Json;

namespace ComparerNums2._0.Services
{
    class FileIOService
    {
        private readonly string PATH;
        
        public FileIOService(string path)
        {
            PATH = path;
        }
        public BindingList<ComparerNum> LoadData() 
        {
            var fileExists = File.Exists(PATH);
            if (!fileExists)
            {
                File.CreateText(PATH).Dispose();
                return new BindingList<ComparerNum>();
            }
            using (var reader = File.OpenText(PATH))
            {
                var fileText = reader.ReadToEnd();
                return JsonConvert.DeserializeObject<BindingList<ComparerNum>>(fileText);
            }
        }
        public void SaveData(object _CompareNumDataList)
        {
            using (StreamWriter writer = File.CreateText(PATH))
            {
                string output = JsonConvert.SerializeObject(_CompareNumDataList);
                writer.Write(output);
            }
        }
    }
}
