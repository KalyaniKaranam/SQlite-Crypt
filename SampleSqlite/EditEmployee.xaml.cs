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
    public partial class EditEmployee : ContentPage
    {
        Employee mSelEmployee;
      
        public EditEmployee(Employee aSelectedEmp)
        {
            //var pass = "MySecretKey";
            InitializeComponent();
            mSelEmployee = aSelectedEmp;
            #region Commented code
            //var data = txtEmpName.Text;
            //var salt = Crypto.CreateSalt(16);
            //var bytes = Crypto.EncryptAes(data, pass, salt);
            //var str = Crypto.DecryptAes(bytes, pass, salt);
            //mSelEmployee.EmpName = str;
#endregion
            BindingContext = mSelEmployee;
        }
      
        public void OnSaveClicked(object sender, EventArgs args)
        {
            var pass = "MySecretKey";
           
            var data = txtEmpName.Text;

            var bytes = Crypto.EncryptAes(data, pass, App.Msalt);
            mSelEmployee.EmpName =Convert.ToBase64String(bytes);
            mSelEmployee.Department = txtDepartment.Text;
            mSelEmployee.Designation = txtDesign.Text;
            mSelEmployee.Qualification = txtQualification.Text;
            App.DAUtil.EditEmployee(mSelEmployee);
            Navigation.PushAsync(new ManageEmployee());
        }
    }
}
