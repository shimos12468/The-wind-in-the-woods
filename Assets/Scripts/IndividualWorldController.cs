using UnityEngine;

public class IndividualWorldController : MonoBehaviour
{
    private LoopReset _loopReset;
    [SerializeField] private Collider2D _trigger;
    [SerializeField] private Collider2D _collider;

    void Awake()
    {
        _loopReset = GameObject.FindWithTag("WorldManager").GetComponent<LoopReset>();
    }
    
    void OnEnable()
    {
        _loopReset.OnLoop.AddListener(ModifyCollider);
    }
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        //_trigger = _loopReset.trigger;
        //_collider = _loopReset.colider;
        _trigger.enabled = true;
        _collider.enabled = false;
        Transform worldSpawnLocation = this.transform.GetChild(0).transform;
        LoopWorldBuilder worldBuilder = GameObject.FindWithTag("WorldManager").GetComponent<LoopWorldBuilder>();
        worldBuilder._WorldSpawnLocationProp = worldSpawnLocation;
    }

    void OnDisable()
    {
        _loopReset.OnLoop.RemoveListener(ModifyCollider);
    }

    private void ModifyCollider()
    {
        _trigger.enabled = false;
        _collider.enabled = true;
        /*
        Debug.Log("Moving edge collider");
        EdgeCollider2D thisCollider = this.GetComponent<EdgeCollider2D>();
        for (int i = 0; i < thisCollider.points.Length; i++)
        {
            Debug.Log("Original X: "  + thisCollider.points[i].x + " Original Y: "  + thisCollider.points[i].y);
            this.GetComponent<EdgeCollider2D>().points[i].y -= 1f;
            this.GetComponent<EdgeCollider2D>().points[i].x -= 1f;
            Debug.Log("New X: " + thisCollider.points[i].x + " New Y: " + thisCollider.points[i].y);
        }
        thisCollider.isTrigger = false;
        */
    }
}
