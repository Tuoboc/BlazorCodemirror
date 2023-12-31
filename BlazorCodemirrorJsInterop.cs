using Microsoft.JSInterop;

namespace BlazorCodemirror
{
    // This class provides an example of how JavaScript functionality can be wrapped
    // in a .NET class for easy consumption. The associated JavaScript module is
    // loaded on demand when first needed.
    //
    // This class can be registered as scoped DI service and then injected into Blazor
    // components for use.

    public class BlazorCodemirrorJsInterop : IAsyncDisposable
    {
        private readonly Lazy<Task<IJSObjectReference>> moduleTask;

        public BlazorCodemirrorJsInterop(IJSRuntime jsRuntime)
        {
            moduleTask = new(() => jsRuntime.InvokeAsync<IJSObjectReference>("import", "./_content/BlazorCodemirror/js/BlazorCodemirror.min.js").AsTask());
        }
        /// <summary>
        /// init editor
        /// </summary>
        /// <param name="ModeURL">mode file path,default value:_content/BlazorCodemirror/js/%N.min.js</param>
        /// <param name="Mime">mode mime ,default value:text/x-csharp</param>
        /// <param name="Height">editor height,default value:300px</param>
        /// <param name="Id">editor id</param>
        /// <param name="Theme">editor theme,default value:dracula</param>
        /// <param name="dotNetHelper"></param>
        /// <returns></returns>
        public async Task InitEditor(string ModeURL, string Mime, string Height, string Width, string Id, string Theme,bool ReadOnly, DotNetObjectReference<BlazorCodemirror> dotNetHelper)
        {
            var module = await moduleTask.Value;
            await module.InvokeVoidAsync("InitEditor", ModeURL, Mime, Height, Width, Id, Theme,ReadOnly);
            await module.InvokeVoidAsync("SetDotNetHelper", dotNetHelper);
        }
        /// <summary>
        /// set editor value
        /// </summary>
        /// <param name="Id">editor id</param>
        /// <param name="Val">value</param>
        /// <returns></returns>
        public async Task SetEditorValue(string Id, string Val)
        {
            var module = await moduleTask.Value;
            await module.InvokeVoidAsync("SetEditorValue", Id, Val);
        }
        /// <summary>
        /// change editor mode
        /// </summary>
        /// <param name="Id">editor id</param>
        /// <param name="Mime">mode mime</param>
        /// <returns></returns>
        public async Task SetEditorMode(string Id, string Mime)
        {
            var module = await moduleTask.Value;
            await module.InvokeVoidAsync("SetEditorMode", Id, Mime);
        }
        public async ValueTask DisposeAsync()
        {
            if (moduleTask.IsValueCreated)
            {
                var module = await moduleTask.Value;
                await module.DisposeAsync();
            }
        }
    }
}