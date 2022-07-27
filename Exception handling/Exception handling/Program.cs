#define CUSTOMEXCEPTION
using Exception_handling;
using System.Diagnostics;

testDivision();
Console.WriteLine("Enter your email:");
var email = Console.ReadLine();
#if CUSTOMEXCEPTION
try
{
    test(email);
}
catch(Exception e)
{
    throw e;
}
#endif
Console.ReadLine();
static void testDivision()
{
    int[] number = { 8, 17, 24, 5, 25 };
    int[] divisor = { 2, 0, 0, 5 };
    int i = 0;
    while(i<number.Length)
        try
        {
            Console.WriteLine("Result: " + number[i] / divisor[i]);
        }
        catch (DivideByZeroException)
        {
            Console.WriteLine("Divide by zero exception");
        }
        catch (IndexOutOfRangeException)
        {
            Console.WriteLine("Index is Out of Range");
        }
        finally
        {
            try
            {
                Debug.WriteLine("Number is " + number[i] + ", divisor is " + divisor[i]);
            }
            catch
            {

            }
            i++;
        }
}
 static bool test(string email)
{
    var trimmedEmail = email.Trim();

    if (trimmedEmail.EndsWith("."))
    {
        throw new InvalidEmailException("Email has invalid domain name ");
    }
    try
    {
        var addr = new System.Net.Mail.MailAddress(email);
    }
    catch
    {
        throw new InvalidEmailException("Email is invalid");
    }
    return true;
}