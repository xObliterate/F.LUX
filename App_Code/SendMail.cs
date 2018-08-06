using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;
using System.Text;

/// <summary>
/// Summary description for SendMail
/// </summary>
public class SendMail
{
    public SendMail()
    {
    }

    public static void sendPasswordResetEmail(string email, string name)
    {
        MailMessage mailMessage = new MailMessage("YourEmail@gmail.com", email);
        Uri uri = HttpContext.Current.Request.Url;

        StringBuilder sb = new StringBuilder();
        sb.Append("Dear " + name + ",<br/><br/>");
        sb.Append("Please click on the following link to reset your password");
        sb.Append("<br/>");
        sb.Append(uri.Scheme + Uri.SchemeDelimiter + uri.Host + ":" + uri.Port + "/ChangePassword.aspx");
        sb.Append("<br/><br/>");
        sb.Append("Thank you,<br/>");
        sb.Append("<b>F.LUX</b>");

        mailMessage.IsBodyHtml = true;
        mailMessage.Body = sb.ToString();
        mailMessage.Subject = "Reset Your Password";
        SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
        smtpClient.Credentials = new System.Net.NetworkCredential()
        {
            UserName = "f.lux12321@gmail.com",
            Password = "flux12321"
        };
        smtpClient.EnableSsl = true;
        smtpClient.Send(mailMessage);
    }

    public static void sendRegistrationEmail(string email, string name, string password)
    {
        MailMessage mailMessage = new MailMessage("YourEmail@gmail.com", email);

        StringBuilder sb = new StringBuilder();
        sb.Append("Dear " + name + ",<br/><br/>");
        sb.Append("Thank you for registering with F.LUX!");
        sb.Append("<br/>");
        sb.Append("Below is your account details:");
        sb.Append("<br/><br/>");
        sb.Append("Email: " + email + "<br/>");
        sb.Append("Password: " + password + "<br/><br/>");
        sb.Append("Regards,<br/>");
        sb.Append("<b>F.LUX</b>");

        mailMessage.IsBodyHtml = true;
        mailMessage.Body = sb.ToString();
        mailMessage.Subject = "Account Registration";
        SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
        smtpClient.Credentials = new System.Net.NetworkCredential()
        {
            UserName = "f.lux12321@gmail.com",
            Password = "flux12321"
        };
        smtpClient.EnableSsl = true;
        smtpClient.Send(mailMessage);
    }

    public static void sendEnquiryEmail(string email, string name, string msg, string replymsg)
    {
        MailMessage mailMessage = new MailMessage("YourEmail@gmail.com", email);

        StringBuilder sb = new StringBuilder();
        sb.Append("Dear " + name + ",<br/><br/>");
        sb.Append("Thank you for contacting with F.LUX!");
        sb.Append("<br/>");
        sb.Append("Below is your enquiry:");
        sb.Append("<br/><br/>");
        sb.Append("Enquiry:" + msg + "<br/>");
        sb.Append("Reply: " + replymsg + "<br/><br/>");
        sb.Append("Regards,<br/>");
        sb.Append("<b>F.LUX</b>");

        mailMessage.IsBodyHtml = true;
        mailMessage.Body = sb.ToString();
        mailMessage.Subject = "Enquiry";
        SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
        smtpClient.Credentials = new System.Net.NetworkCredential()
        {
            UserName = "customerservice.flux@gmail.com",
            Password = "!password123"
        };
        smtpClient.EnableSsl = true;
        smtpClient.Send(mailMessage);
    }
}