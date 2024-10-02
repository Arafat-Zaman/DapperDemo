using DapperDemo.Data;
using System;

class Program
{
    static void Main(string[] args)
    {
        Database.Initialize();

        var userRepository = new UserRepository();

        // Add a new user
        var newUser = new User { Name = "John Doe", Age = 30 };
        userRepository.AddUser(newUser);
        Console.WriteLine("Added new user.");

        // Get all users
        var users = userRepository.GetAllUsers();
        Console.WriteLine("All Users:");
        foreach (var user in users)
        {
            Console.WriteLine($"Id: {user.Id}, Name: {user.Name}, Age: {user.Age}");
        }

        // Update user
        var userToUpdate = users[0];
        userToUpdate.Name = "John Updated";
        userRepository.UpdateUser(userToUpdate);
        Console.WriteLine("Updated user.");

        // Get user by id
        var singleUser = userRepository.GetUserById(userToUpdate.Id);
        Console.WriteLine($"User with Id {singleUser.Id}: Name: {singleUser.Name}, Age: {singleUser.Age}");

        // Delete user
        userRepository.DeleteUser(singleUser.Id);
        Console.WriteLine("Deleted user.");
    }
}
