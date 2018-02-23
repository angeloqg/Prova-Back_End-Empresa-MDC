using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLogic.Entities
{
    [Table("city")]
    public class City
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idCity { get; set; }

        public int? idState { get; set; }

        [StringLength(255)]
        public string nameCity { get; set; }

        public virtual State state { get; set; }
    }
}
