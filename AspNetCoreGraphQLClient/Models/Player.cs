using System;
using System.Collections.Generic;

namespace AspNetCoreGraphQLClient.Models
{
    public partial class Player
    {
        public int Id { get; set; }
        public int? ShirtNo { get; set; }
        public string? Name { get; set; }
        public int? PositionId { get; set; }
        public int? Appearances { get; set; }
        public int? Goals { get; set; }

        public virtual Position? Position { get; set; }
    }
}
