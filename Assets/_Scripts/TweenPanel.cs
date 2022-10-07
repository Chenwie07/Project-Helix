using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class TweenPanel : MonoBehaviour
{
    // we tween Gameobjects. 
    public GameObject panel, score, time, star1, star2, star3, proceedBtn;
    private void Start()
    {
        // naturally we have to do this elsewhere
        time.GetComponent<TextMeshProUGUI>().SetText("Time Elapsed: " + GameManager.instance.TimeElapsed.ToString("F0"));

        LeanTween.moveLocalY(panel, 80, .75f).setEase(LeanTweenType.easeInCubic);
        LeanTween.alpha(time, 1, 1f).setDelay(.3f).
            setEase(LeanTweenType.easeInCubic).
            setOnComplete(ScoreAnim);
    }

    void StarsAnim()
    {
        LeanTween.scale(star1, new Vector3(1f, 1f, 1f), 2f)
            .setEase(LeanTweenType.easeOutElastic);
        if (GameManager.instance.LevelCompleteScore > 550) // B grade - 2 stars
            LeanTween.scale(star2, new Vector3(1f, 1f, 1f), 2f)
                .setDelay(.1f)
                .setEase(LeanTweenType.easeOutElastic);
        if (GameManager.instance.LevelCompleteScore > 900) // A grade - 3 stars. 
            LeanTween.scale(star3, new Vector3(1f, 1f, 1f), 2f)
                .setDelay(.2f)
                .setEase(LeanTweenType.easeOutElastic);
        LeanTween.delayedCall(.5f, ShowProceedButton);
    }

    void ScoreAnim()
    {
        LeanTween.value(score, 0, GameManager.instance.LevelCompleteScore, 1f)
            .setOnUpdate(UpdateScoreText).setOnComplete(StarsAnim);
    }
    void UpdateScoreText(float value)
    {
        score.GetComponent<TextMeshProUGUI>().SetText(value.ToString("F0"));
    }

    void ShowProceedButton()
    {
        LeanTween.scale(proceedBtn, new Vector3(1, 1, 1), 1f).setDelay(.5f).setEase(LeanTweenType.easeOutElastic);
    }

}
