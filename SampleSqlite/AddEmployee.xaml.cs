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
    public partial class AddEmployee : ContentPage
    {
        Employee e = new Employee();
        public AddEmployee()
        {
            InitializeComponent();
        }
        public void OnSaveClicked(object sender, EventArgs args)
        {
            #region Symmetric encryption

            //var pass = "MySecretKey";


            //var data = txtEmpName.Text;

            //var bytes = Crypto.EncryptAes(data, pass, App.Msalt);
            #endregion
            #region Asymmetric Encryption
            var data = txtEmpName.Text;
            var bytes = AsymCrypto.EncryptRsa(data);

#endregion

            var vEmployee = new Employee()
            {
                EmpName = Convert.ToBase64String(bytes),
                Department = txtDepartment.Text,
                Designation = txtDesign.Text,
                Qualification = txtQualification.Text
            };

            #region commented encrypt and decrypt
            //var data = vEmployee.EmpName;
            //var salt = Crypto.CreateSalt(16);
            //var bytes = Crypto.EncryptAes(data, pass, salt);
            #endregion
            App.DAUtil.SaveEmployee(vEmployee);
            Navigation.PushAsync(new ManageEmployee());
        }
    }
}
//#region Commented Code

////e.EmpName = txtEmpName.Text;
////e.Department = txtDepartment.Text;
////e.Designation = txtDesign.Text;
////e.Qualification = txtQualification.Text;

////var data = e.EmpName;
////var salt = Crypto.CreateSalt(16);
////var bytes = Crypto.EncryptAes(data, pass, salt);

////var vEmployee = new List<String>()
////{
////    bytes.ToString(),e.EmpName,e.Department,e.Designation,e.Qualification
////};
//#endregion