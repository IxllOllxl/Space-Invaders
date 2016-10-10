using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;


public class AdaptingEventSystemDragThreshold : MonoBehaviour
{
    [SerializeField]
    private EventSystem eventSystem;
    [SerializeField][Range(50,200)]
    private int referenceDPI = 100;
    [SerializeField][Range(6,16)]
    private float referencePixelDrag = 8f;
    [SerializeField]
    private bool runOnAwake = true;

    void Awake()
    {
        if(Application.platform == RuntimePlatform.IPhonePlayer)
        {
            referenceDPI = 200;
            referencePixelDrag = 16;
        }
        if (runOnAwake)
        {
            eventSystem = GameObject.Find("EventSystem").GetComponent<EventSystem>();
            UpdatePixelDrag(Screen.dpi);
        }
    }

    public void UpdatePixelDrag(float screenDpi)
    {
        if (eventSystem == null)
        {
            Debug.LogWarning("Trying to set pixel drag for adapting to screen dpi, " +
                           "but there is no event system assigned to the script", this);
        }
        eventSystem.pixelDragThreshold = Mathf.RoundToInt(screenDpi / referenceDPI * referencePixelDrag);
    }

    void Reset()
    {
        if (eventSystem == null)
        {
            eventSystem = GetComponent<EventSystem>();
        }
    }
}