using ChronicleOnline.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;

namespace ChronicleOnline.ViewModels
{
    public class LiveStatusViewModel:INotifyPropertyChanged
    {
        private readonly List<Person> _allPersons = new();
        private bool _isRefreshing;
        private DateTime _selectedDate = DateTime.Today;

        public event PropertyChangedEventHandler? PropertyChanged;

        public ObservableCollection<Person> Persons { get; } = new();

        public bool IsRefreshing
        {
            get => _isRefreshing;
            set { _isRefreshing = value; OnPropertyChanged(); }
        }

        public DateTime SelectedDate
        {
            get => _selectedDate;
            set
            {
                _selectedDate = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(DisplayDate));
                ApplyDateFilter();
            }
        }

        public string DisplayDate => SelectedDate.ToString("dd MMM yyyy");

        public ICommand RefreshCommand { get; }
        public ICommand PreviousDayCommand { get; }
        public ICommand NextDayCommand { get; }

        public ICommand TapPersonCommand { get; }

        public LiveStatusViewModel()
        {
            RefreshCommand = new Command(
                execute: async () => await LoadPersonsAsync(),
                canExecute: () => !IsRefreshing);
            PreviousDayCommand = new Command(() => SelectedDate = SelectedDate.AddDays(-1));
            NextDayCommand = new Command(() => SelectedDate = SelectedDate.AddDays(1));
            TapPersonCommand = new Command<Person>(OnPersonTapped);

            _ = LoadPersonsAsync();
        }

        //private void OnPersonTapped(Person person)
        //{
        //    if (person is null || person.Status == StatusType.Exception)
        //        return;

        //    person.Status = person.Status == StatusType.NotClockedIn
        //        ? StatusType.ClockedIn
        //        : StatusType.NotClockedIn;
        //}

        private async void OnPersonTapped(Person person)
        {
            if (person is null) 
                return;

            if (person.Status == StatusType.Exception)
            {
                person.Status = StatusType.PersonNotFound;
                await Task.Delay(1000);
                if (person.Status == StatusType.PersonNotFound)
                    person.Status = StatusType.Exception;
                return;
            }

            person.Status = person.Status == StatusType.NotClockedIn
                ? StatusType.ClockedIn
                : StatusType.NotClockedIn;
        }

        private async Task LoadPersonsAsync()
        {
            IsRefreshing = true;
            ((Command)RefreshCommand).ChangeCanExecute();

            await Task.Delay(800);
            _allPersons.Clear();
            _allPersons.AddRange(new[]
            {
                new Person { Name = "Alexander Allen",   Status = StatusType.Exception,    Initials = "AA", Date = DateTime.Today },
                new Person { Name = "Waleed Ali Anjum",  Status = StatusType.NotClockedIn, Initials = "WA", Date = DateTime.Today },
                new Person { Name = "Henry Baker",       Status = StatusType.Exception,    Initials = "HB", Date = DateTime.Today },
                new Person { Name = "Bill Bloggs",       Status = StatusType.ClockedIn,    Initials = "BB", Date = DateTime.Today },
                new Person { Name = "Joe Bloggs",        Status = StatusType.NotClockedIn, Initials = "JB", Date = DateTime.Today.AddDays(-1) },
                new Person { Name = "Daniel Carter",     Status = StatusType.ClockedIn,    Initials = "DC", Date = DateTime.Today.AddDays(-1) },
                new Person { Name = "Sarah Connor",      Status = StatusType.NotClockedIn, Initials = "SC", Date = DateTime.Today.AddDays(-1) },
                new Person { Name = "Tom Davis",         Status = StatusType.Exception,    Initials = "TD", Date = DateTime.Today.AddDays(1) },
                new Person { Name = "Emma Wilson",       Status = StatusType.ClockedIn,    Initials = "EW", Date = DateTime.Today.AddDays(1) },
            });

            ApplyDateFilter();

            IsRefreshing = false;
            ((Command)RefreshCommand).ChangeCanExecute();
        }
        private void ApplyDateFilter()
        {
            var filtered = _allPersons.Where(p => p.Date.Date == SelectedDate.Date).ToList();

            Persons.Clear();
            foreach (var p in filtered)
                Persons.Add(p);
        }

        protected void OnPropertyChanged([CallerMemberName] string name = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
