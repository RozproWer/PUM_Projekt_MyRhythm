using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public AudioSource Music;
    public bool startPlay;
    public BeatScroller theBS;
    public static GameManager instance;

    public int currentScore;
    public int scorePerNote = 100;
    public int scorePerGoodNote = 125;
    public int scorePerPerfectNote = 150;

    public int currentMultiplier;
    public int multiplierTracker;
    public int[] multiplierThresholds;

    public Text scoreText;
    public Text multiText;

    public float totalNotes;
    public float normalHits;
    public float goodHits;
    public float perfectHits;
    public float missedHits;

    public GameObject resultsScreen;
    public GameObject infoText;
    public Text percentHitText, normalsText, goodsText, perfectsText, missedsText, rankText, finalScoreText;

    // Start is called before the first frame update
    void Start()
    {
        instance = this; 

        scoreText.text = "Score : 0";
        currentMultiplier = 1;

        totalNotes = FindObjectsOfType<NoteObject>().Length;
    }

    // Update is called once per frame
    void Update()
    {
        if (!startPlay)
        {
            if (Input.anyKeyDown)
            {
                infoText.SetActive(false);
                startPlay = true;
                theBS.hasStarted = true;
                Music.Play();
            }
        } else
        {
            if(!Music.isPlaying && !resultsScreen.activeInHierarchy)
            {
                resultsScreen.SetActive(true);

                normalsText.text = normalHits.ToString();
                goodsText.text = goodHits.ToString();
                perfectsText.text = perfectHits.ToString();
                missedsText.text = missedHits.ToString();

                float totalHit = normalHits + goodHits + perfectHits;
                float totalNotesResult = totalHit + missedHits;
                float percentHit = (totalHit / totalNotesResult) * 100f;

                percentHitText.text = percentHit.ToString("F1") + "%";

                string rankVAl = "F";
                if (percentHit > 40)
                {
                    rankVAl = "D";
                    if (percentHit > 55)
                    {
                        rankVAl = "C";
                        if (percentHit > 70)
                        {
                            rankVAl = "B";
                            if (percentHit > 85)
                            {
                                rankVAl = "A";
                                if (percentHit > 95)
                                {
                                    rankVAl = "S";                    
                                }                        
                            }                        
                        }                       
                    }                    
                }

                rankText.text = rankVAl;
                finalScoreText.text = currentScore.ToString();
            }
        }
    }

    public void NoteHit(){
        //Debug.Log("Hit");

        if(currentMultiplier - 1 < multiplierThresholds.Length)
        {
            multiplierTracker++;
            if (multiplierThresholds[currentMultiplier-1] <= multiplierTracker)
            {
                multiplierTracker = 0;
                currentMultiplier++;
            }
        }
        multiText.text = "Multiplier: x"+currentMultiplier;
        //currentScore += scorePerNote * currentMultiplier;
        scoreText.text = "Score : " + currentScore;
    }

    public void NoteMiss(){
       // Debug.Log("Note missed");
        currentMultiplier = 1;
        multiplierTracker = 0;

        multiText.text = "Multiplier: x"+currentMultiplier;
        missedHits++;
    }

    public void NormalHit(){
        currentScore += scorePerNote * currentMultiplier;
        NoteHit();

        normalHits++;
    }
    public void GoodHit(){
        currentScore += scorePerGoodNote * currentMultiplier;
        NoteHit();

        goodHits++;
    }
    public void PerfectHit(){
        currentScore += scorePerPerfectNote * currentMultiplier;
        NoteHit();

        perfectHits++;
    }
}
