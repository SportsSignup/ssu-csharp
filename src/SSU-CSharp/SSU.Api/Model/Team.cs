namespace SSU.Model
{
    /// <summary>
    /// A team is a group of registrations, it's fun to play games on a team.
    /// </summary>
    public class Team : SSUBase
    {
        /// <summary>
        /// The Id of the team
        /// </summary>
        public int? Id { get; set; }

        /// <summary>
        /// The division id of the team
        /// </summary>
        public int? DivisionId { get; set; }

        /// <summary>
        /// The session id of the team
        /// </summary>
        public int? SessionId { get; set; }

        /// <summary>
        /// The name of the team
        /// </summary>
        public string Name { get; set; }

    }
}