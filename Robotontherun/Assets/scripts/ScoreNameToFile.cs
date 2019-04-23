using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace filewriter
{
    public class ScoreNameToFile
    {
        private String UserNameFile;
        private String ScoreFile;

        public ScoreNameToFile()
        {
            UserNameFile = "PlayerName.dat";
            ScoreFile = "TotalScore.dat";
            
        }

        public void UpdateScore(String score)
        {
            if (this.ScoreFileExist())
            {
                File.Delete(ScoreFile);
                var file = File.Open(ScoreFile, FileMode.Create, FileAccess.ReadWrite);

                var add = new StreamWriter(file);

                add.WriteLine(score);
                add.Close();
                file.Close();
            }
            else
            {
                var file = File.Open(ScoreFile, FileMode.Create, FileAccess.ReadWrite);

                var add = new StreamWriter(file);

                add.WriteLine(score);
                add.Close();
                file.Close();
                
            }
        }

        public String GetScore()
        {
            if (this.ScoreFileExist())
            {
                var file = File.Open(ScoreFile, FileMode.Open, FileAccess.Read);

                var data = new StreamReader(file);

                String DataToReturn;

                DataToReturn = data.ReadLine();

                data.Close();
                file.Close();
                return DataToReturn;
            }
            else
            {
                return "0";
            }
        }

        
        private bool ScoreFileExist()
        {
            if(File.Exists(ScoreFile))
            {
                return true;
            }
            else
            {
                return false;
            }

        }    

        public void DeletefileScore()
        {
            if (this.ScoreFileExist())
            {
                File.Delete(ScoreFile);
            }
        }

        public void UpdateUser(String name)
        {
            if (this.UserFileExist())
            {
                File.Delete(UserNameFile);
                var file = File.Open(UserNameFile, FileMode.Create, FileAccess.ReadWrite);

                var add = new StreamWriter(file);

                add.WriteLine(name);
                add.Close();
                file.Close();
            }
            else
            {
                var file = File.Open(UserNameFile, FileMode.Create, FileAccess.ReadWrite);

                var add = new StreamWriter(file);

                add.WriteLine(name);
                add.Close();
                file.Close();

            }
        }

        public String GetUserName()
        {
            if (this.UserFileExist())
            {
                var file = File.Open(UserNameFile, FileMode.Open, FileAccess.Read);

                var data = new StreamReader(file);

                String DataToReturn;

                DataToReturn = data.ReadLine();

                data.Close();
                file.Close();
                return DataToReturn;
            }
            else
            {
                return "No User Name";
            }
        }


        private bool UserFileExist()
        {
            if (File.Exists(UserNameFile))
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public void DeleteUserFile()
        {
            if (this.UserFileExist())
            {
                File.Delete(UserNameFile);
            }
        }
    }
}
