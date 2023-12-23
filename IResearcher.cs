using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgazzSerialize
{
    public interface IResearcher
    {
        string Name { get; }
        void Run(int iteration = 1000);
    }
}
