using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControler : MonoBehaviour
{
    //Variaveis de controle do score
    private int score = 0;
    public Text scoreText, livesTxt;
    //Variaveis do controle de vidas
    public int lives = 3;
    public GameObject ship;
    public Transform spawn;
    public GameObject gameOver; 

    //Classe que pode ser acessada sem importação
    public static GameControler instance;

    //Função de monobehavior, ciclo de vida, acontece antes do start
    void Awake ()
    {
        if ( instance == null)
            instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        //Zera o score no inicio do jogo.
        scoreText.text = "0";
        livesTxt.text = lives.ToString();
        //Inicia a primeira nave...
        Instantiate (ship, spawn.position, spawn.rotation);
    }

    void Update()
    {
        if (gameOver.activeSelf)
        {
            if (Input.anyKey)
                UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        }
    }

   public void UpdateScore (int points)
   {
       //Atualiza o valor quando um inimigo é eliminado.
       score += points;
       //Como é um texto que é exibido é necessário fazer a conversão.
       scoreText.text = score.ToString();
   }

   public void UpdateLives()
   {
       lives --;
       livesTxt.text = lives.ToString();

       if (lives <= 0)
       {
           //game over
           gameOver.SetActive(true);
       }

       else
       {
           Instantiate (ship, spawn.position, spawn.rotation);
       }
   }
}
