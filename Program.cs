using System.Collections.Generic;
namespace DatabaseConPoc
{
    class Program
    {
        static void Main(string[] args)
        {
            DBConnect dbCon = new DBConnect();
            dbCon.SQLQuery = "select * from student";
            List<ResultFromDB> results = new List<ResultFromDB>();
            results = dbCon.ReadData();
            if (results != null)
            {
                foreach (var result in results)
                {
                    System.Console.WriteLine("Student name {0} And Age {1}", result.Name, result.Age);
                }
            }
            else
            {
                System.Console.WriteLine("No record found");
            }
        }
    }
}
