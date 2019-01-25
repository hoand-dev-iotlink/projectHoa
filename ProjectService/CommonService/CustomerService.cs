using ProjectModelCommon.ViewModel;
using ProjectService.InterfaceRep;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;
using System.Web.Helpers;

namespace ProjectService.CommonService
{
    public class CustomerService : ACustomerRep
    {
        /// <summary>
        /// set hash password
        /// </summary>
        /// <param name="password"></param>
        /// <param name="hash"></param>
        /// <returns></returns>
        public override async Task<string> SetHashPassword(string password,string hash)
        {
            using (MD5 md5Hash = MD5.Create())
            {
                string valuehash = string.Format("{0}{1}",password,hash);
                byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(valuehash));

                // Create a new Stringbuilder to collect the bytes
                // and create a string.
                StringBuilder sBuilder = new StringBuilder();

                // Loop through each byte of the hashed data 
                // and format each one as a hexadecimal string.
                for (int i = 0; i < data.Length; i++)
                {
                    sBuilder.Append(data[i].ToString("x2"));
                }

                // Return the hexadecimal string.
                return await Task.FromResult(sBuilder.ToString());
            }
        }

        public override async Task<bool> SendMail(string sendEmail, string subjectEmail, string bodyEmail)
        {
            try
            {
                //Configuring webMail class to send emails  
                //gmail smtp server  
                WebMail.SmtpServer = "smtp.gmail.com";
                //gmail port to send emails  
                WebMail.SmtpPort = 587;
                WebMail.SmtpUseDefaultCredentials = true;
                //sending emails with secure protocol  
                WebMail.EnableSsl = true;
                //EmailId used to send emails from application  
                WebMail.UserName = WebConfigurationManager.AppSettings["AdminEmail"];//"projectauthen@gmail.com";
                WebMail.Password = WebConfigurationManager.AppSettings["PassEmail"]; //"123khongyeu";

                //Sender email address.  
                //WebMail.From = "hoand@iotlink.com.vn";

                //Send email  
                WebMail.Send(
                    to: sendEmail,
                    subject: subjectEmail,
                    body: bodyEmail,
                    isBodyHtml: true
                    );
                return await Task.FromResult(true);
            }
            catch (Exception ex)
            {
                //throw ex;
                return await Task.FromResult(false);
            }
            
        }
    }
}
