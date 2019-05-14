using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
namespace MovieManageMent.Model
{
    public abstract class AbsNotify : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public virtual void OnNotifiyed([CallerMemberName]string nm ="")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nm));
        }
    }
}
