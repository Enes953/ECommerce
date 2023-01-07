using ECommerce.Infrastructure.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Infrastructure.Services.Storage
{
    public class Storage
    {
        protected delegate bool HasFile(string parthOrContainerName, string fileName);
        protected async Task<string> FileRenameAsync(string parthOrContainerName, string fileName, HasFile hasFileMethod ,int num = 1)
        {
            {
                // Get file extension
                string extension = Path.GetExtension(fileName);

                // Create new file name with -num suffix
                string oldName = $"{Path.GetFileNameWithoutExtension(fileName)}-{num}";
                string newFileName = $"{NameOperation.CharacterRegulatory(oldName)}{extension}";

                // Check if new file name already exists
                //if (File.Exists($"{path}\\{newFileName}"))
                if(hasFileMethod(parthOrContainerName, newFileName))
                {
                    // If it does, increment num and try again
                    return await FileRenameAsync(parthOrContainerName, $"{newFileName.Split($"-{num}")[0]}{extension}",hasFileMethod,++num);
                }

                // If it doesn't, return new file name
                return newFileName;
            };
        }
    }
}
