using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkExample
{
    class Program
    {
        static void Main(string[] args)
        {
            using (PeopleContainer4 peoples = new PeopleContainer4())
            {
                peoples.PeopleSet.Add(new People()
                {
                    Id = 1,
                    Name = "Jack",
                    SecondName = "Mack",
                    Adress = "New York"
                });
                peoples.SaveChanges();
            }
            
        }
    }
}
