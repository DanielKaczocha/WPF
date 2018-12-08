using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Tic_Tac_Toe
{
    /// <summary>
    /// Logika interakcji dla klasy Menu.xaml
    /// </summary>
    public partial class Menu : MainWindow
    {
        public Menu()
        {
            InitializeComponent();
        }

        bool was_change = false;

        public static bool IsCross = true;

        
      


        public void player_1_cross_Checked(object sender, RoutedEventArgs e)
        { 
           if(was_change)
                this.player_1_cross.IsChecked = true;
        }
        public void player_2_cross_Checked(object sender, RoutedEventArgs e)
        {

            this.player_1_cross.IsChecked = false;

            IsCross = (bool)this.player_1_cross.IsChecked;

    was_change = true;
        }
        public void player_1_circle_Checked(object sender, RoutedEventArgs e)
        {
            this.player_1_cross.IsChecked = false;
            was_change = true;
        }
        public void player_2_circle_Checked(object sender, RoutedEventArgs e)
        {
          if(was_change)
          this.player_1_cross.IsChecked = true;
        }

        public void Button_Click(object sender, RoutedEventArgs e)
        {
            
           
            

        }

        
    }
}
