namespace SSU
{
    /// <summary>
    /// A Mapping class, wrapping a value to a key name.
    /// </summary>
    public class DataValue : SSUBase
    {
        /// <summary>
        /// The name of the property on the regstration
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The value of the property on the registration
        /// </summary>
        public string Value { get; set; }

    }
}
