using autosalon.Data;
using autosalon.Models;
using autosalon.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace autosalon.Services
{
    public class UserService : IUserService
    {
        private readonly AutoSalonDBContext dbContext;

        public UserService(AutoSalonDBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            return await this.dbContext.Users.ToListAsync();
        }

        public async Task<User> CreateUser(User user)
        {

            this.dbContext.Users.Add(user);
            await this.dbContext.SaveChangesAsync();

            return user;
        }

        async Task<bool> IUserService.DeleteUser(int id)
        {
            var user = await this.dbContext.Users.FindAsync(id);

            if (user == null)
            {
                return false;
            }

            dbContext.Users.Remove(user);

            await dbContext.SaveChangesAsync();

            return true;
        }

        public bool ExistUser(string email)
        {
            var userAlreadyExists = this.dbContext.Users.Any(x => x.Email == email);
            if (userAlreadyExists)
            {
                return true;
            }
            return false;
        }

        public async Task<User> FindUserByEmail(string email)
        {
            var user = await this.dbContext.Users.FirstOrDefaultAsync(x => x.Email == email);

            return user;
        }

        public async Task<User> FindUserById(int id)
        {
            var user = await this.dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);

            return user;
        }
        public async Task<User> UpdateUser(User user)
        {
            //dbContext.Users.Update(user);
            await this.dbContext.SaveChangesAsync();

            return user;
            
        }

        //public Task<User> SaveChanges()
        //{
        //    return dbContext.Users.SaveChanges();
        //}
        //        var updateUser = await dbContext.Users.FirstOrDefaultAsync(u => u.Email == user.Email);

        //        await this.dbContext.SaveChangesAsync();

        //            if (updateUser != null)
        //            {
        //                return updateUser;
        //            }
        //            else
        //            {
        //                throw new NullReferenceException();
        //}

        //        }

    }
}
