using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MVVM_Template_Project.Models
{
    /// <summary>
    /// This is the default MVVM Light DataItem. It's a simlpe class that holds a string and
    /// is used to show how to use the IDataservice Interface and get back either design
    /// or runtime data.
    /// </summary>
    public class DataItem
    {
        public DataItem(string title)
        {
            Title = title;
        }

        public string Title
        {
            get;
            private set;
        }
    }
}
