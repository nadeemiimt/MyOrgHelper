using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Contract
{
    public class ICredentials
    {
        string UserName { get; set; }

        string Password { get; set; }
    }
}
