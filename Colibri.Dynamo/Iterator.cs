using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colibri.Dynamo
{
    /// <summary>
    /// Some Class
    /// </summary>
    public class Iterator
    {
        internal Iterator()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="inputs"></param>
        /// <param name="steps"></param>
        /// <param name="run"></param>
        /// <returns></returns>
        public static List<List<double>> Iterate(List<Domain> inputs, List<int> steps, bool run)
        {
            List<List<double>> output = new List<List<double>>();
            for (int i = 0; i < inputs.Count; i++)
            {
                Domain d = inputs[i];
                int s = steps[i];

                output.Add(Enumerable.Range(d.A, s)
                 .Select(x => d.A + (d.B - d.A) * ((double)x / (s - 1))).ToList());
            }

            return output;
        }
    }
}
