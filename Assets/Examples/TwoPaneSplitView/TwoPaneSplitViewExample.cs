using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class TwoPaneSplitViewExample : EditorWindow
{
    [SerializeField]
    private StyleSheet m_StyleSheet = default;

    [MenuItem("Study/Editor Windows/TwoPaneSplitViewExample")]
    public static void Show()
    {
        TwoPaneSplitViewExample wnd = GetWindow<TwoPaneSplitViewExample>();
        wnd.titleContent = new GUIContent("TwoPaneSplitViewExample");
        wnd.minSize = new Vector2(800, 600);
    }

    public void CreateGUI()
    {
        // Each editor window contains a root VisualElement object
        VisualElement root = rootVisualElement;

        // Main
        var mainContainer = new TwoPaneSplitView(0, 300, TwoPaneSplitViewOrientation.Horizontal);
        root.Add(mainContainer);

        // Left
        VisualElement leftContainer = new VisualElement();
        leftContainer.name = "left";
        leftContainer.style.minWidth = 300;
        leftContainer.Add(CreateLabel("Left"));
        mainContainer.Add(leftContainer);

        // Right
        VisualElement rightContainer = new VisualElement();
        rightContainer.name = "right";
        rightContainer.Add(CreateLabel("Right"));
        mainContainer.Add(rightContainer);
    }

    private Label CreateLabel(string text)
    {
        return new Label(text);
    }
}
