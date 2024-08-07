﻿using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;


class Program
{

    public static int maxCost(List<int> costs, List<string> labels, int dailyCount)
    {
        if(costs is null || labels is null || dailyCount == 0)
        {
            throw new ArgumentNullException("Invalid arguments");
        }
        
        List<(int cost, string label)> combinedList = costs.Zip(labels, (cost, label) => (cost, label)).ToList();

        int totalCosts = 0;
        int totalLaptops = combinedList.Count;

        int days = totalLaptops / dailyCount;
        int remainingLaptops = totalLaptops % dailyCount;

        for (int i = 0; i < days; i++)
        {
            var dailyCost = combinedList.Skip(i * dailyCount)
                                        .Take(dailyCount)
                                        .Sum(item => item.cost);

            totalCosts += dailyCost;
        }

        if (remainingLaptops > 0)
        {
            var remainingCost = combinedList.Skip(days * dailyCount)
                                            .Take(remainingLaptops)
                                            .Sum(item => item.cost);

            totalCosts += remainingCost;
        }

        return totalCosts;
    }


    public static List<string> mostActive(List<string> customers)
    {
        var nameCounts = customers.GroupBy(name => name)
        .Select(group => new { Name = group.Key, Count = group.Count() })
        .ToList();

        double totalNames = customers.Count;

        var namePercentages = nameCounts.Select(n => new { n.Name, Percentage = (n.Count / totalNames) * 100 })
        .ToList();

        var top5PercentNames = namePercentages.Where(n => n.Percentage >= 5)
        .Select(n => n.Name)
        .ToList();

        top5PercentNames.Sort();

        return top5PercentNames;
    }


    public static void fizzBuzz(int n)
    {
        for (int i = 0; i < n; i++)
        {
            if (i % 5 == 0 && i % 3 == 0)
            {
                Console.WriteLine("FizzBuzz");
            }
            else if (i % 3 == 0 && i % 5 != 0)
            {
                Console.WriteLine("Fizz");
            }
            else if (i % 5 == 0 && i % 3 != 0)
            {
                Console.WriteLine("Buzz");
            }
            else
            {
                Console.WriteLine(i);
            }
        }
    }


    // public static Dictionary<string, int> AverageAgeForEachCompany(List<Employee> employees)
    // {
    //     var groupedByCompany = employees.GroupBy(employee => employee.Company);

    //     Dictionary<string, int> avgAge = groupedByCompany.Select(group => new
    //     {
    //         Company = group.Key,
    //         AverageAge = (int)group.Average(employee => employee.Age)
    //     }).ToDictionary(kvp => kvp.Company, kvp => kvp.AverageAge);


    //     return avgAge;

    // }

    // public static Dictionary<string, int> CountOfEmployeesForEachCompany(List<Employee> employees)
    // {

    //     var groupedByCompany = employees.GroupBy(employee => employee.Company);

    //     Dictionary<string, int> count = groupedByCompany.Select(group => new
    //     {
    //         Company = group.Key,
    //         Count = group.Count()
    //     }).ToDictionary(kvp => kvp.Company, kvp => kvp.Count);

    //     return count;
    // }

    // public static Dictionary<string, Employee> OldestAgeForEachCompany(List<Employee> employees)
    // {

    //     var groupedByCompany = employees.GroupBy(employee => employee.Company);
    //     Dictionary<string, Employee> oldest = groupedByCompany.Select(group => new
    //     {
    //         Company = group.Key,
    //         OldestEmployee = group.OrderByDescending(employee => employee.Age).FirstOrDefault()
    //     }).ToDictionary(kvp => kvp.Company, kvp => kvp.OldestEmployee);


    //     return oldest;
    // }


    public static async Task<int> getTotalGoals(string team, int year)
    {
        HttpClient client = new HttpClient();

        int totalGoals = 0;
        int page = 1;
        string teamUrl1 = $"https://jsonmock.hackerrank.com/api/football_matches?year={year}&team1={team}&page={page}";
        string teamUrl2 = $"https://jsonmock.hackerrank.com/api/football_matches?year={year}&team2={team}&page={page}";


        var json = await client.GetStringAsync(teamUrl1);

        Console.WriteLine(json);

        return totalGoals;

    }

    // public static void Main()
    // {
    //     int countOfEmployees = int.Parse(Console.ReadLine());

    //     var employees = new List<Employee>();

    //     for (int i = 0; i < countOfEmployees; i++)
    //     {
    //         string str = Console.ReadLine();
    //         string[] strArr = str.Split(' ');
    //         employees.Add(new Employee
    //         {
    //             FirstName = strArr[0],
    //             LastName = strArr[1],
    //             Company = strArr[2],
    //             Age = int.Parse(strArr[3])
    //         });
    //     }

    //     foreach (var emp in AverageAgeForEachCompany(employees))
    //     {
    //         Console.WriteLine($"The average age for company {emp.Key} is {emp.Value}");
    //     }

    //     foreach (var emp in CountOfEmployeesForEachCompany(employees))
    //     {
    //         Console.WriteLine($"The count of employees for company {emp.Key} is {emp.Value}");
    //     }

    //     foreach (var emp in OldestAgeForEachCompany(employees))
    //     {
    //         Console.WriteLine($"The oldest employee of company {emp.Key} is {emp.Value.FirstName} {emp.Value.LastName} having age {emp.Value.Age}");
    //     }
    // }


    public static void Main(string[] args)
    {
        //await getTotalGoals("Barcelona", 2021);
    }


    // public class Employee
    // {
    //     public string FirstName { get; set; }
    //     public string LastName { get; set; }
    //     public int Age { get; set; }
    //     public string Company { get; set; }
    // }
}
