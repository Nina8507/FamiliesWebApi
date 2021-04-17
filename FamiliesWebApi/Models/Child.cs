using System.Collections.Generic;

namespace FamiliesWebApi.Models
{
    public class Child:Person
    {
        public List<Interest> Interests { get; set; }
        public List<Pet> Pets { get; set; }
        public override string FirstName { get; set; }
        public override string LastName { get; set; }
        public override string HairColor { get; set; }
        public override string EyeColor { get; set; }
        public override int Age { get; set; }
        public override float Weight { get; set; }
        public override int Height { get; set; }
        public override string Sex { get; set; }
    }
}