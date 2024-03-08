using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace Wba.Oefening.Students.Web.ViewComponents
{
    public class RandomUserViewComponent : ViewComponent
    {

        private readonly IHttpClientFactory _clientFactory;

        public RandomUserViewComponent(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            {
                var client = _clientFactory.CreateClient();
                var response = await client.GetAsync("https://randomuser.me/api/");
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    try
                    {
                        var data = JObject.Parse(json);
                        var firstName = data["results"][0]["name"]["first"].ToString();
                        var lastName = data["results"][0]["name"]["last"].ToString();
                        var fullName = $"{firstName} {lastName}";
                        // return View("Index",fullName);
                        return Content(fullName);
                    }
                    catch (Exception ex)
                    {
                        // Handle JSON parsing error
                        return Content($"Error parsing JSON: {ex.Message}");
                    }
                }
                else
                {
                    return Content("Error retrieving random person data");
                }
            }
        }
    }

}

