﻿using System;
using System.Windows.Input;
using PropertyChanged;
using Xamarin.Forms;

namespace PeopleJornal
{
    [ImplementPropertyChanged]
    public class DetailViewModel : ViewModelBase
    {
        IPersonService _personService;
        public ICommand SaveCommand { get; set; }

        public string PersonId { get; set; }
        public string ServiceName { get; set; }
        public string ServiceHandler { get; set; }

        public DetailViewModel()
        {
            Title = "Services";
            _personService = DependencyService.Get<IPersonService>();
            SaveCommand = new Command(() => ExecuteSaveCommand());
        }

        public void Init(string id)
        {
            PersonId = id;
        }

        void ExecuteSaveCommand()
        {
            _personService.SaveDetails(PersonId, ServiceName, ServiceHandler);
        }

    }
}
