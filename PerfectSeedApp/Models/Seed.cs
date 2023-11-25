using System.ComponentModel.DataAnnotations;

namespace PerfectSeedApp.Models
{
    public class Seed
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string SeedSequence { get; set; }
    }
}
