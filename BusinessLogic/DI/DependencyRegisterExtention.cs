using Common.Contract;
using DataLogic;
using Unity.Extension;
using Unity.Lifetime;
using Unity;
using Common.Configs;
using BusinessLogic.Report;
using BusinessLogic.Notification;
using BusinessLogic.Stash;
using Common.Models;
using BusinessLogic.Meeting;
using Common.Utils;
using Unity.log4net;

namespace BusinessLogic.DI
{
    public class DependencyRegisterExtension : UnityContainerExtension
    {        

        protected override void Initialize()
        {
            Container.AddNewExtension<LogCreation>();
            Container.AddNewExtension<Log4NetExtension>();

            Container.RegisterInstance<IConfigurations>(Utility.GetSettings());

            Container.RegisterSingleton<IDataHelper, DataHelper>();
            Container.RegisterSingleton<IHttpRequestHelper, HttpRequestHelper>();

            Container.RegisterSingleton<IJiraStatusHelper, JiraStatusHelper>();
            Container.RegisterSingleton<IJiraTracker, JiraTracker>();

            Container.RegisterSingleton<INotifier, WirePusher>();

            Container.RegisterSingleton<IStashProvider, StashHelper>();

            Container.RegisterSingleton<IStatusHelper, StatusHelper>();

            Container.RegisterSingleton<IConfluencePageHelper, ConfluencePageHelper>();
            Container.RegisterSingleton<IReport, ReportGenerator>();

            Container.RegisterType<ICredentials, Credentials>(new TransientLifetimeManager());

            Container.RegisterSingleton<IMeeting, OutlookServer>(Constants.ExchangeServer);  //need to resolce for func
            Container.RegisterSingleton<IMeeting, LocalOutlook>(Constants.LocalOutlook);
        }        
    }
}
