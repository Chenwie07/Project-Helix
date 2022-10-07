using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/* 
   This script defines the properties of our Levels. 
 */ 
[CreateAssetMenu(menuName = "Level")]
public class LevelProps : ScriptableObject
{

    [SerializeField, Tooltip("The Level Index")]
    private int level; 
    public int Level { get { return level; } }   
    // For Test purposes. 
    // For Day it's a normal Level. (level 1, 2, 3) 
    // Live type contain reactionary Tiles. (level 4 and 5)
    // A level that involves 2 balls to Send down. (Level 6)
    // For Night, there's light and Dark, Dark prevents the Rings below to be seen from afar. (level 7)
    public enum LevelType
    {
        Day, Night, Live, Double
    }

    [SerializeField, Tooltip("Select Level Type")] public LevelType type;
    [SerializeField, Tooltip ("Give the theme of the Level")] public GameObject _levelTheme; 

    [SerializeField, Tooltip("Set the Amount of Rings this Level Spawns 0 Inclusive")]
    private int normalHelixRings;
    [SerializeField, Tooltip("Set the amount of live rings this Level Spawns 0 Inclusive")]
    private int liveHelixRings; 
    public int NormalHelixRings { get { return normalHelixRings; } }
    public int LiveHelixRings { get { return liveHelixRings; } }
}
