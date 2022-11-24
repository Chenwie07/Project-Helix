using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    public LevelProps _levelProps;
    private LevelProps.LevelType type;

    private void Awake()
    {
        type = _levelProps.type; // get the level Type to use. 
        Instantiate(_levelProps._levelTheme); // set the level theme 

        HelixManager.Instance._normalRingSpawnTotal = _levelProps.NormalHelixRings; 
        HelixManager.Instance._liveRingSpawnTotal = _levelProps.LiveHelixRings;
        GameManager.instance.LevelType = type;
        GameManager.instance.CurrentLevel = _levelProps.Level; 
        GameManager.instance.TotalRings = _levelProps.NormalHelixRings + _levelProps.LiveHelixRings;
        GameManager.instance.LevelBGM = _levelProps.LevelBGMClip; 

    }
}
