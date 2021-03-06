using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UsersControlWebApp.ViewModels.Shared
{
    /// <summary>
    ///Clase abstracta que se utiliza para proporcionar los detalles de
    ///filtrado, dirección de ordenamiento, página actual, número de registros por página, etc en pantallas de busqueda.
    /// </summary>
    public abstract class SearchViewModel
    {

        /// <summary>
        /// Página actual solicitada.
        /// </summary>
        public int Page { get; set; }

        /// <summary>
        /// Nombre de la columna por la cual se deben ordenar los datos que se presentaran en la lista.
        /// </summary>
        [Display(Name = "Order By")]
        public string SortColumn { get; set; }


        /// <summary>
        /// Dirección de ordenamiento de los datos. Asc o Desc.
        /// </summary>
        [Display(Name = "Order Direction")]
        public string SortDirection { get; set; }


        /// <summary>
        /// Total número de registros que se recuperaron
        /// </summary>
        public int TotalRecords { get; set; }

        /// <summary>
        /// Número de registros por página
        /// </summary>
        [Display(Name = "Total/Page")]
        [Range(minimum: 1, maximum: 50)]
        public int RecordsPerPage { get; set; }

        /// <summary>
        /// Número total de páginas obtenidos en la búsqueda
        /// </summary>
        [Display(Name = "Total Pages")]
        public int TotalPages { get; set; }

        public SearchViewModel()
        {
            Page = 1;
            SortColumn = "Id";
            SortDirection = "ASC";
            RecordsPerPage = 10;
        }
    }
}   