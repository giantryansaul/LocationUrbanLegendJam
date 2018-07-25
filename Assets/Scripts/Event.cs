using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Event : MonoBehaviour {
    
    public Location location;
    public Item item;
    public float time;
    private List<Event> eventList;
    private EventManager em;
    //private action action
    public string action;
    public string log;
    private ItemManager IM;
	// Use this for initialization
	void Start () {
  

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void createEvent(int itemId, string act, Location loc)
    {
        var item = IM.GetItemById(itemId);
        location = loc;
        action = act;
        time = Time.time;

    }
    public string DisplayLog()
    {
        eventList = em.GetLog();
        IEnumerable<Event> query = eventList.OrderBy(x => x.time);

        foreach (Event itm in query)
        {
            log += "You " + itm.action + " the " + itm.item.Name +  " at " + itm.location;
        }

        return log;
    }
    
}
