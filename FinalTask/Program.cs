using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography.X509Certificates;

namespace FinalTask
{
    class Program
    {
        static void Main(string[] args)
        {
                string file = ("C:\\Users\\sevac\\OneDrive\\Рабочий стол\\Students.dat");

                string path = ("C:\\Users\\sevac\\OneDrive\\Рабочий стол\\Students.");
                Directory.CreateDirectory(path);

                BinaryFormatter formatter = new BinaryFormatter();
                using (var fs = new FileStream(file, FileMode.OpenOrCreate))
                {
                    Student[] students = (Student[])formatter.Deserialize(fs);
                    
                    for (int i = 0; i < students.Length; i++)
                    {
                        string groupFilePath = path + "/" + students[i].Group + ".txt";

                        using (FileStream fileStream = new FileStream(groupFilePath, FileMode.Append))
                        {
                            using (StreamWriter writer = new StreamWriter(fileStream))
                            {
                                writer.WriteLine($"{students[i].Name}, {students[i].DateOfBirth}");
                            }
                        }
                    }
                }
            }
        }

    [Serializable]
    public class Student
    {
        public string Name { get; set; }
        public string Group { get; set; }
        public DateTime DateOfBirth { get; set; }

        public Student(string name, string group, DateTime dateOfBirth)
        {
            Name = name;
            Group = group;
            DateOfBirth = dateOfBirth;
        }
    }
}