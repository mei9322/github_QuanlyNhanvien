using System;
using System.IO;

class DangNhap
{
    public static bool CheckCredentials(string filePath, string username, string password)
    {
        string[] lines = File.ReadAllLines(filePath);

        foreach (string line in lines)
        {
            string[] parts = line.Split(',');
            string storedUsername = parts[0];
            string storedPassword = parts[1];

            if (username == storedUsername && password == storedPassword)
            {
                return true;
            }
        }

        return false;
    }
}
