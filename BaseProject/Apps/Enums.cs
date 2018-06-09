using System;
using BaseProject.Commons.Attributes;

namespace BaseProject.Apps
{
    public class Enums
    {
        public enum AccountType
        {
            [Description("3")]
            [ExtraDescription("mobile")]
             Mobile = 0,
            [Description("1")]
            [ExtraDescription("email")]
             Email,
            [Description("2")]
            [ExtraDescription("facebook")]
            Facebook,
            [Description("4")]
            [ExtraDescription("google")]
            Google
        }
    }
}

