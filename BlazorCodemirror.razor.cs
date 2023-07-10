using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BlazorCodemirror
{
    public partial class BlazorCodemirror : ComponentBase, IDisposable
    {
        private DotNetObjectReference<BlazorCodemirror> dotNetHelper;

        [Inject]
        public IJSRuntime JSRuntime { get; set; }

        /// <summary>
        /// this is name
        /// </summary>
        [Parameter] public string ModeURL { get; set; } = "_content/BlazorCodemirror/js/%N.min.js";
        /// <summary>
        /// TextArea height,unit type px.
        /// </summary>
        [Parameter] public int Height { get; set; } = 300;
        /// <summary>
        /// Mime Type,see https://codemirror.net/5/mode/index.html
        /// </summary>
        [Parameter] public string Mime { get; set; } = "text/x-csharp";
        [Parameter] public string Id { get; set; } = "BlazorCodemirrorTextArea_" + Guid.NewGuid().ToString("N");

        [Parameter] public string Theme { get; set; } = "dracula";

        private string _value;
        [Parameter]
        public string Value
        {
            get => _value;
            set
            {
                if (_value == value) return;
                _value = value;
                ValueChanged.InvokeAsync(value);
                _bcji.SetEditorValue(Id, value);
            }
        }

        [Parameter]
        public EventCallback<string> ValueChanged { get; set; }

        [JSInvokable]
        public void SetEntityValue(string Val)
        {
            Value = Val;
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                dotNetHelper = DotNetObjectReference.Create(this);
                await _bcji.InitEditor(ModeURL, Mime, Height, Id, Theme, dotNetHelper);
            }
        }

        public void Dispose()
        {
            dotNetHelper?.Dispose();
        }
    }
}
