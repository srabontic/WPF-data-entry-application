using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfPractice
{
    class formFields
    {
        public string firstName;
        public string middleName;
        public string lastname;
        public string address1;
        public string address2;
        public string city;
        public string state;
        public string zipCode;
        public string phoneNo;
        public string email;
        public string proof;
        public string dateReceived;

        public void initialize()
        {
            firstName = "";
            middleName = "";
            lastname = "";
            address1 = "";
            address2 = "";
            city = "";
            state = "";
            zipCode = "";

        }
        //public ArrayList arr = new ArrayList();
        char[] delimiters = new char[] { '\t' };

        public string writeFile(formFields formobj)
        {
            string[] lines = File.ReadAllLines("newFile.txt");
            char[] delimiters = new char[] { '\t' };
            bool flag = false;
            foreach (string line in lines)
            {
                string[] reqText = line.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
                if (reqText[0].ToUpper().Equals(firstName.ToUpper()) && reqText[1].ToUpper().Equals(middleName.ToUpper()) && reqText[2].ToUpper().Equals(lastname.ToUpper()) && reqText[8] == phoneNo)
                {
                    flag = true;
                }
            }
            if (flag == false)
            {
                string writeText = firstName.ToUpper() + "\t" + middleName.ToUpper() + "\t" + lastname.ToUpper() + "\t" + address1.ToUpper() + "\t" + address2.ToUpper() + "\t" + city.ToUpper() + "\t" + state.ToUpper() + "\t" + zipCode.ToUpper() + "\t" + phoneNo + "\t" + email.ToUpper() + "\t" + proof.ToUpper() + "\t" + dateReceived.Substring(0, 10);
                using (StreamWriter writetext = File.AppendText("newFile.txt"))
                {
                    writetext.WriteLine(writeText);

                }
                return "OK";
            }
            else
            {
                return "NOK";
            }

                
        }
        public ArrayList readFileAll()
        {
            ArrayList arr = new ArrayList();
            string[] lines = File.ReadAllLines("newFile.txt");
            int count = 0;
            Console.WriteLine("extra");
            foreach (string line in lines)
            {
                Console.WriteLine(line);
                arr.Add(line);
            }
            Console.WriteLine(count);
            return arr;
        }
        public string createRecordToUpdate(formFields formobj, string oldrow)
        {
            string[] lines = File.ReadAllLines("newFile.txt");
            char[] delimiters = new char[] { '\t' };
            bool flag = false;
            foreach (string line in lines)
            {
                string[] reqText = line.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
                if (reqText[0].ToUpper().Equals(firstName.ToUpper()) && reqText[1].ToUpper().Equals(middleName.ToUpper()) && reqText[2].ToUpper().Equals(lastname.ToUpper()) && reqText[8] == phoneNo)
                {
                    flag = true;
                }
            }

            if (flag == true)
            {
                string updateText = firstName.ToUpper() + "\t" + middleName.ToUpper() + "\t" + lastname.ToUpper() + "\t" + address1.ToUpper() + "\t" + address2.ToUpper() + "\t" + city.ToUpper() + "\t" + state.ToUpper() + "\t" + zipCode.ToUpper() + "\t" + phoneNo + "\t" + email.ToUpper() + "\t" + proof.ToUpper() + "\t" + dateReceived.Substring(0, 10);

                //check for the record in file
                string text = File.ReadAllText("newFile.txt");
                text = text.Replace(oldrow, updateText);
                File.WriteAllText("newFile.txt", text);
                return "OK";
            }
            else
            {
                return "NOK";
            }        
            
        }

        public string deleteRecord()
        {
            var oldrow ="";
            string retVal = "";
            string[] lines = File.ReadAllLines("newFile.txt");
            char[] delimiters = new char[] { '\t' };
            bool flag = false;
            foreach (string line in lines)
            {
                string[] reqText = line.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
                if (reqText[0].ToUpper().Equals(firstName.ToUpper()) && reqText[1].ToUpper().Equals(middleName.ToUpper()) && reqText[2].ToUpper().Equals(lastname.ToUpper()) && reqText[8] == phoneNo)
                {
                    flag = true;
                    oldrow = line;
                }
            }
            if (flag == true)
            {
                var newlines = lines.Where(line => !line.Contains(oldrow));
                File.WriteAllLines("newFile.txt", newlines);
                return "OK";
            }
            else
            {
                return "NOK";
            }

        }
    }
}
