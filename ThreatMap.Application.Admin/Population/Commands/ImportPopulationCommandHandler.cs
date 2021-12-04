using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThreatMap.Application.Admin.Population.Repositories;
using ThreatMap.Application.Shared.Common.Services;
using ThreatMap.Domain.Populations;
using ThreatMap.Domain.ValueObjects;

namespace ThreatMap.Application.Admin.Population.Commands
{
    public class ImportPopulationCommandHandler : IRequestHandler<ImportPopulationCommand, List<long>>
    {
        private readonly IPopulationRepository _populationRepository;
        private readonly IDateService _dateService;
        private readonly ICurrentUserService _userService;

        public ImportPopulationCommandHandler(IPopulationRepository populationRepository, IDateService dateService,
            ICurrentUserService userService)
        {
            _populationRepository = populationRepository;
            _dateService = dateService;
            _userService = userService;
        }

        public async Task<List<long>> Handle(ImportPopulationCommand req, CancellationToken cancellationToken)
        {
            var addedpopulationData = new List<ThreatMap.Domain.Populations.Population>();
            foreach (var item in req.features)
            {
                var newLocation = Location.Create(item.geometry.coordinates[0], item.geometry.coordinates[1]);
                var newPopulation = new ThreatMap.Domain.Populations.Population()
                {
                    PeopleCount = item.properties.Liczba_oso,
                    Address = item.properties.Adres,
                    HomeNumber = item.properties.Numer_domu,
                    Street = item.properties.Ulica,
                    Location = newLocation,

                };

                await _populationRepository.CreateAsync(newPopulation);

            }
           
            return addedpopulationData.Select(q => q.Id).ToList();
        }
    }
}