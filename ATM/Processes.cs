using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ATM.Models;

namespace ATM
{
    internal class Processes
    {
        static public List<Model> Accounts { get; }
        private bool _check_name = false;
        private bool _check_password = false;

        static Processes()
        {
            Accounts = new List<Model>() { new Model { Name = "Boss", Password = "1234" }, new Model() { Name = "Cavid", Password = "2563" } };
        }

        private bool CheckName(string Name)
        {
            /*
             * eger if-in body-sinde yazilacaq kod sadece bir setrden ibaretdirse o zaman scope-lari isletmeden kodu yaza bilerik.
             * 
             * if(true/false)
             * {
             *   Console.WriteLine("Hi");
             * }
             * 
             * 
             * if(true/false) Console.WriteLine("Hi");
             * 
             * 
             * if(true/false) 
             *     Console.WriteLine("Hi");
             *     
             *     
             * if(true/false)
             *    Console
             *           .WriteLine("Hi");
             *           
             * Yaddan cixartmamaq lazimdirki C# dilinde setrler sol terefdeki reqemlerle deyil, " ; " ile teyin olunur.    
             * 
             * eyni hallar else ucunde kecerlidi
             * 
             */

            foreach (var item in Name)
            {
                if (item != ' ')
                    _check_name = true;
                else
                {
                    _check_password = false;
                    Console.WriteLine("Please don't use space in the password.");
                    Console.WriteLine();
                }

                if (!char.IsNumber(item))
                    if (!char.IsSymbol(item))
                        if (!char.IsPunctuation(item))
                            if (!char.IsSeparator(item))
                                _check_name = true;
                            else
                            {
                                _check_name = false;
                                Console.WriteLine("Please don't use separator in name.");
                                Console.WriteLine();
                                break;
                            }
                        else
                        {
                            _check_name = false;
                            Console.WriteLine("Please don't use punctuation in name.");
                            Console.WriteLine();
                            break;
                        }
                    else
                    {
                        _check_name = false;
                        Console.WriteLine("Please don't use special symbol in name.");
                        Console.WriteLine();
                        break;
                    }
                else
                {
                    _check_name = false;
                    Console.WriteLine("Please don't use number in name.");
                    Console.WriteLine();
                    break;
                }

            }
            Console.WriteLine();
            if (!_check_name)
                Console.WriteLine("Please make sure the name is not null.");
            Console.WriteLine();

            return _check_name;
        }
        private bool CheckPassword(string Password)
        {
            foreach (var item in Password)
            {
                if (item != ' ')
                    _check_password = true;
                else
                {
                    _check_password = false;
                    Console.WriteLine("Please don't use space in the password.");
                    Console.WriteLine();
                }


                if (!char.IsLetter(item))
                    if (!char.IsSymbol(item))
                        if (!char.IsPunctuation(item))
                            if (!char.IsSeparator(item))
                                _check_password = true;
                            else
                            {
                                _check_password = false;
                                Console.WriteLine("Please don't use separator in password.");
                                Console.WriteLine();
                                break;
                            }
                        else
                        {
                            _check_password = false;
                            Console.WriteLine("Please don't use punctuation in password.");
                            Console.WriteLine();
                            break;
                        }
                    else
                    {
                        _check_password = false;
                        Console.WriteLine("Please don't use special symbol in password.");
                        Console.WriteLine();
                        break;
                    }
                else
                {
                    _check_password = false;
                    Console.WriteLine("Please don't use letter in password.");
                    Console.WriteLine();
                    break;
                }

            }
            Console.WriteLine();
            if (!_check_password)
                Console.WriteLine("Please make sure the name is not null.");
            Console.WriteLine();
            if (Password.Length != 4)
            {
                Console.WriteLine("The length of the password can only consist of 4 digits.");
                _check_password = false;
                Console.WriteLine();
            }

            return _check_password;
        }

        public bool CreateAccount(PostModel model)
        {
            try
            {
                if (CheckName(model.Name) && CheckPassword(model.Password))
                {
                    if (!Accounts.Contains(new Model() { Name = model.Name, Password = model.Password }))
                    {
                        //Accounts-elara elave etmek ucun  yeni bir model yaratdim "new Model".
                        //Model klassinin icindeki Operations-larin data tipi List<OperationModel> oldugundan yeni bir List<OperationModel> yaradaraq
                        //Operations-a teyin edirem "Operations = new List<OperationModel>() "
                        //ve yaratdigim List<OperationModel>-ni yaradarken icinde data olsun deye "List<OperationModel>() {new OperationModel() {...} } " seklinde yaratdim.
                        Accounts.Add(new Model { Name = model.Name, Password = model.Password, Operations = new List<OperationModel>() { new OperationModel() { Operation = 0, Date = DateTime.Now } } });
                        Console.WriteLine("Successful.");
                        Console.WriteLine();
                        return true;
                    }
                    else
                    {
                        Console.WriteLine("You cannot use this name because it is already registered in the system.");
                        Console.WriteLine();
                        return false;
                    }
                }
                _check_name = false;
                _check_password = false;
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public void Login(PostModel model, out Model account)
        {
            try
            {
                Model response = null;
                if (CheckName(model.Name) && CheckPassword(model.Password))
                {

                    foreach (var item in Accounts)
                    {
                        if (item.Name.ToLower() == model.Name.ToLower() && item.Password == model.Password)
                        {
                            response = item;
                        }
                    }
                    if (response != null)
                        account = response;
                    else
                    {
                        account = new Model();
                        Console.WriteLine("Username or Password is incorrect.");
                        Console.WriteLine();
                    }
                }
                else
                {
                    account = new Model();
                }

            }
            catch (Exception ex)
            {
                account = new Model();
                Console.WriteLine(ex.Message);
            }
        }
        public void GetAccounts()
        {
            try
            {
                Console.WriteLine("////////");
                foreach (var item in Accounts)
                {
                    Console.WriteLine("Name : " + item.Name);
                    Console.WriteLine("Balance : " + item.Balance);
                    Console.WriteLine();
                    Console.WriteLine("////////");
                    Console.WriteLine();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void GetOperations(PostModel model)
        {
            try
            {
                if (CheckName(model.Name) && CheckPassword(model.Password))
                {
                    int i =0;
                    foreach (var item in Accounts)
                    {
                        if (item.Name.ToLower() == model.Name.ToLower() && item.Password == model.Password)
                        {
                            Console.WriteLine("Name : " + item.Name);
                            Console.WriteLine("Balance : " + item.Balance);
                            Console.WriteLine("Operation : ");
                            foreach (var operation in item.Operations)
                            {
                                Console.WriteLine($"Operation : {operation.Operation} | Date : {operation.Date}");
                                Console.WriteLine();
                            }
                            Console.WriteLine("////////");
                            i = 1;
                        }
                    }
                    if(i==1)
                    {
                        Console.WriteLine("Username or Password is incorrect.");
                        Console.WriteLine();
                    }

                }
                _check_name = false;
                _check_password = false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void Deposit(string amount, Model model)
        {
            try
            {
                double _amount = 0;

                //TryParse metodu ile amount'un double tipine cevrile bimesin yoxlayiram ve out _amount ile cevrile bildiyi haldaki qiymetin aliram.
                if (double.TryParse(amount, out _amount) && _amount >= 0)
                {

                    model.Balance += _amount;
                    //model.Balance = model.Balance + amount [kohne deyerin ustune amount'un deyerin gelmisem]

                    model.Operations.Add(new() { Operation = _amount, Date = DateTime.Now });
                    Console.WriteLine("Balance : " + model.Balance);
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("You cannot use numbers less than 0 or other symbols (letters/spaces/...) in the entered amount.");
                    Console.WriteLine();
                }
                _check_name = false;
                _check_password = false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        public void Withdraw(string amount, Model model)
        {
            try
            {
                double _amount = 0;

                if (double.TryParse(amount, out _amount))
                {
                    if (model.Balance >= _amount)
                    {
                        model.Balance -= _amount;
                        model.Operations.Add(new (){ Operation = _amount, Date =DateTime.Now});
                        Console.WriteLine($"Balance : " + model.Balance);
                        Console.WriteLine();
                    }
                    else
                    {
                        Console.WriteLine("The amount cannot be higher than your balance.");
                        Console.WriteLine();
                    }
                }
                else
                {
                    Console.WriteLine("You cannot use numbers less than 0 or other symbols (letters/spaces/...) in the entered amount.");
                }
                _check_name = false;
                _check_password = false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
