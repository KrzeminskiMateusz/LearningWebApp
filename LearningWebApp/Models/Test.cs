using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearningRazorPages.Models
{
    public class Test
    {
        public int ID { get; set; }
        public string testName { get; set; }
        public TimeSpan testTimeSpan { get; set; }
        public bool testBool { get; set; }
        public long testLong { get; set; }

    }
}
