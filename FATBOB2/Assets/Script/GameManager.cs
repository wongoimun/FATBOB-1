using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public EvilPaperSpawner Spawner;
    public PhoneSpawner PSpawner;
    public CoinSpawner CSpawner;
    public BubbleTeaSpawner BSpawner;
    public DoughnutSpawner DSpawner;
    public PizzaSpawner PiSpawner;
    public MultiplierSpawner MSpawner;
    public SuperStrengthSpawner SSpawner;

    public static bool StrengthPickedup = false;
    public static float pickedTiming = 999999999999;
    public static float endTiming = 999999999999;

    public static float CurrScore = 0;
    public static float CurrInt = 0;

    public Animator animator;
    public StaminaSystem myStamina;
    public BGScroll background;

    public Text CurrentScore;
    public Text BestScore;
    public bool hasGameEnded = false;

    public float restartDelay = 100f;

    private int numvariable;

    [SerializeField]
    private GameObject gameOverUI;


    private void Start()
    {
        BestScore.text = PlayerPrefs.GetInt("HighScore",0).ToString();
    }

    private void Update()
    {
        if (hasGameEnded) return;
        CurrentScore.text = Coin.score.ToString();

        if(Coin.score >= PlayerPrefs.GetInt("HighScore", 0))
        {
            BestScore.text = Coin.score.ToString();
            PlayerPrefs.SetInt("HighScore", Coin.score);
        }


        //Debug.Log(StrengthPickedup);
        if (StrengthPickedup && (float)Time.time > endTiming)
        {
            StrengthPickedup = false;
            Normal();
            //Debug.Log("Strength ended");
        }

        //code to increase the speed of BOB every time the score is a multiple of 30
        float Integer = Coin.score / 30;
        if (Integer != CurrInt && Coin.score != CurrScore)
        {
            CurrScore = Coin.score;
            CurrInt = Integer;
            SpeedIncrease();
        }
    }

    public static void Strength()
    {
        StrengthPickedup = true;
        pickedTiming = (float)Time.time;
        endTiming = pickedTiming + 10;
        //Debug.Log("picked up " + pickedTiming + " " + endTiming);
        Speedup();
    }

    public static void SpeedIncrease()
    {
        EvilPaperObstacle.Speed++;
        AngryPhoneObstacle.Speed++;
        Coin.Speed++;
        BubbleTea.Speed++;
        Doughnut.Speed++;
        Pizza.Speed++;
        Multiplier.Speed++;
        SuperStrength.Speed++;
        Debug.Log("speed increase");
    }

    public static void Speedup()
    {
        EvilPaperObstacle.Speed += 5;
        AngryPhoneObstacle.Speed += 5;
        Coin.Speed += 5;
        BubbleTea.Speed += 5;
        Doughnut.Speed += 5;
        Pizza.Speed += 5;
        Multiplier.Speed += 5;
        SuperStrength.Speed += 5;
        Debug.Log("speed up");
    }

    public void Normal()
    {
        EvilPaperObstacle.Speed -= 5;
        AngryPhoneObstacle.Speed -= 5;
        Coin.Speed -= 5;
        BubbleTea.Speed -= 5;
        Doughnut.Speed -= 5;
        Pizza.Speed -= 5;
        Multiplier.Speed -= 5;
        SuperStrength.Speed -= 5;
        Debug.Log("normal");
    }

    public void OnPlayerHit()
        {
            //hasGameEnded = true;

            EvilPaperObstacle.Speed = 0;
            Spawner.ShouldSpawn = false;

            AngryPhoneObstacle.Speed = 0;
            PSpawner.ShouldSpawn = false;

            Coin.Speed = 0;
            CSpawner.ShouldSpawn = false;

            BubbleTea.Speed = 0;
            BSpawner.ShouldSpawn = false;

            Doughnut.Speed = 0;
            DSpawner.ShouldSpawn = false;

        Pizza.Speed = 0;
        PiSpawner.ShouldSpawn = false;

        Multiplier.Speed = 0;
        MSpawner.ShouldSpawn = false;

        SuperStrength.Speed = 0;
        SSpawner.ShouldSpawn = false;

        myStamina.STAMINALOSS = 0;
            background.scroll_speed = 0;
            animator.SetBool("Dead", true);


        //BGSoundScript.Instance.gameObject.GetComponent<AudioSource>().pause();
    }

    public void EndGame()
    {
        if(hasGameEnded == false)
        {
            hasGameEnded = true;
            Debug.Log("GAME OVER");
            //Invoke("Restart", restartDelay);
            gameOverUI.SetActive(true);
        }
    }

   public void Restart()
    {
        EvilPaperObstacle.Speed = 10f;
        Spawner.ShouldSpawn = true;

        AngryPhoneObstacle.Speed = 10f;
        PSpawner.ShouldSpawn = true;

        Coin.Speed = 10f;
        CSpawner.ShouldSpawn = true;

        BubbleTea.Speed = 10f;
        BSpawner.ShouldSpawn = true;

        Doughnut.Speed = 10f;
        DSpawner.ShouldSpawn = true;

        Pizza.Speed = 10f;
        PiSpawner.ShouldSpawn = true;

        myStamina.STAMINALOSS = 2f;

        Multiplier.Speed = 10f;
        MSpawner.ShouldSpawn = true;

        SuperStrength.Speed = 10f;
        SSpawner.ShouldSpawn = true;

        Coin.score = 0;
        // animator.SetBool("Dead", true);

    }
    
}