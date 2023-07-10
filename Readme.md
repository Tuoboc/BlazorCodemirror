# BlazorCodemirror
---
This is a code editor component for Blazor,based on Codemirror 5.65.13.  
Component include [c-like](https://codemirror.net/5/mode/clike/index.html) mode and [dracula](https://codemirror.net/5/demo/theme.html#dracula) theme.

## Base Usage
Add package from nuget  
`dotnet add package BlazorCodemirror`

Add style link to index.html
```
<link href="_content/BlazorCodemirror/css/BlazorCodemirror.css" rel="stylesheet" />
<link href="_content/BlazorCodemirror/css/codemirror_5.65.13_theme_dracula.min.css" rel="stylesheet" />
```

Add service to Program.cs  
`builder.Services.AddBlazorCodeMirror();`

Add BlazorCodemirror component in your code  
`<BlazorCodemirror.BlazorCodemirror></BlazorCodemirror.BlazorCodemirror>`
## Parameters
* Id  
  - Component id,if page contains more than one editor,use the id parameter opearate the editor.
* Height
  - Component height,unit px,default value 300px.
* Mime
  - Editor mode,default value `text/x-csharp`.
* ModeURL
  - User mode file directory,default value `_content/BlazorCodemirror/js/%N.min.js`
* Theme
  - Codemirror theme,default value `dracula`
  
## Change code mode
1.Download mode file. for example: [javascript](https://codemirror.net/5/mode/javascript/javascript.js)  
2.Rename file to {modename}.min.js. for example: javascript.min.js   
3.Move file to wwwroot/js  
4.Add BlazorCodemirror section to your code  
`<BlazorCodemirror.BlazorCodemirror Mime="text/javascript" ModeURL="js/%N.min.js"></BlazorCodemirror.BlazorCodemirror>`  
## Change theme  
1.Download theme file  
2.Move file to wwwroot/css  
3.Add style link to index.html  
4.Set Theme parameter for example:  
`<BlazorCodemirror.BlazorCodemirror Mime="text/x-csharp" Theme="dracula" Height="300" ModeURL="_content/BlazorCodemirror/js/%N.min.js" @bind-Value="@data.Template"></BlazorCodemirror.BlazorCodemirror>`