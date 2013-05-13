using System;

namespace SSU
{
    /// <summary>
    /// A session instance resource represents a created registration session. 
    /// </summary>
    public class Session : SSUBase
    {
        /// <summary>
        /// The unique id of this session
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The name of this session
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The description of this session
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// A status message for this session (session ends soon, etc)
        /// </summary>
        public string SessionStatusMessage { get; set; }

        /// <summary>
        /// The date that registration opens
        /// </summary>
        public DateTime? RegistrationOpenDate { get; set; }

        /// <summary>
        /// The date that registration closes
        /// </summary>
        public DateTime? RegistrationCloseDate { get; set; }
        
        /// <summary>
        /// The date that play starts
        /// </summary>
        public DateTime? PlayOpenDate { get; set; }

        /// <summary>
        /// The date that play ends for the session
        /// </summary>
        public DateTime? PlayCloseDate { get; set; }
    }
}
