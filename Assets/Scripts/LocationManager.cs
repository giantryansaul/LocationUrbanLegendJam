using Boo.Lang;
using UnityEngine;

public class LocationManager : MonoBehaviour
{
    [SerializeField] private Location[] _locationStore; // List of Location objects (look in Location folder)
    private List<GameObject> _locationsObjs;
    private List<int> _visitedLocations;
    [SerializeField] private GameObject _locationPrefab;

    void Start()
    {
        SpawnAllLocations();
    }

    private void SpawnAllLocations()
    {
        _locationsObjs = new List<GameObject>();
        for (var i = 0; i < _locationStore.Length; i++)
        {
            var locationObj = Instantiate(_locationPrefab);
            var pos = GameUtils.CreatePositionInCircle(Vector3.zero, 100f, 300f);
            locationObj.GetComponent<LocationBehavior>().InitializeLocation(_locationStore[i], i, pos);
            locationObj.transform.position = pos;
            Debug.Log(pos);
            _locationsObjs.Add(locationObj);
        }
    }
}