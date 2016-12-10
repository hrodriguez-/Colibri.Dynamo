using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colibri.Dynamo
{
    /// <summary>
    /// 
    /// </summary>
    public class Domain
    {
        /// <summary>
        /// 
        /// </summary>
        public int A { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int B { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        public Domain( int a, int b)
        {
            this.A = a;
            this.B = b;
        }
    }
}
