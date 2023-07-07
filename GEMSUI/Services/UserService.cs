using GEMSUI.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace GEMSUI.Services
{
    public class UserService : IUserService
    {
        private readonly IConfiguration _configuration;
        public UserService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string DeleteUser(int id, string token)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_configuration["BaseUrl"] + "/User/");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", string.Format($" {token}"));
                //HTTP GET
                var responseTask = client.GetAsync("DeleteUser/" + id.ToString());
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    var readTask = result.Content.ReadAsStringAsync();
                    readTask.Wait();
                    return readTask.Result;
                }
            }
            return null;
        }

        public User GetUser(int id, string token)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_configuration["BaseUrl"] + "/User/");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", string.Format($" {token}"));
                //HTTP GET
                var responseTask = client.GetAsync("GetUser/" + id.ToString());
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    var readTask = result.Content.ReadAsAsync<User>();
                    readTask.Wait();
                    return readTask.Result;
                }
            }
            return null;
        }

        public List<User> GetUsers(string token)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_configuration["BaseUrl"] + "/User/");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", string.Format($" {token}"));
                //HTTP GET
                var responseTask = client.GetAsync("GetUsers");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    var readTask = result.Content.ReadAsAsync<List<User>>();
                    readTask.Wait();
                    return readTask.Result;
                }
            }
            return null;
        }

        public string Login(Login login)
        {
            using (var client = new HttpClient())
            {
                var content = new StringContent(JsonConvert.SerializeObject(login), Encoding.UTF8, "application/json");
                client.BaseAddress = new Uri(_configuration["BaseUrl"] + "/User/");
                //HTTP GET
                var responseTask = client.PostAsync("Login", content);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    var readTask = result.Content.ReadAsStringAsync();
                    readTask.Wait();
                    return readTask.Result;
                }
            }
            return null;
        }

        public string SaveUser(User user, string token)
        {
            using (var client = new HttpClient())
            {
                var content = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");
                client.BaseAddress = new Uri(_configuration["BaseUrl"] + "/User/");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", string.Format($" {token}"));
                //HTTP GET
                var responseTask = client.PostAsync("SaveUser", content);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    var readTask = result.Content.ReadAsStringAsync();
                    readTask.Wait();
                    return readTask.Result;
                }
            }
            return null;
        }
    }
}
