using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using GJJP8B_HFT_2021221.Models;

namespace GJJP8B_HFT_2021221.WFPClient
{
    public class MainWindowViewModel : ObservableRecipient
    {
        private string errorMessage;

        public string ErrorMessage
        {
            get { return errorMessage; }
            set { SetProperty(ref errorMessage, value); }
        }


        public RestCollection<Cheese> Cheeses { get; set; }
        public RestCollection<Milk> Milks { get; set; }
        public RestCollection<Buyer> Buyers { get; set; }

        private Cheese selectedCheese;
        private Milk selectedMilk;
        private Buyer selectedBuyer;

        public Cheese SelectedCheese
        {
            get { return selectedCheese; }
            set
            {
                if (value != null)
                {
                    selectedCheese = new Cheese()
                    {
                        Name = value.Name,
                        Id = value.Id,
                        Price = value.Price,
                        MilkId = value.MilkId
                    };
                    OnPropertyChanged();
                    (DeleteCheeseCommand as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }

        public Milk SelectedMilk
        {
            get { return selectedMilk; }
            set
            {
                if (value != null)
                {
                    selectedMilk = new Milk()
                    {
                        Name = value.Name,
                        Id = value.Id,
                        Price = value.Price
                    };
                    OnPropertyChanged();
                    (DeleteMilkCommand as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }
        
        public Buyer SelectedBuyer
        {
            get { return selectedBuyer; }
            set
            {
                if (value != null)
                {
                    selectedBuyer = new Buyer()
                    {
                        Name = value.Name,
                        Id = value.Id,
                        Money = value.Money,
                        CheeseId = value.CheeseId
                    };
                    OnPropertyChanged();
                    (DeleteBuyerCommand as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }


        public ICommand CreateCheeseCommand { get; set; }
        public ICommand CreateMilkCommand { get; set; }
        public ICommand CreateBuyerCommand { get; set; }

        public ICommand DeleteCheeseCommand { get; set; }
        public ICommand DeleteMilkCommand { get; set; }
        public ICommand DeleteBuyerCommand { get; set; }

        public ICommand UpdateCheeseCommand { get; set; }
        public ICommand UpdateMilkCommand { get; set; }
        public ICommand UpdateBuyerCommand { get; set; }

        #region cheese noncruds
        public ICommand CheesesUnderPriceCommand { get; set; }
        #endregion

        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }


        public MainWindowViewModel()
        {
            if (!IsInDesignMode)
            {
                #region Cheese
                Cheeses = new RestCollection<Cheese>("http://localhost:37371/", "cheese", "hub");
                #region cruds
                CreateCheeseCommand = new RelayCommand(() =>
                {
                    Cheeses.Add(new Cheese()
                    {
                        Name = SelectedCheese.Name,
                        Price = SelectedCheese.Price,
                        MilkId = SelectedCheese.MilkId

                    });
                });

                UpdateCheeseCommand = new RelayCommand(() =>
                {
                    try
                    {
                        Cheeses.Update(SelectedCheese);
                    }
                    catch (ArgumentException ex)
                    {
                        ErrorMessage = ex.Message;
                    }

                });

                DeleteCheeseCommand = new RelayCommand(() =>
                {
                    Cheeses.Delete(SelectedCheese.Id);
                },
                () =>
                {
                    return SelectedCheese != null;
                });
                SelectedCheese = new Cheese();
                #endregion
                #region noncruds
                CheesesUnderPriceCommand = new RelayCommand(() =>
                {
                    
                });
                #endregion
                #endregion
                #region Milk
                Milks = new RestCollection<Milk>("http://localhost:37371/", "milk", "hub");
                CreateMilkCommand = new RelayCommand(() =>
                {
                    Milks.Add(new Milk()
                    {
                        Name = SelectedMilk.Name,
                        Price = SelectedMilk.Price,

                    });
                });

                UpdateMilkCommand = new RelayCommand(() =>
                {
                    try
                    {
                        Milks.Update(SelectedMilk);
                    }
                    catch (ArgumentException ex)
                    {
                        ErrorMessage = ex.Message;
                    }

                });

                DeleteMilkCommand = new RelayCommand(() =>
                {
                    Milks.Delete(SelectedMilk.Id);
                },
                () =>
                {
                    return SelectedMilk != null;
                });
                SelectedMilk = new Milk();
                #endregion
                #region Buyer
                Buyers = new RestCollection<Buyer>("http://localhost:37371/", "buyer", "hub");
                CreateBuyerCommand = new RelayCommand(() =>
                {
                    Buyers.Add(new Buyer()
                    {
                        Name = SelectedBuyer.Name,
                        Money = SelectedBuyer.Money,
                        CheeseId = SelectedBuyer.CheeseId

                    });
                });

                UpdateBuyerCommand = new RelayCommand(() =>
                {
                    try
                    {
                        Buyers.Update(SelectedBuyer);
                    }
                    catch (ArgumentException ex)
                    {
                        ErrorMessage = ex.Message;
                    }

                });

                DeleteBuyerCommand = new RelayCommand(() =>
                {
                    Buyers.Delete(SelectedBuyer.Id);
                },
                () =>
                {
                    return SelectedBuyer != null;
                });
                SelectedBuyer = new Buyer();

                #endregion
            }
        }
    }
}
