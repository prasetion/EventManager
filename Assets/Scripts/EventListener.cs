using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventListener : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        EventManager<string>.RegisterEvent("testEvent", OnClick);
    }

    private void OnClick(string response)
    {
        // throw new NotImplementedException();
        Debug.Log("Event triggered with response: " + response);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
            EventManager<string>.TriggerEvent("testEvent", "ini adalah response");
    }
}
