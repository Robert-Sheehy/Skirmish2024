using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{

    public Image HealthBar;
    public float health = 100f;
    public float maxHealth;
    public GameObject healthBarGO;

    // Start is called before the first frame update
    void Start()
    {



        //maxHealth = health;
        //slider.value = calculateHealth();
    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject newGuy  = GameObject.CreatePrimitive(PrimitiveType.Cube);
            newGuy.transform.position = new Vector3(Random.Range(-20f, 20f), 1, Random.Range(-20f, 20f));
            Instantiate(healthBarGO, newGuy.transform);
            newGuy.AddComponent<CW_Health>();

        }
        //slider.value = calculateHealth();

        //if(health < maxHealth)
        //{
        //    //Application.LoadLevel(Application.loadedLevel);
        //    HealthBar.color = Color.yellow;
        //}

        //if(health <= 0)
        //{
        //    Destroy(gameObject);
        //}
        //if(health > maxHealth)
        //{
        //    health = maxHealth;
        //}
    }

    //float calculateHealth()
    //{
    //    return health / maxHealth;
    //}    

    //public void TakeDamage(float damage)
    //{
    //    health -= damage;
    //    HealthBar.fillAmount = health / 100f;
    //}

    //public void Heal(float healingAmount)
    //{
    //    health += healingAmount;
    //    health = Mathf.Clamp(health, 0, 100);

    //    HealthBar.fillAmount = health / 100f;
    //}
}
