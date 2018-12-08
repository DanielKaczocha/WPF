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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Tic_Tac_Toe
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            Sign_Choice();
            InitializeComponent();
            Begin_First_Brushes();
            
        }


        char cross = 'X';
        char circle = 'O';

        bool tour = true;


        List<int> player_1 = new List<int>();
        List<int> player_2 = new List<int>();

        bool game_over;

        char sign_player_1;
        char sign_player_2;

        byte first_brushes;

        public bool sign_is_cross = true;

        private void Sign_Choice()
        {
            Menu window_menu = new Menu();

            

            if (Menu.IsCross == true)
            {
                sign_player_1 = cross;
                sign_player_2 = circle;
                tour = true;
                first_brushes = 2;
            }
            else
            {
                sign_player_1 = circle;
                sign_player_2 = cross;
                tour = false;
                first_brushes = 1;
            }

        }
        private void Begin_First_Brushes()
        {
            if (first_brushes == 1)
            {
                Napis.Background = Brushes.Green;
                Napis.Content = "Tura: " + sign_player_1;
            }
            else if (first_brushes == 2)
            {
                Napis.Background = Brushes.Red;
                Napis.Content = "Tura: " + sign_player_1;
            }
            first_brushes = 0;
        }

        private void Click(object sender, RoutedEventArgs e)
        {
            
            Button button = (Button)sender;

                if (tour)
                {
                    Napis.Background = Brushes.Green;

                    
                    button.Content = sign_player_1;
                    button.IsEnabled = false;
                    tour = false;

                    
                    Napis.Content = "Tura: " + sign_player_2;

                }
                else
                {
                    Napis.Background = Brushes.Red;

                    
                    button.Content = sign_player_2;
                    button.IsEnabled = false;
                    tour = true;

 
                    Napis.Content = "Tura: " + sign_player_1;

                }

                var kolumna = Grid.GetColumn(button);
                var wiersz = Grid.GetRow(button);

                Game_Control(button, tour);



            }

            void Game_Control(Button button, bool tour)
            {
                var column = Grid.GetColumn(button);
                var row = Grid.GetRow(button);

                var close_button = (row + 1) * 10 + (column + 1);



                if (tour)
                {
                    player_1.Add(close_button);
                    Control_Game_Over(ref player_1);
                }
                else
                {
                    player_2.Add(close_button);
                    Control_Game_Over(ref player_2);
                }

                if(game_over)
                {
                this.A1.IsEnabled = this.A2.IsEnabled = this.A3.IsEnabled = this.B1.IsEnabled = this.B2.IsEnabled = this.B3.IsEnabled = this.C1.IsEnabled = this.C2.IsEnabled = this.C3.IsEnabled = false;

                }


            }

            void Control_Game_Over(ref List<int> button_click)
            {
                if (button_click.Contains(11) && button_click.Contains(21) && button_click.Contains(31))
                {
                    column_11.Visibility = Visibility.Visible;
                    column_21.Visibility = Visibility.Visible;
                    column_31.Visibility = Visibility.Visible;

                    game_over = true;
                }
                else if (button_click.Contains(12) && button_click.Contains(22) && button_click.Contains(32))
                {
                    column_12.Visibility = Visibility.Visible;
                    column_22.Visibility = Visibility.Visible;
                    column_32.Visibility = Visibility.Visible;

                    game_over = true;
                }
                else if (button_click.Contains(13) && button_click.Contains(23) && button_click.Contains(33))
                {
                    column_13.Visibility = Visibility.Visible;
                    column_23.Visibility = Visibility.Visible;
                    column_33.Visibility = Visibility.Visible;

                    game_over = true;
                }
                else if (button_click.Contains(11) && button_click.Contains(12) && button_click.Contains(13))
                {
                    row_11.Visibility = Visibility.Visible;
                    row_12.Visibility = Visibility.Visible;
                    row_13.Visibility = Visibility.Visible;
                
                    game_over = true;
                }
                else if (button_click.Contains(21) && button_click.Contains(22) && button_click.Contains(23))
                {
                    row_21.Visibility = Visibility.Visible;
                    row_22.Visibility = Visibility.Visible;
                    row_23.Visibility = Visibility.Visible;

                    game_over = true;
                }
                else if (button_click.Contains(31) && button_click.Contains(32) && button_click.Contains(33))
                {
                    row_31.Visibility = Visibility.Visible;
                    row_32.Visibility = Visibility.Visible;
                    row_33.Visibility = Visibility.Visible;

                    game_over = true;
                }
                else if (button_click.Contains(31) && button_click.Contains(22) && button_click.Contains(13))
                {
                    cant_1_31.Visibility = Visibility.Visible;
                    cant_1_22.Visibility = Visibility.Visible;
                    cant_1_13.Visibility = Visibility.Visible;

                    game_over = true;
                }
                else if (button_click.Contains(11) && button_click.Contains(22) && button_click.Contains(33))
                {
                    cant_2_11.Visibility = Visibility.Visible;
                    cant_2_22.Visibility = Visibility.Visible;
                    cant_2_33.Visibility = Visibility.Visible;

                    game_over = true;
                }
                else if ((this.A1.IsEnabled == false) && (this.A2.IsEnabled == false) && (this.A3.IsEnabled == false) && (this.B1.IsEnabled == false) && (this.B2.IsEnabled == false) && (this.B3.IsEnabled == false)
                && (this.C1.IsEnabled == false) && (this.C2.IsEnabled == false) && (this.C3.IsEnabled == false))
                {
                Napis.Background = Brushes.Purple;
                Napis.Content = "REMIS";

            }
                
            }

        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            this.A1.IsEnabled = this.A2.IsEnabled = this.A3.IsEnabled = this.B1.IsEnabled = this.B2.IsEnabled = this.B3.IsEnabled = this.C1.IsEnabled = this.C2.IsEnabled = this.C3.IsEnabled = true;
            this.A1.Content = this.A2.Content = this.A3.Content = this.B1.Content = this.B2.Content = this.B3.Content = this.C1.Content = this.C2.Content = this.C3.Content = "";

            column_11.Visibility = column_21.Visibility = column_31.Visibility = column_12.Visibility = column_22.Visibility = column_32.Visibility = column_13.Visibility = column_23.Visibility = column_33.Visibility = row_11.Visibility
                = row_12.Visibility = row_13.Visibility = row_21.Visibility = row_22.Visibility = row_23.Visibility = row_31.Visibility = row_32.Visibility = row_33.Visibility = cant_1_31.Visibility = cant_1_22.Visibility = cant_1_13.Visibility = cant_2_11.Visibility
                = cant_2_22.Visibility = cant_2_33.Visibility = Visibility.Hidden;


            player_1.Clear();
            player_2.Clear();
            game_over = false;
            Sign_Choice();
            InitializeComponent();
            Begin_First_Brushes();
        }

        private void Menu_Click(object sender, RoutedEventArgs e)
        {
            Menu window_menu = new Menu();
            window_menu.Show();
            
         

            
            
        }
    }
    }

