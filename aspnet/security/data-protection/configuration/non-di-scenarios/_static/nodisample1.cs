using System;
using System.IO;
using Microsoft.AspNet.DataProtection;
 
public class Program
{
    public static void Main(string[] args)
    {
        // get the path to %LOCALAPPDATA%\myapp-keys
        string destFolder = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
            "myapp-keys");
 
        // instantiate the data protection system at this folder
        var dataProtectionProvider = new DataProtectionProvider(
            new DirectoryInfo(destFolder));
 
        var protector = dataProtectionProvider.CreateProtector("Program.No-DI");
        Console.Write("Enter input: ");
        string input = Console.ReadLine();
 
        // protect the payload
        string protectedPayload = protector.Protect(input);
        Console.WriteLine($"Protect returned: {protectedPayload}");
 
        // unprotect the payload
        string unprotectedPayload = protector.Unprotect(protectedPayload);
        Console.WriteLine($"Unprotect returned: {unprotectedPayload}");
    }
}
 
/*
 * SAMPLE OUTPUT
 *
 * Enter input: Hello world!
 * Protect returned: CfDJ8FWbAn6...ch3hAPm1NJA
 * Unprotect returned: Hello world!
 */