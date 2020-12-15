using System;
using System.Collections.Generic;

namespace Fotografos.Persistence
{
    public partial class Photographer
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Surename { get; set; }
        public string Addess { get; set; }
        public string City { get; set; }
        public long Postalcode { get; set; }
        public long Telephone { get; set; }
    }
}
