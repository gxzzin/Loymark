using System.Collections.Generic;

namespace UsersControl.DTO
{

    /// <summary>
    /// Data Transfer Object for search activity results.
    /// </summary>
    public class ActivitySearchResultDTO
    {
        public int Page { get; set; }

        public int TotalRecords { get; set; }

        public int TotalPages { get; set; }

        public IEnumerable<ActivityReadDTO> Activities { get; set; }

        public ActivitySearchResultDTO(int page, int totalRecords, int totalPages, IEnumerable<ActivityReadDTO> activities)
        {
            Page = page;
            TotalRecords = totalRecords;
            TotalPages = totalPages;
            Activities = activities;
        }
    }
}