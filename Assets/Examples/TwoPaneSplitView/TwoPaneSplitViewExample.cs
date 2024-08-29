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
        VisualElement root = rootVisualElement;
        //CreateTwoPanelSplitView(root);
        CreateThreePanelSplitView(root);
    }

    private void CreateTwoPanelSplitView(VisualElement parent)
    {
        // Main
        var mainContainer = new TwoPaneSplitView(0, 300, TwoPaneSplitViewOrientation.Horizontal);
        parent.Add(mainContainer);

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

    private void CreateThreePanelSplitView(VisualElement parent)
    {
        // Left & Mid
        var leftMidContainer = new TwoPaneSplitView(0, 300, TwoPaneSplitViewOrientation.Horizontal);
        var midRightContainer = new TwoPaneSplitView(0, 300, TwoPaneSplitViewOrientation.Horizontal);
        parent.Add(leftMidContainer);

        // Left
        VisualElement leftContainer = new VisualElement();
        leftContainer.name = "left";
        leftContainer.style.minWidth = 300;
        leftContainer.Add(CreateLabel("Left"));
        leftMidContainer.Add(leftContainer);
        leftMidContainer.Add(midRightContainer);

        // Mid
        VisualElement middleContainer = new VisualElement();
        middleContainer.name = "Middle";
        middleContainer.style.minWidth = 300;
        middleContainer.Add(CreateLabel("Middle"));
        midRightContainer.Add(middleContainer);

        // Right
        VisualElement rightContainer = new VisualElement();
        rightContainer.name = "right";
        rightContainer.Add(CreateLabel("Right"));
        midRightContainer.Add(rightContainer);
    }

    private Label CreateLabel(string text)
    {
        return new Label(text);
    }
}
