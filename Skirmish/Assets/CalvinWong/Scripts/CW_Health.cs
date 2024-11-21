using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CW_Health : MonoBehaviour
{
    int health = 100;
    int maxHealth = 100;
    float visibleCooldown = 4;
    float timer;
    Image healthBar; Image[] images;
    // Start is called before the first frame update
    void Start()
    {
         images = GetComponentsInChildren<Image>();

        foreach (Image i in images)
            if (i.name == "Green")
                healthBar = i;  
        
        healthBar.transform.parent.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
            takeDamage(25);

        timer -= Time.deltaTime;
        if (timer < 1)
        {
                setOpacity(timer);
                if (timer<0)
                    healthBar.transform.parent.gameObject.SetActive(false);

                
        }
        
    }


    internal void takeDamage(int damageAmount)
    {
        healthBar.transform.parent.gameObject.SetActive(true);
        setOpacity(1f);
        timer = visibleCooldown;
        health -= damageAmount;
        if (health <= 0)
        {
            die();
            healthBar.fillAmount = 0;
        }
        else
        {
            healthBar.fillAmount = (float) health / (float) maxHealth;
        }


    }

    void setOpacity(float opacity)
    {
        foreach (Image i in images)
        { i.GetComponent<CanvasRenderer>().SetAlpha(opacity); }
    }

    private void die()
    {
        Destroy(gameObject);
    }
}
