using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SSU.Model
{
    public class GameLocation : SSUBase
    {
        public int? Id { get; set; }

        public string Name { get; set; }

        public string WebsiteUrl { get; set; }

        public string MapUrl { get; set; }

        public string Description { get; set; }

        public Address Address { get; set; }
    }
}
