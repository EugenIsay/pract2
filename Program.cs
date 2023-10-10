using bank;
class program
{
    static void Main()
    {
        ConsoleKeyInfo key;
        int u_id;
        int r_id;
        float value;
        int id;
        string full_name;
        float amount;
        bank_account[] users = new bank_account[5];
        for (int i = 0; i < users.Length; i++)
        {
            
            users[i] = new bank_account();
            users[i].open(1 + i, $"isay {1 + i}", 500 * (i + 1));

        }
        Console.WriteLine("Используйте английскую раскладку при работе");
        start:
            Console.WriteLine("Введите ваш индификатор");
            u_id = Convert.ToInt32(Console.ReadLine());
        while (true)
        {
            Console.WriteLine("Выберите действие которое хотите выполнить");
            Console.WriteLine("P - пополнить, S - показать информацию, W - снять деньги, A - снять все деньги, T - перевести, E - выйти");
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
                    users[u_id].withdraw(Convert.ToInt32(Console.ReadLine()));
                    break;
                case "A":
                    users[u_id].all();
                    break;
                case "T":
                    Console.WriteLine("Сколько вы хотите перевести?");
                    value = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Кому вы хотите перевести? (введите индификатор)");
                    r_id = Convert.ToInt32(Console.ReadLine());
                    users[u_id].transfer(value, false);
                    users[r_id].transfer(value, true);
                    break;
                case "E":
                Console.Clear();
                    goto start;
            }

        }

    }
}