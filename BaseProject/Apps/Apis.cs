using System;

namespace BaseProject.Apps
{
    public class Apis
    {
        private static Apis _instance;
        public static Apis Instance
        {
            get { return _instance ?? (_instance = new Apis()); }
        }

        public string MostRepoApi(int page, int limit)
        {
            return String.Format("https://api.github.com/search/repositories?q=stars:%3E=1000&sort=stars&order=desc&per_page={0}&page={1}", limit, page);
        }
    }
}

