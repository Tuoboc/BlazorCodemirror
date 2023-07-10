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

        public async Task InitEditor(string ModeURL, string Mime, int Height, string Id, string Theme, DotNetObjectReference<BlazorCodemirror> dotNetHelper)
        {
            var module = await moduleTask.Value;
            await module.InvokeVoidAsync("InitEditor", ModeURL, Mime, Height, Id, Theme);
            await module.InvokeVoidAsync("SetDotNetHelper", dotNetHelper);
        }

        public async Task SetEditorValue(string Id, string Val)
        {
            var module = await moduleTask.Value;
            await module.InvokeVoidAsync("SetEditorValue", Id, Val);
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