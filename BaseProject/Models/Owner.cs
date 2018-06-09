using System;
using System.Runtime.Serialization;

namespace BaseProject.Models
{
    [DataContract]
    public class Owner : BaseModel
    {
        [DataMember(Name = "login")]
        public string Login { get; set; }
        [DataMember(Name = "id")]
        public int ID { get; set; }
        [DataMember(Name = "avatar_url")]
        public string AvatarURL { get; set; }
        [DataMember(Name = "gravatar_id")]
        public string GravatarID { get; set; }
        [DataMember(Name = "url")]
        public string URL { get; set; }
        [DataMember(Name = "html_url")]
        public string HtmlURL { get; set; }
        [DataMember(Name = "followers_url")]
        public string FollowersURL { get; set; }
        [DataMember(Name = "following_url")]
        public string FollowingURL { get; set; }
        [DataMember(Name = "gists_url")]
        public string GistsURL { get; set; }
        [DataMember(Name = "starred_url")]
        public string StarredURL { get; set; }
        [DataMember(Name = "subscriptions_url")]
        public string SubscriptionsURL { get; set; }
        [DataMember(Name = "organizations_url")]
        public string OrganizationsURL { get; set; }
        [DataMember(Name = "repos_url")]
        public string ReposURL { get; set; }
        [DataMember(Name = "events_url")]
        public string EventsURL { get; set; }
        [DataMember(Name = "received_events_url")]
        public string ReceivedEventsURL { get; set; }
        [DataMember(Name = "type")]
        public string Type { get; set; }
        [DataMember(Name = "site_admin")]
        public bool SiteAdmin { get; set; }
    }
}

