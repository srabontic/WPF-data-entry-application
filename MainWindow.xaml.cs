using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
using System.Windows.Threading;


namespace WpfPractice
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    class listViewOP
    {
        string name;
        string phone;
    }
    public partial class MainWindow : Window
    {
        //string filename = @"C:\Desktop\newfile.txt";
        formFields formobj = new formFields();
        public string oldrow = "";
        public MainWindow()
        {
            InitializeComponent();
            //formFields formobj = new formFields();
            textBox_firstName.Focus();
            GetDetails();
        }

        private void textBox_phone_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (textBox_phone.Text.Length == textBox_phone.MaxLength)
            {
                textBox_email.Focus();
            }
        }

        private void textBox_firstName_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(textBox_firstName.Text.Length == textBox_firstName.MaxLength)
            {
                textBox_midName.Focus();
            }
        }

        private void textBox_midName_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(textBox_midName.Text.Length == textBox_midName.MaxLength)
            {
                textBox_midName.Focus();
            }
        }

        private void textBox_lastName_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(textBox_lastName.Text.Length == textBox_lastName.MaxLength)
            {
                textBox_lastName.Focus();
            }
        }

        private void textBox_add1_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(textBox_add1.Text.Length == textBox_add1.MaxLength)
            {
                textBox_add2.Focus();
            }
        }

        private void textBox_add2_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(textBox_add2.Text.Length == textBox_add2.MaxLength)
            {
                textBox_city.Focus();
            }
        }

        private void textBox_city_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(textBox_city.Text.Length == textBox_city.MaxLength)
            {
                comboBox_state.Focus();
            }
        }


        private void textBox_zip_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(textBox_zip.Text.Length == textBox_zip.MaxLength)
            {
                textBox_phone.Focus();
            }
        }

        private void textBox_email_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(textBox_email.Text.Length == textBox_email.MaxLength)
            {
                checkBox_yes.Focus();
            }
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            resetFormField();
        }

        private void resetFormField()
        {
            formobj.initialize();
            //focus the first name field
            textBox_firstName.Focus();
            textBox_firstName.Text = "";
            textBox_midName.Text = "";
            textBox_lastName.Text = "";
            textBox_add1.Text = "";
            textBox_add2.Text = "";
            textBox_city.Text = "";
            comboBox_state.Text = "";
            textBox_zip.Text = "";
            textBox_phone.Text = "";
            textBox_email.Text = "";
            checkBox_yes.IsChecked = false;
            checkBox_no.IsChecked = false;
            datePicker.SelectedDate = DateTime.Today;

            labelError.Content = "";
            //GetDetails();
            //myListView.Items.Clear();
        }

        //validation of data entered
        private Boolean validationOfFields()
        {
            string reqField = requiredFieldValidation();  //req field check
            string validValue = validValueCheck(); //check valid values
            if (reqField == "" && validValue == "")
            {
                return true;
            }
            else
            {
                labelError.Content = reqField + validValue;
                return false;
            }
        }

        //valid values check for city and phone number
        private string validValueCheck()
        {
            string validValError = "";
            foreach(char c in textBox_city.Text)
            {
                if (c<'9'  && c> '0')
                {
                    validValError = validValError + "Enter a valid city" + "\n";
                    break;
                }
            }
            foreach (char d in textBox_phone.Text)
            {
                if(d > '9' || d< '0')
                {
                    validValError = validValError + "Enter a valid phone number" + "\n";
                    break;
                }
            }
            Boolean b = Regex.IsMatch(textBox_email.Text,
                @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
                RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            if (b == false)
            {
                validValError = validValError + "Enter a valid email address" + "\n";
            }
            return validValError;

        }

        //required field validation
        private string requiredFieldValidation()
        {
            string reqError ="";
            if(textBox_firstName.Text == "")
            {
                reqError = reqError + "Enter first name." + "\n";
            }
            if (textBox_lastName.Text == "")
            {
                reqError = reqError + "Enter last name." + "\n";
            }
            if (textBox_add1.Text == "")
            {
                reqError = reqError + "Enter address line 1." + "\n";
            }
            if (textBox_city.Text == "")
            {
                reqError = reqError + "Enter city." + "\n";
            }
            if (comboBox_state.Text == "")
            {
                reqError = reqError + "Select state." + "\n";
            }
            if (textBox_zip.Text == "")
            {
                reqError = reqError + "Enter zip code." + "\n";
            }
            if (textBox_phone.Text == "")
            {
                reqError = reqError + "Enter phone number." + "\n";
            }
            if (textBox_email.Text == "")
            {
                reqError = reqError + "Enter email address." + "\n";
            }
            if(checkBox_yes.IsChecked == true && checkBox_no.IsChecked == true)
            {
                reqError = reqError + "Enter any one option for" +"\n" + "proof of purchase" + "\n";
            }
            if (checkBox_yes.IsChecked == false && checkBox_no.IsChecked == false)
            {
                reqError = reqError + "Enter proof of purchase attached or not" + "\n";
            }
            if(datePicker.SelectedDate.ToString() == "")
            {
                reqError = reqError + "Enter date received." + "\n";
            }
            //labelError.Content = reqError;
            return reqError;
            
        }

        //move form field values to variables
        private void fieldTovariable()
        {
            string ckeck_proof = "";

            formobj.firstName = textBox_firstName.Text;
            if (textBox_midName.Text == "")
                { formobj.middleName = "NA"; }
            else { formobj.middleName = textBox_midName.Text; }
            formobj.lastname = textBox_lastName.Text;
            formobj.address1 = textBox_add1.Text;
            if(textBox_add2.Text == "")
            {
                formobj.address2 = "NA";
            }
            else { formobj.address2 = textBox_add2.Text; }
            
            formobj.city = textBox_city.Text;
            formobj.state = comboBox_state.Text;
            formobj.zipCode = textBox_zip.Text;
            formobj.phoneNo = textBox_phone.Text;
            formobj.email = textBox_email.Text;
            if(checkBox_yes.IsChecked == true)
            {
                ckeck_proof = "yes";
            }
            else if (checkBox_no.IsChecked == true)
            {
                ckeck_proof = "no";
            }
            formobj.proof = ckeck_proof;
            formobj.dateReceived = datePicker.SelectedDate.ToString();
            Console.WriteLine(formobj.dateReceived);
        }

        //delete record
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            fieldTovariable();
            string r = formobj.deleteRecord();
            if (r.Equals("OK"))
            {
                resetFormField();
                Action.Text = "  Delete Successful!!";
                GetDetails();
            }
            else
            {
                Action.Text = "  Record not deleted!!";
                GetDetails();

            }
        }

        //update record
        private void Update_Click(object sender, RoutedEventArgs e)
        {
            if (validationOfFields())
            {
                fieldTovariable();
                string ok=formobj.createRecordToUpdate(formobj, oldrow);
                
                if (ok.Equals("OK"))
                {
                    Action.Text = "  Update Successful!!";
                    resetFormField();
                    GetDetails();
                }
                else if (ok.Equals("NOK"))
                {
                    Action.Text = "  Record does not exist!!";
                    GetDetails();
                }
                
            }
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            //on tab focus add button first

            if (validationOfFields())
            {
                fieldTovariable();
                string ok = formobj.writeFile(formobj);
                resetFormField();
                //Console.WriteLine("ADDED");
                if (ok.Equals("OK"))
                {
                    Action.Text = "  Add Successful!!";
                }
                else if (ok.Equals("NOK"))
                {
                    Action.Text = "  Duplicate record!!";
                }
                GetDetails();

            }
        }

        //show all customer details in listview
        private void GetDetails()
        {
            //reset listview
            Console.WriteLine("In get details");
            myListView.Items.Clear();
            
            Console.WriteLine("after clear");
            foreach(var v in myListView.Items)
            {
                myListView.Items.Remove(v);
            }

            //populate customer details in listview

            char[] delimiters = new char[] { '\t' };
            ArrayList arr = new ArrayList();
            arr = formobj.readFileAll();
            Console.WriteLine(arr);
            
            foreach(string s in arr)
            {
                Console.WriteLine(s);
                string[] reqText = s.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);

                string showName;
                if (reqText[1] == "NA")
                {
                    showName = reqText[0] + " " + reqText[2];
                }
                else
                {
                    showName = reqText[0] + " " + reqText[1] + " " + reqText[2];
                }
                myListView.Items.Add(new { name = showName, phone = reqText[8] });

                myListView.SelectedItem = null;
            }
            

        }

        //display selcected data in the form for selcted listview row
        private void myListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            labelError.Content = "";
            char[] delimiters = new char[] { '\t'};
            int selectedIdx = myListView.SelectedIndex;
            Console.WriteLine("Value >>>" + selectedIdx);
            if (selectedIdx < 0) {
                myListView.SelectedItem = null;
            }
            else {
                ArrayList selectedArr = new ArrayList();
                selectedArr = formobj.readFileAll();
                string selctedRow = (string)selectedArr[selectedIdx];
                oldrow = selctedRow;
                //Console.WriteLine(selctedRow);  //move selcted data to oldrow will be used as old row duing update
                string[] selcetdFields = selctedRow.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
                Console.WriteLine(selcetdFields[0]);
                listTofillFormField(selcetdFields);
            }

        }

        //move file data to form fields
        private void listTofillFormField(string[] selcetdFields)
        {
            textBox_firstName.Text = selcetdFields[0];
            if (selcetdFields[1] != "NA")
            {
                textBox_midName.Text = selcetdFields[1];
            }
            textBox_lastName.Text = selcetdFields[2];
            textBox_add1.Text = selcetdFields[3];
            if(selcetdFields[4] != "NA")
            {
                textBox_add2.Text = selcetdFields[4];
            } 
            textBox_city.Text = selcetdFields[5];
            comboBox_state.Text = selcetdFields[6];
            textBox_zip.Text = selcetdFields[7];
            textBox_phone.Text = selcetdFields[8];
            textBox_email.Text = selcetdFields[9];
            if (selcetdFields[10] == "YES")
            {
                checkBox_yes.SetCurrentValue(CheckBox.IsCheckedProperty, true);
                checkBox_no.SetCurrentValue(CheckBox.IsCheckedProperty, false);
            }
            if (selcetdFields[10] == "NO")
            {
                checkBox_yes.SetCurrentValue(CheckBox.IsCheckedProperty, false);
                checkBox_no.SetCurrentValue(CheckBox.IsCheckedProperty, true);
            }
            
            datePicker.SelectedDate = DateTime.Parse(selcetdFields[11]);
        }

    }
}
