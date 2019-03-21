using System;
using System.IO;


namespace Project_Application
{
    class File_Acess
    {

        static string Path = Properties.Settings.Default.path;

        static internal void NewMessage(Users.Message d)
        {
            string textToWrite = $"From:{d.Sender} To:{d.Receiver} At: {d.Datetime} | {d.Content}";
            string path = Path + $"\\MessageID{d.MessageId}.txt";
            File.WriteAllText(path, textToWrite);
        }

        static internal void EditMessage(Users.Message d)
        {
            string textToOverwrite = $"From:{d.Sender} To:{d.Receiver} At: {d.Datetime} | {d.Content} *MESSAGE EDITED AT {DateTime.UtcNow}*";
            string path = Path + $"\\MessageID{d.MessageId}.txt";
            File.WriteAllText(path, textToOverwrite);
        }

        static internal void DeleteMessage(Users.Message d)
        {
            string path = Path + $"\\MessageID{d.MessageId}.txt";
            File.Delete(path);
        }
    }
}
