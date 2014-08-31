using FlyoutsSample.Common;
using Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FlyoutsSample
{
    public abstract class NotifyPropertyChangedBase : INotifyPropertyChanged
    {
        protected void UpdateAndNotify<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            if (!EqualityComparer<T>.Default.Equals(value, field))
            {
                field = value;
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged = delegate { };
    }

    public class CartItem : NotifyPropertyChangedBase
    {
        private Movie movie;
        public Movie Movie
        {
            get { return movie; }
            set { UpdateAndNotify(ref movie, value); }
        }

        private uint quantity;
        public uint Quantity
        {
            get { return quantity; }
            set { UpdateAndNotify(ref quantity, value); }
        }

        private bool isAGift;
        public bool IsAGift
        {
            get { return isAGift; }
            set { UpdateAndNotify(ref isAGift, value); }
        } 
    }

    public class MainViewModel : NotifyPropertyChangedBase
    {
        public ObservableCollection<Movie> AvailableMovies { get; set; }

        public ObservableCollection<CartItem> CartItems { get; set; }

        public ICommand AddToCartCommand { get; set; }

        public ICommand RemoveOneFromCartCommand { get; set; }
        public ICommand RemoveFromCartCommand { get; set; }

        public MainViewModel()
        {
            AvailableMovies = new ObservableCollection<Movie>(MoviesRepository.Movies);

            CartItems = new ObservableCollection<CartItem>();

            AddToCartCommand = new RelayCommand(AddToCart);

            RemoveOneFromCartCommand = new RelayCommand(RemoveOneFromCart);
            RemoveFromCartCommand = new RelayCommand(RemoveFromCart);
        }

        private void AddToCart(object parameter)
        {
            Movie movie = (Movie)parameter;

            CartItem cartItem = CartItems.SingleOrDefault(item => item.Movie == movie);

            if (cartItem == null)
            {
                cartItem = new CartItem { Movie = movie, Quantity = 0 };

                CartItems.Add(cartItem);
            }

            ++cartItem.Quantity;
        }

        private void RemoveFromCart(object parameter)
        {
            CartItem cartItem = (CartItem)parameter;

            CartItems.Remove(cartItem);
        }

        private void RemoveOneFromCart(object parameter)
        {
            CartItem cartItem = (CartItem)parameter;

            cartItem.Quantity = Math.Max(cartItem.Quantity - 1, 1);
        }
    }
}
