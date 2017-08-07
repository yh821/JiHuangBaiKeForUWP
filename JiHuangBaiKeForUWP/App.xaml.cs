﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.ApplicationModel.VoiceCommands;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using JiHuangBaiKeForUWP.Model;

namespace JiHuangBaiKeForUWP
{
    /// <summary>
    /// 提供特定于应用程序的行为，以补充默认的应用程序类。
    /// </summary>
    sealed partial class App : Application
    {
        /// <summary>
        /// 初始化单一实例应用程序对象。这是执行的创作代码的第一行，
        /// 已执行，逻辑上等同于 main() 或 WinMain()。
        /// </summary>
        public App()
        {
            InitializeComponent();
            Suspending += OnSuspending;
        }

        /// <summary>
        /// 注册语音指令
        /// </summary>
        private static async Task InsertVoiceCommands()
        {
            await VoiceCommandDefinitionManager.InstallCommandDefinitionsFromStorageFileAsync(
                await StorageFile.GetFileFromApplicationUriAsync(new Uri("ms-appx:///frontCortanaVoiceCommands.xml")));
        }

        /// <summary>
        /// 全局变量初始化
        /// </summary>
        public void GlobalInitializeComponent()
        {
            // 读取游戏版本
            Global.GameVersion = SettingSet.GameVersionSettingRead();
            // 设置AutoSuggestBox的数据源
            Global.SetAutoSuggestBoxItemSource();
        }

        /// <summary>
        /// 在应用程序由最终用户正常启动时进行调用。
        /// 将在启动应用程序以打开特定文件等情况下使用。
        /// </summary>
        /// <param name="e">有关启动请求和过程的详细信息。</param>
        protected override async void OnLaunched(LaunchActivatedEventArgs e)
        {
            // 帧计数器
            //#if DEBUG
            //    if (System.Diagnostics.Debugger.IsAttached)
            //    {
            //        this.DebugSettings.EnableFrameRateCounter = true;
            //    }
            //#endif 

            // 安装VCD命令文件
            await InsertVoiceCommands();

            //全局初始化
            GlobalInitializeComponent();

            var rootFrame = Window.Current.Content as Frame;

            // 不要在窗口已包含内容时重复应用程序初始化，
            // 只需确保窗口处于活动状态
            if (rootFrame == null)
            {
                // 创建要充当导航上下文的框架，并导航到第一页    
                rootFrame = new Frame();

                rootFrame.NavigationFailed += OnNavigationFailed;

                if (e.PreviousExecutionState == ApplicationExecutionState.Terminated)
                {
                    //TODO: 从之前挂起的应用程序加载状态
                }

                // 将框架放在当前窗口中
                Window.Current.Content = rootFrame;
            }

            if (e.PrelaunchActivated == false)
            {
                if (rootFrame.Content == null)
                    rootFrame.Navigate(typeof(MainPage), e.Arguments);
                // 确保当前窗口处于活动状态
                Window.Current.Activate();
            }

            ((Frame) Window.Current.Content).RequestedTheme =
                SettingSet.ThemeSettingRead() ? ElementTheme.Dark : ElementTheme.Light;

        }

        /// <summary>
        /// 导航到特定页失败时调用
        /// </summary>
        ///<param name="sender">导航失败的框架</param>
        ///<param name="e">有关导航失败的详细信息</param>
        private void OnNavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            throw new Exception("Failed to load Page " + e.SourcePageType.FullName);
        }

        /// <summary>
        /// 在将要挂起应用程序执行时调用。  在不知道应用程序
        /// 无需知道应用程序会被终止还是会恢复，
        /// 并让内存内容保持不变。
        /// </summary>
        /// <param name="sender">挂起的请求的源。</param>
        /// <param name="e">有关挂起请求的详细信息。</param>
        private void OnSuspending(object sender, SuspendingEventArgs e)
        {
            var deferral = e.SuspendingOperation.GetDeferral();
            //TODO: 保存应用程序状态并停止任何后台活动
            deferral.Complete();
        }

        protected override void OnActivated(IActivatedEventArgs args)
        {
            base.OnActivated(args);
            // 如果程序不是因为语音命令而激活的，就不处理
            if (args.Kind != ActivationKind.VoiceCommand) return;

            //将参数转为语音指令事件对象
            var vcargs = (VoiceCommandActivatedEventArgs)args;
            // 分析被识别的命令
            var res = vcargs.Result;
            var resText = vcargs.Result.Text;
            // 获取被识别的命令的名字
            var cmdName = res.RulePath[0];
            Type navType = null;
            string propertie = null;
            //判断用户使用的是哪种语音指令
            switch (cmdName)
            {
                case "searchItem":
                    navType = typeof(MainPage);
                    //获取语音指令的参数
                    propertie = res.SemanticInterpretation.Properties["search"][0];
//                    propertie = resText;
//                    System.Diagnostics.Debug.Assert(false, propertie);
                    break;
//                case "QueryFlight":
//                    navType = typeof(QueryPage);
//                    //获取语音指令的参数
//                    propertie = res.SemanticInterpretation.Properties["City"][0];
//                    break;
//                case "NavToPage":
//                    //获取语音指令的参数
//                    propertie = res.SemanticInterpretation.Properties["Destination"][0];
//
//                    //根据 propertie 参数决定跳转到指定界面，这里就不判断了
//                    navType = typeof(QueryPage);
//                    break;
            }
            //获取页面引用
            var root = Window.Current.Content as Frame;
            if (root == null)
            {
                root = new Frame();
                Window.Current.Content = root;
            }
            root.Navigate(navType, propertie);

            // 确保当前窗口处于活动状态
            Window.Current.Activate();
        }
    }
}
