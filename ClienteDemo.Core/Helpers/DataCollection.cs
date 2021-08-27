using System.Linq;
using System.Collections.Generic;

namespace ClienteDemo.Core.Helpers
{
    public class DataCollection<T>
    {
        public int Page { get; set; }
        public int Total { get; set; }
        public int Pages { get; set; }
        public IEnumerable<T> Items { get; set; }
        public bool HasItems => Items != null && Items.Any();
    }
}
