using AutoMapper;
using Core.Persistence.Paging;
using ECommerce.Application.Features.Products.Models;
using ECommerce.Application.Services.Repositories;
using ECommerce.Core.CrossCuttingConcerns.Logging.Serilog;
using ECommerce.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Features.Products.Queries.GetListProduct
{
    public class GetListProductQueryHandler : IRequestHandler<GetListProductQuery, ProductListModel>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        private readonly LoggerServiceBase _logger;

        public GetListProductQueryHandler(IProductRepository productRepository, IMapper mapper, LoggerServiceBase logger)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<ProductListModel> Handle(GetListProductQuery request, CancellationToken cancellationToken)
        {
            _logger!.Info("ÜRÜNLER LİSTELENDİ");
            IPaginate<Product> products = await _productRepository.GetListAsync(
                                                            include:
                                                            p=>p.Include(p=>p.ProductImageFiles),
                                                            index: request.PageRequest.Page,
                                                            size: request.PageRequest.PageSize);

            ProductListModel mappedProductListModel = _mapper.Map<ProductListModel>(products);         
            return mappedProductListModel;

        }
    }
}
