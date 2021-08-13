using System;

namespace SerialisationApp
{
    class Program
    {
        private static readonly string _path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        public static void Main(string[] args)
        {
            //CREATE Trainee
            Trainee trainee = new Trainee { FirstName = "Cathy", LastName = "French", SpartaNo = 123 };

            //CREATE a binary serialiser
            var _serialiser = new SerialiserBinary();
            
            //WRITE trainee to file(binary)
            _serialiser.SerialiseToFile($"{_path}/BinaryTrainee.bin", trainee);

            Trainee deserialiseBinaryTrainee = _serialiser.DeserialiseFromFile<Trainee>($"{_path}/BinaryTrainee.bin");

            //CREATE an XML serialiser
            var serialiserX = new SerialiserXML();
            //CREATE a course
            Course eng91 = new Course { Title = "Engineering 91", Subject = "C# SDET", StartDate = new DateTime(2021, 8, 13) };
            //ADD Trainees
            eng91.AddTrainee(trainee);
            eng91.AddTrainee(new Trainee { FirstName = "Martin", LastName = "Beard", SpartaNo = 321 });

            serialiserX.SerialiseToFile($"{_path}/XMLCourse.xml", eng91);

            //JSON
            var serialiserJ = new SerialiserJSON();

            serialiserJ.SerialiseToFile($"{_path}/JsonTrainee.json", trainee);

            var editedCourse2 = serialiserJ.DeserialiseFromFile<Course>($"{_path}/JsonTrainee.json");

            Trainee deserializedJsonTrainee = serialiserJ.DeserialiseFromFile<Trainee>($"{_path}/JsonTrainee.json");
        }
    }
}
