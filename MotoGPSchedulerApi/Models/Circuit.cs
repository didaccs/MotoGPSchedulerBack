using System.ComponentModel.DataAnnotations;

namespace MotoGPSchedulerApi.Models
{
    public class Circuit: BaseModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public float Length { get; set; }

        [Required]
        public int TurnsLeft { get; set; }

        [Required]
        public int TurnsRight { get; set; }

        [Required]
        public float Width { get; set; }

        [Required]
        public int StraightLong { get; set; }

        [Required]
        public virtual Country Country { get; set; }

        public virtual Record LastRecord { get; set; }
    }
}
