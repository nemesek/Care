using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Care.Domain
{
    public class Test
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public virtual Student Student { get; set; }
    }
}
