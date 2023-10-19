using System;
using System.Windows;
using System.Windows.Controls;

namespace Calculator;

public partial class MainWindow : Window
{
    private string currentInput = string.Empty;
    private double result = 0;
    private string currentOperator = string.Empty;
    public MainWindow()
    {
        InitializeComponent();
    }
    private void CalculateResult()
    {
        if (!string.IsNullOrEmpty(currentInput))
        {
            double secondOperand = double.Parse(currentInput);
            switch (currentOperator)
            {
                case "+":
                    result += secondOperand;
                    break;
                case "-":
                    result -= secondOperand;
                    break;
                case "X":
                    result *= secondOperand;
                    break;
                case "/":
                    if (secondOperand != 0)
                        result /= secondOperand;
                    else
                        result = double.NaN;
                    break;
                case "X2":
                    result = Math.Pow(result, 2);
                    break;
                case "/2":
                    if (result != 0)
                        result /= 2;
                    else
                        result = double.NaN;
                    break;
            }
            DisplayResult.Content = result.ToString();
            currentInput = string.Empty;
        }
    }
    private void OperatorButton_Click(object sender, RoutedEventArgs e)
    {
        if (!string.IsNullOrEmpty(currentOperator))
        {
            CalculateResult();
            currentOperator = (sender as Button).Content.ToString();
        }
        else
        {
            currentOperator = (sender as Button).Content.ToString();
            result = double.Parse(currentInput);
            currentInput = string.Empty;
        }
    }
    private void EqualsButton_Click(object sender, RoutedEventArgs e)
    {
        CalculateResult();
        currentOperator = string.Empty;
    }
    private void ClearButton_Click(object sender, RoutedEventArgs e)
    {
        currentInput = string.Empty;
        result = 0;
        currentOperator = string.Empty;
        DisplayResult.Content = "0";
    }
    private void NumButton_Click(object sender, RoutedEventArgs e)
    {
        string digit = (sender as Button).Content.ToString();
        currentInput += digit;
        DisplayResult.Content = currentInput;
    }

    private void DecimalButton_Click(object sender, RoutedEventArgs e)
    {
        if (!currentInput.Contains("."))
        {
            currentInput += ".";
            DisplayResult.Content = currentInput;
        }
    }
    private void PlusMinusButton_Click(object sender, RoutedEventArgs e)
    {
        if (!string.IsNullOrEmpty(currentInput) && currentInput != "0")
        {
            if (currentInput[0] == '-')
            {
                currentInput = currentInput.Substring(1);
            }
            else
            {
                currentInput = "-" + currentInput;
            }

            DisplayResult.Content = currentInput;
        }
    }

}
