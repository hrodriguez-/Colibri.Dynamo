using Autodesk.DesignScript.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colibri.Dynamo.Utilities
{
    public static class Utilities
    {
        /// <summary>
        ///     Static method for report generation.
        /// </summary>
        /// <param name="chartObjects"></param>
        /// <returns></returns>
        [IsVisibleInDynamoLibrary(false)]
        public static List<Domain> CreateDomains(List<int> start, List<int> end, List<string> names)
        {
            List<Domain> output = new List<Domain>();
            for(int i=0; i<start.Count; i++)
            {
                output.Add(new Domain(start[i], end[i]));
            }

            return output;
        }
    }   
}
