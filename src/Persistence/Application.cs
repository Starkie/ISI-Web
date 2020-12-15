using System;
using System.Collections.Generic;

#nullable disable

namespace Fotografos.Persistence
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
