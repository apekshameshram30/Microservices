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
    public class GetByUserName: IRequest<List<ProductDTO>>
    {
        public string? UserName { get; set; }
    }
    public class GetByUserNameHandler : IRequestHandler<GetByUserName, List<ProductDTO>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetByUserNameHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<ProductDTO>> Handle(GetByUserName request, CancellationToken cancellationToken)
        {
            var product = await _context.Products.FirstOrDefaultAsync(p => p.UserName == request.UserName);
            if (product == null)
            {
                throw new($"Product with ID {request.UserName} not found");
            }

            var productDto = _mapper.Map<ProductDTO>(product);
            return new List<ProductDTO> { productDto };
        }

    }
    
    
}
