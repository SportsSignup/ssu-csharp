using System;

namespace SSU.Model
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class Registration    
    {
        public RestException RestException { get; set; }

        /// <summary>
        /// The Id of the Registration
        /// </summary>
        public int? Id { get; set; }

        /// <summary>
        /// The Id of the Person that the Registration belongs to
        /// </summary>
        public int? PersonId { get; set; }

        /// <summary>
        /// The Id of the Session that the Registration belongs to
        /// </summary>
        public int? SessionId { get; set; }

        /// <summary>
        /// The Id of the Division that the Registration belongs to
        /// </summary>
        public int? DivisionId { get; set; }
        
        /// <summary>
        /// The Id of the Team that the registration is assigned to (if there is one)
        /// </summary>
        public int? TeamId { get; set; }
        
        /// <summary>
        /// The role of the registrant (Player, Coach, Manager, etc)
        /// </summary>
        public string Role { get; set; }
        
        /// <summary>
        /// The date/time the person registered
        /// </summary>
        public DateTimeOffset? RegistrationDate { get; set; }
        
        /// <summary>
        /// The First Name of the Registrant
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// The Middle Name of the registrant (if there is one)
        /// </summary>
        public string MiddleName { get; set; }

        /// <summary>
        /// The Last Name of the registrant
        /// </summary>
        public string LastName { get; set; }
    }
}
