using AJS.Services.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AJS.Services.Interfaces
{
    /// <summary>
    /// Ads API Service Interface
    /// </summary>

    public interface IAdsApiService
    {
        Task<List<AdApiServiceModel>> GetAllAds()
    }
}
