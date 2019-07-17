using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public EvilPaperSpawner Spawner;
    public PhoneSpawner PSpawner;
    public CoinSpawner CSpawner;
    public BubbleTeaSpawner BSpawner;
    public DoughnutSpawner DSpawner;

    public Animator animator;
    public StaminaSystem myStamina;
    public BGScroll background;

    public Text CurrentScore;
    public Text BestScore;
    private bool hasGameEnded = false;


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

    }

    public void OnPlayerHit()
        {
            hasGameEnded = true;

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

        myStamina.STAMINALOSS = 0;
            background.scroll_speed = 0;
            animator.SetBool("Dead", true);

        Debug.Log("GAME OVER");

        //BGSoundScript.Instance.gameObject.GetComponent<AudioSource>().pause();
    }

}