using autosalon.Data;
using autosalon.Models;
using autosalon.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace autosalon.Services
{
    public class CarService:ICarService
    {
        private readonly AutoSalonDBContext dbContext;

        public CarService(AutoSalonDBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<Car>> GetCars()
        {
            return await this.dbContext.Cars.ToListAsync();
        }

        public async Task<Car> AddCar(Car car)
        {
            this.dbContext.Cars.Add(car);
            await this.dbContext.SaveChangesAsync();

            return car;
        }

        async Task<bool> ICarService.DeleteCar(int id)
        {
            var car = await this.dbContext.Cars.FindAsync(id);

            if (car == null)
            {
                return false;
            }

            dbContext.Cars.Remove(car);

            await dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<Car> FindCarById(int id)
        {
            var car = await this.dbContext.Cars.FirstOrDefaultAsync(x => x.Id == id);

            return car;
        }
    }
}
