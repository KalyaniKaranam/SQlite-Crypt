using PCLCrypto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static PCLCrypto.WinRTCrypto;

using Xamarin.Forms;

namespace SampleSqlite
{
    public partial class App : Application
    {
        private static byte[] msalt
            = new byte[] { 8, 30, 237, 197, 14, 91, 245, 75, 16, 214, 162, 238, 37, 240, 95, 175 };
    private static ICryptographicKey pkey;
        public static byte[] Msalt
        {
            get { return msalt; }
            set { msalt = value; }
        }
        public static ICryptographicKey Publickey
        {
            get { return pkey ; }
            set { pkey = value; }
        }


        static DataAccess dbUtils;
      

        public App()
        {
            InitializeComponent();

            NavigationPage mainPage = new NavigationPage(new ManageEmployee());

            //Msalt = Crypto.CreateSalt(16);
#region Asymmetric Encryption
            Publickey = AsymCrypto.CreateKey();
            Publickey = pkey;
#endregion
            Msalt = msalt;

            MainPage = mainPage;

        }
        public static DataAccess DAUtil
        {
            get
            {
                if (dbUtils == null)
                {
                    dbUtils = new DataAccess();
                }
                return dbUtils;
            }
        }

        
        protected override void OnStart()
        {

            //Msalt = Crypto.CreateSalt(16);
          
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
