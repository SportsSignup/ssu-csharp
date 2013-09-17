namespace SSU.Model
{
    /// <summary>
    /// A Mapping class, wrapping a value to a key name.
    /// </summary>
    public class OrganizationInfo : SSUBase
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string WebSite { get; set; }

        public string SiteURL { get; set; }

        public string SessionWord { get; set; }

        public bool ShowSessionInfo { get; set; }

        public bool ShowRegistrarInfo { get; set; }

        public bool IsAYF { get; set; }

        public bool IsStoreActive { get; set; }

        public string BackgroundColor { get; set; }

        public string HeaderImageURL { get; set; }

        public string HeaderAlignment { get; set; }

        public string SocialSharingImageURL { get; set; }

        public string SocialSharingDescription { get; set; }

        public string TranslationLanguages { get; set; }

    }
}
