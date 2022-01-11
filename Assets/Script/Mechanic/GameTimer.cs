using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    public float time;
    public Text timerText;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (time > 0)
        {
            time -= Time.deltaTime;
        }

        DisplayTime(time);
    }

    void DisplayTime(float timeToDisplay)
    {
        if (timeToDisplay < 0)
        {
            timeToDisplay = 0;
        } else if (timeToDisplay > 0)
        {
            timeToDisplay += 1;
        }

        float seconds = Mathf.FloorToInt(timeToDisplay);

        if (seconds < 10)
        {
            timerText.text = string.Format("{0:0}s", seconds);
        } else
        {
            timerText.text = string.Format("{0:00}s", seconds);
        }
    }
}
