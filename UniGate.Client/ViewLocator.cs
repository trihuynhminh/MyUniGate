using System;
using Avalonia.Controls;
using Avalonia.Controls.Templates;
using UniGate.Client.ViewModels;

namespace UniGate.Client;

public class ViewLocator : IDataTemplate
{
    public Control? Build(object? data)
    {
        if (data is null)
            return null;

        var name = data.GetType().FullName!.Replace("ViewModel", "View", StringComparison.Ordinal);
        // Logic: Nó sẽ tự đổi tên:
        // UniGate.Client.ViewModels.HomeViewModel 
        // -> UniGate.Client.Views.HomeView

        var type = Type.GetType(name);

        if (type != null)
        {
            return (Control)Activator.CreateInstance(type)!;
        }

        // Nếu không tìm thấy, nó hiện dòng chữ này giúp mình debug
        return new TextBlock { Text = "⚠️ Không tìm thấy View: " + name };
    }

    public bool Match(object? data)
    {
        return data is ViewModelBase;
    }
}