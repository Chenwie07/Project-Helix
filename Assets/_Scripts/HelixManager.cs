using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelixManager : MonoBehaviour
{
    public List<GameObject> helixRings = new List<GameObject>();
    public List<GameObject> liveHelixRings = new List<GameObject>();
    public static HelixManager Instance { get; set; }
    public Material helixSafeMat;
    public Material helixUnSafeMat;

    private float _distanceBetweenRingsOnY;

    public int _normalRingSpawnTotal;
    public int _liveRingSpawnTotal;

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        int liveCounter = 0; // counts the number of live Rings spawned so far. 
        int liveCallCounter = 0;

        int normalRingCount = helixRings.Count;
        int liveRingCount = liveHelixRings.Count;
        //_ringsSpawnTotal = GameManager.currentLevelIndex + 5; // given by Level Scriptable object. 
        for (int i = 0; i < _normalRingSpawnTotal; i++)
        {
            if (i == 0)
                SpawnRing(helixRings[0]);
            else
            {
                liveCallCounter++;
                SpawnRing(helixRings[Random.Range(1, normalRingCount - 1)]);
            }
            // first check if LiveRings exists in the first place
            if (_liveRingSpawnTotal > 0)
            {
                if (liveCallCounter > 2)
                {
                    liveCallCounter = 0;
                    liveCounter++;
                    SpawnRing(liveHelixRings[Random.Range(0, liveRingCount - 1)]);
                }
                else if (Random.Range(1, 4) == 3)
                {
                    liveCounter++;
                    liveCallCounter = 0;
                    SpawnRing(liveHelixRings[Random.Range(0, liveRingCount - 1)]);
                }
            }
            // implement mechanic, make sure a Live ring is spawned at least every 3 normal ring, or 1/3 chance in-between.
        }

        // if they're any live rings left, spawn them towards the end, rare chance of this happening though.
        // But this spawn mechanic will be modified in the future. 
        if (liveCounter <= liveRingCount && _liveRingSpawnTotal > 0)
        {
            for (int i = liveCounter; i < liveRingCount; i++)
            {
                SpawnRing(liveHelixRings[Random.Range(0, liveRingCount - 1)]);
            }
        }

        // spawn the goal ring. 
        SpawnRing(helixRings[normalRingCount - 1]);
    }

    private void SpawnRing(GameObject ring)
    {
        // transform will use only the y axis of this object as it's reference for positioning, the rest will remain default/identity. 
        Instantiate(ring, transform.up * _distanceBetweenRingsOnY, Quaternion.identity, transform);

        // modify the distance for next spawn
        _distanceBetweenRingsOnY -= 5f;
    }

    // this event should only occur when the ring is LIve. 
    public void OnRingBounce(GameObject ringFloor)
    {
        var _mat = ringFloor.GetComponent<MeshRenderer>().material;
        if (_mat.name == "mat_SafeFloor (Instance)")
            ringFloor.GetComponent<MeshRenderer>().material = helixUnSafeMat;
        else
            ringFloor.GetComponent<MeshRenderer>().material = helixSafeMat;
    }
}
