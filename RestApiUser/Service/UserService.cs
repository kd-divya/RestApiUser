using System.Text.RegularExpressions;
using Newtonsoft.Json;
using RestApiUser.Model;

namespace RestApiUser.Service
{
    public class UserService : IUserService
    {
        public readonly ILogger<UserService> logger;

        public UserService(ILogger<UserService> logger)
        {
            this.logger = logger;
        }

        public User User (int id)
        {
            try
            {
                var user = new User();
                HttpClient client = new HttpClient();

                var apiUrl = @$"https://jsonplaceholder.typicode.com/users/{id}";
                var response = client.GetAsync(apiUrl).Result;
                if(response.IsSuccessStatusCode)
                {
                    var data = response.Content.ReadAsStringAsync();            
                    var cust = JsonConvert.DeserializeObject<User>(data.Result);
                    string pattern = @"^(.*?)@";
                    Match match = Regex.Match(cust.Email, pattern);
                    if (match.Success)
                    {
                        string email = match.Groups[1].Value;
                        user.Email = email;
                    }
                    return user;
                }
                else
                {
                    logger.LogError("The User Service has thrown Error!");
                }
                return user;
            }
            catch(Exception ex)
            {
                logger.LogError($"The User Service has thrown {ex.Message}");
                throw ex;
            }
            
        }
    }
}
