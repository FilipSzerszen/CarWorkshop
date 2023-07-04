using CarWorkshop.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkshop.Infrastructure.Seeders
{
    public class CarWorkshopSeeder
    {
        private readonly CarWorkshopDbContext _dbContext;

        public CarWorkshopSeeder(CarWorkshopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Seed()
        {
            if(await _dbContext.Database.CanConnectAsync())
            {
                if(!_dbContext.CarWorkshops.Any()) {
                    var MazdaAso = new Domain.Entities.CarWorkshop()
                    {
                        Name="Mazda ASO",
                        Description = "Autoryzowany serwis Mazda",
                        About = "Jesteśmy na rynku od 1990 roku",
                        ContactDetails = new()
                        {
                            City ="Wrocław",
                            Street = "Borowska 3",
                            PostalCode = "50-536",
                            PhoneNumber = "+48 111-222-333"
                        }
                    };
                    MazdaAso.EncodeName();

                    _dbContext.CarWorkshops.Add(MazdaAso);
                    await _dbContext.SaveChangesAsync();
                }
            }
        }
    }
}
