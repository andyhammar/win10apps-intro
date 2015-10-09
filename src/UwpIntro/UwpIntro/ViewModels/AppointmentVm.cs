using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using UwpIntro.Annotations;

namespace UwpIntro.ViewModels
{
    public class AppointmentVm : INotifyPropertyChanged
    {
        public AppointmentVm()
        {
            DateTime = DateTimeOffset.Now;
        }

        private string _title;
        private DateTimeOffset _date;

        public DateTimeOffset DateTime
        {
            get { return _date; }
            set { _date = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(DateString));
            }
        }

        public string DateString => _date.ToString("D");

        public string Title
        {
            get { return _title; }
            set { _title = value; OnPropertyChanged();}
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
