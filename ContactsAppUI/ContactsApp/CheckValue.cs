using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace ContactsApp
{
   public class CheckValue
    {
        public bool IsValueCkeck(string Text)
        {

            if (Text != string.Empty )
            {
               return true;
            }

            return false;
        }

    }
}
