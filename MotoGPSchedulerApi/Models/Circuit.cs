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
