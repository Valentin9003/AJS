using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace AJS.Services.Interfaces
{
    public interface IServiceHelper
    {
        Task<HttpContext>GetCurrentHttpContext();

        Task<string>GetUserLocalization();
    }
}
