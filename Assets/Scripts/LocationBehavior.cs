using UnityEngine;
using UnityEngine.Events;

public class LocationBehavior : MonoBehaviour
{
    public Vector3 DropZone;//the area that the location with go
    private bool Accesslocation = false;// did they click on the location
    private bool WaitingINPUT = false;//when location gets access we wait for player input before update/recycling info
    private bool Done = false;//when we are done with the location
    public Question Question;//this is where the lore and answers will be stored

    public bool GetReponse = false;//when the user input for the question this will turn true
    public int Response;//this will be the user response to they question
    private GameObject _itemModel;
    public int LocationStoreId;
    public Location LocationReference;
    private bool _playerInLocation;
    [SerializeField] private LocationUI _locationUi;

    private void Start()
    {
        _playerInLocation = false;
    }
    
    public void InitializeLocation(Location location, int locationStoreId, Vector3 pos)
    {
        _itemModel = Instantiate(location.Model, transform);
        LocationReference = location;
        LocationStoreId = locationStoreId;
        DropZone = pos;
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            GetComponentInChildren<MeshRenderer>().material.color = Color.red;
            _playerInLocation = true;
        }
    }

    public bool OpenLocationMenu()
    {
        return _playerInLocation;
    }

    public bool Moved(Vector3 NewSpot)
    {
        DropZone = NewSpot;
        return true;
    }
    
    public void SetResponse(int selected)
    {
        //when the user picks an answer
        Response = selected;//we will set the response to the selected item
        GetReponse = true;//and tell the game an answer was picked
    }
    
    //used if they want to un-click the location
    public void PauseLocation()
    {
        Accesslocation = false;
        WaitingINPUT = false;
        Done = false;
        GetReponse = false;
    }

    //when the location has be selected return success/failure from the UI
    public bool SelectLocation()
    {
        if (Accesslocation == false)//if ready to be selected
        {
            Accesslocation = true;//location has been selected
            return true;
        }
        else
        {
            return false;
        }
    }
    
    public string GetLore()
    {
        return Question.GetLore();
    }
    
    public string GetAnswer()
    {
        return Question.GetAnswer();
    }
    
    void Update()
    {
        gameObject.transform.position = DropZone;//place object at new location

        if (
            (Accesslocation)//if they open the location
            &&
            (WaitingINPUT==false)//and we are not waiting..
           )
        {
                WaitingINPUT = true;//we start waiting for player input
            //this is where the UI would be grabing the data Lore/answer to deplay on the interface
        }
        else if(
                (GetReponse)//if user give us an answer
                &&
                (WaitingINPUT)//and we where waitig for that answer
                )
        {
            Done = true;//we flag the location for done
        }
    }
}