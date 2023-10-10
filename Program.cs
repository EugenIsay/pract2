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
        Console.WriteLine($"Введите сколько пользователей в программе");
        bank_account[] users = new bank_account[Convert.ToInt32(Console.ReadLine())];
        for (int i = 0; i < users.Length; i++)
        {
            users[i] = new bank_account();
            Console.WriteLine($"Введите информацию для {i + 1} пользователя");
            Console.WriteLine($"Его id это его порядковый номер");
            Console.WriteLine($"Его Имя:");
            full_name = Console.ReadLine();
            Console.WriteLine($"Сколько средств у него на счету:");
            amount = float.Parse(Console.ReadLine());
            if (amount < 0)
            {
                i--;
                Console.WriteLine("Вас счёт не может уйти в минус!");
            }
            else
            {
                users[i].open(i, full_name, amount);
            }
            //Автозаполнение
            //users[i].open(1 + i, $"isay {1 + i}", 500 * (i + 1));

        }
        Console.WriteLine("Используйте английскую раскладку при работе");
        start:
        Console.WriteLine("Введите ваш индификатор");
        u_id = Convert.ToInt32(Console.ReadLine()) - 1;
        while (true)
        {
            Console.WriteLine("Выберите действие которое хотите выполнить");
            Console.WriteLine("P - пополнить, S - показать информацию, W - снять деньги, A - снять все деньги, T - перевести, E - выйти");
            key = Console.ReadKey(true);
            switch (key.Key.ToString())
            {
                case "P":
                    Console.WriteLine("Сколько вы хотите положить?");
                    users[u_id].put(float.Parse(Console.ReadLine()));
                    break;
                case "S":
                    users[u_id].show_info(out id, out full_name, out amount);
                    Console.WriteLine(id);
                    Console.WriteLine(full_name);
                    Console.WriteLine(amount);
                    break;
                case "W":
                    Console.WriteLine("Сколько вы хотите снять?");
                    users[u_id].withdraw(float.Parse(Console.ReadLine()));
                    break;
                case "A":
                    users[u_id].all();
                    break;
                case "T":
                    Console.WriteLine("Сколько вы хотите перевести?");
                    value = float.Parse(Console.ReadLine());
                    users[u_id].show_info(out id, out full_name, out amount);
                    if (amount - value < 0)
                    {
                        Console.WriteLine("Вас счёт не может уйти в минус!");
                    }
                    else
                    {
                        Console.WriteLine("Кому вы хотите перевести? (введите индификатор)"); 
                        r_id = Convert.ToInt32(Console.ReadLine()) - 1;
                        users[u_id].transfer(value, false);
                        users[r_id].transfer(value, true);
                    }
                    break;
                case "E":
                    Console.WriteLine("Вы вышли из своего id");
                    goto start;
            }

        }

    }
}