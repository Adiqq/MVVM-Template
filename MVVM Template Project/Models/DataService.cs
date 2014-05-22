using System;
using System.Collections.ObjectModel;
using MVVM_Template_Project.Auxiliary.Helpers;

namespace MVVM_Template_Project.Models
{
    public class DataService : IDataService
    {
        public void GetData(Action<DataItem, Exception> callback)
        {
            // Use this to connect to the actual data service

            var item = new DataItem("Welcome to MVVM Light [ Runtime ]");
            callback(item, null);
        }

        public ObservableCollection<string> GetNames(int anAmount)
        {
            var col = new ObservableCollection<string>();
            for (int i = 0; i < anAmount; i++)
            {
                col.Add(Random_Helper.RandomName());
            }
            return col;
        }

        public ObservableCollection<Person> GetPeople(int anAmount)
        {
            var col = new ObservableCollection<Person>();
            for (int i = 0; i < anAmount; i++)
            {
                col.Add(Person.GetRandomPerson());
            }
            return col;
        }
    }
}