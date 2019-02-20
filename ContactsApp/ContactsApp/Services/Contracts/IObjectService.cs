using System;
using System.Collections.Generic;
using System.Text;

namespace ContactsApp.Services.Contracts
{
    public interface IObjectService
    {
        T GetInstance<T>() where T : class;
    }
}
