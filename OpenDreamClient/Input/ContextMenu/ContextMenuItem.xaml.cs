using OpenDreamClient.Rendering;
using OpenDreamShared.Dream;
using Robust.Client.AutoGenerated;
using Robust.Client.Graphics;
using Robust.Client.UserInterface.Controls;
using Robust.Client.UserInterface.XAML;

namespace OpenDreamClient.Input.ContextMenu;

[GenerateTypedNameReferences]
internal sealed partial class ContextMenuItem : PanelContainer {
    private static readonly StyleBox HoverStyle = new StyleBoxFlat(Color.Gray);

    public readonly ClientObjectReference Target;
    public readonly MetaDataComponent EntityMetaData;
    public readonly DMISpriteComponent? EntitySprite;

    private readonly ContextMenuPopup _menu;

    public ContextMenuItem(ContextMenuPopup menu, ClientObjectReference target, MetaDataComponent metadata, DMISpriteComponent sprite) {
        IoCManager.InjectDependencies(this);
        RobustXamlLoader.Load(this);

        Target = target;
        EntityMetaData = metadata;
        EntitySprite = sprite;
        _menu = menu;

        NameLabel.Margin = new Thickness(2, 0, 4, 0);
        NameLabel.Text = metadata.EntityName;

        Icon.Texture = sprite.Icon.CurrentFrame;
    }

    protected override void MouseEntered() {
        base.MouseEntered();

        PanelOverride = HoverStyle;
        _menu.SetActiveItem(this);
    }

    protected override void MouseExited() {
        base.MouseExited();

        PanelOverride = null;
    }
}
