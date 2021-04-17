namespace FamiliesWebApi.Models
{
    public class Person
    {
        public virtual int Id { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual string HairColor { get; set; }
        public virtual string EyeColor { get; set; }
        public virtual int Age { get; set; }
        public virtual float Weight { get; set; }
        public virtual int Height { get; set; }
        public virtual string Sex { get; set; }
    }
}