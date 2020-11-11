using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;

namespace Sample1.MarkupExtensions
{
    public class Translator : INotifyPropertyChanged
    {
        #region Private Fields

        private static readonly Assembly _assembly = IntrospectionExtensions.GetTypeInfo(typeof(Translator)).Assembly;
        private static Dictionary<string, string> StaticLangDictionary = new Dictionary<string, string>();

        #endregion Private Fields

        #region Public Properties

        public static Translator Instance { get; } = new Translator();

        #endregion Public Properties

        #region Public Events

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion Public Events

        #region Public Indexers

        public string this[string key] => GetValue(key);

        #endregion Public Indexers

        #region Public Methods

        public string GetValue(string key) => (StaticLangDictionary.TryGetValue(key, out var p) && !string.IsNullOrEmpty(p)) ? p : key;

        public void Update(string lang = null)
        {
            StaticLangDictionary = LoadDict(lang);
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(null));
        }

        #endregion Public Methods

        #region Private Methods

        private Dictionary<string, string> LoadDict(string lang)
        {
            return new Dictionary<string, string> 
            {
                ["Select_a_vehicle"] = "Select a vehicle"
            };
        }

        #endregion Private Methods
    }
}