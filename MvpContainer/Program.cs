using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;
//using Microsoft.Extensions.DependencyInjection;
using SelfMadeContainerExample;

namespace MvpContainer
{
    internal static class Program
    {
        public static IServiceProvider ServiceProvider;

        /// <summary>
        /// 應用程式的主要進入點。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //ServiceCollection = new ServiceCollection();

            RegisterAllViews();
            Service.AddSingleton<Form1>();
            Service.AddSingleton<PresenterFactory>();
            Service.AddTransit<IPresenter, Presenter>();
            ServiceProvider = Service.BuildServiceProvider();

            Application.Run(ServiceProvider.GetService<Form1>());
        }


        private static void RegisterAllViews()
        {
            // 获取所有需要扫描的程序集
            var assemblies = new[] { Assembly.GetExecutingAssembly() };

            // 获取所有的类型
            var types = assemblies.SelectMany(a => a.GetTypes()).ToList();

            // 筛选出所有的 View 接口（命名以 'View' 结尾的接口）
            var viewInterfaces = types.Where(t => t.IsInterface && t.Name.EndsWith("View")).ToList();

            foreach (var viewInterface in viewInterfaces)
            {
                // 找到实现了该接口的类型
                var implementations = types.Where(t => t.IsClass && !t.IsAbstract && viewInterface.IsAssignableFrom(t)).ToList();

                foreach (var implementation in implementations)
                {
                    // 注册接口和实现
                    Service.AddTransit(viewInterface, implementation);
                    Service.AddTransit(implementation, implementation);
                }
            }
        }
    }
}
