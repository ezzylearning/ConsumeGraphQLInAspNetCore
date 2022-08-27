using System;
using System.Collections.Generic;

namespace AspNetCoreGraphQLServer.Models
{
    public partial class Match
    {
        public int Id { get; set; }
        public int? Team1 { get; set; }
        public int? Team2 { get; set; }
        public int? Team1Goals { get; set; }
        public int? Team2Goals { get; set; }

        public virtual Team? Team1Navigation { get; set; }
        public virtual Team? Team2Navigation { get; set; }
    }
}
