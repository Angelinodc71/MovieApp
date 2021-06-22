using System;
using System.ComponentModel.DataAnnotations;

namespace Movie_App.ViewModel
{
    public class MovieViewModel
    {
        public Guid id { get; set; }
        [Required (ErrorMessage ="El campo Nombre es requerido")]
        [MaxLength(30)]
        public string name { get; set; }
        [Required (ErrorMessage ="El campo Género es requerido")]
        [MaxLength(30)]
        public string genre { get; set; }  
    }
}