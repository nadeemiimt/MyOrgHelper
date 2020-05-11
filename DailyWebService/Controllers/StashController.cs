using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Common.Contract;
using Common.Models;
using Common.Utils;

namespace DailyWebService.Controllers
{
    public class StashController : ApiController
    {
        private readonly IStashProvider stashProvider;
        public StashController(INotifier notifier, IDataHelper dataHelper, IStashProvider stashProvider, IJiraStatusHelper jiraStatusHelper)
        {
            this.stashProvider = stashProvider;
        }
        // GET api/<controller>
        public List<Value> GetPrList(string userName, string password)
        {
            userName = Utility.DecryptStringAES(userName);
            password = Utility.DecryptStringAES(password);
            return this.stashProvider.GetPrList(userName, password);
        }

        public List<Value> GetCustomPrList(string userName, string password, string[] prs)
        {
            userName = Utility.DecryptStringAES(userName);
            password = Utility.DecryptStringAES(password);
            return this.stashProvider.GetCustomPrList(userName, password, prs);
        }

        public StashOverviewResponse GetPrSummary(string userName, string password, long prId)
        {
            userName = Utility.DecryptStringAES(userName);
            password = Utility.DecryptStringAES(password);
            return this.stashProvider.GetPrSummary(userName, password, prId);
        }

        public StashMergeStatusResponse GetMergeDetails(string userName, string password, long prId)
        {
            userName = Utility.DecryptStringAES(userName);
            password = Utility.DecryptStringAES(password);
            return this.stashProvider.GetMergeDetails(userName, password, prId);
        }

        public StashRebaseResponse RebasePR(string userName, string password, long prId, long version)
        {
            userName = Utility.DecryptStringAES(userName);
            password = Utility.DecryptStringAES(password);
            return this.stashProvider.RebasePR(userName, password, prId, version);
        }

        public StashRebaseResponse ApprovePr(string userName, string password, long prId, long version)
        {
            userName = Utility.DecryptStringAES(userName);
            password = Utility.DecryptStringAES(password);
            return this.stashProvider.ApprovePr(userName, password, prId, version);
        }

        public StashMergedResponse MergePR(string userName, string password, long prId, long version)
        {
            userName = Utility.DecryptStringAES(userName);
            password = Utility.DecryptStringAES(password);
            return this.stashProvider.MergePR(userName, password, prId, version);
        }
    }
}