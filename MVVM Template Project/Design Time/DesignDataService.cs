using System;
using System.Collections.ObjectModel;
using System.Windows.Media;
using MVVM_Template_Project.Models;

namespace MVVM_Template_Project.Design
{
    public class DesignDataService : IDataService
    {
        public void GetData(Action<DataItem, Exception> callback)
        {
            // Use this to create design time data

            var item = new DataItem("Welcome to MVVM Light [design]");
            callback(item, null);
        }

        public ObservableCollection<string> GetNames(int anAmount)
        {
            var col = new ObservableCollection<string>();
            for (int i = 0; i < 5; i++)
            {
                col.Add("Design name: " + (i+1));
            }
            return col;
        }

        public ObservableCollection<Person> GetPeople(int anAmount)
        {
            var col = new ObservableCollection<Person>();
            for (int i = 0; i < anAmount; i++)
            {
                col.Add(new Person("Dummy","some_phone",DateTime.Now, Colors.Blue, PersonSex.Male));
            }
            return col;
        }
    }
}