using System;
using System.Collections.Generic;

namespace Fotografos.Domain
{
    public partial class Application
    {
        public long Id { get; set; }
        public string Date { get; set; }
        public string EquimentDescription { get; set; }
        public string Resume { get; set; }
        public long? PhotographerId { get; set; }
    }
}
