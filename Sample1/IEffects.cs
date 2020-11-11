using Xamarin.Forms;

namespace Sample1
{
    public interface IEffects
    {
        #region Public Methods

        void OpenPicker(Picker picker, string cancel);

        #endregion Public Methods
    }
}