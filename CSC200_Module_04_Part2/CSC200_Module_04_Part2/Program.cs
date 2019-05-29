using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace CSC200_Module_04_Part2
{
    class Program
    {
        public static void DoSomething(IPrintable obj)
        {
            obj.Print();
        }
        static void Main(string[] args)
        {
            //MyStaticProperty = 17;
            ////MyProperty = 17;

            //A.MyStaticProperty = 17; // Access static property from non-static class A
            //A myObjA = new A();
            //myObjA.MyProperty = 27;

            //S.MyStaticProperty = 27;
            //// S myObjB = new S(); // Can't create a new class for something that's static

            //IMyContract myC = new C();
            //((C)myC).a = 7; // Need to cast C to gain access to a

            IPrintable myStudent = new Student("Alice", "CS", 3.78);
            IPrintable myCourse = new Course();
            DoSomething(myStudent);
            DoSomething(myCourse);



            // ArrayList myStudentList = new ArrayList();

            List<Student> myStudentList = new List<Student>();
            List<int> myIntList = new List<int>();
            myIntList.Add(23);
            myIntList.Add(17);

            myStudentList.Add(new Student("Alice", "CS", 4.0));
            myStudentList.Add(new Student("Bob", "Math", 2.7));
            myStudentList.Add(new Student("Kyle", "History", 3.2));
            myStudentList.Add(new Student("Joyce", "undecided", 3.7));
            myStudentList.Add(new Student("Reginald", "Romanian", 3.1));
            
            //myStudentList.Add(12);
            //myStudentList.Add(5);
            //myStudentList.Add(15);
            //myStudentList.Add(19);
            //myStudentList.Add(17); // will run into error if one value is double instead of int

            foreach (Student item in myStudentList)
            {
                //Console.WriteLine(item);
                item.Print();
            }




            myStudentList.Sort(); // uses regular IComparable
            //myStudentList.Sort(new StudentComparerByGPA());
            Console.WriteLine("After: ");
            foreach (Student item in myStudentList)
            {
                //Console.WriteLine(item);
                item.Print();
            }

            
        }

        public void NonStaticMethod()
        {
            MyProperty = 17;
            MyStaticProperty = 27;
        }

        public int MyProperty { get; set; }
        public static int MyStaticProperty { get; set; }
    }

    class A
    {
        public int MyProperty { get; set; }
        public static int MyStaticProperty { get; set; }
    }

    static class S
    {
        // public int MyProperty { get; set; } // Can't access non-static in static class
        public static int MyStaticProperty { get; set; }
    }

    interface IMyContract
    {
        int MyProperty { get; set; } // everything inside the interface is public
        string BuildHouse();
    }

    public class C : IMyContract
    {
        public int a;

        public string BuildHouse() // Must follow interface's code block and all must be public
        {
            return "House built";
        }

        public int MyProperty { get; set; }
    }

    public interface I1
    {
        void method();
    }

    public interface I2
    {
        void method();
    }

    public class D : I1, I2
    {
        void I1.method()
        {

        }
        void I2.method()
        {

        }
    }

    public interface IPrintable
    {
        void Print();
    }

    public class Student : IPrintable, IComparable
    {
        public void Print()
        {
            Console.WriteLine(Name + " : " + Major + " : GPA = " + GPA);
        }

        public int CompareTo(object obj)
        {
            //this.Name compare to obj.Name;
            //return this.Name.CompareTo(((Student)obj).Name); // this compares the name

            if (this.GPA < ((Student)obj).GPA) // compares by GPA
                return -1;
            else if (this.GPA > ((Student)obj).GPA)
                return 0;
            else
                return -1;
            //return (int)(this.GPA - ((Student)obj).GPA); //does not work well
        }

        public string Name { get; set; }
        public string Major { get; set; }
        public double GPA { get; set; }

        public Student( string nm, string mj, double gpa)
        {
            Name = nm;
            Major = mj;
            GPA = gpa;
        }

    }

    public class Course : IPrintable
    {
        public string CourseName { get; set; }
        public string InstructorName { get; set; }
        public void Print()
        {
            Console.WriteLine(CourseName + " : " + InstructorName);
        }
    }

    class StudentComparerByName : IComparer
    {
        public int Compare(object x, object y)
        {
            // return ((Student) x).Name.CompareTo(((Student)y).Name);
            return String.Compare(((Student)x).Name, (((Student)y).Name));
        }
    }

    class StudentComparerByGPA : IComparer
    {
        public int Compare(object x, object y)
        {
            double xGPA = ((Student)x).GPA;
            double yGPA = ((Student)y).GPA;

            if (xGPA < yGPA)
                return -1;
            else if (xGPA == yGPA)
                return 0;
            else
                return 1;
        }
    }

    class StudentComparerByMajor : IComparer
    {
        public int Compare(object x, object y)
        {
            return String.Compare(((Student)x).Major, (((Student)y).Major));
        }
    }
}

