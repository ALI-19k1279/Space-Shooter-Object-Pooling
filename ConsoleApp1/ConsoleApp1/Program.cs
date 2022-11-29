using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;


namespace ObjectPooling
{
    class Factory
    {
        // Maximum objects allowed!
        private static int _PoolMaxSize = 4;
        // My Collection Pool
        private static readonly Queue objPool = new Queue(_PoolMaxSize);
        public Student GetStudent()
        {
            Student oStudent;
            // Check from the collection pool. If exists, return
            // object; else, create new
            if (Student.ObjectCounter >= _PoolMaxSize &&
               objPool.Count > 0)
            {
                // Retrieve from pool
                oStudent = RetrieveFromPool();
            }
            else
            {
                oStudent = GetNewStudent();
            }
            return oStudent;
        }
        private Student GetNewStudent()
        {
            // Creates a new Student
            Student oStu = new Student();
            objPool.Enqueue(oStu);
            return oStu;
        }
        protected Student RetrieveFromPool()
        {
            Student oStu;
            // Check if there are any objects in my collection
            if (objPool.Count > 0)
            {
                oStu = (Student)objPool.Dequeue();
                Student.ObjectCounter--;
            }
            else
            {
                // Return a new object
                oStu = new Student();
            }
            return oStu;
        }
    }
    class Student
    {
        public static int ObjectCounter = 0;
        public Student()
        {
            ++ObjectCounter;
        }
        private string _Firstname;
        private string _Lastname;
        private int _RollNumber;
        private string _Class;


        public string Firstname
        {
            get
            {
                return _Firstname;
            }
            set
            {
                _Firstname = value;
            }
        }

        public string Lastname
        {
            get
            {
                return _Lastname;
            }
            set
            {
                _Lastname = value;
            }
        }

        public string Class
        {
            get
            {
                return _Class;
            }
            set
            {
                _Class = value;
            }
        }

        public int RollNumber
        {
            get
            {
                return _RollNumber;
            }
            set
            {
                _RollNumber = value;
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Factory fa = new Factory();
            Student myStu = fa.GetStudent();
            myStu.Firstname = "Ali";
            myStu.RollNumber = 1279;
            Console.WriteLine("First object");
            Console.WriteLine(myStu +" " +myStu.Firstname + " " + myStu.RollNumber);
            Student myStu1 = fa.GetStudent();
            Console.WriteLine("recycled instance from pool 2nd obj");
            Console.WriteLine(myStu1 + " " + myStu1.Firstname + " " + myStu1.RollNumber);
            Student myStu2 = fa.GetStudent();
            Console.WriteLine("2nd recycled instance from pool 3rd obj");
            Console.WriteLine(myStu2 + " " + myStu2.Firstname + " " + myStu2.RollNumber);
          


            Console.Read();
        }
    }
}