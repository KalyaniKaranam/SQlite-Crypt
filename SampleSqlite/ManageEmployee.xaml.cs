using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SampleSqlite
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ManageEmployee : ContentPage
    {
        public byte[] MyProperty { get; set; }
        public ManageEmployee()
        {
            InitializeComponent();

            var vList = App.DAUtil.GetAllEmployees();
            #region Symmetric Decyption
            //var pass = "MySecretKey";
            //foreach (var item in vList)
            //{
            //    var data = item.EmpName;
            //    if (App.Msalt != null)
            //    {
            //        byte[] encryptedData = Convert.FromBase64String(data);
            //        var strEmployee = Crypto.DecryptAes(encryptedData, pass, App.Msalt);
            //        item.EmpName = strEmployee;
            //    }


            //}
            #endregion
            #region Asymmetric Decryption
            //foreach (var item in vList)
            //{
            //    var data = item.EmpName;
               
            //        byte[] encryptedData = Convert.FromBase64String(data);
            //        var strEmployee = AsymCrypto.DecryptRsa(encryptedData);
            //        item.EmpName = strEmployee;
               
            //}
            #endregion
            lstData.ItemsSource = vList;

           
        }
        #region Commented Code
        //public ManageEmployee(byte[] salt)
        //{
        //    InitializeComponent();
        //    MyProperty = salt;
        //    var vList = App.DAUtil.GetAllEmployees();

        //    lstData.ItemsSource = vList;
        //}
#endregion
        void OnSelection(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
            {
                return;

            }

            var vSelUser = (Employee)e.SelectedItem;
            Navigation.PushAsync(new ShowEmployee(vSelUser));
        }
        public void OnNewClicked(object sender, EventArgs args)
        {
            Navigation.PushAsync(new AddEmployee());
        }
        public async void OnDeleteClicked(object sender, EventArgs args)
        {
            bool accepted = await DisplayAlert("Confirm", "Are you Sure ?", "Yes", "No");
            if (accepted)
            {
                App.DAUtil.DeleteAllEmployee();
                var vList = App.DAUtil.GetAllEmployees();
                lstData.ItemsSource = vList;
            }
        }
    }
}
