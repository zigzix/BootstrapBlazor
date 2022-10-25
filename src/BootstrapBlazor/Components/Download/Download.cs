﻿// Copyright (c) Argo Zhang (argo@163.com). All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.
// Website: https://www.blazor.zone or https://argozhang.github.io/

namespace BootstrapBlazor.Components;

/// <summary>
/// 下载组件
/// </summary>
[JSModuleAutoLoader]
public class Download : BootstrapModuleComponentBase
{
    [Inject]
    [NotNull]
    private DownloadService? DownloadService { get; set; }

    /// <summary>
    /// OnInitialized 方法
    /// </summary>
    protected override void OnInitialized()
    {
        base.OnInitialized();

        DownloadService.RegisterStream(this, DownloadFromStream);
        DownloadService.RegisterUrl(this, DownloadFromUrl);
    }

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    /// <returns></returns>
    protected override Task ModuleInitAsync() => Task.CompletedTask;

    /// <summary>
    /// 调用 download 方法
    /// </summary>
    /// <param name="option"></param>
    /// <returns></returns>
    protected virtual async Task DownloadFromStream(DownloadOption option)
    {
        if (option.FileStream == null)
        {
            throw new InvalidOperationException($"the {nameof(option.FileStream)} is null");
        }
        if (Module != null)
        {
#if NET5_0
            // net 5.0 not support
            await Task.CompletedTask;
#elif NET6_0_OR_GREATER
            using var streamRef = new DotNetStreamReference(option.FileStream);
            await Module.InvokeVoidAsync($"{ModuleName}.downloadFileFromStream", option.FileName, streamRef);
#endif
        }
    }

    /// <summary>
    /// 调用 CreateUrl 方法
    /// </summary>
    /// <param name="option"></param>
    /// <returns></returns>
    protected virtual async Task DownloadFromUrl(DownloadOption option)
    {
        if (string.IsNullOrEmpty(option.Url))
        {
            throw new InvalidOperationException($"{nameof(option.Url)} not set");
        }

        if (Module != null)
        {
            await Module.InvokeVoidAsync($"{ModuleName}.downloadFileFromUrl", option.FileName, option.Url);
        }
    }

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    protected override async ValueTask DisposeAsync(bool disposing)
    {
        if (disposing)
        {
            DownloadService.UnRegisterStream(this);
            DownloadService.UnRegisterUrl(this);
        }

        await base.DisposeAsync(disposing);
    }
}
