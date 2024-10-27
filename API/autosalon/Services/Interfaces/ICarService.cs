using autosalon.Models;

namespace autosalon.Services.Interfaces
{
    public interface ICarService
    {
        Task<IEnumerable<Car>> GetCars();
        Task<Car> AddCar(Car car);
        Task<bool> DeleteCar(int id);
        Task<Car> FindCarById(int id);
    }
}
