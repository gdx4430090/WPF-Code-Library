using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CommandDemo.Annotations;
using GalaSoft.MvvmLight.CommandWpf;

namespace CommandDemo
{
    public class MianViewModel:INotifyPropertyChanged
    {
        private int slideValue=0;

        public int SlideValue
        {
            get { return slideValue; }
            set
            {
                slideValue = value;
                OnPropertyChanged(nameof(SlideValue));
            }
        }

        public RelayCommand<int> ValueChanged { get; private set; }

        public MianViewModel()
        {
            ValueChanged=new RelayCommand<int>(OnValueChanged);
        }

        private void OnValueChanged(int value)
        {
            SlideValue = value;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
