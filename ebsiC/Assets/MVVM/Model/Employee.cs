using ebsiC.Assets.Classes;
using System;

namespace ebsiC.Assets.MVVM.Model
{
    public class Employee : ObservableObject
    {
        private string _employeeID;
        private string _firstName;
        private string? _middleName;
        private string _lastName;
        private int _jobTitleID;
        private int _departmentID;
        private string _dateHired;
        private string? _email;
        private long? _phoneNumber;
        private string? _sssNumber;
        private string? _philHealthNumber;
        private string? _pagIbigNumber;
        private string? _tinNumber;
        private string? _status;
        private byte[]? _profilePic;

        public string EmployeeID
        {
            get => _employeeID;
            set => SetProperty(ref _employeeID, value);
        }

        public string FirstName
        {
            get => _firstName;
            set => SetProperty(ref _firstName, value);
        }

        public string? MiddleName
        {
            get => _middleName;
            set => SetProperty(ref _middleName, value);
        }

        public string LastName
        {
            get => _lastName;
            set => SetProperty(ref _lastName, value);
        }

        public int JobTitleID
        {
            get => _jobTitleID;
            set => SetProperty(ref _jobTitleID, value);
        }

        public int DepartmentID
        {
            get => _departmentID;
            set => SetProperty(ref _departmentID, value);
        }

        public string DateHired
        {
            get => _dateHired;
            set => SetProperty(ref _dateHired, value);
        }

        public string? Email
        {
            get => _email;
            set => SetProperty(ref _email, value);
        }

        public long? PhoneNumber
        {
            get => _phoneNumber;
            set => SetProperty(ref _phoneNumber, value);
        }

        public string? SSSNumber
        {
            get => _sssNumber;
            set => SetProperty(ref _sssNumber, value);
        }

        public string? PhilHealthNumber
        {
            get => _philHealthNumber;
            set => SetProperty(ref _philHealthNumber, value);
        }

        public string? PagIbigNumber
        {
            get => _pagIbigNumber;
            set => SetProperty(ref _pagIbigNumber, value);
        }

        public string? TinNumber
        {
            get => _tinNumber;
            set => SetProperty(ref _tinNumber, value);
        }

        public string? Status
        {
            get => _status;
            set => SetProperty(ref _status, value);
        }
        public byte[]? ProfilePic
        {
            get => _profilePic;
            set
            {
                _profilePic = value;
                OnPropertyChanged();
            }
        }

    }
}
