using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;
using Common.Contract;
using Common.Models;
using Common.Utils;
using DailyWebService.Models;
using Unity;
using Unity.Resolution;

namespace DailyWebService.Controllers
{
    [Authorize]
    public class MeetingController : ApiController
    {
        private IMeeting meeting;
        private readonly IUnityContainer container;
        private readonly IHttpRequestHelper httpRequestHelper;
        private readonly IConfigurations configurations;

        public MeetingController(IUnityContainer container, IHttpRequestHelper httpRequestHelper, IConfigurations configurations)
        {
            this.container = container;
            this.httpRequestHelper = httpRequestHelper;
            this.configurations = configurations;
        }

        [HttpPost]
        [Route("meeting/token")]
        public string Token([FromBody]string code)
        {
            var result = Utility.Authenticate(code, this.configurations, this.httpRequestHelper, false);

            return result;
        }

        public async Task<IEnumerable<MeetingDataList>> GetMeetingsAsync(MeetingRequest meetingRequest)
        {
            if (meetingRequest.IsLocal)
            {
                meeting = container.Resolve<IMeeting>(Constants.LocalOutlook);
            }
            else
            {
                meeting = container.Resolve<IMeeting>(Constants.ExchangeServer, new ParameterOverride("token", meetingRequest.MeetingToken), new ParameterOverride("action", null));
            }

            return await meeting.SearchCalendarItemsAsync(meetingRequest.From, meetingRequest.To);
        }
    }
}
