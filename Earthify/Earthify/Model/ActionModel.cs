using System;
using System.Collections.Generic;
using System.Text;

namespace Earthify.Model
{
    public class ActionModel
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string Impact_Level { get; set; }
        public string Impact_Description { get; set; }
        public string Frequency { get; set; }
    }
}
