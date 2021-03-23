using System.Collections.Generic;

namespace Sample1.Models
{
    public class A
    {
        #region Public Properties

        public List<Vehicle> Vehicles { get; set; }

        #endregion Public Properties
    }

    public class Policy
    {
        #region Public Properties

        public A A { get; set; }
        public bool AllowElectronicPayments { get; set; }
        

        #endregion Public Properties
    }

    public class Vehicle
    {
        #region Public Properties

        public string DisplayName { get; set; }

        #endregion Public Properties
    }
}