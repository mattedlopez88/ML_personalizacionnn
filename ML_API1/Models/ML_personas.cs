using System.ComponentModel.DataAnnotations;

namespace ML_personalizacion.Models
{
    public class ML_personas
    {
        [Key]
        public int ML_id { get; set; }
        public string ML_nombre { get; set; }
        public string ML_apellido { get; set; }
        public string ML_email { get; set; }
        public string ML_telefono { get; set; }
    }
}
