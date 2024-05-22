using Application3.DTO;
using Application3.Interface;
using AutoMapper;
using Domain3.Entity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application3.CQRS.Command
{
    public class AddCompany: IRequest<string>
    {
        public CompanyDTO? companyDto { get; set; }
    }
    public class AddProductHandler : IRequestHandler<AddCompany, string>
    {
        private readonly ICompanyDbContext _context;
        private readonly IMapper _mapper;

        public AddProductHandler(ICompanyDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<string> Handle(AddCompany request, CancellationToken cancellationToken)
        {
            var product = _mapper.Map<Company>(request.companyDto);
            _context.Company.Add(product);
            await _context.SaveChangesAsync();

            return "Product Added Successfully";
        }
    }
}


