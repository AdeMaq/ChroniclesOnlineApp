using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace ChronicleOnline.Models
{
    public class Person:INotifyPropertyChanged
    {
        private StatusType _status;
        public string? Name { get; set; }
        public string? Initials { get; set; }
        public DateTime Date { get; set; }
        public StatusType Status
        {
            get => _status;
            set
            {
                _status = value;
                OnPropertyChanged();
                
            }
        }
        public bool HasException => Status == StatusType.Exception;
        public bool IsNotClockedIn => Status == StatusType.NotClockedIn;
        public bool IsClockedIn => Status == StatusType.ClockedIn;
        public bool PersonNotFound => Status == StatusType.PersonNotFound;

        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string? name = null) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
