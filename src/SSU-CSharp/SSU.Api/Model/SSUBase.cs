using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SSU.Model;

namespace SSU
{
    public abstract class SSUBase
    {
        public RestException RestException { get; set; }

        public Uri Uri { get; set; }
    }
}
