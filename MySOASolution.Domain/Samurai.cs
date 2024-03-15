using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace MySOASolution.Domain
{
    public class Samurai
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        public int SamuraiId { get; set; }

        [NotNull]
        public string Name { get; set; } = string.Empty;

        [NotNull]
        public string Origin { get; set; } = string.Empty;

        public IEnumerable<Quote>? Quotes { get; set; }

        public IEnumerable<Battle>? Battles { get; set; }

        public Horse? Horse { get; set; }
    }
}
