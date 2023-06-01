using System;
using System.Collections.Generic;

class TeamMember
{
    public string Name { get; set; }
    public int SkillLevel { get; set; }
    public double CourageFactor { get; set; }

    public TeamMember(string name, int skillLevel, double courageFactor)
    {
        Name = name;
        SkillLevel = skillLevel;
        CourageFactor = courageFactor;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Plan Your Heist!");

        // Prompt the user to enter the difficulty level of the bank
        Console.Write("Enter the difficulty level of the bank: ");
        int bankDifficultyLevel = int.Parse(Console.ReadLine());

        // Create a list to store team members
        List<TeamMember> teamMembers = new List<TeamMember>();

        while (true)
        {
            // Prompt the user to enter a team member's name
            Console.Write("Enter the team member's name (or leave blank to stop adding members): ");
            string teamMemberName = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(teamMemberName))
            {
                break;
            }

            // Prompt the user to enter a team member's skill level
            Console.Write("Enter the team member's skill level (positive integer): ");
            int skillLevel = int.Parse(Console.ReadLine());

            // Prompt the user to enter a team member's courage factor
            Console.Write("Enter the team member's courage factor (between 0.0 and 2.0): ");
            double courageFactor = double.Parse(Console.ReadLine());

            // Create a new team member and add it to the list
            TeamMember teamMember = new TeamMember(teamMemberName, skillLevel, courageFactor);
            teamMembers.Add(teamMember);
        }

        Console.WriteLine($"Number of team members: {teamMembers.Count}");

        int totalSkillLevel = 0;
        Random random = new Random();

        foreach (TeamMember teamMember in teamMembers)
        {
            totalSkillLevel += teamMember.SkillLevel;
        }

        Console.WriteLine($"Total skill level of the team: {totalSkillLevel}");
        Console.Write("Enter the number of trial runs: ");
        int numberOfTrials = int.Parse(Console.ReadLine());

        int successfulRuns = 0;
        int failedRuns = 0;

        for (int i = 1; i <= numberOfTrials; i++)
        {
            int luckValue = random.Next(-10, 11);
            int bankDifficultyWithLuck = bankDifficultyLevel + luckValue;

            // Compare the team's skill level with the bank's difficulty level (including luck) and increment the appropriate counter
            if (totalSkillLevel >= bankDifficultyWithLuck)
            {
                Console.WriteLine($"Trial {i}: Heist Successful!");
                successfulRuns++;
            }
            else
            {
                Console.WriteLine($"Trial {i}: Heist Failed!");
                failedRuns++;
            }
        }

        // Display the report showing the number of successful and failed runs
        Console.WriteLine("\nHeist Report:");
        Console.WriteLine($"Successful Runs: {successfulRuns}");
        Console.WriteLine($"Failed Runs: {failedRuns}");
    }
}
