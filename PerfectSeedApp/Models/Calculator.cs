using System.ComponentModel.DataAnnotations;

namespace PerfectSeedApp.Models
{
    public class Calculator
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Seed { get; set; }
    }
}
