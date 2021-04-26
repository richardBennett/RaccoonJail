namespace Models.Requests
{
    public class InmateUpdateRequest
    {
        public ArrestLocation? ArrestLocation { get; set; }
        public HappinessLevel? HappinessLevel { get; set; }
        public HungerLevel? HungerLevel { get; set; }
        public long Id { get; set; }
        public string Name { get; set; }
        public decimal? SizeInOz { get; set; }
        public int? TimeServedInMonths { get; set; }
    }
}