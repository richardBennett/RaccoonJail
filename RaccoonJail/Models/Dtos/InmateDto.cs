namespace Models.Dtos
{
    public class InmateDto
    {
        public string ArrestLocation { get; set; }
        public string HappinessLevel { get; set; }
        public string HungerLevel { get; set; }
        public long Id { get; set; }
        public string Name { get; set; }
        public decimal SizeInOz { get; set; }
        public int TimeServedInMonths { get; set; }
    }
}