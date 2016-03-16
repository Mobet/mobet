﻿using Mobet.Settings;
using Mobet.Settings.Provider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mobet.Authorization.Configuration
{
    public class ResourcesSettingProvider : SettingProvider
    {
        public override IEnumerable<Setting> GetSettings(SettingProviderContext context)
        {
            return new[]
            {
                new Setting(ResourcesConsts.ResourcesDomain,"https://120.25.244.254:44300/",new SettingGroup("Resources"))
            };
        }

    }
}