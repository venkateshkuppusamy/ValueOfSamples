using ValueOfAPI.Models;

namespace ValueOfAPI.Services
{
    public interface IUserService
    {
        Task<List<User>> Get();
        Task<User> Get(int id);
        Task<int> Create(User user);
        Task Update(int id, User user);
        Task Delete(int id);
    }

    public class UserService : IUserService
    {
        private readonly List<User> _users;
        private static int runningID;

        public UserService()
        {
            _users = new List<User>();
            _users.Add(new User() { Id = ++runningID, Age= AgeVO.From(20), BirthYear= BirthYearVO.From(2001), FullName="KP" });
            _users.Add(new User() { Id = ++runningID, Age = AgeVO.From(22), BirthYear = BirthYearVO.From(2003), FullName = "VK" });
            _users.Add(new User() { Id = ++runningID, Age = AgeVO.From(23), BirthYear = BirthYearVO.From(2004), FullName = "SN" });
        }

        public async Task<int> Create(User user)
        {
            user.Id = ++runningID;
            _users.Add(user);
            return await Task.FromResult(user.Id);
        }

        public async Task Delete(int id)
        {
            var user = _users.FirstOrDefault(f => f.Id ==id);
            if (user != null)
                _users.Remove(user);
            await Task.Delay(0);
        }

        public async Task<List<User>> Get()
        {
            return await Task.FromResult(_users);
        }

        public async Task<User> Get(int id)
        {
            return await Task.FromResult(_users.FirstOrDefault(f => f.Id == id));
        }

        public async Task Update(int id, User user)
        {
            var userFromCol = _users.FirstOrDefault(f => f.Id == id);
            if (userFromCol != null)
            {
                userFromCol.FullName = user.FullName;
                userFromCol.Age = user.Age;
                userFromCol.BirthYear = user.BirthYear;
            }
            await Task.Delay(0);
        }
    }
}