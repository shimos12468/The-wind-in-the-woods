using UnityEngine;
using UnityEngine.Serialization;

// Will handle seamlessly building the next world in a loop
public class LoopWorldBuilder : MonoBehaviour
{
    private static GameObject _previousWorld;
    private Transform _worldSpawnLocation;
    public Transform Loop;
    public Transform _WorldSpawnLocationProp
    {
        set => _worldSpawnLocation = value;
    }
    
    [SerializeField] private GameObject _worldTilemap;

    public void SpawnNewLoop()
    {
        //Debug.Log("Spawning new loop!");
        GameObject newWorld = Instantiate(_worldTilemap, _worldSpawnLocation);
        newWorld.transform.parent = this.transform;
        
        if (_previousWorld)
        {
            Debug.Log("Destroying previous loop called: " + _previousWorld.name);
            Destroy(_previousWorld);
            _previousWorld = this.transform.GetChild(1).gameObject;
        }
        else
        {
            Debug.Log("No previous loop to destroy...must be the first loop!");
            _previousWorld = this.transform.GetChild(0).gameObject;
            
        }

        Loop.transform.parent = newWorld.transform;
        Loop.transform.localPosition= Vector3.zero;
        Loop.transform.parent = null;

        Debug.Log("New previous loop is: " + _previousWorld.name);
    }
}
