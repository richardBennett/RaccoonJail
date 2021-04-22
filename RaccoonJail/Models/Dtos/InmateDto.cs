namespace Models.Dtos
{
    public class InmateDto
    {
        public ArrestLocation ArrestLocation { get; set; }
        public HappinessLevel HappinessLevel { get; set; }
        public HungerLevel HungerLevel { get; set; }
        public long Id { get; set; }
        public string Name { get; set; }
        public decimal Size { get; set; }
    }
}