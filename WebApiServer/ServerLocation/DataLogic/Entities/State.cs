using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLogic.Entities
{
    [Table("state")]
    public class State
    {
        public State()
        {
            city = new HashSet<City>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idState { get; set; }

        public int? idCountry { get; set; }

        [StringLength(255)]
        public string nameState { get; set; }

        public virtual ICollection<City> city { get; set; }

        public virtual Country country { get; set; }
    }
}
