using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using StrataTest.Interfaces;
using StrataTest.Models;

namespace StrataTest.Repository
{
    public class UserRepository : IUserRepository
    {
        private string _dataSource;
        public UserRepository(string dataSource)
        {
            _dataSource = dataSource;
        }

        public User GetUserByName(string userName)
        {
            var users = ProcessJson();
            return users.FirstOrDefault(x => x.Name == userName);
        }

        public User GetUserByEmail(string emailAddress)
        {
            return ProcessJson().FirstOrDefault(x => x.EmailAddress == emailAddress);
        }

        //TODO make into generic extension method
        private IEnumerable<User> ProcessJson()
        {
            return JsonConvert.DeserializeObject<List<User>>(File.ReadAllText(_dataSource));
        }
    }
}