using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Care.Domain
{
    public class Answer
    {
        public int Id { get; set; }
        public string Value { get; set; }
        public virtual Test Test { get; set; }
        public virtual Question Question { get; set; }

    }
}
