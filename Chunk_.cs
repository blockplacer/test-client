using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brickon.Map
{
    public class Chunk_<T> : List<Chunk_<T>>
    {
        public T Value { set; get; }
    }
   
}
