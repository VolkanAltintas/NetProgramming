using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Teacher teacher = new Teacher();
            teacher.Id = 1;
            teacher.FirstName = "Grace";
            teacher.LastName = "Li";
            teacher.PhoneNumber="05551231231";
            teacher.Address = "Manisa";
            List<Teacher> list = new List<Teacher>();
            list.Add(teacher);

            foreach (Teacher x in list)
                Console.WriteLine(x.FirstName + " " + x.LastName);

            Student student = new Student();
            student.Id = 1;
            student.FirstName = "Mark";
            student.LastName = "Chris";
            student.PhoneNumber = "05051231231";
            student.Address = "İzmir";
            List<Student> list2 = new List<Student>();
            list2.Add(student);

            foreach(Student x in list2)
                Console.WriteLine(x.FirstName + " "+x.LastName);

            List<IPerson> persons = new List<IPerson>();
            persons.Add(student);
            persons.Add(teacher);
            foreach (IPerson x in persons)
                Console.WriteLine(x.FirstName + " " + x.LastName);


        }
    }
}
