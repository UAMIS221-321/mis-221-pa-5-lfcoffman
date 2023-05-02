namespace mis_221_pa_5_lfcoffman
{
    public class TrainerUtility
    {
        //Trainer ID/Name/Email Address, Mailing Address
        //All functions to add, edit, or delete trainer info
        public static List<Trainer> trainerList;

        //Trainer Utility class constructor
        public TrainerUtility(List<Trainer> trainers)
        {
            trainerList = trainers;
        }
        public static List<Trainer> ReadAllTrainers()
        {
            List<Trainer> trainerList = new List<Trainer>();
            //open file
            using(StreamReader inFile = new StreamReader("trainers.txt"))
            {
                //process file (needs to be in loop to read in one line at a time)
                string line = inFile.ReadLine(); //priming read
                while(line != null)
                {
                    string[] temp = line.Split("#"); //splits up each line and stores data in new temp array
                    int trainerID = int.Parse(temp[0]);
                    string trainerName = temp[1];
                    string trainerEmail = temp[2];
                    string trainerMail = temp[3];
                    Trainer trainer = new Trainer(trainerID, trainerName, trainerEmail, trainerMail);
                    trainerList.Add(trainer);
                    line = inFile.ReadLine(); //update read (reads all data from one line at a time)
                }
                //close file
                inFile.Close();
                return trainerList;
            }
        }
        public static void ManageTrainersMenu()
        {
            trainerList = ReadAllTrainers();
            System.Console.WriteLine("\x1B[0m" + "Manage Trainer Information" + "\x1B[0m");
            System.Console.WriteLine("Enter 1 to add a new trainer");
            System.Console.WriteLine("Enter 2 to edit a trainer");
            System.Console.WriteLine("Enter 3 to delete a trainer");
            string trainerMenuInput = Console.ReadLine();
            if(trainerMenuInput == "1")
            {
                AddTrainer();
            }
            else if(trainerMenuInput == "2")
            {
                EditTrainer();
            }
            else if(trainerMenuInput == "3")
            {
                DeleteTrainer();
            }
            WriteAllTrainers(trainerList);
        }

        private static void AddTrainer()
        {
            //Allows user to enter/add new trainer data
            System.Console.WriteLine("\x1B[0m" + "Add New Trainer" + "\x1B[0m");
            System.Console.WriteLine("Enter Trainer's ID ");
            int trainerID = int.Parse(Console.ReadLine());
            System.Console.WriteLine("Enter Trainer's Name");
            string trainerName = Console.ReadLine();
            System.Console.WriteLine("Enter Trainer's Email Address");
            string trainerEmail = Console.ReadLine();
            System.Console.WriteLine("Enter Trainer's Mailing Address");
            string trainerMail = Console.ReadLine();
            Trainer newTrainer = new Trainer(trainerID, trainerName ,trainerEmail, trainerMail);
            using (StreamWriter outFile = new StreamWriter("trainers.txt"))
            {
                for(int i = 0; i < GetTrainerLength(); i++)
                {
                    outFile.Write(trainerList[i].GetTrainerID() + "#"); 
                    outFile.Write(trainerList[i].GetTrainerName() + "#");
                    outFile.Write(trainerList[i].GetTrainerEmail() + "#");
                    outFile.Write(trainerList[i].GetTrainerMail() + "#");
                }
                outFile.Write(newTrainer.GetTrainerID() + "#"); 
                outFile.Write(newTrainer.GetTrainerName() + "#");
                outFile.Write(newTrainer.GetTrainerEmail() + "#");
                outFile.Write(newTrainer.GetTrainerMail() + "#");
                //close trainers file
                outFile.Close();
            }
        }
        private static void EditTrainer()
        {
            //Allows user to edit existing trainer data
            System.Console.WriteLine("\x1B[0m" + "Edit Trainer" + "\x1B[0m");
            System.Console.WriteLine("Enter Trainer ID to edit that trainer");
            int trainerID = int.Parse(Console.ReadLine());
            //Finds trainer that corresponds to ID input
            Trainer editTrainer = FindTrainer(trainerID);
            if(editTrainer!=null)
            {
                string trainerName = editTrainer.GetTrainerName();
                string trainerEmail = editTrainer.GetTrainerEmail();
                string trainerMail = editTrainer.GetTrainerMail();
                //Have user enter new info for trainer
                System.Console.WriteLine("Current Trainer Name: " + trainerName);
                System.Console.WriteLine("What would you like to change Trainer Name to?");
                string newTrainerName = Console.ReadLine();
                System.Console.WriteLine("Current Trainer Name: " + trainerEmail);
                System.Console.WriteLine("What would you like to change Trainer Email Address to?");
                string newTrainerEmail = Console.ReadLine();
                System.Console.WriteLine("Current Trainer Name: " + trainerMail);
                System.Console.WriteLine("What would you like to change Trainer Mailing Address to?");
                string newTrainerMail = Console.ReadLine();
                //update the trainer file
                editTrainer.SetTrainerName(newTrainerName);
                editTrainer.SetTrainerEmail(newTrainerEmail);
                editTrainer.SetTrainerMail(newTrainerMail);
                System.Console.WriteLine("Trainer has been updated");
            }
            else
            {
                System.Console.WriteLine("Trainer was not found");
            }
        }
        private static void DeleteTrainer()
        {
            int trainerID;
            //Allows user to delete trainer data
            System.Console.WriteLine("\x1B[0m" + "Delete Trainer" + "\x1B[0m");
            System.Console.WriteLine("Enter the Trainer ID you would like to delete");
            trainerID = int.Parse(Console.ReadLine());
            using (StreamWriter outFile = new StreamWriter("trainers.txt"))
            {
                //write every line in trainers out to file
                for(int i = 0; i<GetTrainerLength(); i++)
                {
                    if(trainerList[i].GetTrainerID() == trainerID)
                    {
                        i++;
                        continue;
                    }
                    Trainer currentTrainer = trainerList[i];
                    outFile.Write(currentTrainer.GetTrainerID() + "#"); 
                    outFile.Write(currentTrainer.GetTrainerName() + "#");
                    outFile.Write(currentTrainer.GetTrainerEmail() + "#");
                    outFile.Write(currentTrainer.GetTrainerMail() + "#");
                }
                //close trainers file
                outFile.Close();
            }
        }
        private static Trainer FindTrainer(int trainerID)
        {
            int count = 0;
            while(count < trainerList.Count)
            {
                if(trainerList[count].trainerID == trainerID)
                {
                    return trainerList[count];
                }
                count++;
            }
            return null;
        }
        public static void WriteAllTrainers(List<Trainer> trainerList)
        {
            //open up trainers file
            using(StreamWriter outFile = new StreamWriter("trainers.txt"))
            {
                //write every line in trainers out to file
                for(int i = 0; i<GetTrainerLength(); i++)
                {
                    Trainer currentTrainer = trainerList[i];
                    outFile.WriteLine(currentTrainer.GetTrainerID() + "#"); 
                    outFile.WriteLine(currentTrainer.GetTrainerName() + "#");
                    outFile.WriteLine(currentTrainer.GetTrainerEmail() + "#");
                    outFile.WriteLine(currentTrainer.GetTrainerMail() + "#");
                }
                //close trainers file
                outFile.Close();
            }
        }
        public static int GetTrainerLength()
        {
            int count = 0;
            //open file
            using(StreamReader inFile = new StreamReader("trainers.txt"))
            {
                //process file (needs to be in loop to read in one line at a time)
                string line = inFile.ReadLine(); //priming read
                while(line != null)
                {
                    line = inFile.ReadLine(); //update read (reads all data from one line at a time)
                    count++;
                }
                //close file
                inFile.Close();
                return count;
            }
        }
    }
}