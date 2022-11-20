using Application.Features.Brands.Dtos;
using Application.Features.Brands.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Application.Features.Brands.Commands.CreateBrand
{
    public partial class CreateBrandEntityCommand:IRequest<CreatedBrandEntityDto>
    {
        public string Name { get; set; }
        public class CreateBrandCommandHandler : IRequestHandler<CreateBrandEntityCommand, CreatedBrandEntityDto>
        {
           private readonly IBrandRepository _brandRepository;
           private readonly IMapper _mapper;
            private readonly BrandEntityBusinessRules _brandEntityBusinessRules;

            public CreateBrandCommandHandler(IBrandRepository brandRepository, IMapper mapper, BrandEntityBusinessRules brandEntityBusinessRules)
            {
                _brandRepository = brandRepository;
                _mapper = mapper;
                _brandEntityBusinessRules = brandEntityBusinessRules;
            }

            public async Task<CreatedBrandEntityDto> Handle(CreateBrandEntityCommand request, CancellationToken cancellationToken)
            {
                await _brandEntityBusinessRules.BrandEntityNameCanNotBeDuplicatedWhenInserted(request.Name);

                Brand mappedBrand = _mapper.Map<Brand>(request);
                Brand createdBrand = await _brandRepository.AddAsync(mappedBrand);
                CreatedBrandEntityDto createdBrandEntityDto = _mapper.Map<CreatedBrandEntityDto>(createdBrand);
                return createdBrandEntityDto;
            }
        }
    }
}
