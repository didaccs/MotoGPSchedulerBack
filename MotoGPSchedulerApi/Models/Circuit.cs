using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MotoGPSchedulerApi.Models
{
    public class Circuit
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public float Length { get; set; }

        [Required]
        public int Turns { get; set; }

        [Required]
        public float Width { get; set; }

        [Required]
        public int StraightLong { get; set; }

        [Required]
        public Country Country { get; set; }

        public Record LastRecord { get; set; }
    }
}
