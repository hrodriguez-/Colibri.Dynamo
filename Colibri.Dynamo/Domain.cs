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

        internal Domain( int a, int b)
        {
            this.A = a;
            this.B = b;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <returns></returns>
        public static Domain Create(int A, int B)
        {
            return new Domain(A, B);
        }
    }
}
