using System.Collections.Generic;
using System.Threading.Tasks;
using UsersControl.DTO;
using UsersControl.Models;

namespace UsersControl.Data
{
    public interface IActivityModelService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="searchDTO"></typeparam>
        Task<IEnumerable<Activity>> GetActivities(ActivitySearchDTO searchDTO);
    
    }
}