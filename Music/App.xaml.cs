using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Music
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            ResourceDictionary darkTheme = new ResourceDictionary { Source = new Uri("Resourses/DarkTheme.xaml", UriKind.Relative) };
            ResourceDictionary lightTheme = new ResourceDictionary { Source = new Uri("Resourses/LightTheme.xaml", UriKind.Relative) };

            Application.Current.Resources.MergedDictionaries.Add(darkTheme);
            Application.Current.Resources.MergedDictionaries.Add(lightTheme);

     
        }
    }
}
