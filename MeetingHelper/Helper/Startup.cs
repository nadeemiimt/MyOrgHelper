using BusinessLogic.DI;
using Unity;

namespace DailyHelper.Helper
{
    public static class Startup
    {
        public static UnityContainer Register()
        {
            var container = new UnityContainer();

            container.AddNewExtension<DependencyRegisterExtension>();

            container.RegisterType<Form3>();
            container.RegisterType<Form1>();
            container.RegisterType<Form2>();
            container.RegisterType<Form4>();
            container.RegisterType<Form5>();

            return container;
        }
    }
}
