using System;

namespace XmlDataValidator.BLL.Interfaces
{
    public interface ILoggerService
    {
        void Error(Exception exception);
        void Info(string message);
    }
}