export function InitEditor(modeUrl, mime, height, width, id, theme,readonly) {
    CodeMirror.modeURL = modeUrl;
    var textArea = document.getElementById(id);
    var editor = CodeMirror.fromTextArea(textArea,
        {
            lineNumbers: true,
            theme: theme,
            indentUnit: 4,
            readOnly: readonly
        });
    editor.setSize(width, height);
    var val = mime, m, mode, spec;

    if (m = /.+\.([^.]+)$/.exec(val)) {
        var info = CodeMirror.findModeByExtension(m[1]);
        if (info) {
            mode = info.mode;
            spec = info.mime;
        }
    } else if (/\//.test(val)) {
        var info = CodeMirror.findModeByMIME(val);
        if (info) {
            mode = info.mode;
            spec = val;
        }
    } else {
        mode = spec = val;
    }
    if (mode) {
        editor.setOption("mode", spec);
        CodeMirror.autoLoadMode(editor, mode);
    } else {
        alert("Could not find a mode corresponding to " + val);
    }
    editor.on('blur', function () {
        SetEntityValue(editor.getValue());
    });
}

export function SetEditorValue(id, val) {
    var editor = document.querySelector('#' + id + ' + .CodeMirror').CodeMirror;
    editor.setValue(val);
}
export function SetDotNetHelper(value) {
    window.dotNetHelper = value;
}
export function SetEntityValue(Val) {
    window.dotNetHelper.invokeMethodAsync('SetEntityValue', Val);
}

export function SetEditorMode(id, mime) {
    var editor = document.querySelector('#' + id + ' + .CodeMirror').CodeMirror;
    var val = mime, m, mode, spec;

    if (m = /.+\.([^.]+)$/.exec(val)) {
        var info = CodeMirror.findModeByExtension(m[1]);
        if (info) {
            mode = info.mode;
            spec = info.mime;
        }
    } else if (/\//.test(val)) {
        var info = CodeMirror.findModeByMIME(val);
        if (info) {
            mode = info.mode;
            spec = val;
        }
    } else {
        mode = spec = val;
    }
    if (mode) {
        editor.setOption("mode", spec);
        CodeMirror.autoLoadMode(editor, mode);
    } else {
        alert("Could not find a mode corresponding to " + val);
    }
}
