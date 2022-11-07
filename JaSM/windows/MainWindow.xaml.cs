using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace JaSM.windows
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        // window controls...

        private void main_WD_MouseDown(object sender, MouseButtonEventArgs e)
        {
            // window drag and drop function...
            if (e.LeftButton == MouseButtonState.Pressed) { DragMove(); }
        }

        private void exit_GD_MouseDown(object sender, MouseButtonEventArgs e)
        {
            // window and application close function...
            Application.Current.Shutdown();
        }

        private void minimize_GD_MouseDown(object sender, MouseButtonEventArgs e)
        {
            // window minimize function...
            WindowState = WindowState.Minimized;
        }

        // #######################################################################
        // menu controls...
        // #######################################################################

        private void system_BT_GD_MouseDown(object sender, MouseButtonEventArgs e)
        {
            // call controller function...
            PageControler(system_PG_GD, system_BT_GD, "system_focus");
        }

        private void cpu_BT_GD_MouseDown(object sender, MouseButtonEventArgs e)
        {
            // call controller function...
            PageControler(cpu_PG_GD, cpu_BT_GD, "cpu_focus");
        }

        private void gpu_BT_GD_MouseDown(object sender, MouseButtonEventArgs e)
        {
            // call controller function...
            PageControler(gpu_PG_GD, gpu_BT_GD, "gpu_focus");
        }

        private void storage_BT_GD_MouseDown(object sender, MouseButtonEventArgs e)
        {
            // call controller function...
            PageControler(storage_PG_GD, storage_BT_GD, "storage_focus");
        }

        private void info_BT_GD_MouseDown(object sender, MouseButtonEventArgs e)
        {
            // call controller function...
            PageControler(info_PG_GD, info_BT_GD, "info_focus");
        }

        private void repo_BT_GD_MouseDown(object sender, MouseButtonEventArgs e)
        {
            // open browser with address set to the repo of the application on the github function...
            throw new NotImplementedException();
        }

        private void PageControler(Grid pageName, Grid buttonName, string imageName)
        {
            // page controller function that makes a specified page visible and others invisible...

            // lists of manipulated elements...
            List<Grid> pageGrids = new() { system_PG_GD, cpu_PG_GD, gpu_PG_GD, storage_PG_GD, info_PG_GD };
            List<Grid> menuGrids = new() { system_BT_GD, cpu_BT_GD, gpu_BT_GD, storage_BT_GD, info_BT_GD };

            // check if null...
            if (pageName != null && buttonName != null && imageName != null)
            {
                // hide all pages...
                foreach (Grid iteratingPageGrid in pageGrids) { iteratingPageGrid.Visibility = Visibility.Hidden; }
                // set unfocused images on all buttons...
                foreach (Grid iteratingMenuGrid in menuGrids) { iteratingMenuGrid.Background = new ImageBrush(BitmapFrame.Create(Application.GetResourceStream(new Uri("resources/" + iteratingMenuGrid.Name.ToString().Trim().Replace("_BT_GD", "") + "_unfocus.png", UriKind.Relative)).Stream)); }

                // show target page...
                pageName.Visibility = Visibility.Visible;
                // set focus image
                buttonName.Background = new ImageBrush(BitmapFrame.Create(Application.GetResourceStream(new Uri("resources/" + imageName + ".png", UriKind.Relative)).Stream));
            }
            else
            {
                // warn user of malfunctioning behavior...
                throw new NotImplementedException();
            }
        }

        // #######################################################################
        // link redirects...
        // #######################################################################

        private void info_language_BT_TB_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            // link to the official C# repository, idk why, fuck it, I like it in the UI...
            OpenLinks("https://github.com/dotnet/csharplang");
        }

        private void info_frame_BT_TB_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            // link to the official .NET repository, still think it looks good in UI...
            OpenLinks("https://github.com/dotnet");
        }

        private void info_built_BT_TB_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            // link to the official VS 2022 page...
            OpenLinks("https://visualstudio.microsoft.com");
        }

        private void info_repo_BT_TB_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            // ...
            OpenLinks("");
        }

        private void info_visual_BT_TB_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            // ...
            OpenLinks("");
        }

        private void info_reading_BT_TB_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            // ...
            OpenLinks("");
        }

        private void info_menuIcons_BT_TB_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            // ...
            OpenLinks("");
        }

        private void info_toolbarIcons_BT_TB_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            // ...
            OpenLinks("");
        }

        private void repo_BT_GD_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            // ...
            OpenLinks("");
        }

        private void OpenLinks(string link)
        {
            // for some fucking reason, this new .NET has the UseShellExecute set to False therefore I need this shit...
            var processStart = new ProcessStartInfo(link) { UseShellExecute = true, Verb = "open" };
            Process.Start(processStart);
        }
    }
}