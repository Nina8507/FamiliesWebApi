namespace FamiliesWebApi.Models
{
    public class Adult:Person
    {
        public Adult()
        {}
        public Job JobTitle { get; set; }
        public override int Id { get; set; }
        
        public override string FirstName { get; set; }
        public override string LastName { get; set; }
        public override string HairColor { get; set; }
        public override int Age { get; set; }
        public override float Weight { get; set; }
        public override int Height { get; set; }
        public override string Sex { get; set; }

    }
}