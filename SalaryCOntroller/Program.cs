using System;
using System.Collections.Generic;
using SalaryCOntroller.Entities;
using System.IO;
using System.Linq;
using System.Globalization;

namespace SalaryCOntroller
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Employee> Control = new List<Employee>();

            Console.Write("Digite onde esta localizado o arquivo: ");
            string document = Console.ReadLine();
            Console.Write("Digite o salario Para filtrar as informações de acordo: ");
            double LimitSal = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            try
            {

                using (StreamReader doc = File.OpenText(document))
                {
                    while (!doc.EndOfStream)
                    {
                        string[] fields = doc.ReadLine().Split(',');
                        string name = fields[0];
                        string email = fields[1];
                        double Sal = double.Parse(fields[2], CultureInfo.InvariantCulture);
                        Control.Add(new Employee(name, email, Sal));
                    }

                    var emails = Control.Where(obj => obj.Salary > LimitSal).OrderBy(obj => obj.Email).Select(obj => obj.Email);
                    var names = Control.Where(obj => obj.Salary > LimitSal).OrderBy(obj => obj.Name).Select(obj => obj.Name);
                    var EmpSalary = Control.Where(obj => obj.Salary > LimitSal).OrderBy(obj => obj.Salary).Select(obj => obj.Salary);

                    Console.WriteLine("Informações dos funcionarios que recebem mais de R$ " + LimitSal.ToString("F2", CultureInfo.InvariantCulture) + " mensais");

                    Console.WriteLine();

                    foreach (string email in emails)
                    {
                        Console.WriteLine("Email: " + email);
                    }
                    Console.WriteLine();
                    Console.WriteLine("Os Respectivos nomes: ");
                   foreach (string name in names)
                   {
                    Console.WriteLine(name);
                   }
                    
                }
            }
            catch (IOException e)
            {

                Console.WriteLine("An error occurred");
                Console.WriteLine(e.Message);
            }
        }
    }
}

