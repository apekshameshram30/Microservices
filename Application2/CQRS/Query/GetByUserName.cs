using Application.CQRS.Query;
using Application.DTO;
using Application.Interface;
using Application2.DTO;
using Application2.Interface;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application2.CQRS.Query
{
    public class GetByUserName : IRequest<List<UserDTO>>
    {
        public string? UserName { get; set; }
    }
    public class GetByUserNameHandler : IRequestHandler<GetByUserName, List<UserDTO>>
    {
        private readonly IUserDbContext _context;
        private readonly IMapper _mapper;

        public GetByUserNameHandler(IUserDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<UserDTO>> Handle(GetByUserName request, CancellationToken cancellationToken)
        {
            var user = await _context.UserDetails.FirstOrDefaultAsync(p => p.UserName == request.UserName);
            if (user == null)
            {
                throw new($"Product with ID {request.UserName} not found");
            }

            var userdto = _mapper.Map<UserDTO>(user);
            return new List<UserDTO> { userdto };
        }

        
    }

}



