using Xamarin.Forms;

namespace Sample1.Models
{
    public interface IEffects
    {
        #region Public Methods

        void OpenPicker(Picker picker, string cancel);

        #endregion Public Methods
    }
}