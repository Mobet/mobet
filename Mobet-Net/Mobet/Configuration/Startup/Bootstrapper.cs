﻿using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Collections.ObjectModel;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Compilation;

using Autofac;
using Autofac.Core;
using Autofac.Integration.WebApi;
using Autofac.Integration.Mvc;

using Castle.Core.Logging;
using Castle.Services.Logging.Log4netIntegration;

using Mobet.Dependency;
using Mobet.Dependency.ConventionalRegistrars;
using Mobet.Domain.UnitOfWork.ConventionalRegistras;
using Mobet.EntityFramework.ConventionalRegistras;
using Mobet.Logging;
using Mobet.AutoMapper;
using Mobet.Auditing.ConventionalRegistras;
using Mobet.Modules.Logging;
using Mobet.Runtime.Session.Modules;
using Mobet.Caching;
using Mobet.Events.Modules;
using Mobet.Events.ConventionalRegistras;
using Mobet.Settings.Provider;
using Mobet.EntityFramework.Configuration;

namespace Mobet.Configuration.Startup
{
    public class Bootstrapper
    {
        private const string AssemblySkipLoadingPattern = "^System|^vshost32|^Nito.AsyncEx|^mscorlib|^Microsoft|^AjaxControlToolkit|^Antlr3|^Autofac|^NSubstitute|^AutoMapper|^Castle|^ComponentArt|^CppCodeProvider|^DotNetOpenAuth|^EntityFramework|^EPPlus|^FluentValidation|^ImageResizer|^itextsharp|^log4net|^MaxMind|^MbUnit|^MiniProfiler|^Mono.Math|^MvcContrib|^Newtonsoft|^NHibernate|^nunit|^Org.Mentalis|^PerlRegex|^QuickGraph|^Recaptcha|^Remotion|^RestSharp|^Telerik|^Iesi|^TestFu|^UserAgentStringLibrary|^VJSharpCodeProvider|^WebActivator|^WebDev|^WebGrease";

        public IStartupConfiguration StartupConfiguration
        {
            get
            {
                //IocManager.Instance.RegisterIfNot<IStartupConfiguration, StartupConfiguration>();
                return IocManager.Instance.Resolve<IStartupConfiguration>();
            }
        }


        public void RegisterWebMvcApplication(params IModule[] modules)
        {
            var assemblies = FilterSystemAssembly(BuildManager.GetReferencedAssemblies().Cast<Assembly>());

            IocManager.Instance.AddConventionalRegistrar(new BasicConventionalRegistrar());
            IocManager.Instance.AddConventionalRegistrar(new ControllerConventionalRegistrar());

            IocManager.Instance.RegisterAssemblyByConvention(assemblies, modules);

            DependencyResolver.SetResolver(new AutofacDependencyResolver(IocManager.Instance.IocContainer));
        }
        public void RegisterWebApiApplication(params IModule[] modules)
        {
            var assemblies = FilterSystemAssembly(BuildManager.GetReferencedAssemblies().Cast<Assembly>());
            HttpConfiguration configuration = GlobalConfiguration.Configuration;

            IocManager.Instance.AddConventionalRegistrar(new BasicConventionalRegistrar());
            IocManager.Instance.AddConventionalRegistrar(new ControllerConventionalRegistrar());
            IocManager.Instance.AddConventionalRegistrar(new ApiControllerConventionalRegistrar());

            IocManager.Instance.RegisterAssemblyByConvention(assemblies, modules);

            configuration.DependencyResolver = new AutofacWebApiDependencyResolver(IocManager.Instance.IocContainer);
        }
        public void RegisterConsoleApplication(params IModule[] modules)
        {
            IocManager.Instance.AddConventionalRegistrar(new BasicConventionalRegistrar());
            IocManager.Instance.RegisterAssemblyByConvention(AppDomain.CurrentDomain.GetAssemblies());
        }

        private static Assembly[] FilterSystemAssembly(IEnumerable<Assembly> assemblies)
        {
            return assemblies
                .Where(assembly => !Regex.IsMatch(assembly.FullName, AssemblySkipLoadingPattern, RegexOptions.IgnoreCase | RegexOptions.Compiled))
                .ToArray();
        }
    }

    public static class BootstrapperExtensions
    {
        private const string AssemblySkipLoadingPattern = "^System|^vshost32|^Nito.AsyncEx|^mscorlib|^Microsoft|^AjaxControlToolkit|^Antlr3|^Autofac|^NSubstitute|^AutoMapper|^Castle|^ComponentArt|^CppCodeProvider|^DotNetOpenAuth|^EntityFramework|^EPPlus|^FluentValidation|^ImageResizer|^itextsharp|^log4net|^MaxMind|^MbUnit|^MiniProfiler|^Mono.Math|^MvcContrib|^Newtonsoft|^NHibernate|^nunit|^Org.Mentalis|^PerlRegex|^QuickGraph|^Recaptcha|^Remotion|^RestSharp|^Telerik|^Iesi|^TestFu|^UserAgentStringLibrary|^VJSharpCodeProvider|^WebActivator|^WebDev|^WebGrease";

        public static Bootstrapper UseDataAccessEntityFramework(this Bootstrapper bootstrap)
        {
            IocManager.Instance.AddConventionalRegistrar(new UnitOfWorkConventionalRegistrar());
            IocManager.Instance.AddConventionalRegistrar(new EntityFrameworkConventionalRegistrar());
            IocManager.Instance.RegisterAssemblyByConvention(GetAssemblies());

            return bootstrap;
        }
        public static Bootstrapper UseDataAccessNHibernet(this Bootstrapper bootstrap)
        {
            return bootstrap;
        }
        public static Bootstrapper UseDataAccessMongoDb(this Bootstrapper bootstrap)
        {
            return bootstrap;
        }
        public static Bootstrapper UseDataAccessMicrosoftDataAccess(this Bootstrapper bootstrap)
        {
            return bootstrap;
        }
        public static Bootstrapper UseCacheProviderRedis(this Bootstrapper bootstrap, string configuration)
        {
            IocManager.Instance.RegisterWithParameters<ICache, RedisCache>("configuration", configuration);
            return bootstrap;
        }
        public static Bootstrapper UseCacheProviderInMemory(this Bootstrapper bootstrap)
        {
            IocManager.Instance.Register<ICache, Caching.Netcache>();
            return bootstrap;
        }
        public static Bootstrapper UseLoggingLog4net(this Bootstrapper bootstrap, string configFile = "log4net.config")
        {
            IocManager.Instance.RegisterWithParameters<ILoggerFactory, Log4netFactory>("configFile", configFile);
            IocManager.Instance.RegisterModule(new LoggingModule());
            return bootstrap;
        }
        public static Bootstrapper UseLoggingNLog(this Bootstrapper bootstrap)
        {
            return bootstrap;
        }
        public static Bootstrapper UseAuditing(this Bootstrapper bootstrap)
        {
            IocManager.Instance.AddConventionalRegistrar(new AuditingInterceptorRegistrar());
            IocManager.Instance.RegisterAssemblyByConvention(GetAssemblies());
            return bootstrap;
        }
        public static Bootstrapper UseAutoMapper(this Bootstrapper bootstrap)
        {
            AutoMapperBootstrapper.Initialize(GetAssemblies());
            return bootstrap;
        }
        public static Bootstrapper UseAppSession(this Bootstrapper bootstrap)
        {
            IocManager.Instance.RegisterModule(new AppSessionModule());
            return bootstrap;
        }
        public static Bootstrapper UseEventBus(this Bootstrapper bootstrap)
        {
            IocManager.Instance.AddConventionalRegistrar(new EventBusConventionalRegistras());
            IocManager.Instance.RegisterAssemblyByConvention(GetAssemblies());
            IocManager.Instance.RegisterModule(new EventBusModule());
            return bootstrap;
        }

        private static Assembly[] GetAssemblies()
        {
            var path = GetPhysicalPath(AppDomain.CurrentDomain.BaseDirectory);
            return FilterSystemAssembly(GetAssemblies(path)).ToArray();
        }
        private static List<string> GetAllFiles(string directoryPath)
        {
            return Directory.GetFiles(directoryPath, "*.*", SearchOption.AllDirectories).ToList();
        }
        private static List<Assembly> GetAssemblies(string directoryPath)
        {
            var filePaths = GetAllFiles(directoryPath).Where(t => t.EndsWith(".exe") || t.EndsWith(".dll"));
            return filePaths.Select(Assembly.LoadFile).ToList();
        }
        private static string GetPhysicalPath(string relativePath)
        {
            if (HttpContext.Current == null)
            {
                if (relativePath.StartsWith("~"))
                {
                    relativePath = relativePath.Remove(0, 2);
                }
                return Path.GetFullPath(relativePath);
            }
            if (relativePath.StartsWith("~"))
            {
                return HttpContext.Current.Server.MapPath(relativePath);
            }

            if (relativePath.StartsWith("/") || relativePath.StartsWith("\\"))
            {
                return HttpContext.Current.Server.MapPath("~" + relativePath);
            }
            if (HttpContext.Current != null)
            {
                return relativePath + "bin";
            }
            return HttpContext.Current.Server.MapPath("~/" + relativePath);
        }
        private static Assembly[] FilterSystemAssembly(IEnumerable<Assembly> assemblies)
        {
            return assemblies
                .Where(assembly => !Regex.IsMatch(assembly.FullName, AssemblySkipLoadingPattern, RegexOptions.IgnoreCase | RegexOptions.Compiled))
                .ToArray();
        }

    }
}