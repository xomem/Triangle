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

namespace Triangle
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private double AX, AY, BX, BY, CX, CY;
        private double result;
        private double p;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            AX = Convert.ToDouble(AXTextBox.Text);
            AY = Convert.ToDouble(AYTextBox.Text);

            BX = Convert.ToDouble(BXTextBox.Text);
            BY = Convert.ToDouble(BYTextBox.Text);

            CX = Convert.ToDouble(CXTextBox.Text);
            CY = Convert.ToDouble(CYTextBox.Text);

            DrawTriangle();

            double AB = Math.Sqrt(Math.Pow(BX - AX, 2) + Math.Pow(BY - AY, 2));
            double BC = Math.Sqrt(Math.Pow(CX - BX, 2) + Math.Pow(CY - BY, 2));
            double CA = Math.Sqrt(Math.Pow(AX - CX, 2) + Math.Pow(AY - CY, 2));
            p = (AB + BC + CA) / 2;

            result = Math.Sqrt(p * (p - AB) * (p - BC) * (p - CA));

            ResultLabel.Visibility = Visibility.Visible;
            ResultTextBlock.Text = Convert.ToString(Math.Round(result, 4));
        }

        private void DrawTriangle()
        {
            Canvas.Children.Clear();
            StackPanel stackPanel = new StackPanel();

            Line ABline = new Line();

            ABline.Stroke = Brushes.Red;

            ABline.X1 = AX * 30;
            ABline.X2 = BX * 30;
            ABline.Y1 = AY * 30;
            ABline.Y2 = BY * 30;
            ABline.StrokeThickness = 1;
            ABline.HorizontalAlignment = HorizontalAlignment.Left;
            ABline.VerticalAlignment = VerticalAlignment.Center;

            Line BCline = new Line();

            BCline.Stroke = Brushes.Black;

            BCline.X1 = BX * 30;
            BCline.X2 = CX * 30;
            BCline.Y1 = CY * 30;
            BCline.Y2 = BY * 30;
            BCline.StrokeThickness = 1;
            BCline.HorizontalAlignment = HorizontalAlignment.Left;
            BCline.VerticalAlignment = VerticalAlignment.Center;
            Line CAline = new Line();

            CAline.Stroke = Brushes.Green;

            CAline.X1 = CX * 30;
            CAline.X2 = AX * 30;
            CAline.Y1 = CY * 30;
            CAline.Y2 = AY * 30;
            CAline.StrokeThickness = 1;
            CAline.HorizontalAlignment = HorizontalAlignment.Left;
            CAline.VerticalAlignment = VerticalAlignment.Center;


            Canvas.Children.Add(CAline);
            Canvas.Children.Add(BCline);
            Canvas.Children.Add(ABline);
        }
    }
}
