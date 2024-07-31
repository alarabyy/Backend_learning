namespace oop7_delegate
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Employee[] employe = new Employee[]
            {
               new Employee{Id=1,FirstName="hamo1",LastName="alaraby1",Gender="male",salary=500},
               new Employee{Id=2,FirstName="hamo2",LastName="alaraby2",Gender="male",salary=600},
               new Employee{Id=3,FirstName="hamo3",LastName="alaraby3",Gender="male",salary=800},
               new Employee{Id=4,FirstName="hamo4",LastName="alaraby4",Gender="male",salary=700},
               new Employee{Id=5,FirstName="hamo5",LastName="alaraby5",Gender="male",salary=900},
               new Employee{Id=6,FirstName="hamo6",LastName="alaraby6",Gender="male",salary=200},
               new Employee{Id=7,FirstName="hamo7",LastName="alaraby7",Gender="male",salary=300},
            };

            report re = new report();

            re.processless600(employe);
            re.process600(employe);
            re.process800(employe);
            re.process900(employe);
        }
    }
}
