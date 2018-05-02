using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public partial class Review
    {

        public override string ToString()
        {
            return $"[id:{id}] Rated {rating:0.#} by {username}";
        }
    }
}
