using System;
using System.ComponentModel.DataAnnotations;

namespace MotoGPSchedulerApi.Models
{
    public class Country: BaseModel
    {
        [Required]
        public String Name { get; set; }
    }
}
