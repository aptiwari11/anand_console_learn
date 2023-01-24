using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp_Learn
{
    public class StringManupulations
    {

        public string urlcorrection(string url , string keyWord)
        {
            string idParamCondition = $"id eq {keyWord}";
            string changedUrl = string.Empty;
            int pos = url.IndexOf(keyWord);
            if (pos > 0)
            {
                if (url.EndsWith($"{keyWord}'))"))
                {
                    changedUrl = url.Remove(pos + keyWord.Length + 2);
                    //url = chnagedUrl +  )";
                    url = changedUrl + $" or ({idParamCondition}))";

                }
            }
            return url;
        }
    }
}
