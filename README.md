# Eto.Generator

Generates views/controls for models in Eto.Forms.

## Usage

[Using dotnet script](https://github.com/filipw/dotnet-script)

```csharp
#! "netcoreapp2.0"

#r "nuget: Eto.Forms, *"
#r "nuget: Eto.Platform.Gtk, *"
#r "Eto.Generator.dll"

using Eto.Forms;
using Eto.Generator;

class MyModel
{
    public string Title { get; set; }
    public bool? IsChecked { get; set; }
    public List<string> StringList { get; set; }
}
var app = new Application(new Eto.GtkSharp.Platform());
var gridView = new GridViewGenerator().GetGridView<MyModel>(); //That's all you need for basic usage
gridView.DataStore = new []{
    new MyModel{
        Title = "My First Model",
        IsChecked = true,
        StringList = new List<string>{
            "First",
            "Second"
        }
    },
    new MyModel{
        Title = "My Second Model",
        IsChecked = null,
        StringList = null
    }
};
app.Run(new Form {
    Title = "Generator Test",
    Content = gridView
})
```

Result:

![Result Image](https://raw.githubusercontent.com/SlowLogicBoy/Eto.Generator/master/Resources/sample1.PNG "Result image")

## TODO

- [ ] Editable support
