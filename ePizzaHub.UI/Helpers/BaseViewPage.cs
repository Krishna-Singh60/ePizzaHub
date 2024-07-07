using ePizzaHub.Model;
using Microsoft.AspNetCore.Mvc.Razor;
using System.Text.Json;


namespace ePizzaHub.UI.Helpers
{
    public abstract class BaseViewPage<TModel> : RazorPage<TModel>
    {
        public UserModel CurrentUser
        {
            get
            {
                if (User.Claims.Count() > 0)
                {
                    string userData = User.Claims.FirstOrDefault(c => c.Type == System.Security.Claims.ClaimTypes.UserData)?.Value;
                    if (!string.IsNullOrEmpty(userData))
                    {
                        return JsonSerializer.Deserialize<UserModel>(userData);
                    }
                }
                return null;
            }
        }
    }
}
