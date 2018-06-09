using System;
using System.Runtime.Serialization;
using System.Windows.Input;
using BaseProject.Commons.Commands;
using BaseProject.Views;

namespace BaseProject.Models
{
    [DataContract]
    public class Repos : BaseModel
    {
        [DataMember(Name = "id")]
        public int ID { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "full_name")]
        public string FullName { get; set; }

        [DataMember(Name = "owner")]
        public Owner Owner { get; set; }

        [DataMember(Name = "private")]
        public bool Private { get; set; }

        [DataMember(Name = "html_url")]
        public string HtmlURL { get; set; }

        [DataMember(Name = "description")]
        public string Description { get; set; }

        [DataMember(Name = "fork")]
        public bool Fork { get; set; }

        [DataMember(Name = "url")]
        public string URL { get; set; }

        [DataMember(Name = "forks_url")]
        public string ForksURL { get; set; }

        [DataMember(Name = "keys_url")]
        public string KeysURL { get; set; }

        [DataMember(Name = "collaborators_url")]
        public string Collaborators_url { get; set; }

        [DataMember(Name = "teams_url")]
        public string Teams_url { get; set; }

        [DataMember(Name = "hooks_url")]
        public string Hooks_url { get; set; }

        [DataMember(Name = "issue_events_url")]
        public string Issue_events_url { get; set; }

        [DataMember(Name = "events_url")]
        public string Events_url { get; set; }

        [DataMember(Name = "assignees_url")]
        public string Assignees_url { get; set; }

        [DataMember(Name = "branches_url")]
        public string Branches_url { get; set; }

        [DataMember(Name = "tags_url")]
        public string Tags_url { get; set; }

        [DataMember(Name = "blobs_url")]
        public string Blobs_url { get; set; }

        [DataMember(Name = "git_tags_url")]
        public string Git_tags_url { get; set; }

        [DataMember(Name = "git_refs_url")]
        public string Git_refs_url { get; set; }

        [DataMember(Name = "trees_url")]
        public string Trees_url { get; set; }

        [DataMember(Name = "statuses_url")]
        public string Statuses_url { get; set; }

        [DataMember(Name = "languages_url")]
        public string Languages_url { get; set; }

        [DataMember(Name = "stargazers_url")]
        public string StargazersURL { get; set; }

        [DataMember(Name = "contributors_url")]
        public string ContributorsURL { get; set; }

        [DataMember(Name = "subscribers_url")]
        public string SubscribersURL { get; set; }

        [DataMember(Name = "subscription_url")]
        public string SubscriptionURL { get; set; }

        [DataMember(Name = "commits_url")]
        public string CommitsURL { get; set; }

        [DataMember(Name = "git_commits_url")]
        public string GitCommitsURL { get; set; }

        [DataMember(Name = "comments_url")]
        public string CommentsURL { get; set; }

        [DataMember(Name = "issue_comment_url")]
        public string IssueCommentURL { get; set; }

        [DataMember(Name = "contents_url")]
        public string ContentsURL { get; set; }

        [DataMember(Name = "compare_url")]
        public string CompareURL { get; set; }

        [DataMember(Name = "merges_url")]
        public string MergesURL { get; set; }

        [DataMember(Name = "archive_url")]
        public string ArchiveURL { get; set; }

        [DataMember(Name = "downloads_url")]
        public string DownloadsURL { get; set; }

        [DataMember(Name = "issues_url")]
        public string IssuesURL { get; set; }

        [DataMember(Name = "pulls_url")]
        public string PullsURL { get; set; }

        [DataMember(Name = "milestones_url")]
        public string MilestonesURL { get; set; }

        [DataMember(Name = "notifications_url")]
        public string NotificationsURL { get; set; }

        [DataMember(Name = "labels_url")]
        public string LabelsURL { get; set; }

        [DataMember(Name = "releases_url")]
        public string ReleasesURL { get; set; }

        [DataMember(Name = "deployments_url")]
        public string DeploymentsURL { get; set; }

        [DataMember(Name = "created_at")]
        public DateTime CreatedAt { get; set; }

        [DataMember(Name = "updated_at")]
        public DateTime UpdatedAt { get; set; }

        [DataMember(Name = "pushed_at")]
        public DateTime PushedAt { get; set; }

        [DataMember(Name = "git_url")]
        public string GitURL { get; set; }

        [DataMember(Name = "ssh_url")]
        public string SshURL { get; set; }

        [DataMember(Name = "clone_url")]
        public string CloneURL { get; set; }

        [DataMember(Name = "svn_url")]
        public string SvnURL { get; set; }

        [DataMember(Name = "homepage")]
        public string Homepage { get; set; }

        [DataMember(Name = "size")]
        public int Size { get; set; }

        [DataMember(Name = "stargazers_count")]
        public int StargazersCount { get; set; }

        [DataMember(Name = "watchers_count")]
        public int WatchersCount { get; set; }

        [DataMember(Name = "language")]
        public string Language { get; set; }

        [DataMember(Name = "has_issues")]
        public bool HasIssues { get; set; }

        [DataMember(Name = "has_projects")]
        public bool HasProjects { get; set; }

        [DataMember(Name = "has_downloads")]
        public bool HasDownloads { get; set; }

        [DataMember(Name = "has_wiki")]
        public bool HasWiki { get; set; }

        [DataMember(Name = "has_pages")]
        public bool HasPages { get; set; }

        [DataMember(Name = "forks_count")]
        public int ForksCount { get; set; }

        [DataMember(Name = "mirror_url")]
        public object MirrorURL { get; set; }

        [DataMember(Name = "archived")]
        public bool Archived { get; set; }

        [DataMember(Name = "open_issues_count")]
        public int OpenIssuesCount { get; set; }

        [DataMember(Name = "license")]
        public License License { get; set; }

        [DataMember(Name = "forks")]
        public int Forks { get; set; }

        [DataMember(Name = "open_issues")]
        public int OpenIssues { get; set; }

        [DataMember(Name = "watchers")]
        public int Watchers { get; set; }

        [DataMember(Name = "default_branch")]
        public string DefaultBranch { get; set; }

        [DataMember(Name = "score")]
        public double Score { get; set; }


        public ICommand SelectedCommand 
        {
            get
            {
                return new DelegateCommand(async () =>
               {
                   System.Diagnostics.Debug.WriteLine("OK");
                    await MainPage.Instance.Detail.Navigation.PushAsync(new DetailPage());
               });
            }
        }
    }
}

