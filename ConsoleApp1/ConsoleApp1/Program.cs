using System;
using System.Collections.Generic;
using System.Data.SQLite;

class User
{
    public int ID { get; set; }
    public string Firstname { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public int Age { get; set; }
}

class Program
{
    static List<User> users = new List<User>
    {
        new User { ID = 1, Firstname = "Вадим", Username = "VadosVagos", Password = "********", Age = 24 },
        new User { ID = 2, Firstname = "Carl", Username = "CJ", Password = "********", Age = 90 },
        new User { ID = 3, Firstname = "Владислав", Username = "Vladik", Password = "********", Age = 32 }
    };

    static void ShowUsers()
    {
        Console.WriteLine("Список пользователей:");
        Console.WriteLine("ID    Firstname    Username    Password    Age");
        foreach (var user in users)
        {
            Console.WriteLine($"{user.ID}.    {user.Firstname}        {user.Username}        {user.Password}        {user.Age}");
        }
    }

    static void AddUser()
    {
        User newUser = new User();
        newUser.ID = users.Count + 1;
        Console.Write("Введите имя нового пользователя: ");
        newUser.Firstname = Console.ReadLine();
        Console.Write("Введите логин нового пользователя: ");
        newUser.Username = Console.ReadLine();
        Console.Write("Введите пароль нового пользователя: ");
        newUser.Password = Console.ReadLine();
        Console.Write("Введите возраст нового пользователя: ");
        newUser.Age = Convert.ToInt32(Console.ReadLine());
        users.Add(newUser);
        Console.WriteLine("Пользователь успешно добавлен!");
    }

    static void UpdateUser()
    {
        Console.Write("Введите ID пользователя для обновления: ");
        int userID = Convert.ToInt32(Console.ReadLine());
        User userToUpdate = users.Find(u => u.ID == userID);
        if (userToUpdate != null)
        {
            Console.Write("Введите новое имя пользователя: ");
            userToUpdate.Firstname = Console.ReadLine();
            Console.Write("Введите новый логин пользователя: ");
            userToUpdate.Username = Console.ReadLine();
            Console.Write("Введите новый пароль пользователя: ");
            userToUpdate.Password = Console.ReadLine();
            Console.Write("Введите новый возраст пользователя: ");
            userToUpdate.Age = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Пользователь успешно обновлен!");
        }
        else
        {
            Console.WriteLine("Пользователь с указанным ID не найден.");
        }
    }

    static void DeleteUser()
    {
        Console.Write("Введите ID пользователя для удаления: ");
        int userID = Convert.ToInt32(Console.ReadLine());
        User userToDelete = users.Find(u => u.ID == userID);
        if (userToDelete != null)
        {
            users.Remove(userToDelete);
            Console.WriteLine("Пользователь успешно удален!");
        }
        else
        {
            Console.WriteLine("Пользователь с указанным ID не найден.");
        }
    }

    static void AuthorizeUser()
    {
        Console.Write("Введите логин: ");
        string username = Console.ReadLine();
        Console.Write("Введите пароль: ");
        string password = Console.ReadLine();
        User user = users.Find(u => u.Username == username && u.Password == password);
        if (user != null)
        {
            Console.WriteLine("Вы успешно авторизованы!");
        }
        else
        {
            Console.WriteLine("Неверный логин или пароль.");
        }
    }

    static void Main()
    {
        while (true)
        {
            Console.WriteLine("Работа с таблицей Users.");
            Console.WriteLine("Выберите действие:");
            Console.WriteLine("1) Посмотреть все записи");
            Console.WriteLine("2) Добавить нового пользователя");
            Console.WriteLine("3) Обновить существующего пользователя");
            Console.WriteLine("4) Удалить существующего пользователя");
            Console.WriteLine("5) Авторизоваться в системе");
            Console.Write("> ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Clear();
                    ShowUsers();
                    break;
                case "2":
                    Console.Clear();
                    AddUser();
                    break;
                case "3":
                    Console.Clear();
                    UpdateUser();
                    break;
                case "4":
                    Console.Clear();
                    DeleteUser();
                    break;
                case "5":
                    AuthorizeUser();
                    break;
                default:
                    Console.WriteLine("Некорректный выбор, попробуйте снова.");
                    break;
            }
        }
    }
}
