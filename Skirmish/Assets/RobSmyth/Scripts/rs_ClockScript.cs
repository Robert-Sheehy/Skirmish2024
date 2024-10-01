using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class rs_ClockScript : MonoBehaviour
{
    public float timeValue;
    public TMP_Text clockText;
    // Start is called before the first frame update
    void Start()
    {
        timeValue = 10.0f;
    }

    // Update is called once per frame
    void Update()
    {
        clockText.text = "Time: " + DateTime.Now.ToString("HH:mm:ss") + "\n\n\tBoss: " + timeValue;
        
        timeValue -= Time.deltaTime;



        if(timeValue > 8 && timeValue < 9)
        {
           clockText.text = "Time: " + DateTime.Now.ToString("HH:mm:ss") + "\n" + "WARNING" + "\n\tBoss: " + timeValue;
        }
       if (timeValue > 6 && timeValue < 7)
       {
            clockText.text = "Time: " + DateTime.Now.ToString("HH:mm:ss") + "\n" + "WARNING" + "\n\tBoss: " + timeValue;
        }
       if (timeValue < 3)
       {
            clockText.text = "WARNING" + "\n\tBoss: " + timeValue;
        }
        if (timeValue <= 0)
        {
            clockText.text = "You Died";
        }
    }

}
