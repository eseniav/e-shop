using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace eshop.Models
{
    internal abstract class User
    {
        internal int id = 0;
        private string lastname = "";
        public string LastName
        {
            get => lastname;
            set
            {
                lastname = IsValidCyrillic(value) ? lastname : "";
            }
        }
        private string firstname = "";
        public string FirstName
        {
            get => firstname;
            set
            {
                firstname = IsValidCyrillic(value) ? firstname : "";
            }
        }
        private string patronymic = "";
        public string Patronymic
        {
            get => patronymic;
            set
            {
                patronymic = IsValidCyrillic(value) ? patronymic : "";
            }
        }
        private string email = "";
        public string Email
        {
            get => email;
            set
            {
                email = CheckEmail(value) ? email : "";
            }
        }
        private DateTime birthDate;
        public DateTime BirthDate
        {
            get => birthDate;
            set
            {
                if (CheckAge(value))
                    birthDate = value;
            }
        }
        /// <summary>
        /// Дата рождения в формате дд.мм.гггг
        /// </summary>
        public string BirthDateToString => birthDate.ToString("dd.MM.yyyy");
        private string login = "testLogin";
        public string Login
        {
            get => login;
            set
            {
                login = CheckLogin(value) ? login : "testLogin";
            }
        }
        private string password = "";
        public string Password
        {
            get => password;
            set
            {
                if (CheckLogin(value))
                    password = value;
            }
        }
        public string FullName => FormatName(FullName);
        public string AbbreviatedName => FormatName(AbbreviatedName);
        public int Age => CalculateAge(birthDate);
        private int CalculateAge(DateTime date)
        {
            int age = DateTime.Today.Year - date.Year;
            if (date.Date > DateTime.Today.AddYears(-age))
                age--;
            return age;
        }
        /// <summary>
        /// Форматирует ФИО в виде Фамилия Имя Отчество или Фамилия И.О.
        /// </summary>
        /// <param name="name"></param>
        /// <returns>если аргумент FullName, то Фамилия Имя Отчество, в остальных случаях - Фамилия И.О.</returns>
        public string FormatName(string name) => name == FullName ? $"{lastname} {firstname} {patronymic}"
            : $"{lastname} {firstname.Substring(0, 1)}. {patronymic.Substring(0, 1)}.";
        bool IsValidCyrillic(string input) => Regex.IsMatch(input, @"^[ЁёА-я\-]{2,}$");
        bool CheckLogin(string input) => Regex.IsMatch(input, @"^(?=[^А-яЁё]*$)[A-Za-z0-9 _-]{3,}$");
        bool CheckPassword(string input) => Regex.IsMatch(input, @"^(?=[^А-яЁё]*$)(?=.*[A-Z])(?=.*[0-9])[A-Za-z0-9 _-]{6,}$");
        bool CheckEmail(string input) => Regex.IsMatch(input, @"^(?=[^А-яЁё]*$)([^.]*\.[^.]*)([^@]*@[^@]*)$");
        bool CheckAge(DateTime date) => CalculateAge(date) > 5 && date < DateTime.Today;
    }
    internal class Customer : User
    {

    }
    internal class Administrator : User
    {

    }
}
