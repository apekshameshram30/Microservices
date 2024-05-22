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
    public  class GetProduct :IRequest<List<ProductDTO>>
    {
    }
    public class GetProductHandler : IRequestHandler<GetProduct, List<ProductDTO>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetProductHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<ProductDTO>> Handle(GetProduct request,CancellationToken cancellationToken)
        {
            var product= await _context.Products.ToListAsync();
            return _mapper.Map<List<ProductDTO>>(product);
        }
    }
}
