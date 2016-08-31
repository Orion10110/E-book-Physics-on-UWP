using Newtonsoft.Json;
using System;
using System.IO;
using System.Runtime.Serialization.Json;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.Foundation.Metadata;
using Windows.Phone.UI.Input;
using Windows.Storage;
using Windows.Storage.Streams;
using Windows.UI;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Navigation;

namespace Physics
{
    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    sealed partial class App : Application
    {
        /// <summary>
        /// Initializes the singleton application object.  This is the first line of authored code
        /// executed, and as such is the logical equivalent of main() or WinMain().
        /// </summary>
        public App()
        {
            this.InitializeComponent();
            this.Suspending += OnSuspending;
        }

        /// <summary>
        /// Invoked when the application is launched normally by the end user.  Other entry points
        /// will be used such as when the application is launched to open a specific file.
        /// </summary>
        /// <param name="e">Details about the launch request and process.</param>
        protected override async void OnLaunched(LaunchActivatedEventArgs e)
        {
            try
            {
                if (await ApplicationData.Current.LocalFolder.TryGetItemAsync("setting.json") != null)
                {

                    SerializeSetting dser;
                    var Folder = Windows.Storage.ApplicationData.Current.LocalFolder;
                    var filer = await Folder.GetFileAsync("setting.json");
                    var datar = await filer.OpenReadAsync();

                    using (StreamReader r = new StreamReader(datar.AsStream()))
                    {
                        string text = r.ReadToEnd();
                        dser = JsonConvert.DeserializeObject<SerializeSetting>(text);

                    }

                    SettingApp.FontSize = dser.FontSize;
                    SettingApp.BackgroundColor = dser.BackgroundColor;
                    SettingApp.FontColor = dser.FontColor;
                    SettingApp.ProcentPage = dser.ProcentPage;

                }
            }
            catch (Exception)
            {

               
            }
           
          

            if (await ApplicationData.Current.LocalFolder.TryGetItemAsync("PhysicsDB.db") == null)
            {
                StorageFile databaseFile = await Package.Current.InstalledLocation.GetFileAsync("PhysicsDB.db");
                await databaseFile.CopyAsync(ApplicationData.Current.LocalFolder);
            }
#if DEBUG
            if (System.Diagnostics.Debugger.IsAttached)
            {
                this.DebugSettings.EnableFrameRateCounter = true;
            }
#endif

            AppShell shell = Window.Current.Content as AppShell;

            // Do not repeat app initialization when the Window already has content,
            // just ensure that the window is active
            if (shell == null)
            {
                // Create a AppShell to act as the navigation context and navigate to the first page
                shell = new AppShell();

                // Set the default language
                shell.Language = Windows.Globalization.ApplicationLanguages.Languages[0];

                shell.AppFrame.NavigationFailed += OnNavigationFailed;

                if (e.PreviousExecutionState == ApplicationExecutionState.Terminated)
                {
                    //TODO: Load state from previously suspended application
                }
            }

            // Place our app shell in the current Window
            Window.Current.Content = shell;

            if (shell.AppFrame.Content == null)
            {
                // When the navigation stack isn't restored, navigate to the first page
                // suppressing the initial entrance animation.
                shell.AppFrame.Navigate(typeof(Views.Page1), e.Arguments, new Windows.UI.Xaml.Media.Animation.SuppressNavigationTransitionInfo());
            }

            // Ensure the current window is active
            Window.Current.Activate();
        }

        /// <summary>
        /// Invoked when Navigation to a certain page fails
        /// </summary>
        /// <param name="sender">The Frame which failed navigation</param>
        /// <param name="e">Details about the navigation failure</param>
        void OnNavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            throw new Exception("Failed to load Page " + e.SourcePageType.FullName);
        }

        /// <summary>
        /// Invoked when application execution is being suspended.  Application state is saved
        /// without knowing whether the application will be terminated or resumed with the contents
        /// of memory still intact.
        /// </summary>
        /// <param name="sender">The source of the suspend request.</param>
        /// <param name="e">Details about the suspend request.</param>
        private async void OnSuspending(object sender, SuspendingEventArgs e)
        {
          

            var deferral = e.SuspendingOperation.GetDeferral();

                Color f = SettingApp.FontColor.Color;
                Color b = SettingApp.BackgroundColor.Color;
                SerializeSetting mysetting = new SerializeSetting(SettingApp.FontSize, f.A, f.R, f.G, f.B, b.A, b.R, b.G, b.B,SettingApp.ProcentPage);
                var Folder = Windows.Storage.ApplicationData.Current.LocalFolder;
                var file = await Folder.CreateFileAsync("setting.json", Windows.Storage.CreationCollisionOption.ReplaceExisting);
                var data = await file.OpenStreamForWriteAsync();

            using (StreamWriter r = new StreamWriter(data))
            {
                var serelizedfile = JsonConvert.SerializeObject(mysetting);
                r.Write(serelizedfile);

            }
            //TODO: Save application state and stop any background activity
            deferral.Complete();



         
           
        }

        private void Application_Suspending(object sender, SuspendingEventArgs e)
        {
           

        }
    }
}
