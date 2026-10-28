using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;

public static class LockoutManager
{
    private static string filePath = Path.Combine(
        Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
        "GIBDD_Lockout.dat");

    public static DateTime? GetLockoutTime()
    {
        if (File.Exists(filePath))
        {
            string content = File.ReadAllText(filePath);
            if (DateTime.TryParse(content, out DateTime lockTime))
            {
                return lockTime;
            }
        }
        return null;
    }

    public static void SaveLockoutTime(DateTime time)
    {
        Directory.CreateDirectory(Path.GetDirectoryName(filePath));
        File.WriteAllText(filePath, time.ToString());
    }

    public static void ClearLockout()
    {
        if (File.Exists(filePath))
            File.Delete(filePath);
    }
}