using System.Collections.Generic;
using System.Threading.Tasks;
using UsersControl.DTO;
using UsersControl.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace UsersControl.Data
{
    /// <summary>
    /// Activity model service (Reposotiry).
    /// </summary>
    public class ActivityModelService : IActivityModelService
    {
        private readonly UsersControlDbContext db;

        public ActivityModelService(UsersControlDbContext db)
        {
            this.db = db;
        }

        /// <summary>
        /// Get an ordered and filtered page of activities.
        /// </summary>
        /// <param name="searchDTO"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Activity>> GetActivities(ActivitySearchDTO searchDTO)
        {
            //Create query...
            var query = from x in db.Activities select x;

            //Filter by user...
            if (searchDTO.UserId != null && searchDTO.UserId > 0)
            {
                query = query.Where(x => x.UserId == searchDTO.UserId);
            }

            //Filter by activity type...
            if (!string.IsNullOrEmpty(searchDTO.ActivityType) && (new string[]{ "i", "u", "d"}).Contains(searchDTO.ActivityType))
            {
                query = query.Where(x => x.ActivityType.Trim().Equals(searchDTO.ActivityType.Trim()));
            }

             //Count Total Records...
            searchDTO.TotalRecords = await query.CountAsync();

            //Calculete Total Pages...
            searchDTO.TotalPages = searchDTO.TotalRecords / searchDTO.RecordsPerPage;

            //Just in case there are records that cannot be included in the last page, let's add another page more...
            if (searchDTO.TotalRecords % searchDTO.RecordsPerPage > 0)
                searchDTO.TotalPages++;

            //Just in case the requested page no longer exist, let's go to a page back...
            if (searchDTO.TotalPages > 0 && searchDTO.Page > searchDTO.TotalPages)
                searchDTO.Page--;

            //Order and Paginate records..
            query = query.OrderByDescending(x => x.CreateDate).Skip((searchDTO.Page - 1) * searchDTO.RecordsPerPage).Take(searchDTO.RecordsPerPage);

            //Finally, materialize records and return them...
            return await query.ToListAsync();

        }
    
    }
}