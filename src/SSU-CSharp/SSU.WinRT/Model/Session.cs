using System;

namespace SSU.Model
{
    /// <summary>
    /// A session instance resource represents a created registration session. 
    /// </summary>
    public sealed class Session
    {
        public RestException RestException { get; set; }

        /// <summary>
        /// The unique id of this session
        /// </summary>
        public int? Id { get; set; }

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
        public DateTimeOffset? RegistrationOpenDate { get; set; }

        /// <summary>
        /// The date that registration closes
        /// </summary>
        public DateTimeOffset? RegistrationCloseDate { get; set; }
        
        /// <summary>
        /// The date that play starts
        /// </summary>
        public DateTimeOffset? PlayOpenDate { get; set; }

        /// <summary>
        /// The date that play ends for the session
        /// </summary>
        public DateTimeOffset? PlayCloseDate { get; set; }
    }
}
