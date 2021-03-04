using NLog;
using XmlDataValidator.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XmlDataValidator.BLL.BusinessModels;

namespace XmlDataValidator.BLL.Services
{
    public class LoggerService : BaseService, ILoggerService
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public LoggerService(ConfigurationSettings configurationSettings) : base(configurationSettings)
        {
        }

        #region [Error]

        public void Error(Exception exception) => logger.Error(GetErrorMessage(exception));

        #endregion

        #region [Info]

        public void Info(string message) => logger.Info(message);

        #endregion

        #region [GetErrorMessage]

        private static string GetErrorMessage(Exception exception)
        {
            var errors = string.Empty;

            var ex = exception;
            while (ex != null)
            {
                errors += (errors.Length > 0 ? ". " : string.Empty) + $"{ex.Message}";
                ex = ex.InnerException;
            }

            return errors;
        }

        #endregion
    }
}
