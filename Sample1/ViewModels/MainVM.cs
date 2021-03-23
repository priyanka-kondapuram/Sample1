using Newtonsoft.Json;
using Sample1.Helper;
using Sample1.Models;
using Sample1.Views;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Sample1.ViewModels
{
    public class MainVM : BaseViewModel
    {
        #region Public Methods

        public override async Task PerformActionAsync(object obj)
        {
            await PerformLogin(obj).ConfigureAwait(true);
        }

        #endregion Public Methods

        #region Private Methods

        private async Task<Res> CallAPIService<Res>()
        {
            var result = default(Res);
            try
            {
                await Task.Delay(5000);
                var json = JsonConvert.SerializeObject(new Policy
                {
                    A = new A
                    {
                        Vehicles = new List<Vehicle>
                        {
                            new Vehicle { DisplayName = "Vehicle-1" },
                            new Vehicle { DisplayName = "Vehicle-2" },
                            new Vehicle { DisplayName = "Vehicle-3" }
                        }
                    },
                    AllowElectronicPayments = true
                });
                //var json = JsonConvert.SerializeObject(new Policy
                //{
                //    A = new A
                //    {
                //    }
                //});
                result = JsonConvert.DeserializeObject<Res>(json);
            }
            catch (Exception)
            {
                return result;
            }
            return result;
        }

        private void ChangeMainPage()
        {
            try
            {
                Application.Current.MainPage = new MasterPage().MakeNavigationPage();
            }
            catch (Exception ex)
            {
                return;
            }
        }

        private void LoginUser()
        {
            var policy = CallAPIService<Policy>().GetAwaiter().GetResult();
            if (policy != null)
            {
                AppValues.Instance.Update(policy);
                Tools.TryInvokeOnMainThreadAsync(ChangeMainPage);
            }
        }

        private async Task PerformLogin(object obj)
        {
            await Task.Run(LoginUser).ConfigureAwait(false);
        }

        #endregion Private Methods

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