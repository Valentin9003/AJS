using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace AJS.Services.Interfaces
{
    /// <summary>
    /// Service Helper Interface
    /// </summary>
    public interface IServiceHelper
    {
        HttpContext GetCurrentHttpContext();

        string GetUserLocalization();
    }
}
