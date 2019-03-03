using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MotoGPSchedulerApi.Models
{
    public class Event: BaseModel
    {
        public DateTime Date { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual Circuit Circuit { get; set; }
    }
}
