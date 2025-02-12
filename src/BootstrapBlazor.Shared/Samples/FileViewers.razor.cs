﻿// Copyright (c) Argo Zhang (argo@163.com). All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.
// Website: https://www.blazor.zone or https://argozhang.github.io/

namespace BootstrapBlazor.Shared.Samples;

/// <summary>
/// FileViewers
/// </summary>
public partial class FileViewers
{
    /// <summary>
    /// GetAttributes
    /// </summary>
    /// <returns></returns>
    private IEnumerable<AttributeItem> GetAttributes() => new AttributeItem[]
    {
        // TODO: 移动到数据库中
        new() {
            Name = nameof(FileViewer.Filename),
            Description = "Excel/Word 文件路径或者URL",
            Type = "string",
            ValueList = " — ",
            DefaultValue = " — "
        },
        new() {
            Name = nameof(FileViewer.Width),
            Description = "宽度",
            Type = "string",
            ValueList = "-",
            DefaultValue = "100%"
        },
        new() {
            Name = nameof(FileViewer.Height),
            Description = "高度",
            Type = "string",
            ValueList = " — ",
            DefaultValue = "700px"
        },
        new() {
            Name = nameof(FileViewer.StyleString),
            Description = "组件外观 Css Style",
            Type = "string",
            ValueList = "-",
            DefaultValue = "-"
        },
        new() {
            Name = nameof(FileViewer.Html),
            Description = "设置 Html 直接渲染",
            Type = "string",
            ValueList = "-",
            DefaultValue = "-"
        },
        new() {
            Name = nameof(FileViewer.Stream),
            Description = "用于渲染的文件流,为空则用Filename参数读取文件",
            Type = "Stream",
            ValueList = "-",
            DefaultValue = "-"
        },
        new() {
            Name = nameof(FileViewer.IsExcel),
            Description = "文件流模式需要指定是否 Excel",
            Type = "bool",
            ValueList = "true|false",
            DefaultValue = "false"
        },
        new() {
            Name = nameof(FileViewer.NodataString),
            Description = "无数据提示文本",
            Type = "string",
            ValueList = "-",
            DefaultValue = "无数据"
        },
        new() {
            Name = nameof(FileViewer.LoadingString),
            Description = "载入中提示文本",
            Type = "string",
            ValueList = "-",
            DefaultValue = "载入中..."
        },
        new() {
            Name = "Reload(string filename)",
            Description = "重新载入文件方法",
            Type = "async Task",
            ValueList = " — ",
            DefaultValue = " — "
        },
        new() {
            Name = "Refresh()",
            Description = "刷新方法",
            Type = "async Task",
            ValueList = " — ",
            DefaultValue = " — "
        }
    };
}
