using System;

namespace Common.Utils
{
    public static class SingletonAction
    {
        static SingletonAction()
        {
            token = string.Empty;
            code = string.Empty;
        }
        public static Action action { get; set; }

        public static string code { get; set; }
        public static string token { get; set; }
    }
}
