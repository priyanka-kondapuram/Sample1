using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Sample1
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        #region Private Fields

        private readonly Dictionary<string, Item> _propertyDict = new Dictionary<string, Item>();

        #endregion Private Fields

        #region Public Properties

        public ICommand ActionAsync { get; set; }

        public bool IsExecuting { get => Get<bool>(); set => Set(value); }

        #endregion Public Properties

        #region Public Constructors

        public BaseViewModel()
        {
            ActionAsync = new Command<object>(async (obj) =>
            {
                IsExecuting = true;
                await PerformActionAsync(obj).ConfigureAwait(true);
                IsExecuting = false;
            }, canExecute: (obj) => !IsExecuting);
        }

        #endregion Public Constructors

        #region Public Events

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion Public Events

        #region Public Methods

        public virtual async Task PerformActionAsync(object obj)
        {
            await Task.Delay(1).ConfigureAwait(false);
            throw new Exception("Please implement 'GenericActionAsync'.");
        }

        #endregion Public Methods

        #region Protected Methods

        protected T Get<T>(T def = default, [CallerMemberName] string propertyName = null)
        {
            try
            {
                return _propertyDict.TryGetValue(propertyName, out var val) ? (T)val.Value : (T)(_propertyDict[propertyName] = new Item { Value = def, Default = def }).Value;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void Notify([CallerMemberName] string propertyName = "") => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        protected bool Set<T>(T value, [CallerMemberName] string propertyName = null)
        {
            try
            {
                if (_propertyDict.TryGetValue(propertyName, out var val))
                {
                    if (Equals(value, val.Value))
                    {
                        return false;
                    }
                    else
                    {
                        _propertyDict[propertyName].Value = value;
                        Notify(propertyName);
                        return true;
                    }
                }
                _propertyDict[propertyName] = new Item { Value = value, Default = default(T) };
                Notify(propertyName);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion Protected Methods

        #region Private Classes

        private class Item
        {
            #region Internal Properties

            internal object Default { get; set; }
            internal object Value { get; set; }

            #endregion Internal Properties
        }

        #endregion Private Classes
    }
}