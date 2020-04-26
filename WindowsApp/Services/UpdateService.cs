using Octokit;
using System;
using System.Reflection;

namespace WindowsApp.Services
{
    public static class UpdateService
    {
        public static void CheckForUpdates(string owner, string repo, Action<string, string> callback)
        {
            Release latest;

            try
            {
                var client = new GitHubClient(new ProductHeaderValue(repo));
                latest = client.Repository.Release.GetLatest(owner, repo).Result;
            }
            catch (Exception)
            {
                return;
            }

            var currentVersion = Assembly.GetEntryAssembly()?.GetName().Version;
            var latestVersion = new Version(latest.TagName.Substring(1) + ".0");
            var isUpToDate = currentVersion != null && currentVersion.CompareTo(latestVersion) >= 0;

            if (!isUpToDate) callback(latest.TagName, latest.Assets[0].BrowserDownloadUrl);
        }
    }
}
