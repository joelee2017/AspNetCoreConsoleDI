using AspNetCoreConsoleDI.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace AspNetCoreConsoleDI.Interface
{
    public interface IQuadraticService
    {
        QuadraticRoots CalculateRoots(Double a, Double b, Double c);
    }
}
