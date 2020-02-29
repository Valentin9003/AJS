using AJS.Data;
using AJS.Services.Interfaces;
using AJS.Services.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AJS.Services.Implementations
{
    /// <summary>
    /// Ads API Service
    /// </summary>
    public class AdsApiService : IAdsApiService
    {
        private readonly AJSDbContext db;

        public AdsApiService(AJSDbContext db)
        {
            this.db = db;
        }

        public async Task<List<AdApiServiceModel>> GetAllAds()
        {
            return await db.Ad.Select(a => new AdApiServiceModel
            {
                // TODO: Implement me
            }).ToListAsync();
        }
    }
}
