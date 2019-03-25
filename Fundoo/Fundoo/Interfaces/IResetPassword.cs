using System;
using System.Collections.Generic;
using System.Text;

namespace Fundoo.Interfaces
{
    public interface ResetPassword
    {
        void SendPassword(string emailAddress);
    }
}
