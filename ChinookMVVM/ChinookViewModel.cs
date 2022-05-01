using ChinookDbLib;
using MVVM.Tools;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChinookMVVM
{
    public class ChinookViewModel : ObservableObject
    {
        private ChinookContext db;

        public ChinookViewModel Init(ChinookContext db)
        {
            this.db = db;
            Customers = db.Customers.ToList();
            return this;
        }

        private ObservableCollection<string> list = new ObservableCollection<string>()
        {
            "Test",
            "Value",
            "Bled"
        };

        public ObservableCollection<string> List
        {
            get { return list; }
            set {
                list = value; 
                RaisePropertyChangedEvent(nameof(List));
            }
        }

        private List<Customer> customers;

        public List<Customer> Customers
        {
            get { return customers; }
            set
            {
                customers = value;
                RaisePropertyChangedEvent(nameof(List));
            }
        }


    }
}

