using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace ElmishNewWindowTest.Gui.Views
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            this.Activated += StartElmish;
        }

        private void StartElmish (object sender, EventArgs e)
        {
            this.Activated -= StartElmish;
            ElmishNewWindowTest.Gui.mainModule.main(MainWindow, () => new Window1());
        }

    }
}
