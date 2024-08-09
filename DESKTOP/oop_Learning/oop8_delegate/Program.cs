
namespace oop88_delegate
{
    public class Program
    {
        static void Main(string[] args)
        {
            Employee2[] employe = new Employee2[]
            {
               new Employee2{Id=1,FirstName="hamo1",LastName="alaraby1",Gender="male",salary=500},
               new Employee2{Id=2,FirstName="hamo2",LastName="alaraby2",Gender="male",salary=600},
               new Employee2{Id=3,FirstName="hamo3",LastName="alaraby3",Gender="male",salary=800},
               new Employee2{Id=4,FirstName="hamo4",LastName="alaraby4",Gender="male",salary=700},
               new Employee2{Id=5,FirstName="hamo5",LastName="alaraby5",Gender="male",salary=900},
               new Employee2{Id=6,FirstName="hamo6",LastName="alaraby6",Gender="male",salary=200},
               new Employee2{Id=7,FirstName="hamo7",LastName="alaraby7",Gender="male",salary=300},
            };

            Report re = new Report();

            re.processes(employe, "sale >= 200", e => e.salary >= 200);
            re.processes(employe, "sale >= 500", e => e.salary >= 500);
            re.processes(employe, "sale >= 600", e => e.salary >= 600);
            re.processes(employe, "sale >= 700", e => e.salary >= 700);
            re.processes(employe, "sale >= 800", e => e.salary >= 800);

            Console.ReadKey();
        }

        static bool sale200(Employee2 e) => e.salary >= 200;
        static bool sale500(Employee2 e) => e.salary >= 500;
        static bool sale600(Employee2 e) => e.salary >= 600;
        static bool sale700(Employee2 e) => e.salary >= 700;
        static bool sale800(Employee2 e) => e.salary >= 800;
    }
}
