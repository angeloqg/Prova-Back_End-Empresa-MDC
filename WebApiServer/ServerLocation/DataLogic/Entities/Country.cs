using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLogic.Entities
{
    [Table("country")]
    public class Country
    {
        public Country()
        {
            state = new HashSet<State>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idCountry { get; set; }

        [StringLength(255)]
        public string nameCountry { get; set; }

        public virtual ICollection<State> state { get; set; }
    }
}
