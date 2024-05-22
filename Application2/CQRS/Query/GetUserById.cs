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
    public class GetUserById : IRequest<List<UserDTO>>
    {
        public int Id { get; set; }
    }
    public class GetUsersByIdHandler : IRequestHandler<GetUserById, List<UserDTO>>
    {
        private readonly IUserDbContext _context;
        private readonly IMapper _mapper;

        public GetUsersByIdHandler(IUserDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<UserDTO>> Handle(GetUserById request, CancellationToken cancellationToken)
        {

            var user = await _context.UserDetails.FirstOrDefaultAsync(u => u.UserId == request.Id);
            var dto = _mapper.Map<UserDTO>(user);
            return new List<UserDTO> { dto };
        }
    }

}
