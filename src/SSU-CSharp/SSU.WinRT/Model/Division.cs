
namespace SSU.Model
{
    /// <summary>
    /// A division is a sub-grouping of a league, usually based around participant age or grade.
    /// </summary>
    public sealed class Division
    {
        public RestException RestException { get; set; }

        /// <summary>
        /// The id of the division
        /// </summary>
        public int? Id { get; set; }

        /// <summary>
        /// The session id this division belongs to
        /// </summary>
        public int? SessionId { get; set; }

        /// <summary>
        /// The name of the division
        /// </summary>
        public string Name { get; set; }
    }
}
