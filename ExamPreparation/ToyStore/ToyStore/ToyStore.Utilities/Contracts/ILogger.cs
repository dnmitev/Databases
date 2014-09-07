using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyStore.Utilities.Contracts
{
    public interface ILogger<T>
    {
        void Log(T data);
    }
}
