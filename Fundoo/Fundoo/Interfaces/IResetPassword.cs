using System;
using System.Collections.Generic;
using System.Text;

namespace Fundoo.Interfaces
{
    public interface IResetPassword
    {
        void SendPassword(string emailAddress);
    }
}
