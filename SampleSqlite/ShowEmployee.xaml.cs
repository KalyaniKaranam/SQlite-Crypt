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
    public partial class ShowEmployee : ContentPage
    {
        Employee mSelEmployee;
        AddEmployee a = new AddEmployee();
        

        public ShowEmployee(Employee aSelectedEmp)
        {
            //var pass = "MySecretKey";
            InitializeComponent();            
            mSelEmployee = aSelectedEmp;
            var data = mSelEmployee.EmpName;



            //if(App.Msalt != null)
            //{
            byte[] encryptedData = Convert.FromBase64String(data);
            var strEmployee =AsymCrypto.DecryptRsa(encryptedData);
            mSelEmployee.EmpName = strEmployee;
            //}

            BindingContext = mSelEmployee;
        }
       
        public void OnEditClicked(object sender, EventArgs args)
        {
            Navigation.PushAsync(new EditEmployee(mSelEmployee));
        }
        public async  void OnDeleteClicked(object sender, EventArgs args)
        {
            bool accepted = await DisplayAlert("Confirm", "Are you Sure ?", "Yes", "No");
            if (accepted)
            {
                App.DAUtil.DeleteEmployee(mSelEmployee);
            }
            await Navigation.PushAsync(new ManageEmployee());
           
        }

       

    }
}
