using System.ComponentModel;

namespace Sample1
{
    public class AppValues : INotifyPropertyChanged
    {
        #region Public Properties

        public static AppValues Instance { get; } = new AppValues();
        public Policy Policy { get; set; }

        #endregion Public Properties

        #region Public Events

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion Public Events

        #region Public Methods

        public void Notify() => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(null));

        public void Update(Policy policy)
        {
            Policy = policy;
            Notify();
        }

        #endregion Public Methods
    }
}