using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEventManager : MonoBehaviour {
    private List<GameEvent> eventlist;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void addEventtoList(GameEvent ev)
    {
        eventlist.Add(ev);
    }
   
    public List<GameEvent> GetLog()
    {
        return eventlist;
    }
}
