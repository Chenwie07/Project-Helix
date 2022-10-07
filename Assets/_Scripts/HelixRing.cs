using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelixRing : MonoBehaviour
{
    private Transform _player;
    public Event _ringEvent; 
    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").transform; 
    }
    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > _player.transform.position.y)
        {
            AudioManager.instance.Play("Whoosh"); 
            _ringEvent.Occurred(); // call this only once. 
            Destroy(gameObject); 
        }
    }
}
