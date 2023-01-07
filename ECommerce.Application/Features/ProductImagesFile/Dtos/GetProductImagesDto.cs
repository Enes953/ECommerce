using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Features.ProductImagesFile.Dtos
{
    public class GetProductImagesDto
    {
        public string FilePath { get; set; }
        public string FileName { get; set; }
        public int Id { get; set; }
    }
}
