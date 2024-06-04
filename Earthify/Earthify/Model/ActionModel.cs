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
        public double ProgressValue { get; set; }
        public string ActionCode
        {
            get
            {
                return (string.IsNullOrEmpty(Category) ? "" : Category.Substring(0, 1)) + "00" + Id;
            }
        }
    }
}
