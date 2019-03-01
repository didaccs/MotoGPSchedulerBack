using System;
using System.ComponentModel.DataAnnotations;

namespace MotoGPSchedulerApi.Models
{
    public class Record: BaseModel
    {
        [Required]
        public TimeSpan Time { get; set; }

        [Required]
        public string Pilot { get; set; }
    }
}
