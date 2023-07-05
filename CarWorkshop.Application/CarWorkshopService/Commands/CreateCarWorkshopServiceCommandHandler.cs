﻿using CarWorkshop.Application.ApplicationUser;
using CarWorkshop.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkshop.Application.CarWorkshopService.Commands
{
    public class CreateCarWorkshopServiceCommandHandler : IRequestHandler<CreateCarWorkshopServiceCommand>
    {
        private readonly ICarWorkshopRepository _carWorkshopRepository;
        private readonly ICarWorkshopServiceRepository _carWorkshopServiceRepository;
        private readonly IUserContext _userContext;

        public CreateCarWorkshopServiceCommandHandler(ICarWorkshopRepository carWorkshopRepository,
            ICarWorkshopServiceRepository carWorkshopServiceRepository, IUserContext userContext)
        {
            _carWorkshopRepository = carWorkshopRepository;
            _carWorkshopServiceRepository = carWorkshopServiceRepository;
            _userContext = userContext;
        }

        public async Task<Unit> Handle(CreateCarWorkshopServiceCommand request, CancellationToken cancellationToken)
        {
            var carWorkshop = await _carWorkshopRepository.GetByEncodedName(request.CarWorkshopEncodedName!);

            var user = _userContext.GetCurrentUser();
            var isEditable = user != null && (carWorkshop.CreatedById == user.Id || user.IsInRole("Admin"));

            if (!isEditable)
            {
                return Unit.Value;
            }

            var carWorkshopService = new Domain.Entities.CarWorkshopService()
            {
                Description = request.Description,
                Cost = request.Cost,
                CarWorkshopId = carWorkshop.Id
            };

            await _carWorkshopServiceRepository.Create(carWorkshopService);

            return Unit.Value;
        }
    }
}
