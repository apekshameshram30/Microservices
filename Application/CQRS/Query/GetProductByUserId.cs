using Application.DTO;
using Application.Interface;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CQRS.Query
{
    public class GetProductByUserId:IRequest<List<ProductDTO>>
    {
        public int Id { get; set; }
    }
    public class GetProductByUserIdHandler:IRequestHandler<GetProductByUserId, List<ProductDTO>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetProductByUserIdHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<ProductDTO>> Handle(GetProductByUserId request, CancellationToken cancellationToken)
        {
            var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == request.Id);
            if (product == null)
            {
                throw new ($"Product with ID {request.Id} not found");
            }

            var productDto = _mapper.Map<ProductDTO>(product);
            return new List<ProductDTO> { productDto };
        }

    }
}
