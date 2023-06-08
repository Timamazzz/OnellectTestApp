using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnellectRandomizer.Domain.Models
{
    public class RandomizeResult
    {
        public IEnumerable<int> OriginalSequence { get; init; }

        public IEnumerable<int> SortedSequence { get; init; }
    }
}
