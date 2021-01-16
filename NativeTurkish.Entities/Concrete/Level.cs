using System;
using System.Collections.Generic;
using System.Text;

namespace NativeTurkish.Entities.Concrete
{
    public class Level
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Question> Questions { get; set; }
    }
}
