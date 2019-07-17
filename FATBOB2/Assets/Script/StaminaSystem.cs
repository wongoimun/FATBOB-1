using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine .UI;

public class StaminaSystem : MonoBehaviour
{
    public Slider myStaminaBar;
    public GameManager GameManagerInstance;
    public float MAXSTAMINA;
    public float STAMINALOSS;

    // Start is called before the first frame update
    void Start()
    {
        myStaminaBar.value = MAXSTAMINA;
    }

    // Update is called once per frame
    void Update()
    {
        MAXSTAMINA -= STAMINALOSS * Time.deltaTime;
        myStaminaBar.value = MAXSTAMINA;

        if(MAXSTAMINA <= 0)
        {
            GameManagerInstance.OnPlayerHit();
        }

        if(BubbleTea.hitBubbleTea)
        {
            float toIncrease = 0.20f * MAXSTAMINA;
            if(100 - MAXSTAMINA <= toIncrease)
            {
                MAXSTAMINA = 100;
            }
            if(100 - MAXSTAMINA > toIncrease)
            {
                MAXSTAMINA += toIncrease;
            }
            BubbleTea.hitBubbleTea = false;
        }

        if (Doughnut.hitDoughnut)
        {
            float toIncrease = 0.30f * MAXSTAMINA;
            if (100 - MAXSTAMINA <= toIncrease)
            {
                MAXSTAMINA = 100;
            }
            if (100 - MAXSTAMINA > toIncrease)
            {
                MAXSTAMINA += toIncrease;
            }
            Doughnut.hitDoughnut = false;
        }
    }
}
