using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace PGE.Fantasy_World.Common
{
    public class Point
    {
        public double X;
        public double Y;
        public double Z;

        public Point(double x, double y=0.0, double z=0.0)
        {
            X = x;
            Y = y;
            Z = z;
        }
    }
}
