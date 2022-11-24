using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 
    For Future updates we shall remodel our scripts
    and have this be our home for playerprefs of all kinds. 
 */
public class SaveScript : MonoBehaviour
{
 
    public void ClearAllSaves()
    {
        PlayUtilityManager.instance.UnlockAchievement(ProjectHelixGPGSIds.achievement_clear_saves);
        PlayerPrefs.DeleteAll();
    }
}
