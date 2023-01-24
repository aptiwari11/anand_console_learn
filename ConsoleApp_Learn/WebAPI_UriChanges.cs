using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp_Learn
{
    public class WebAPI_UriChanges
    {

       public void UrIchange()
        {
            // To deal with special chars in UR string , like odata query has single quote and that needs to replacted with 4 sigle quotes. Other ways of handling this situation is to manupulate the sting an eacape the chars.  
            string serviceUrl = "anand's";
            string url = "https://qa01-main.prophet21lab.com/" + serviceUrl;
            string[] urlSplitStrings = url.Split(new[] { url }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string urlSplitString in urlSplitStrings)
            {
                if (urlSplitString.Contains("'"))
                {
                    url.Replace(urlSplitString, Uri.EscapeDataString(urlSplitString));
                }
            }
            if (serviceUrl.Contains("'"))
            {
                serviceUrl.Replace("'", "''''");
                serviceUrl.Replace("'", Uri.EscapeDataString(serviceUrl));
                
            }

            Uri.EscapeDataString(url);
        }
    }
}
