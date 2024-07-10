using System.ComponentModel;

namespace TestSamples {
    // Реализуйте интерфейс INotifyPropertyChanged,
    // чтобы к свойствам Employee можно было привязываться.
    // Реализация свойств должна быть максимально короткой.
    public class Employee : INotifyPropertyChanged
    {
        private string firstName = "";
        public string FirstName
        {
            get => firstName;
            set
            {
                firstName = value;
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(nameof(FirstName)));
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(nameof(FullName)));
            }
        }
        private string lastName = "";
        public string LastName
        {
            get => lastName;
            set
            {
                lastName = value;
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(nameof(LastName)));
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(nameof(FullName)));
            }
        }
        public string FullName => FirstName + LastName;
        private int age = 0;
        public int Age
        {
            get => age;
            set
            {
                age = value;
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(nameof(Age)));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}