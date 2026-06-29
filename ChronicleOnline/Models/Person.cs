using System;
using ChronicleOnline.Services;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace ChronicleOnline.Models
{
    public class Person:INotifyPropertyChanged
    {
        private StatusType _status;

        public Person()
        {
            LocalizationResouceManager.Instance.PropertyChanged += OnLocalizationPropertyChanged;
        }
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
                OnPropertyChanged(nameof(LocalizedStatus));
                OnPropertyChanged(nameof(HasException));
                OnPropertyChanged(nameof(IsNotClockedIn));
                OnPropertyChanged(nameof(IsClockedIn));
                OnPropertyChanged(nameof(PersonNotFound));
            }
        }

        public string LocalizedStatus =>
            LocalizationResouceManager.Instance[$"Status_{Status}"];
        public bool HasException => Status == StatusType.Exception;
        public bool IsNotClockedIn => Status == StatusType.NotClockedIn;
        public bool IsClockedIn => Status == StatusType.ClockedIn;
        public bool PersonNotFound => Status == StatusType.PersonNotFound;

        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnLocalizationPropertyChanged(object? sender, PropertyChangedEventArgs e) =>
        OnPropertyChanged(nameof(LocalizedStatus));
        private void OnPropertyChanged([CallerMemberName] string? name = null) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
