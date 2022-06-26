using System.Collections;
using System.Collections.Generic;

namespace UsersControl.DTO
{
    /// <summary>
    /// Data Transfer Object for search user results.
    /// </summary>
    public class UserSearchResultDTO
    {
        public int Page { get; set; }

        public int TotalRecords { get; set; }

        public int TotalPages { get; set; }

        public IEnumerable<UserReadDTO> Users { get; set; }
        
        public UserSearchResultDTO(int page, int totalRecords, int totalPages, IEnumerable<UserReadDTO> users)
        {
            Page = page;
            TotalRecords = totalRecords;
            TotalPages = totalPages;
            Users = users;
        }
    }
}