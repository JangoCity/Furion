# 选项

提供强类型对象读取配置方式。

---

## 关于选项 <Badge text="推荐" type="warning" />

选项模式是 `ASP.NET Core` 推荐的动态读取配置的方式，这种方式将配置文件数据用一个强类型来托管，能够实现默认值设置，动态热加载等等功能。

## 两者区别

选项和配置最大的区别就是前者通过强类型封装配置节点，可通过面向对象的方式读取配置。

## 如何使用

例如，我们需要动态配置应用的名称、版本号及版权信息。

### 配置 `appsetting.json`

```json {2-6}
{
  "AppInfo": {
    "Name": "Fur",
    "Version": "1.0.0",
    "Company": "Baiqian"
  }
}
```

### 创建强类型类

```cs {1,5-7}
using Fur.Options;

namespace Fur.Application
{
    // 配置 `appsetting.json` 中对应的键名
    [OptionsSettings("AppInfo")]
    public class AppInfoOptions : IAppOptions
    {
        public string Name { get; set; }
        public string Version { get; set; }
        public string Company { get; set; }
    }
}
```

::: warning 选项说明
在 `Fur` 框架中，选项需继承 `IAppOptions` 接口，该接口在 `Fur.Options` 命名空间下。

默认情况下，Fur 会根据**类名**查找 `appsetting.json` 对应的键，若类型和配置不一样，需通过 `[OptionsSettings(jsonKey)]` 特性指定。
:::

### 读取选项

#### 🥒 直接读取 <Badge text="不推荐" type="error" />

```cs
var appInfo = App.Configuration.GetSection("AppInfo").Get<AppInfoOptions>();
```

::: tip 不推荐理由
直接读取的方式无法应用于选项验证和后期配置功能。
:::

#### 🥒 使用依赖注入配置选项 <Badge text="推荐" type="warning" />

- 在 `Fur.Web.Entry` 项目 `Startup.cs` 中 `ConfigureServices` 添加如下配置：

```cs {2,8,10,12}
using Fur.Application;
using Microsoft.Extensions.DependencyInjection;

namespace Fur.Web.Entry
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddFur(options =>
            {
                options.AddAppOptions<AppInfoOptions>();
            });

            services.AddControllers();
        }
    }
}
```

- 在**可依赖注入类**中使用

```cs {3,10-13}
using Fur.Application;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Fur.Web.Entry.Controllers
{
    [Route("api/[controller]")]
    public class DefaultController : ControllerBase
    {
        private readonly AppInfoOptions _appInfoOptions;
        public DefaultController(IOptionsMonitor<AppInfoOptions> optionsMonitor)
        {
            _appInfoOptions = optionsMonitor.CurrentValue;
        }
    }
}
```

- 在**静态类**中使用

```cs
var appInfoOptions = App.GetOptions<AppInfoOptions>();
```

## 选项验证

Fur 支持特性方式和自定义复杂验证方式验证选项值。

### 特性方式

```cs {2,10,12,14}
using Fur.Options;
using System.ComponentModel.DataAnnotations;

namespace Fur.Application
{
    // 配置 `appsetting.json` 中对应的键名
    [OptionsSettings("AppInfo")]
    public class AppInfoOptions : IAppOptions
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Version { get; set; }
        [MinLength(20)]
        public string Company { get; set; }
    }
}
```

### 自定义验证

#### 🥒 创建自定义验证类，需继承 `IValidateOptions<TOptions>`接口，如：`AppInfoOptionsValidation`：

```cs {1,5-14}
using Microsoft.Extensions.Options;

namespace Fur.Application
{
    public class AppInfoOptionsValidation : IValidateOptions<AppInfoOptions>
    {
        public ValidateOptionsResult Validate(string name, AppInfoOptions options)
        {
            if (options.Company.Length <= 20)
            {
                return ValidateOptionsResult.Fail("公司名称不能少于20个字符");
            }

            return ValidateOptionsResult.Success;
        }
    }
}
```

#### 🥒 关联选项验证

只需要继承 `IAppOptions<TOptions, IValidateOptions<TOptions>>` 接口即可。

```cs {8}
using Fur.Options;
using System.ComponentModel.DataAnnotations;

namespace Fur.Application
{
    // 配置 `appsetting.json` 中对应的键名
    [OptionsSettings("AppInfo")]
    public class AppInfoOptions : IAppOptions<AppInfoOptions, AppInfoOptionsValidation>
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Version { get; set; }
        [Required]
        public string Company { get; set; }
    }
}
```

#### 🥒 完整代码

```cs
using Fur.Options;
using Microsoft.Extensions.Options;
using System.ComponentModel.DataAnnotations;

namespace Fur.Application
{
    // 配置 `appsetting.json` 中对应的键名
    [OptionsSettings("AppInfo")]
    public class AppInfoOptions : IAppOptions<AppInfoOptions, AppInfoOptionsValidation>
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Version { get; set; }
        [Required]
        public string Company { get; set; }
    }

    public class AppInfoOptionsValidation : IValidateOptions<AppInfoOptions>
    {
        public ValidateOptionsResult Validate(string name, AppInfoOptions options)
        {
            if (options.Company.Length <= 20)
            {
                return ValidateOptionsResult.Fail("公司名称不能少于20个字符");
            }

            return ValidateOptionsResult.Success;
        }
    }
}
```

## 后期配置

后期配置选项也就是当配置不存在时默认配置。

```cs {7,13-15}
using Fur.Options;

namespace Fur.Application
{
    // 配置 `appsetting.json` 中对应的键名
    [OptionsSettings("AppInfo")]
    public class AppInfoOptions : IAppOptions<AppInfoOptions>
    {
        public string Name { get; set; }
        public string Version { get; set; }
        public string Company { get; set; }

        public void PostConfigure(AppInfoOptions options)
        {
            options.Name = "默认名称";
        }
    }
}
```

::: tip 特别说明
选项验证默认继承了后期配置接口，接口定义源码为：

```cs
using Microsoft.Extensions.Options;

namespace Fur.Options
{
    public partial interface IAppOptions { }

    public partial interface IAppOptions<TOptions> : IAppOptions
        where TOptions : class, IAppOptions
    {
        void PostConfigure(TOptions options) { }
    }

    public partial interface IAppOptions<TOptions, TOptionsValidation> : IAppOptions<TOptions>
        where TOptions : class, IAppOptions
        where TOptionsValidation : class, IValidateOptions<TOptions>
    {
    }
}
```

:::

## 自定义查找键

默认情况下，Fur 会根据**类名**查找 `appsetting.json` 对应的键，若类型和配置不一样，需通过 `[OptionsSettings(string)]` 特性指定。

```cs {6}
using Fur.Options;

namespace Fur.Application
{
    // 配置 `appsetting.json` 中对应的键名
    [OptionsSettings("AppInfo")]
    public class AppInfoOptions : IAppOptions
    {
        public string Name { get; set; }
        public string Version { get; set; }
        public string Company { get; set; }
    }
}
```

## 注册选项

`Fur` 框架提供了便捷的选项注入拓展方法，如：

```cs
services.AddAppOptions<AppInfoOptions>();
```

::: warning 特别注意
`services.AddAppOptions<TOptions>()` 拓展需在 `services.AddFur()` 调用之后注册或通过委托在里面注册。

以下两个代码都是有效的：

```cs
services.AddFur();
services.AddAppOptions<AppInfoOptions>();
```

```cs
// 推荐使用此方式
services.AddFur(options =>
{
    options.AddAppOptions<AppInfoOptions>();
});
```

:::

---

😀😁😂🤣😃😄😍😎

::: details 了解更多

想了解更多 `选项` 知识可查阅 [ASP.NET Core - 选项](https://docs.microsoft.com/zh-cn/aspnet/core/fundamentals/configuration/options?view=aspnetcore-5.0) 章节。

:::