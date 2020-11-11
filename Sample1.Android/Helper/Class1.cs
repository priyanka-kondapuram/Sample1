using Android.App;
using Android.Text;
using Android.Text.Style;
using Sample1.Droid.Helper;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: Xamarin.Forms.Dependency(typeof(Effects))]

namespace Sample1.Droid.Helper
{
    public class Effects : IEffects
    {
        #region Private Fields

        private AlertDialog _dialog;

        #endregion Private Fields

        #region Public Methods

        //"L_Cancel".Translate()
        public void OpenPicker(Picker picker, string cancel)
        {
            if (picker.IsFocused)
            {
                picker.Unfocus();
            }
            using (var builder = new AlertDialog.Builder(MainActivity.Instance))
            {
                if (!picker.IsSet(Picker.TitleColorProperty))
                {
                    builder.SetTitle(picker.Title ?? "");
                }
                else
                {
                    var title = new SpannableString(picker.Title ?? "");
                    title.SetSpan(new ForegroundColorSpan(picker.TitleColor.ToAndroid()), 0, title.Length(), SpanTypes.ExclusiveExclusive);

                    builder.SetTitle(title);
                }

                var items = picker.Items.ToArray();
                builder.SetItems(items, (s, e) => ((IElementController)picker).SetValueFromRenderer(Picker.SelectedIndexProperty, e.Which));

                builder.SetNegativeButton(cancel, (o, args) => { });

                ((IElementController)picker).SetValueFromRenderer(VisualElement.IsFocusedPropertyKey, true);

                _dialog = builder.Create();
            }
            _dialog.SetCanceledOnTouchOutside(true);
            _dialog.DismissEvent += (sender, args) =>
            {
                (picker as IElementController)?.SetValueFromRenderer(VisualElement.IsFocusedPropertyKey, false);
            };
            _dialog.Show();
        }

        #endregion Public Methods
    }
}