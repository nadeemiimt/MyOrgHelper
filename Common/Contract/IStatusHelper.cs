using Common.Models;
using System;
using System.Collections.Generic;

namespace Common.Contract
{
    public interface IStatusHelper
    {
        List<JiraStatusDto> GetStatus(string userName, string password, DateTime? fromDate, DateTime? toDate, string[] users);

        List<ConfluenceTableData> GetConfluenceStatus(string userName, string password, string[] users, int count);

    }
}
