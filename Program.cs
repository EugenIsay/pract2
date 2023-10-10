using bank;
class program
{
    static void Main()
    {
        ConsoleKeyInfo key;
        int u_id;
        int id;
        string full_name;
        float amount;
        //bank_account user = new bank_account();
        //user.open(1, "isay", 500);
        bank_account[] users = new bank_account[5];
        for (int i = 0; i < users.Length; i++)
        {
            users[i] = new bank_account();
            users[i].open(1 + i, $"isay {1 + i}", 500 * (i + 1));
        }
        Console.WriteLine("Используйте английскую раскладку при работе");
        Console.WriteLine("Введите ваш индификатор");
        u_id = Convert.ToInt32(Console.ReadLine()) - 1;
        while (true)
        {
            Console.WriteLine("Выберите действие которое хотите выполнить");
            Console.WriteLine("P - пополнить, S - показать информацию, W - снять деньги, T - перевести");
            key = Console.ReadKey(true);
            switch (key.Key.ToString())
            {
                case "P":
                    Console.WriteLine("Сколько вы хотите положить?");
                    users[u_id].put(Convert.ToInt32(Console.ReadLine()));
                    break;
                case "S":
                    users[u_id].show_info(out id, out full_name, out amount);
                    Console.WriteLine(id);
                    Console.WriteLine(full_name);
                    Console.WriteLine(amount);
                    break;
                case "W":
                    Console.WriteLine("Сколько вы хотите снять?");
                    Console.WriteLine("A - снять всё, W - снять определённое количество");
                    key = Console.ReadKey(true);
                    if (key.Key.ToString() == "A")
                    {
                        users[u_id].all();
                    }
                    else
                    {
                        users[u_id].withdraw(Convert.ToInt32(Console.ReadLine()));
                    }
                    break;
                case "T":
                    Console.WriteLine("Сколько вы хотите перевести?");
                    users[u_id].transfer();
                    break;

            }

        }

    }
}