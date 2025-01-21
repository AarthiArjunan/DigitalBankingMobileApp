using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalMobileBank.ViewModel
{

    public class CardsModel
    {
     
        public string CardName { get; set; }
        public string CardNumber { get; set; }
        public string CurrentBalance { get; set; }
    
        public CardsModel( string cardNumber, string currentBalance, string cardName)
        {
           
            CardNumber = cardNumber;
            CurrentBalance = currentBalance;
            CardName = cardName;
        }

    }

    public class Transaction
    {
        public string UserImage { get; set; }
        public string Title { get; set; }
        public string Date { get; set; }
        public string Amount { get; set; }
    }
    public class Contact
    {
        public string Name { get; set; }
        public string Details { get; set; }
        public string Initials { get; set; }
    }


    public class CardsViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Contact> ContactDetails { get; private set; }
        public ObservableCollection<Contact> FilteredContacts { get; set; }
        public ObservableCollection<Transaction> Transactions { get; set; }
        public ObservableCollection<CardsModel> CardsList { get; set; }

        private string cardNumber = "**** **** **** 7410";

        public string CardNumber
        {
            get => cardNumber;
            set
            {
                cardNumber = value;
                OnPropertyChanged(nameof(CardNumber));
            }
        }

        private string currentAmount = "6.815,53";

        public string CurrentAmount
        {
            get => currentAmount;
            set
            {
                currentAmount = value;
                OnPropertyChanged(nameof(CurrentAmount));
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public CardsViewModel()
        {
            CardsList = new ObservableCollection<CardsModel>();
            CardsList.Add(new CardsModel( "**** **** **** 7910", "20.000", "CREDIT CARD"));
            CardsList.Add(new CardsModel( "**** **** **** 7410", "6.815,53", "DEBIT CARD"));
            CardsList.Add(new CardsModel( "**** **** **** 7110", "5.000", "PRE PAID CARD"));

            ContactDetails = new ObservableCollection<Contact>
            {
                new Contact { Name = "Ananya Bhattacharya", Details = "Paytm • 849872310487509", Initials = "AB" },
                new Contact { Name = "Rohan Fernandes", Details = "Google Pay • 733071162766371", Initials = "RF" },
                new Contact { Name = "Esha Patel", Details = "PhonePe • 974959366460334", Initials = "EP" },
                new Contact { Name = "Bhavna Singh", Details = "3 accounts", Initials = "BS" },
                new Contact { Name = "Kartik Wadhwa", Details = "2 accounts", Initials = "KW" },
                new Contact { Name = "Sanjay Arora", Details = "Amazon Pay • 837291047562834", Initials = "SA" },
                new Contact { Name = "Aditi Sharma", Details = "ICICI Bank • 984736281047562", Initials = "AS" },
                new Contact { Name = "Annette Black", Details = "PayPal • 849872310487509", Initials = "AB" },
                new Contact { Name = "Robert Fox", Details = "Skrill • 733071162766371", Initials = "RF" },
                new Contact { Name = "Eleanor Pena", Details = "Revolut • 974959366460334", Initials = "EP" },
                new Contact { Name = "Brooklyn Simmons", Details = "3 accounts", Initials = "BS" },
                new Contact { Name = "Kristin Watson", Details = "2 accounts", Initials = "KW" },
            };

            FilteredContacts = new ObservableCollection<Contact>(ContactDetails);
        }

        public void FilterContacts(string searchText)
        {
            if (string.IsNullOrWhiteSpace(searchText))
            {
                FilteredContacts = new ObservableCollection<Contact>(ContactDetails);
            }
            else
            {
                var filteredList = ContactDetails.Where(c => c.Name.ToLower().StartsWith(searchText.ToLower())).ToList();
                FilteredContacts = new ObservableCollection<Contact>(filteredList);
            }

            OnPropertyChanged(nameof(FilteredContacts));
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
