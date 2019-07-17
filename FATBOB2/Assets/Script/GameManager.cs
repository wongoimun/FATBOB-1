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

    public Animator animator;
    public StaminaSystem myStamina;
    public BGScroll background;

    public Text CurrentScore;
    public Text BestScore;
    private bool hasGameEnded = false;

    public float restartDelay = 100f;
    

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

   /* void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }*/

    


}