using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnellectRandomizer.Domain.Confiuration
{
    public class Configuration
    {
        public int MinValue { get; set; }

        public int MaxValue { get; set; }

        public int MinSize { get; set; }

        public int MaxSize { get; set; }

        public string ApiUrl { get; set; }
    }
}
