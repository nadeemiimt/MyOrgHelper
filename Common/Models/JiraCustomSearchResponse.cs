namespace Common.Models
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Common.Utils;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class JiraCustomSearchResponse
    {
        [JsonProperty("expand")]
        public string Expand { get; set; }

        [JsonProperty("startAt")]
        public long StartAt { get; set; }

        [JsonProperty("maxResults")]
        public long MaxResults { get; set; }

        [JsonProperty("total")]
        public long Total { get; set; }

        [JsonProperty("issues")]
        public List<Issue> Issues { get; set; }
    }

    public partial class Issue
    {
        [JsonProperty("expand")]
        public string Expand { get; set; }

        [JsonProperty("id")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long Id { get; set; }

        [JsonProperty("self")]
        public Uri Self { get; set; }

        [JsonProperty("key")]
        public string Key { get; set; }

        [JsonProperty("fields")]
        public IssueFields Fields { get; set; }
    }

    public partial class IssueFields
    {
        [JsonProperty("customfield_13100")]
        public object Customfield13100 { get; set; }

        [JsonProperty("customfield_14432")]
        public object Customfield14432 { get; set; }

        [JsonProperty("customfield_14433")]
        public object Customfield14433 { get; set; }

        [JsonProperty("customfield_13102")]
        public object Customfield13102 { get; set; }

        [JsonProperty("customfield_14430")]
        public object Customfield14430 { get; set; }

        [JsonProperty("customfield_14431")]
        public object Customfield14431 { get; set; }

        [JsonProperty("customfield_13104")]
        public object Customfield13104 { get; set; }

        [JsonProperty("customfield_14436")]
        public object Customfield14436 { get; set; }

        [JsonProperty("resolution")]
        public Priority Resolution { get; set; }

        [JsonProperty("customfield_13103")]
        public object Customfield13103 { get; set; }

        [JsonProperty("customfield_14437")]
        public object Customfield14437 { get; set; }

        [JsonProperty("customfield_14434")]
        public object Customfield14434 { get; set; }

        [JsonProperty("customfield_13105")]
        public object Customfield13105 { get; set; }

        [JsonProperty("customfield_14435")]
        public Customfield1 Customfield14435 { get; set; }

        [JsonProperty("customfield_10500")]
        public object Customfield10500 { get; set; }

        [JsonProperty("customfield_12800")]
        public Customfield1 Customfield12800 { get; set; }

        [JsonProperty("customfield_14429")]
        public Customfield1 Customfield14429 { get; set; }

        [JsonProperty("customfield_10501")]
        public object Customfield10501 { get; set; }

        [JsonProperty("customfield_14427")]
        public object Customfield14427 { get; set; }

        [JsonProperty("customfield_10503")]
        public string Customfield10503 { get; set; }

        [JsonProperty("customfield_14428")]
        public Customfield1 Customfield14428 { get; set; }

        [JsonProperty("lastViewed")]
        public string LastViewed { get; set; }

        [JsonProperty("customfield_12000")]
        public object Customfield12000 { get; set; }

        [JsonProperty("customfield_14421")]
        public object Customfield14421 { get; set; }

        [JsonProperty("customfield_14300")]
        public object Customfield14300 { get; set; }

        [JsonProperty("customfield_14422")]
        public object Customfield14422 { get; set; }

        [JsonProperty("customfield_12002")]
        public object Customfield12002 { get; set; }

        [JsonProperty("customfield_12001")]
        public object Customfield12001 { get; set; }

        [JsonProperty("customfield_14420")]
        public object Customfield14420 { get; set; }

        [JsonProperty("customfield_12004")]
        public object Customfield12004 { get; set; }

        [JsonProperty("customfield_14425")]
        public object Customfield14425 { get; set; }

        [JsonProperty("customfield_12003")]
        public object Customfield12003 { get; set; }

        [JsonProperty("customfield_14426")]
        public object Customfield14426 { get; set; }

        [JsonProperty("labels")]
        public List<object> Labels { get; set; }

        [JsonProperty("customfield_12005")]
        public object Customfield12005 { get; set; }

        [JsonProperty("customfield_14424")]
        public object Customfield14424 { get; set; }

        [JsonProperty("customfield_14418")]
        public object Customfield14418 { get; set; }

        [JsonProperty("customfield_14419")]
        public object Customfield14419 { get; set; }

        [JsonProperty("customfield_14416")]
        public object Customfield14416 { get; set; }

        [JsonProperty("customfield_14417")]
        public object Customfield14417 { get; set; }

        [JsonProperty("aggregatetimeoriginalestimate")]
        public object Aggregatetimeoriginalestimate { get; set; }

        [JsonProperty("issuelinks")]
        public List<Issuelink> Issuelinks { get; set; }

        [JsonProperty("assignee")]
        public Assignee Assignee { get; set; }

        [JsonProperty("components")]
        public List<Priority> Components { get; set; }

        [JsonProperty("customfield_14410")]
        public long Customfield14410 { get; set; }

        [JsonProperty("customfield_14411")]
        public long Customfield14411 { get; set; }

        [JsonProperty("customfield_13200")]
        public object Customfield13200 { get; set; }

        [JsonProperty("customfield_13203")]
        public object Customfield13203 { get; set; }

        [JsonProperty("customfield_14414")]
        public object Customfield14414 { get; set; }

        [JsonProperty("customfield_13202")]
        public object Customfield13202 { get; set; }

        [JsonProperty("customfield_14415")]
        public object Customfield14415 { get; set; }

        [JsonProperty("customfield_14412")]
        public object Customfield14412 { get; set; }

        [JsonProperty("customfield_14413")]
        public object Customfield14413 { get; set; }

        [JsonProperty("customfield_14407")]
        public string Customfield14407 { get; set; }

        [JsonProperty("customfield_14408")]
        public object Customfield14408 { get; set; }

        [JsonProperty("customfield_14405")]
        public object Customfield14405 { get; set; }

        [JsonProperty("customfield_14406")]
        public object Customfield14406 { get; set; }

        [JsonProperty("customfield_14409")]
        public string Customfield14409 { get; set; }

        [JsonProperty("subtasks")]
        public List<Subtask> Subtasks { get; set; }

        [JsonProperty("customfield_14400")]
        public object Customfield14400 { get; set; }

        [JsonProperty("reporter")]
        public Assignee Reporter { get; set; }

        [JsonProperty("customfield_12101")]
        public object Customfield12101 { get; set; }

        [JsonProperty("customfield_13311")]
        public Customfield1 Customfield13311 { get; set; }

        [JsonProperty("customfield_12100")]
        public object Customfield12100 { get; set; }

        [JsonProperty("customfield_14403")]
        public object Customfield14403 { get; set; }

        [JsonProperty("customfield_14404")]
        public string Customfield14404 { get; set; }

        [JsonProperty("customfield_14401")]
        public object Customfield14401 { get; set; }

        [JsonProperty("customfield_14402")]
        public object Customfield14402 { get; set; }

        [JsonProperty("customfield_13306")]
        public Customfield1 Customfield13306 { get; set; }

        [JsonProperty("customfield_13305")]
        public object Customfield13305 { get; set; }

        [JsonProperty("customfield_13308")]
        public Customfield1 Customfield13308 { get; set; }

        [JsonProperty("customfield_13307")]
        public object Customfield13307 { get; set; }

        [JsonProperty("customfield_13309")]
        public DateTimeOffset Customfield13309 { get; set; }

        [JsonProperty("progress")]
        public Progress Progress { get; set; }

        [JsonProperty("votes")]
        public Votes Votes { get; set; }

        [JsonProperty("issuetype")]
        public Issuetype Issuetype { get; set; }

        [JsonProperty("project")]
        public Project Project { get; set; }

        [JsonProperty("customfield_13300")]
        public string Customfield13300 { get; set; }

        [JsonProperty("customfield_13302")]
        public object Customfield13302 { get; set; }

        [JsonProperty("customfield_13301")]
        public string Customfield13301 { get; set; }

        [JsonProperty("customfield_13304")]
        public object Customfield13304 { get; set; }

        [JsonProperty("customfield_13303")]
        public object Customfield13303 { get; set; }

        [JsonProperty("customfield_10700")]
        public object Customfield10700 { get; set; }

        [JsonProperty("resolutiondate")]
        public string Resolutiondate { get; set; }

        [JsonProperty("watches")]
        public Watches Watches { get; set; }

        [JsonProperty("customfield_12200")]
        public object Customfield12200 { get; set; }

        [JsonProperty("customfield_14500")]
        public object Customfield14500 { get; set; }

        [JsonProperty("customfield_14501")]
        public object Customfield14501 { get; set; }

        [JsonProperty("customfield_10016")]
        public object Customfield10016 { get; set; }

        [JsonProperty("customfield_10017")]
        public object Customfield10017 { get; set; }

        [JsonProperty("customfield_10018")]
        public object Customfield10018 { get; set; }

        [JsonProperty("customfield_11900")]
        public object Customfield11900 { get; set; }

        [JsonProperty("customfield_10019")]
        public string Customfield10019 { get; set; }

        [JsonProperty("updated")]
        public string Updated { get; set; }

        [JsonProperty("timeoriginalestimate")]
        public object Timeoriginalestimate { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("customfield_10010")]
        public object Customfield10010 { get; set; }

        [JsonProperty("customfield_10011")]
        public object Customfield10011 { get; set; }

        [JsonProperty("customfield_10012")]
        public object Customfield10012 { get; set; }

        [JsonProperty("customfield_11101")]
        public List<Customfield1> Customfield11101 { get; set; }

        [JsonProperty("customfield_10013")]
        public object Customfield10013 { get; set; }

        [JsonProperty("customfield_10014")]
        public object Customfield10014 { get; set; }

        [JsonProperty("customfield_10015")]
        public object Customfield10015 { get; set; }

        [JsonProperty("customfield_10005")]
        public object Customfield10005 { get; set; }

        [JsonProperty("customfield_10006")]
        public object Customfield10006 { get; set; }

        [JsonProperty("customfield_10007")]
        public string Customfield10007 { get; set; }

        [JsonProperty("customfield_10008")]
        public Customfield1 Customfield10008 { get; set; }

        [JsonProperty("customfield_10009")]
        public string Customfield10009 { get; set; }

        [JsonProperty("summary")]
        public string Summary { get; set; }

        [JsonProperty("customfield_10000")]
        public object Customfield10000 { get; set; }

        [JsonProperty("customfield_10001")]
        public object Customfield10001 { get; set; }

        [JsonProperty("customfield_12301")]
        public object Customfield12301 { get; set; }

        [JsonProperty("customfield_10002")]
        public object Customfield10002 { get; set; }

        [JsonProperty("customfield_12300")]
        public object Customfield12300 { get; set; }

        [JsonProperty("customfield_10003")]
        public object Customfield10003 { get; set; }

        [JsonProperty("customfield_10004")]
        public string Customfield10004 { get; set; }

        [JsonProperty("customfield_12302")]
        public object Customfield12302 { get; set; }

        [JsonProperty("customfield_14600")]
        public object Customfield14600 { get; set; }

        [JsonProperty("environment")]
        public object Environment { get; set; }

        [JsonProperty("duedate")]
        public object Duedate { get; set; }

        [JsonProperty("fixVersions")]
        public List<object> FixVersions { get; set; }

        [JsonProperty("customfield_13500")]
        public object Customfield13500 { get; set; }

        [JsonProperty("customfield_14704")]
        public object Customfield14704 { get; set; }

        [JsonProperty("customfield_14705")]
        public object Customfield14705 { get; set; }

        [JsonProperty("customfield_14702")]
        public object Customfield14702 { get; set; }

        [JsonProperty("customfield_14703")]
        public object Customfield14703 { get; set; }

        [JsonProperty("customfield_14708")]
        public object Customfield14708 { get; set; }

        [JsonProperty("customfield_14709")]
        public object Customfield14709 { get; set; }

        [JsonProperty("customfield_14706")]
        public object Customfield14706 { get; set; }

        [JsonProperty("customfield_14707")]
        public object Customfield14707 { get; set; }

        [JsonProperty("priority")]
        public Priority Priority { get; set; }

        [JsonProperty("customfield_10100")]
        public object Customfield10100 { get; set; }

        [JsonProperty("customfield_12400")]
        public Assignee Customfield12400 { get; set; }

        [JsonProperty("customfield_14700")]
        public object Customfield14700 { get; set; }

        [JsonProperty("customfield_10101")]
        public object Customfield10101 { get; set; }

        [JsonProperty("customfield_14701")]
        public object Customfield14701 { get; set; }

        [JsonProperty("customfield_12401")]
        public object Customfield12401 { get; set; }

        [JsonProperty("customfield_14820")]
        public object Customfield14820 { get; set; }

        [JsonProperty("customfield_13724")]
        public object Customfield13724 { get; set; }

        [JsonProperty("customfield_14812")]
        public object Customfield14812 { get; set; }

        [JsonProperty("customfield_14813")]
        public object Customfield14813 { get; set; }

        [JsonProperty("customfield_14818")]
        public string Customfield14818 { get; set; }

        [JsonProperty("timeestimate")]
        public object Timeestimate { get; set; }

        [JsonProperty("versions")]
        public List<object> Versions { get; set; }

        [JsonProperty("customfield_13727")]
        public object Customfield13727 { get; set; }

        [JsonProperty("customfield_14819")]
        public object Customfield14819 { get; set; }

        [JsonProperty("status")]
        public Status Status { get; set; }

        [JsonProperty("customfield_14810")]
        public Customfield1 Customfield14810 { get; set; }

        [JsonProperty("customfield_14811")]
        public object Customfield14811 { get; set; }

        [JsonProperty("customfield_11301")]
        public object Customfield11301 { get; set; }

        [JsonProperty("customfield_13600")]
        public object Customfield13600 { get; set; }

        [JsonProperty("customfield_10203")]
        public object Customfield10203 { get; set; }

        [JsonProperty("customfield_13955")]
        public string Customfield13955 { get; set; }

        [JsonProperty("customfield_14803")]
        public object Customfield14803 { get; set; }

        [JsonProperty("customfield_10204")]
        public Assignee Customfield10204 { get; set; }

        [JsonProperty("customfield_13954")]
        public string Customfield13954 { get; set; }

        [JsonProperty("customfield_14804")]
        public object Customfield14804 { get; set; }

        [JsonProperty("customfield_10205")]
        public object Customfield10205 { get; set; }

        [JsonProperty("customfield_14801")]
        public object Customfield14801 { get; set; }

        [JsonProperty("customfield_10206")]
        public string Customfield10206 { get; set; }

        [JsonProperty("customfield_14802")]
        public object Customfield14802 { get; set; }

        [JsonProperty("customfield_10207")]
        public object Customfield10207 { get; set; }

        [JsonProperty("customfield_14807")]
        public Customfield1 Customfield14807 { get; set; }

        [JsonProperty("aggregatetimeestimate")]
        public object Aggregatetimeestimate { get; set; }

        [JsonProperty("customfield_10208")]
        public object Customfield10208 { get; set; }

        [JsonProperty("customfield_13716")]
        public object Customfield13716 { get; set; }

        [JsonProperty("customfield_14808")]
        public Customfield1 Customfield14808 { get; set; }

        [JsonProperty("customfield_14805")]
        public object Customfield14805 { get; set; }

        [JsonProperty("customfield_14806")]
        public object Customfield14806 { get; set; }

        [JsonProperty("customfield_14809")]
        public Customfield1 Customfield14809 { get; set; }

        [JsonProperty("creator")]
        public Assignee Creator { get; set; }

        [JsonProperty("customfield_14000")]
        public object Customfield14000 { get; set; }

        [JsonProperty("aggregateprogress")]
        public Progress Aggregateprogress { get; set; }

        [JsonProperty("customfield_10201")]
        public Assignee Customfield10201 { get; set; }

        [JsonProperty("customfield_10202")]
        public object Customfield10202 { get; set; }

        [JsonProperty("customfield_12500")]
        public object Customfield12500 { get; set; }

        [JsonProperty("customfield_13704")]
        public object Customfield13704 { get; set; }

        [JsonProperty("customfield_13706")]
        public object Customfield13706 { get; set; }

        [JsonProperty("customfield_13708")]
        public object Customfield13708 { get; set; }

        [JsonProperty("timespent")]
        public object Timespent { get; set; }

        [JsonProperty("aggregatetimespent")]
        public object Aggregatetimespent { get; set; }

        [JsonProperty("customfield_14902")]
        public object Customfield14902 { get; set; }

        [JsonProperty("customfield_14903")]
        public object Customfield14903 { get; set; }

        [JsonProperty("customfield_14901")]
        public object Customfield14901 { get; set; }

        [JsonProperty("customfield_14904")]
        public object Customfield14904 { get; set; }

        [JsonProperty("customfield_13938")]
        public object Customfield13938 { get; set; }

        [JsonProperty("workratio")]
        public long Workratio { get; set; }

        [JsonProperty("created")]
        public string Created { get; set; }

        [JsonProperty("customfield_10300")]
        public object Customfield10300 { get; set; }

        [JsonProperty("customfield_12600")]
        public object Customfield12600 { get; set; }

        [JsonProperty("customfield_13801")]
        public object Customfield13801 { get; set; }

        [JsonProperty("customfield_13800")]
        public Customfield1 Customfield13800 { get; set; }

        [JsonProperty("customfield_14450")]
        public object Customfield14450 { get; set; }

        [JsonProperty("customfield_14451")]
        public object Customfield14451 { get; set; }

        [JsonProperty("customfield_13001")]
        public object Customfield13001 { get; set; }

        [JsonProperty("customfield_13000")]
        public object Customfield13000 { get; set; }

        [JsonProperty("customfield_14452")]
        public object Customfield14452 { get; set; }

        [JsonProperty("customfield_14453")]
        public object Customfield14453 { get; set; }

        [JsonProperty("customfield_11500")]
        public object Customfield11500 { get; set; }

        [JsonProperty("customfield_12701")]
        public object Customfield12701 { get; set; }

        [JsonProperty("customfield_12700")]
        public object Customfield12700 { get; set; }

        [JsonProperty("customfield_13910")]
        public List<string> Customfield13910 { get; set; }

        [JsonProperty("customfield_12703")]
        public object Customfield12703 { get; set; }

        [JsonProperty("customfield_14449")]
        public object Customfield14449 { get; set; }

        [JsonProperty("customfield_12702")]
        public object Customfield12702 { get; set; }

        [JsonProperty("customfield_12705")]
        public object Customfield12705 { get; set; }

        [JsonProperty("customfield_12704")]
        public object Customfield12704 { get; set; }

        [JsonProperty("customfield_12707")]
        public object Customfield12707 { get; set; }

        [JsonProperty("customfield_12706")]
        public object Customfield12706 { get; set; }

        [JsonProperty("customfield_14440")]
        public object Customfield14440 { get; set; }

        [JsonProperty("customfield_14443")]
        public string Customfield14443 { get; set; }

        [JsonProperty("customfield_14201")]
        public object Customfield14201 { get; set; }

        [JsonProperty("customfield_14444")]
        public object Customfield14444 { get; set; }

        [JsonProperty("customfield_14441")]
        public string Customfield14441 { get; set; }

        [JsonProperty("customfield_14442")]
        public string Customfield14442 { get; set; }

        [JsonProperty("customfield_14200")]
        public Customfield1 Customfield14200 { get; set; }

        [JsonProperty("customfield_14447")]
        public object Customfield14447 { get; set; }

        [JsonProperty("customfield_14448")]
        public object Customfield14448 { get; set; }

        [JsonProperty("customfield_14445")]
        public object Customfield14445 { get; set; }

        [JsonProperty("customfield_14446")]
        public string Customfield14446 { get; set; }

        [JsonProperty("customfield_13900")]
        public object Customfield13900 { get; set; }

        [JsonProperty("customfield_13902")]
        public object Customfield13902 { get; set; }

        [JsonProperty("customfield_14438")]
        public object Customfield14438 { get; set; }

        [JsonProperty("customfield_13901")]
        public object Customfield13901 { get; set; }

        [JsonProperty("customfield_14439")]
        public object Customfield14439 { get; set; }

        [JsonProperty("customfield_13904")]
        public object Customfield13904 { get; set; }

        [JsonProperty("customfield_13903")]
        public object Customfield13903 { get; set; }

        [JsonProperty("customfield_13905")]
        public object Customfield13905 { get; set; }
    }

    public partial class Progress
    {
        [JsonProperty("progress")]
        public long ProgressProgress { get; set; }

        [JsonProperty("total")]
        public long Total { get; set; }
    }

    public partial class Priority
    {
        [JsonProperty("self")]
        public Uri Self { get; set; }

        [JsonProperty("id")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description", NullValueHandling = NullValueHandling.Ignore)]
        public string Description { get; set; }

        [JsonProperty("iconUrl", NullValueHandling = NullValueHandling.Ignore)]
        public Uri IconUrl { get; set; }
    }

    public partial class Customfield1
    {
        [JsonProperty("self")]
        public Uri Self { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }

        [JsonProperty("id")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long Id { get; set; }
    }

    public partial class Issuelink
    {
        [JsonProperty("id")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long Id { get; set; }

        [JsonProperty("self")]
        public Uri Self { get; set; }

        [JsonProperty("type")]
        public TypeClass Type { get; set; }

        [JsonProperty("inwardIssue")]
        public Subtask InwardIssue { get; set; }
    }

    public partial class Subtask
    {
        [JsonProperty("id")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long Id { get; set; }

        [JsonProperty("key")]
        public string Key { get; set; }

        [JsonProperty("self")]
        public Uri Self { get; set; }

        [JsonProperty("fields")]
        public SubtaskFields Fields { get; set; }
    }

    public partial class SubtaskFields
    {
        [JsonProperty("summary")]
        public string Summary { get; set; }

        [JsonProperty("status")]
        public Status Status { get; set; }

        [JsonProperty("priority")]
        public Priority Priority { get; set; }

        [JsonProperty("issuetype")]
        public Issuetype Issuetype { get; set; }
    }

    public partial class TypeClass
    {
        [JsonProperty("id")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("inward")]
        public string Inward { get; set; }

        [JsonProperty("outward")]
        public string Outward { get; set; }

        [JsonProperty("self")]
        public Uri Self { get; set; }
    }

    public partial class Project
    {
        [JsonProperty("self")]
        public Uri Self { get; set; }

        [JsonProperty("id")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long Id { get; set; }

        [JsonProperty("key")]
        public string Key { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("avatarUrls")]
        public AvatarUrls AvatarUrls { get; set; }

        [JsonProperty("projectCategory")]
        public Priority ProjectCategory { get; set; }
    }

    public partial class Votes
    {
        [JsonProperty("self")]
        public Uri Self { get; set; }

        [JsonProperty("votes")]
        public long VotesVotes { get; set; }

        [JsonProperty("hasVoted")]
        public bool HasVoted { get; set; }
    }

    public partial class Watches
    {
        [JsonProperty("self")]
        public Uri Self { get; set; }

        [JsonProperty("watchCount")]
        public long WatchCount { get; set; }

        [JsonProperty("isWatching")]
        public bool IsWatching { get; set; }
    }

    public partial class JiraCustomSearchResponse
    {
        public static JiraCustomSearchResponse FromJson(string json) => JsonConvert.DeserializeObject<JiraCustomSearchResponse>(json, Converter.Settings);
    }
}
