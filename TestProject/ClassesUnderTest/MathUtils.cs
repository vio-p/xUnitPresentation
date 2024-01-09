using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.ClassesUnderTest
{
    public class MathUtils
    {
        public static T Add<T>(T a, T b) where T : notnull
        {
            dynamic dynamicA = a;
            dynamic dynamicB = b;
            return dynamicA + dynamicB;
        }
    }
}
