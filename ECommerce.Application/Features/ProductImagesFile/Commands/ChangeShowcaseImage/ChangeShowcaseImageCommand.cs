using ECommerce.Application.Features.ProductImagesFile.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Features.ProductImagesFile.Commands.ChangeShowcaseImage
{
    public class ChangeShowcaseImageCommand:IRequest<ChangedShowcaseImageDto>
    {
        public string ImageId { get; set; }
        public string ProductId { get; set; }
    }
}
