using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using RamailoGames;

public class PlayAndWin : MonoBehaviour
{
    public static PlayAndWin instance;
    private RamailoGamesScoreManager scoreManager;

    [Header("Play and Win")]
    public TextMeshProUGUI attemptsText;
    public TextMeshProUGUI playAndWinLeadingScoreTxt;
    public TextMeshProUGUI scoreToBeatText;
    int currentAttempts;
    int playandwinLeadingScore;
   

    [Header("CANVAS")]
    public Button playBtn;
    public GameObject claimBtn;
    public GameObject attemptsInterface;
    public GameObject attemptsBuyButton;

    [Header("Game State")]
    public GameState gameState;
    bool isGamePlay = false;


    public enum GameState
    {
        MainMenu,
        GamePlay
    }

   
    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        if (!ScoreAPI.instance.playAndWin)
        {
            Debug.Log("Not play and win");
            playBtn.interactable = true;
            return;
        }

        switch (gameState) 
        {
            case GameState.MainMenu:
                InvokeRepeating("CheckScoreApi", 2f, 1f);

                break;

            case GameState.GamePlay:
                isGamePlay = true;
                scoreManager = FindObjectOfType<RamailoGamesScoreManager>();
                break;

        }

    }

  
    IEnumerator GetData()
    {
        yield return new WaitForSeconds(0.5f);      //wait
        print(ScoreAPI.instance.fetechedAttempts + " is player remaining Attempts");  //print feteched attempts

        currentAttempts = ScoreAPI.instance.fetechedAttempts; //set attempts
        playandwinLeadingScore = ScoreAPI.instance.fetechedPlayAndWinLeadingScore;

        yield return new WaitForEndOfFrame(); //wait
        attemptsText.text = currentAttempts.ToString(); // update attempts in canvas

        if(playAndWinLeadingScoreTxt != null)
        {
            playAndWinLeadingScoreTxt.text = playandwinLeadingScore.ToString();
        }

        //attemptsInterface.SetActive(true);
        PlayBtnState(); //set button state
    }

    void PlayBtnState()
    {
        if(currentAttempts <= 0) // current attempts is zero or less than zero
        {
            playBtn.interactable = false;

            attemptsBuyButton.SetActive(true);
            attemptsInterface.SetActive(false);
            return;
        }

        playBtn.interactable = true;

        attemptsBuyButton.SetActive(false);
        attemptsInterface.SetActive(true);

    }

    public void RequestAttemptAgain()
    {
        //request again
        StartCoroutine(GetData());
    }

    void CheckScoreApi()
    {
        if (ScoreAPI.instance.hasFetechedAttempts == false)
        {
            Debug.Log("has yet to fetech attempts");
            return;
        }

        StartCoroutine(GetData());
    }

    public void OpenUrl()
    {
        ScoreAPI.instance.BuyAttempts();
    }

    public void ClaimUrl()
    {
        ScoreAPI.instance.Claim((int)scoreManager.currentScore);
    }

    public void PlayandWinGameOver()
    {
        StartCoroutine(Enum_PlayAndWin_GameOver());
    }

    public IEnumerator Enum_PlayAndWin_GameOver()
    {
        if (!ScoreAPI.instance.playAndWin)
        {
            Debug.Log("Not play and win");
            NormalHighScoreCheck();
            yield break;
        }

        ScoreAPI.instance.setData();
        yield return new WaitForEndOfFrame();
        yield return new WaitForSeconds(0.5f);
        InvokeRepeating("CheckScoreApi", 1f, 1f);

        yield return new WaitForSeconds(2f);

        // check if currentscore is less than leading score

        if ((int)scoreManager.currentScore <= playandwinLeadingScore)
        {
            scoreToBeatText.gameObject.SetActive(true);
            int scoreToBeat = playandwinLeadingScore - (int)scoreManager.currentScore;
            print(scoreToBeat + " to beat Play&Win Leading Score. ");
            scoreToBeatText.text = scoreToBeat.ToString() + " score to beat. ";
            yield break;
        }
        else if ((int)scoreManager.currentScore > playandwinLeadingScore)
        {
            print((int)scoreManager.currentScore + "is current score.");
            print(playandwinLeadingScore + " is leading score.");
            print("Player beat Play&Win Leading score");
            claimBtn.SetActive(true);
        }

       

      
    }

    void NormalHighScoreCheck()
    {
        if((int)scoreManager.currentScore <= RamailoGamesApiHandler.highScore)
        {

            scoreToBeatText.gameObject.SetActive(true);
            int scoreToBeat = RamailoGamesApiHandler.highScore - (int)scoreManager.currentScore;
            print(scoreToBeat + " to beat high Score. ");
            scoreToBeatText.text = scoreToBeat.ToString() + " score to beat HighScore. ";

            return;
        }
        else if ((int)scoreManager.currentScore > RamailoGamesApiHandler.highScore)
        {
            scoreToBeatText.gameObject.SetActive(true);
            scoreToBeatText.text = "Congrats, you have beat HighScore.";
        }

    }

}
