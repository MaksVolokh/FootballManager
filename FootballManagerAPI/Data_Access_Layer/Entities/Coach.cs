namespace FootballManagerDAL.Entities
{
    public class Coach
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        // navigation properties
        public FootballTeam FootballTeam { get; set; }
    }
}
