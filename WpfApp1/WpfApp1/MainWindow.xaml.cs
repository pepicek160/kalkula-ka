using System;
using System.Windows;
using System.Windows.Controls;

namespace YourNamespace
{
    public partial class MainWindow : Window
    {
        private bool isNewInput = true;
        private double currentResult = 0;
        private string currentOperator = "";

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            string content = button.Content.ToString();

            switch (content)
            {
                case "=":
                    Calculate();
                    break;
                case "C":
                    Clear();
                    break;
                default:
                    AppendInput(content);
                    break;
            }
        }

        private void Calculate()
        {
            try
            {
                double inputValue = Convert.ToDouble(Displej.Text);
                switch (currentOperator)
                {
                    case "+":
                        currentResult += inputValue;
                        break;
                    case "-":
                        currentResult -= inputValue;
                        break;
                    case "×":
                        currentResult *= inputValue;
                        break;
                    case "÷":
                        if (inputValue != 0)
                            currentResult /= inputValue;
                        else
                            MessageBox.Show("Cannot divide by zero", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        break;
                    default:
                        currentResult = inputValue;
                        break;
                }

                Displej.Text = currentResult.ToString();
                isNewInput = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Clear()
        {
            Displej.Text = "0";
            isNewInput = true;
            currentResult = 0;
            currentOperator = "";
        }

        private void AppendInput(string input)
        {
            if (isNewInput)
            {
                Displej.Text = "0";
                isNewInput = false;
            }

            if (Displej.Text == "0" && input != ",")
                Displej.Text = input;
            else
                Displej.Text += input;
        }
    }
}

