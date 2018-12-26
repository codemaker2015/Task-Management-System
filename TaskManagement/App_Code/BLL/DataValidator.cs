using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
///this class for input data varification
/// Contains static methods
/// </summary>
public class DataValidator
{
    public DataValidator()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    /// <summary>
    /// Check for valid email Id
    /// </summary>
    /// <param name="emailID">email iD</param>
    /// <returns>if email id is not valid returns msg why email id is not valid else empty string for valid email id</returns>
    public static string EmailValidator(string emailID)
    {
        if (IsEmpty(emailID))
        {
            return "Email Id cant be empty";
        }
        else if (!IsEndWithDotCom(emailID))
        {
            return "Email Id must end with '.com'";
        
        }
        else if (!IsContainsAtTheRate(emailID))
        {
            return "Email Id must contain '@'";
        }
        else
        {
            return "";
        }
    }

    /// <summary>
    /// This method checks the input string whether empty or not
    /// </summary>
    /// <param name="inputString">string to check</param>
    /// <returns>true for empty string else false</returns>
    public static bool IsEmpty(string inputString)
    {
        if (inputString.Length == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    /// <summary>
    /// this method checks input data is number or not
    /// </summary>
    /// <param name="inputString">string to check</param>
    /// <returns>true if string is a number else false</returns>
    public static bool IsNumber(string inputString)
    {
        double result;
        return double.TryParse(inputString, out result);
    }

    /// <summary>
    /// Checks input string ends with .com or not
    /// </summary>
    /// <param name="inputString">string to check</param>
    /// <returns>if ends with .com true else false</returns>
    public static bool IsEndWithDotCom(string inputString)
    {
        return inputString.EndsWith(".com");
    }

    /// <summary>
    /// checks input string contains "@" or not
    /// </summary>
    /// <param name="inputString">string to check</param>
    /// <returns>if contains '@' true else false</returns>
    public static bool IsContainsAtTheRate(string inputString)
    {
        return inputString.Contains("@");
    }

    /// <summary>
    /// checks input string is DateTime type or not
    /// </summary>
    /// <param name="inputString">string to check</param>
    /// <returns>if DateTime type true else false</returns>
    public static bool IsDate(string inputString)
    {
        DateTime result;
        return DateTime.TryParse(inputString, out result);
    }
}
