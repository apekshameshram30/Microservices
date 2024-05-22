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
    public class GetUsers : IRequest<List<UserDTO>>
    {
    }
    public class GetUsersHandler : IRequestHandler<GetUsers, List<UserDTO>>
    {
        private readonly IUserDbContext _context;
        private readonly IMapper _mapper;

        public GetUsersHandler (IUserDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<UserDTO>> Handle(GetUsers request,  CancellationToken cancellationToken)
        {
            var getUser = await _context.UserDetails.ToListAsync();
            return _mapper.Map<List<UserDTO>>(getUser);
        }
    }
}
