using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace HospitalMS
{
    class Controller
    {
        public Controller()
        {
           
        }
        public void CheckNumericValuesTextBox(TextBox textBox) {
            foreach (char c in textBox.Text.ToCharArray())
            {
                if (!char.IsDigit(c))
                {
                    MessageBox.Show("This textbox accepts only numbers.");
                    textBox.Clear();
                    break;
                }
            }
        }
        public bool CheckPasswordBox(PasswordBox passwordBox)
        {
            bool flag = false;
            if (!System.Text.RegularExpressions.Regex.IsMatch(passwordBox.Password, "[a-zA-Z]+$"))
            {
                flag = true;
            }
            else
            {
                MessageBox.Show("Such character is not available.");
                passwordBox.Clear();
            }
            return flag;
        }
        public string ReturnStringFromTextBox(TextBox textBox)
        {
            string input = "";
            if (textBox.Text != null)
            {
                input = textBox.Text;
            }
            return input;
        }
        public string ReturnPasswordFromTextBox(PasswordBox passwordBox)
        {
            string password = "";
            if (passwordBox.Password != null)
            {
                password = passwordBox.Password;
            }
            return password;
        }

        public void CheckLiteralValuesTextBox(TextBox textBox)
        {
            if (textBox.Text.Length != 0)
                if (!System.Text.RegularExpressions.Regex.IsMatch(textBox.Text, "^[a-zA-Z]"))
                {
                    MessageBox.Show("Accepts only Latin characters.");
                    textBox.Clear();
                }
        }
    }
}
