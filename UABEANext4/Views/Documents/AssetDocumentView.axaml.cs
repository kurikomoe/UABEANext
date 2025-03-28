using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using System.Linq;
using UABEANext4.AssetWorkspace;
using UABEANext4.ViewModels.Documents;

namespace UABEANext4.Views.Documents;
public partial class AssetDocumentView : UserControl
{
    public AssetDocumentView()
    {
        InitializeComponent();

        if (DataContext is AssetDocumentViewModel docVm)
        {
            docVm.ShowPluginsContextMenu += ShowPluginsContextMenu;
            docVm.ShowFiltersContextMenu += ShowFiltersContextMenu;
        }
    }

    private void ShowPluginsContextMenu()
    {
        FlyoutBase.ShowAttachedFlyout(showPluginsBtn);
    }
    
    private void ShowFiltersContextMenu()
    {
        FlyoutBase.ShowAttachedFlyout(showFiltersBtn);
    }

    // necessary since SelectedItems isn't bindable
    private void DataGrid_SelectionChanged(object? sender, SelectionChangedEventArgs e)
    {
        if (DataContext is AssetDocumentViewModel docVm)
        {
            var selectedAssetInsts = dataGrid.SelectedItems.Cast<AssetInst>().ToList();
            docVm.OnAssetOpened(selectedAssetInsts);
        }
    }
}
