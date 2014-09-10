namespace Company.Utilities.Contracts
{
    using System;
    using System.Linq;

    public interface ILogger<T>
    {
        void Log(T data);
    }
}