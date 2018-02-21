using System;
using System.Windows;

using System.Windows.Media.Animation;

namespace Organiser
{
    public partial class MainWindow : Window
    {
        
        public DataDictionary data_dictionary;
        System.Windows.Forms.NotifyIcon ni;

        #region - КОНСТРУКТОР -
        public MainWindow()
        {
            InitializeComponent();

            ni = new System.Windows.Forms.NotifyIcon();

            try
            {
                ni.Icon = new System.Drawing.Icon("091_032.ico");
            }
            catch (Exception)
            {

            }
            
            ni.Visible = true;
            ni.DoubleClick += delegate( object sender, EventArgs e ) { this.Show(); this.WindowState = System.Windows.WindowState.Normal; };

            data_dictionary = new DataDictionary();
        }
        #endregion

        #region - СОБЫТИЯ ГЛАВНОЙ ФОРМЫ -
        protected override void OnStateChanged(EventArgs e)
        {
            if (WindowState == System.Windows.WindowState.Minimized)
            {
                if (ni.Icon != null)
                {
                    this.Hide();
                }
            }

            base.OnStateChanged(e);
        }
        #endregion

        #region - METHOD -

        #endregion

        #region -EVENT-
        // свернуть/равернуть левую панель
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (PanelLeft.ActualWidth > 100)
            {
                ((Storyboard)FindResource("sbPanelLeftColapsed")).Begin(PanelLeft);
            }
            else
            {
                ((Storyboard)FindResource("sbPanelLeftMax")).Begin(PanelLeft);
            }
        }

        // свернуть/равернуть панель настроек
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (PanelSettings.ActualWidth > 100)
            {
                ((Storyboard)FindResource("sbPanelSetColapsed")).Begin(PanelSettings);
            }
            else
            {
                ((Storyboard)FindResource("sbPanelSetMax")).Begin(PanelSettings);
            }
        }

        // что бы был открыт только один экспандер
        private void Ex1_Expanded(object sender, RoutedEventArgs e)
        {
            Ex2.IsExpanded = false;
        }
        private void Ex2_Expanded(object sender, RoutedEventArgs e)
        {
            Ex1.IsExpanded = false;
        }
        #endregion
    }

}
