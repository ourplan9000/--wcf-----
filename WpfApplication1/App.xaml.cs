using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApplication1
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        [DebuggerNonUserCode()]
        static void Main(string[] args)
        {
            WpfApplication1.App app = new WpfApplication1.App();

          
            
            app.Run();
        }
    }
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        Mutex mutex;
        public App()
        {
            bool firstApplicattionInstance;
            string UniqueAppStr = Assembly.GetExecutingAssembly().ToString();

            mutex = new Mutex(true, UniqueAppStr, out firstApplicattionInstance);
            if (!firstApplicattionInstance)
            {
                //MessageBox.Show(UniqueAppStr);
                MessageBox.Show("这个程序已经在运行！");
                mutex.ReleaseMutex();
                Environment.Exit(Environment.ExitCode);
                // return;
            }
           
            this.MainWindow = MainWindow;
            this.ShutdownMode = ShutdownMode.OnMainWindowClose;
            this.DispatcherUnhandledException += App_DispatcherUnhandledException;
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
        }

        void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {

            MessageBox.Show(e.ExceptionObject.ToString());
           
          
        }

        void App_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            MessageBox.Show(e.Exception.StackTrace.ToString());
            e.Handled = true;
        }
    }
}
