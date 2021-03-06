﻿namespace SSU.Model
{
    /// <summary>
    /// Exceptions returned in the HTTP response body when something goes wrong.
    /// </summary>
    public class RestException
    {
        /// <summary>
        /// The HTTP status code for the exception.
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// (Conditional) An error code to find help for the exception.
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// A more descriptive message regarding the exception.
        /// </summary>
        public string Message { get; set; }
    }
}