using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventListener : MonoBehaviour
{
    private delegate void EventDelegate();

    // Start is called before the first frame update
    void Start()
    {
        EventManager<string>.RegisterEvent("testEvent", OnClick);
        EventManager<EventDelegate>.RegisterEvent("eventDelegate", OnEventDelegate);
    }

    private void OnEventDelegate(EventDelegate eventDelegate)
    {
        // throw new NotImplementedException();
        Debug.Log("Event Delegate");
    }

    private void OnClick(string response)
    {
        // throw new NotImplementedException();
        Debug.Log("Event triggered with response: " + response);
        EventManager<string>.UnregisterEvent("testEvent", OnClick);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            EventManager<string>.TriggerEvent("testEvent", "ini adalah response");
            EventManager<EventDelegate>.TriggerEvent("eventDelegate", null);
        }
    }
}
