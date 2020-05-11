using Common.Models;
using System.Collections.Generic;

namespace Common.Contract
{
    public interface IStashProvider
    {
        List<Value> GetPrList(string userName, string password);

        List<Value> GetCustomPrList(string userName, string password, string[] prs);

        StashOverviewResponse GetPrSummary(string userName, string password, long prId);

        StashMergeStatusResponse GetMergeDetails(string userName, string password, long prId);

        StashRebaseResponse RebasePR(string userName, string password, long prId, long version);

        StashMergedResponse MergePR(string userName, string password, long prId, long version);

        StashRebaseResponse ApprovePr(string userName, string password, long prId, long version);
    }
}
