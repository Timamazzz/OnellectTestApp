using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnellectRandomizer.Domain.Interfaces
{
    public interface ISortingService
    {
        void Sort(List<int> sequence);
    }
}
