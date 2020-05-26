using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using KoffieMachineDomain;
using KoffieMachineDomain.Decorators;
using KoffieMachineDomain.Factories;
using KoffieMachineDomain.JSON;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Windows.Input;
using TeaAndChocoLibrary;

namespace Dpint_wk456_KoffieMachine.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private DrinkFactory drinkFactory;
        private PaymentFactory paymentFactory;
        private CardPayment card;
        private TeaBlendRepository teaBlendRepository;
        private Deserializer deserializer;

        public List<string> Blends { get; set; }
        public List<string> KoffieSpecials { get; set; }

        public ObservableCollection<string> LogText { get; private set; }

        public MainViewModel()
        {
            _coffeeStrength = Strength.Normal;
            _sugarAmount = Amount.Normal;
            _milkAmount = Amount.Normal;

            LogText = new ObservableCollection<string>();
            LogText.Add("Starting up...");
            LogText.Add("Done, what would you like to drink?");

            drinkFactory = new DrinkFactory();
            paymentFactory = new PaymentFactory();
            teaBlendRepository = new TeaBlendRepository();
            deserializer = new Deserializer();
            

            Blends = new List<string>(teaBlendRepository.BlendNames);
            KoffieSpecials = new List<string>();

            foreach (var item in deserializer.GetSpecialCoffees())
            {
                KoffieSpecials.Add(item.Naam);
            }

            card = (CardPayment)paymentFactory.CreatePayment("Card", 0, null);

            PaymentCardUsernames = new ObservableCollection<string>(card.CashOncards.Keys);
            SelectedPaymentCardUsername = PaymentCardUsernames[0];
        }

        #region Drink properties to bind to
        private IDrink _selectedDrink;
        public string SelectedDrinkName
        {
            get { return _selectedDrink?.Name; }
        }

        public double? SelectedDrinkPrice
        {
            get { return _selectedDrink?.GetPrice(); }
        }
        #endregion Drink properties to bind to

        #region Payment
        public RelayCommand PayByCardCommand => new RelayCommand(() =>
        {
            PayDrink(payWithCard: true);
        });

        public ICommand PayByCoinCommand => new RelayCommand<double>(coinValue =>
        {
            PayDrink(payWithCard: false, insertedMoney: coinValue);
        });

        private void PayDrink(bool payWithCard, double insertedMoney = 0)
        {

            if (_selectedDrink != null && payWithCard)
            {
                card.Username = SelectedPaymentCardUsername;
                insertedMoney = card.CashOncards[SelectedPaymentCardUsername];
                RemainingPriceToPay = card.PayDrink(RemainingPriceToPay);
                RaisePropertyChanged(() => PaymentCardRemainingAmount);
            }
            else if (_selectedDrink != null && !payWithCard)
            {
                RemainingPriceToPay = paymentFactory.CreatePayment("Coin", insertedMoney, null).PayDrink(RemainingPriceToPay);
                
            }
            LogText.Add($"Inserted {insertedMoney.ToString("C", CultureInfo.CurrentCulture)}, Remaining: {RemainingPriceToPay.ToString("C", CultureInfo.CurrentCulture)}.");

            if (_selectedDrink != null && RemainingPriceToPay == 0)
            {
                _selectedDrink.LogDrinkMaking(LogText);
                LogText.Add("------------------");
                _selectedDrink = null;
            }
        }

        public double PaymentCardRemainingAmount => card.CashOncards.ContainsKey(SelectedPaymentCardUsername ?? "") ? card.CashOncards[SelectedPaymentCardUsername] : 0;

        public ObservableCollection<string> PaymentCardUsernames { get; set; }
        private string _selectedPaymentCardUsername;
        public string SelectedPaymentCardUsername
        {
            get { return _selectedPaymentCardUsername; }
            set
            {
                _selectedPaymentCardUsername = value;
                RaisePropertyChanged(() => SelectedPaymentCardUsername);
                RaisePropertyChanged(() => PaymentCardRemainingAmount);
            }
        }

        private double _remainingPriceToPay;
        public double RemainingPriceToPay
        {
            get { return _remainingPriceToPay; }
            set { _remainingPriceToPay = value; RaisePropertyChanged(() => RemainingPriceToPay); }
        }
        #endregion Payment

        #region Coffee buttons
        private Strength _coffeeStrength;
        public Strength CoffeeStrength
        {
            get { return _coffeeStrength; }
            set { _coffeeStrength = value; RaisePropertyChanged(() => CoffeeStrength); }
        }

        private Amount _sugarAmount;
        public Amount SugarAmount
        {
            get { return _sugarAmount; }
            set { _sugarAmount = value; RaisePropertyChanged(() => SugarAmount); }
        }

        private Amount _milkAmount;
        public Amount MilkAmount
        {
            get { return _milkAmount; }
            set { _milkAmount = value; RaisePropertyChanged(() => MilkAmount); }
        }

        private string _blend;
        public string Blend
        {
            get { return _blend; }
            set { _blend = value; RaisePropertyChanged(() => Blend); }
        }

        private string _special;
        public string Special
        {
            get { return _special; }
            set { _special = value; RaisePropertyChanged(() => Special); }
        }

        public ICommand DrinkCommand => new RelayCommand<string>((drinkName) =>
        {
            _selectedDrink = null;

            _selectedDrink = drinkFactory.CreateDrink(drinkName, CoffeeStrength, SugarAmount, MilkAmount, false, false, Blend, Special);
         
            
            if(_selectedDrink != null)
            {
                RemainingPriceToPay = _selectedDrink.GetPrice();
                LogText.Add($"Selected {_selectedDrink.Name}, price: {RemainingPriceToPay.ToString("C", CultureInfo.CurrentCulture)}");
            }
        });

        public ICommand DrinkWithSugarCommand => new RelayCommand<string>((drinkName) =>
        {
            _selectedDrink = null;
            RemainingPriceToPay = 0;

            _selectedDrink = drinkFactory.CreateDrink(drinkName, CoffeeStrength, SugarAmount, MilkAmount, true, false, Blend, Special);

            if (_selectedDrink != null)
            {
                RemainingPriceToPay = _selectedDrink.GetPrice();
                LogText.Add($"Selected {_selectedDrink.Name} with sugar, price: {RemainingPriceToPay.ToString("C", CultureInfo.CurrentCulture)}");
            }
        });

        public ICommand DrinkWithMilkCommand => new RelayCommand<string>((drinkName) =>
        {
            _selectedDrink = null;

            _selectedDrink = drinkFactory.CreateDrink(drinkName, CoffeeStrength, SugarAmount, MilkAmount, false, true, Blend, Special);

            if (_selectedDrink != null)
            {
                RemainingPriceToPay = _selectedDrink.GetPrice();
                LogText.Add($"Selected {_selectedDrink.Name} with milk, price: {RemainingPriceToPay}");
            }
        });

        public ICommand DrinkWithSugarAndMilkCommand => new RelayCommand<string>((drinkName) =>
        {
            _selectedDrink = null;
            RemainingPriceToPay = 0;

            _selectedDrink = drinkFactory.CreateDrink(drinkName, CoffeeStrength, SugarAmount, MilkAmount, true, true, Blend, Special);

            if (_selectedDrink != null)
            {
                RemainingPriceToPay = _selectedDrink.GetPrice();
                LogText.Add($"Selected {_selectedDrink.Name} with sugar and milk, price: {RemainingPriceToPay}");
            }
        });

        #endregion Coffee buttons
    }
}