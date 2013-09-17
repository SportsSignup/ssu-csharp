namespace SSU.Model
{
    public class RosteredIndividual : SSUBase
    {
        public int? Id { get; set; }
        public char FirstInitial { get; set; }
        public string LastName { get; set; }
        public string JerseyNumber { get; set; }
        public string Role { get; set; }
    }
}