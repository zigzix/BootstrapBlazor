﻿// Copyright (c) Argo Zhang (argo@163.com). All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.
// Website: https://www.blazor.zone or https://argozhang.github.io/

using Console = BootstrapBlazor.Components.Console;

namespace UnitTest.Components;

public class ConsoleTest : BootstrapBlazorTestBase
{
    [Fact]
    public void Height_OK()
    {
        var cut = Context.RenderComponent<Console>(builder => builder.Add(a => a.Height, 100));

        Assert.Contains("style=\"height: 100px;\"", cut.Markup);
    }

    [Fact]
    public void HeaderText_OK()
    {
        var cut = Context.RenderComponent<Console>(builder => builder.Add(a => a.HeaderText, "HeaderText"));

        Assert.Contains("HeaderText", cut.Markup);
    }

    [Fact]
    public void Items_OK()
    {
        var cut = Context.RenderComponent<Console>(builder =>
        {
            builder.Add(a => a.Items, new List<ConsoleMessageItem>()
            {
                new ConsoleMessageItem() {Message = "Test1"}, new ConsoleMessageItem() {Message = "Test2"}
            });
        });

        var res = cut.Find(".console-window").HasChildNodes;
        Assert.True(res);

        cut.SetParametersAndRender(pb =>
        {
            pb.Add(a => a.ItemTemplate, item => builder =>
            {
                builder.AddContent(0, $"test-{item.Message}-end");
            });
        });
        cut.Contains("test-Test1-end");
        cut.Contains("test-Test2-end");
    }

    [Fact]
    public void OnClear_OK()
    {
        var clearClicked = false;
        var cut = Context.RenderComponent<Console>(builder =>
        {
            builder.Add(a => a.Items, new List<ConsoleMessageItem>()
            {
                new ConsoleMessageItem() {Message = "Test1"}, new ConsoleMessageItem() {Message = "Test2"}
            });
        });
        Assert.DoesNotContain("btn-secondary", cut.Markup);
        Assert.False(clearClicked);

        // 实例触发 OnClear 方法
        cut.Instance.ClearConsole();

        cut.SetParametersAndRender(pb =>
        {
            pb.Add(a => a.OnClear, new Action(() =>
            {
                clearClicked = true;
            }));
        });
        cut.Find(".btn-secondary").Click();
        Assert.True(clearClicked);
    }

    [Fact]
    public void ClearButtonText_OK()
    {
        var cut = Context.RenderComponent<Console>(builder =>
        {
            builder.Add(a => a.Items, new List<ConsoleMessageItem>()
            {
                new ConsoleMessageItem() {Message = "Test1"}, new ConsoleMessageItem() {Message = "Test2"}
            });
            builder.Add(a => a.OnClear, new Action(() => { }));
            builder.Add(a => a.ClearButtonText, "Console Clear");
        });

        Assert.Contains("Console Clear", cut.Markup);
    }

    [Fact]
    public void OnClearButtonText_OK()
    {
        var cut = Context.RenderComponent<Console>(builder =>
        {
            builder.Add(a => a.Items, new List<ConsoleMessageItem>()
            {
                new ConsoleMessageItem() {Message = "Test1"}, new ConsoleMessageItem() {Message = "Test2"}
            });
            builder.Add(a => a.OnClear, new Action(() => { }));
            builder.Add(a => a.ClearButtonIcon, "fa-solid fa-xmark");
        });

        Assert.Contains("fa-solid fa-xmark", cut.Markup);
    }


    [Fact]
    public void ClearButtonColor_OK()
    {
        var cut = Context.RenderComponent<Console>(builder =>
        {
            builder.Add(a => a.Items, new List<ConsoleMessageItem>()
            {
                new ConsoleMessageItem() {Message = "Test1"}, new ConsoleMessageItem() {Message = "Test2"}
            });
            builder.Add(a => a.OnClear, new Action(() => { }));
            builder.Add(a => a.ClearButtonColor, Color.Primary);
        });

        Assert.Contains("btn-primary", cut.Markup);
    }

    [Fact]
    public void ShowAutoScroll_OK()
    {
        var cut = Context.RenderComponent<Console>(builder =>
        {
            builder.Add(a => a.Items, new List<ConsoleMessageItem>()
            {
                new ConsoleMessageItem() {Message = "Test1"}, new ConsoleMessageItem() {Message = "Test2"}
            });
            builder.Add(a => a.ShowAutoScroll, true);
        });

        Assert.Contains("form-check", cut.Markup);
    }

    [Fact]
    public void AutoScrollString_OK()
    {
        var cut = Context.RenderComponent<Console>(builder =>
        {
            builder.Add(a => a.Items, new List<ConsoleMessageItem>()
            {
                new ConsoleMessageItem() {Message = "Test1"}, new ConsoleMessageItem() {Message = "Test2"}
            });
            builder.Add(a => a.IsAutoScroll, true);
        });
        Assert.Contains("data-bb-scroll=\"auto\"", cut.Markup);

        cut.SetParametersAndRender(pb =>
        {
            pb.Add(a => a.IsAutoScroll, false);
        });
        Assert.DoesNotContain("data-bb-scroll=\"auto\"", cut.Markup);
    }

    [Fact]
    public void AutoScrollText_OK()
    {
        var cut = Context.RenderComponent<Console>(builder =>
        {
            builder.Add(a => a.Items, new List<ConsoleMessageItem>()
            {
                new ConsoleMessageItem() {Message = "Test1"}, new ConsoleMessageItem() {Message = "Test2"}
            });
            builder.Add(a => a.AutoScrollText, "AutoScrollText");
            builder.Add(a => a.ShowAutoScroll, true);
        });

        Assert.Contains("AutoScrollText", cut.Markup);
    }

    [Fact]
    public void LightTitle_OK()
    {
        var cut = Context.RenderComponent<Console>(builder =>
        {
            builder.Add(a => a.Items, new List<ConsoleMessageItem>()
            {
                new ConsoleMessageItem() {Message = "Test1"}, new ConsoleMessageItem() {Message = "Test2"}
            });
            builder.Add(a => a.LightTitle, "LightTitle");
        });

        Assert.Contains("LightTitle", cut.Markup);
    }

    [Fact]
    public void ClickAutoScroll_OK()
    {
        var cut = Context.RenderComponent<Console>(builder =>
        {
            builder.Add(a => a.Items, new List<ConsoleMessageItem>()
            {
                new ConsoleMessageItem() {Message = "Test1"}, new ConsoleMessageItem() {Message = "Test2"}
            });
            builder.Add(a => a.ShowAutoScroll, true);
        });

        cut.Find(".card-footer input").Click();
        var res = cut.Instance.IsAutoScroll;
        Assert.False(res);
    }

    [Fact]
    public void MessageItemColor_OK()
    {
        var cut = Context.RenderComponent<Console>(builder =>
        {
            builder.Add(a => a.Items, new List<ConsoleMessageItem>()
            {
                new ConsoleMessageItem() {Message = "Test1", Color = Color.Danger}, new ConsoleMessageItem() {Message = "Test2"}
            });
        });

        Assert.Contains("text-danger", cut.Markup);
    }

    [Fact]
    public void FooterTemplate_OK()
    {
        var cut = Context.RenderComponent<Console>(pb =>
        {
            pb.Add(a => a.Items, new List<ConsoleMessageItem>()
            {
                new ConsoleMessageItem() {Message = "Test1", Color = Color.Danger}, new ConsoleMessageItem() {Message = "Test2"}
            });
            pb.Add(a => a.FooterTemplate, builder =>
            {
                builder.AddContent(0, "test-footer-template");
            });
        });
        Assert.Contains("test-footer-template", cut.Markup);
    }

    [Fact]
    public void ShowLight_OK()
    {
        var cut = Context.RenderComponent<Console>(pb =>
        {
            pb.Add(a => a.Items, new List<ConsoleMessageItem>()
            {
                new ConsoleMessageItem() {Message = "Test1", Color = Color.Danger}, new ConsoleMessageItem() {Message = "Test2"}
            });
            pb.Add(a => a.ShowLight, false);
        });
        Assert.DoesNotContain("light", cut.Markup);
    }

    [Fact]
    public void LightColor_OK()
    {
        var cut = Context.RenderComponent<Console>(pb =>
        {
            pb.Add(a => a.Items, new List<ConsoleMessageItem>()
            {
                new ConsoleMessageItem() {Message = "Test1", Color = Color.Danger}, new ConsoleMessageItem() {Message = "Test2"}
            });
            pb.Add(a => a.LightColor, Color.Danger);
        });
        Assert.Contains("light-danger", cut.Markup);
    }

    [Fact]
    public void IsFlashLight_OK()
    {
        var cut = Context.RenderComponent<Console>(pb =>
        {
            pb.Add(a => a.Items, new List<ConsoleMessageItem>()
            {
                new ConsoleMessageItem() {Message = "Test1", Color = Color.Danger}, new ConsoleMessageItem() {Message = "Test2"}
            });
            pb.Add(a => a.IsFlashLight, false);
        });
        Assert.DoesNotContain("flash", cut.Markup);
    }

    [Fact]
    public void HeaderTemplate_OK()
    {
        var cut = Context.RenderComponent<Console>(pb =>
        {
            pb.Add(a => a.Items, new List<ConsoleMessageItem>()
            {
                new ConsoleMessageItem() {Message = "Test1", Color = Color.Danger}, new ConsoleMessageItem() {Message = "Test2"}
            });
            pb.Add(a => a.HeaderTemplate, builder =>
            {
                builder.AddContent(0, "test-header-template");
            });
        });
        Assert.Contains("test-header-template", cut.Markup);
    }
}
