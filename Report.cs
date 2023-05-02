namespace mis_221_pa_5_lfcoffman
{
    public class Report
    {
        //View various reports, save report to file
        //Individual Customer Sessions, Historical Customer Sessions, Historical Revenue Report
        public static void Reports()
        {
            string customerEmail = " ";
            while(customerEmail != "-1")
            {
                System.Console.WriteLine("What is the customer's Email Address?");
                customerEmail = Console.ReadLine();
                if(customerEmail == "-1")
                {
                    break;
                }
                if(BookingUtility.SearchEmail(customerEmail) == -1)
                {
                    System.Console.WriteLine("Could not find a report for " + customerEmail);
                    continue;
                }
                else{
                    string customerName = "" ;
                    System.Console.WriteLine(customerEmail + "Report");
                    StreamReader inFile = new StreamReader("transactions.txt");          //open file
                string line = inFile.ReadLine();
                while(line!= null)
                {
                    string [] temp = line.Split("#");
                    if(temp[2] == customerEmail)
                    {
                        System.Console.WriteLine("Customer: " + temp[1]);
                        System.Console.WriteLine("Email: " + temp[2]);
                        System.Console.WriteLine("Date: " + temp[3]);
                        System.Console.WriteLine("Trainer: " + temp[4]);
                        customerName = temp[1];
                    }
                    line = inFile.ReadLine();                             //update
                }
                inFile.Close(); 
                System.Console.WriteLine("Enter Y to save report or N to skip");
                string saveInput = Console.ReadLine();
                if(saveInput.ToUpper() == "n")
                {
                    string temp = "report.txt";
                    string pathName = String.Concat(customerName, temp);
                    StreamWriter outFile = new StreamWriter(pathName);
                    outFile.WriteLine(customerName + "Report: ");
                    StreamReader file = new StreamReader("transactions.txt");
                    string newLine = file.ReadLine();
                    while(newLine != null)
                    {
                        string [] newTemp = newLine.Split("#");
                        if(newTemp[2] == customerEmail)
                        {
                            System.Console.WriteLine("Customer: " + newTemp[1]);
                            System.Console.WriteLine("Email: " + newTemp[2]);
                            System.Console.WriteLine("Date: " + newTemp[3]);
                            System.Console.WriteLine("Trainer: " + newTemp[4]);
                            customerName = newTemp[1];
                        }
                        newLine = file.ReadLine();
                    }
                    outFile.Close();
                    file.Close();
                    System.Console.WriteLine("File saved as " + pathName);
                    }
                    else if(saveInput.ToUpper()== "N")
                    {
                        break;
                    }
                    else{
                        System.Console.WriteLine("Wrong input");
                    }
                }
            }
        }
    }
}