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
            return this;
        }

        private ObservableCollection<string> list;

        public ObservableCollection<string> List
        {
            get { return list; }
            set {
                list = value; 
                RaisePropertyChangedEvent(nameof(List));
            }
        }

    }
}

