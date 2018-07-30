using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;

/// <summary>
/// Summary description for InputValidation
/// </summary>
public class InputValidation
{
    public static bool ValidatePassword(string p1, string p2)
    {
        bool pass = true;
        if (p1.Equals(p2) == false)
        {
            pass = false;
        }
        else if (p1.Length < 6 && p1.Length < 6)
        {
            pass = false;
        }
        return pass;
    }

    public static bool ValidatePhone(string phone)
    {
        string pattern = @"^(8|9)[0-9]{7}$";
        bool pass = ((Regex.Match(phone, pattern).Success) ? true : false);
        return pass;
    }

    public static bool ValidateFax(string fax)
    {
        string pattern = @"^(6)[0-9]{7}$";
        bool pass = ((Regex.Match(fax, pattern).Success) ? true : false);
        return pass;
    }

    public static bool ValidateEmail(string email)
    {
        string pattern = @"^[0-9a-zA-Z-_\$#.]+@[0-9a-zA-Z-_\$#]+\.[a-zA-Z]{2,5}$";
        bool pass = ((Regex.Match(email, pattern).Success) ? true : false);
        return pass;
    }

    public static bool ValidateCC(string cc)
    {
        string pattern = @"^(?:4[0-9]{12}(?:[0-9]{3})?|5[1-5][0-9]{14}|3[47][0-9]{13}|3(?:0[0-5]|[68][0-9])[0-9]{11}|6(?:011|5[0-9]{2})[0-9]{12}(?:2131|1800|35\d{3})\d{11})$";
        bool pass = ((Regex.Match(cc, pattern).Success) ? true : false);
        return pass;
    }

    public static void ClearInputs(ControlCollection ctrls)
    {
        foreach (Control ctrl in ctrls)
        {
            if (ctrl is TextBox)
                ((TextBox)ctrl).Text = string.Empty;
            ClearInputs(ctrl.Controls);
        }
    }
    //////


    public static bool IsValidCvv(string Cvv)
    {
        string pattern = @"^\d{3}$";
        bool isValid = ((Regex.Match(Cvv, pattern).Success) ? true : false);
        return isValid;
    }

    public static bool IsValidExpiration(string ExpiryDate)
    {
        string[] date = Regex.Split(ExpiryDate, "/");
        string[] currentDate = Regex.Split(DateTime.Now.ToString("MM/yyyy"), "/");
        int compareYears = string.Compare(date[1], currentDate[1]);
        int compareMonths = string.Compare(date[0], currentDate[0]);

        //if expiration date is in MM/YYYY format
        if (Regex.Match(ExpiryDate, @"^\d{2}/\d{4}$").Success)
        {
            //if month is "01-12" and year starts with "20"
            if (Regex.Match(date[0], @"^[0][1-9]|[1][0-2]$").Success)
            {
                //if expiration date is after current date
                if ((compareYears == 1) || (compareYears == 0 && (compareMonths == 1)))
                {
                    return true;
                }
            }
        }
        return false;
    }
}