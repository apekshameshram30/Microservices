using Application2.DTO;
using Application2.Interface;
using AutoMapper;
using Domain2.Entity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application2.CQRS.Command
{
    public class AddUser :IRequest<string>
    {
        public UserDTO? userDto {  get; set; }
    }

    public  class AddUserHandler : IRequestHandler<AddUser, string>
    {
        private readonly IUserDbContext _context;
        private readonly IMapper _mapper;

        public AddUserHandler(IUserDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<string> Handle(AddUser request, CancellationToken cancellationToken)
        {
            var users = _mapper.Map<User>(request.userDto);
            _context.UserDetails.Add(users);
            await _context.SaveChangesAsync();

            return "User Added";
        }
    }
}
