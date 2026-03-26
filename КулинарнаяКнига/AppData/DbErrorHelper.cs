using System;
using System.Data.Entity.Core;

namespace КулинарнаяКнига.AppData
{
    internal static class DbErrorHelper
    {
        public static string ToUserMessage(Exception exception)
        {
            if (exception is EntityCommandExecutionException && exception.InnerException != null)
            {
                return $"Ошибка выполнения SQL-запроса: {exception.InnerException.Message}";
            }

            return exception.Message;
        }
    }
}
