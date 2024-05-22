using Application.DTO;
using Application.Interface;
using AutoMapper;
using Domain.Entity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CQRS.Command
{
    public class AddProduct: IRequest<string>
    {
        public ProductDTO? productDto { get; set; }
    }
    public class AddProductHandler:IRequestHandler<AddProduct, string>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public AddProductHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<string> Handle(AddProduct request, CancellationToken cancellationToken)
        {
            var product= _mapper.Map<Product>(request.productDto);
            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return "Product Added Successfully";
        }
    }
}

