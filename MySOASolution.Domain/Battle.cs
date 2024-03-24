namespace MySOASolution.Domain
{
    public class Battle
    {
        public int BattleId { get; set; }
        public string? Name { get; set; }

        public IEnumerable<Samurai>? Samurais { get; set; }
    }
}
