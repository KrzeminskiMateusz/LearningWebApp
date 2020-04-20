using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearningApi.Models
{
    public class TodoItemDTO
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public bool IsComplete { get; set; }
    }
}
