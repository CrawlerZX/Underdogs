using UnityEngine;
using UnityEditor;
public class HierarchyMenu
{
    // Text.
    [MenuItem("GameObject/Create Other/Text")]
    public static void CreateText()
    {
        InstantiatePrefab("Prefabs/Text");
    }
    // Button.
    [MenuItem("GameObject/Create Other/Button")]
    public static void CreateButton()
    {
        InstantiatePrefab("Prefabs/Button");
    }
    // Toggle.
    [MenuItem("GameObject/Create Other/Toggle")]
    public static void CreateToggle()
    {
        InstantiatePrefab("Prefabs/Toggle");
    }
    // Toggle Switch.
    [MenuItem("GameObject/Create Other/Toggle Switch")]
    public static void CreateSwitch()
    {
        InstantiatePrefab("Prefabs/Toggle Switch");
    }
    // Slider.
    [MenuItem("GameObject/Create Other/Slider")]
    public static void CreateSlider()
    {
        InstantiatePrefab("Prefabs/Slider");
    }
    // Scrollbar.
    [MenuItem("GameObject/Create Other/Scrollbar")]
    public static void CreateScrollbar()
    {
        InstantiatePrefab("Prefabs/Scrollbar");
    }
    // Dropdown.
    [MenuItem("GameObject/Create Other/Dropdown")]
    public static void CreateDropdown()
    {
        InstantiatePrefab("Prefabs/Dropdown");
    }
    // InputField.
    [MenuItem("GameObject/Create Other/Input Field")]
    public static void CreateInputfield()
    {
        InstantiatePrefab("Prefabs/InputField");
    }
    // Panel.
    [MenuItem("GameObject/Create Other/Panel")]
    public static void CreatePanel()
    {
        InstantiatePrefab("Prefabs/Panel");
    }
    // Scroll View.
    [MenuItem("GameObject/Create Other/Scroll View")]
    public static void CreateScrollView()
    {
        InstantiatePrefab("Prefabs/Scroll View");
    }
    // Dialog.
    [MenuItem("GameObject/Create Other/Dialog")]
    public static void CreateDialog()
    {
        InstantiatePrefab("Prefabs/Dialog");
    }
    //-----------------------------------------------------------------------------------------------
    private static void InstantiatePrefab(string resourcesPatch)
    {
        if (MonoBehaviour.FindObjectOfType<Canvas>() == null)
        {
            // Create firts canvas.
            CreateFirtsCanvas();
        }
        // Create object.
        GameObject m_object;
        m_object = UnityEditor.PrefabUtility.InstantiatePrefab(Resources.Load(resourcesPatch, typeof(GameObject))) as GameObject;
        m_object.layer = 5;
        m_object.name = Resources.Load(resourcesPatch, typeof(GameObject)).name;
        // Parent with canvas.
        if (Selection.activeGameObject != null)
        {
            if (Selection.activeGameObject.GetComponent<Canvas>())
            {
                m_object.transform.SetParent(Selection.activeGameObject.transform);
            }
            else
            {
                m_object.transform.SetParent(MonoBehaviour.FindObjectOfType<Canvas>().transform);
            }
        }
        else
        {
            m_object.transform.SetParent(MonoBehaviour.FindObjectOfType<Canvas>().transform);
        }
        // reset scale and position.
        m_object.transform.localScale = new Vector3(1, 1, 1);
        m_object.GetComponent<RectTransform>().offsetMin = Vector2.zero;
        m_object.GetComponent<RectTransform>().offsetMax = Vector2.zero;
        GameObject m_sizeOrigin;
        m_sizeOrigin = Resources.Load(resourcesPatch, typeof(GameObject)) as GameObject;
        m_object.GetComponent<RectTransform>().sizeDelta = m_sizeOrigin.GetComponent<RectTransform>().sizeDelta;
        // Hierarchy select.
        Selection.activeGameObject = m_object;
    }
    static void CreateFirtsCanvas()
    {
        GameObject m_Canvas;
        // m_Canvas = UnityEditor.PrefabUtility.InstantiatePrefab(Resources.Load("Prefabs/Canvas", typeof(GameObject))) as GameObject;
        // m_Canvas.name = Resources.Load("Prefabs/Canvas", typeof(GameObject)).name;
        m_Canvas = new GameObject("Canvas");
        m_Canvas.AddComponent<Canvas>();
        m_Canvas.GetComponent<Canvas>().renderMode = RenderMode.ScreenSpaceOverlay;
        m_Canvas.AddComponent<UnityEngine.UI.CanvasScaler>();
        m_Canvas.AddComponent<UnityEngine.UI.GraphicRaycaster>();
        m_Canvas.layer = 5;
        // Event system.
        CreateEventSystem();
    }
    // InputField.
    [MenuItem("GameObject/Create Other/Event System")]
    static void CreateEventSystem()
    {
        if (MonoBehaviour.FindObjectOfType<UnityEngine.EventSystems.EventSystem>() == null)
        {
            GameObject m_Event;
            m_Event = new GameObject("EventSystem");
            m_Event.AddComponent<UnityEngine.EventSystems.EventSystem>();
            m_Event.AddComponent<UnityEngine.EventSystems.StandaloneInputModule>();
        }
    }
}