using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace calculatorApp
{
    public partial class Form1 : Form
    {
        private string currentNumber, operation;
        private float firstNumber, secondNumber, result;
        private bool isDuplicate;

        public Form1()
        {
            InitializeComponent();
            Reset();
        }

        private void Reset()
        {
            currentNumber = "";
            operation = "";
            firstNumber = 0;
            secondNumber = 0;
            result = 0;
            isDuplicate = false;
            labelResult.Text = "0";
        }

        private void GetNumber(string inputNumber)
        {
            currentNumber += inputNumber;
            labelResult.Text = currentNumber;
        }

        private void GetOperation(string inputOperation)
        {
            if (!string.IsNullOrEmpty(currentNumber))
            {
                firstNumber = float.Parse(labelResult.Text);
                operation = inputOperation;
                currentNumber = "";
                isDuplicate = false;
            }
        }

        private void Calculate()
        {
            if (!isDuplicate)
            {
                secondNumber = float.Parse(labelResult.Text);
            }

            try
            {
                switch (operation)
                {
                    case "+":
                        result = firstNumber + secondNumber;
                        break;
                    case "-":
                        result = firstNumber - secondNumber;
                        break;
                    case "*":
                        result = firstNumber * secondNumber;
                        break;
                    case "/":
                        if (secondNumber != 0)
                        {
                            result = firstNumber / secondNumber;
                        }
                        else
                        {
                            labelResult.Text = "Error";
                            Reset();
                            return;
                        }
                        break;
                    default:
                        result = secondNumber;
                        break;
                }
            }
            catch
            {
                labelResult.Text = "Error";
                Reset();
                return;
            }

            labelResult.Text = result.ToString();
            firstNumber = result;
            currentNumber = "";
            isDuplicate = true;
        }

        private void NumberButton_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            GetNumber(button.Text);
        }

        private void OperationButton_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            GetOperation(button.Text);
        }

        private void btnPN_Click(object sender, EventArgs e)
        {
            if (float.Parse(labelResult.Text) != 0)
            {
                if (labelResult.Text.Contains("-"))
                {
                    currentNumber = labelResult.Text.Replace("-", "");
                }
                else
                {
                    currentNumber = "-" + labelResult.Text;
                }
                labelResult.Text = currentNumber;
            }
        }
        private void btnDot_Click(object sender, EventArgs e)
        {
            if (!currentNumber.Contains("."))
            {
                GetNumber(".");
            }
        }

        private void btnC_Click(object sender, EventArgs e)
        {
            Reset();
        }
        private void btnEqual_Click(object sender, EventArgs e)
        {
            Calculate();
        }
    }
}