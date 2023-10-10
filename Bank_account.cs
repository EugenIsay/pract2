using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace bank
{
    class bank_account
    {
        private int id;
        private string full_name;
        private float amount;
        public void open(int id, string full_name, float amount)
        {
            this.id = id;
            this.full_name = full_name; 
            this.amount = amount;
        }
        public void show_info(out int id, out string full_name, out float amount)
        {
            id = this.id;
            full_name = this.full_name;
            amount = this.amount;
        }
        public void put(float amount)
        {
            this.amount += amount;
            Console.WriteLine("Операция по пополнению счёта успешно проведена");
        }
        public void withdraw(float amount)
        {
            if (this.amount - amount < 0)
            {
                Console.WriteLine("Вас счёт не может уйти в минус!");
            }
            else
            {
                this.amount -= amount;
                Console.WriteLine("Операция по снятию денег успешно проведена");
            }
        }
        public void all()
        {
            amount = 0;
            Console.WriteLine("Операция по снятию всех денег успешно проведена");
        }
        public void transfer(float amount, bool t)
        {

            if (t == false)
                this.amount -= amount;
            else if (t == true)
                this.amount += amount;
        }
    }
}