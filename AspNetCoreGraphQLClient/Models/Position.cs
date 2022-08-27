using System;
using System.Collections.Generic;

namespace AspNetCoreGraphQLClient.Models
{
    public partial class Position
    {
        public Position()
        {
            Players = new HashSet<Player>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public int? DisplayOrder { get; set; }

        public virtual ICollection<Player> Players { get; set; }
    }
}
