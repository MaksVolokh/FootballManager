namespace FootballManagerAPI.Controllers.Entities
{
    public class FootballPlayer
    {
        public int Id { get; set; }
        public string FirstName { get; set; } 
        public string LastName { get; set; } 
        public int Number { get; set; }

        public FootballPlayer(int id, string firstName, string lastName, int number)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Number = number;
        }
    }
}
