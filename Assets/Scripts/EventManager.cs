using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour {
    private List<Event> eventlist;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void addEventtoList(Event ev)
    {
        eventlist.Add(ev);
    }
   
    public List<Event> GetLog()
    {
        return eventlist;
    }
}
