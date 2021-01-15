using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class GameManager : MonoBehaviour
{
    #region Public&Private Fields
    //Public:    
    public int difficulty = 1;
    public Animator GameOverAnimator;

    //Private:
    //private float scalingDifficulty = 1f;
    
    #region Ring
    [SerializeField] GameObject ring;
    private float counterWall;
    private float ascendingCd = 0.01f;
    private float ascending = 0f;
    private float smoothing = 1f;
    #endregion

    #region Explosions
    private float counterExplosions;
    [SerializeField] float explosionsCd = 3f;
    private float newX = 0f;
    private float newZ = 0f;
    
    #endregion

    [SerializeField] GameObject newLight;

    [SerializeField] GameObject explosions;

    #endregion
 
    #region Own Methods

	void RingCreator(){
        ring.transform.Translate(new Vector3(0,0,ascending));
        ascending += 0.01f / smoothing;
        smoothing += 1;
    }

    void ExplosionsSpawner(){
        newX = Random.Range(-50f,50f); //coordonnées d'un carré, pas d'un cercle ! 
        newZ = Random.Range(-50f,50f);

        Instantiate(explosions, new Vector3(newX,-0.5f,newZ), Quaternion.identity);
    }
    
    public void GameOver(){
        GameOverAnimator.SetBool("IsGameOver", true);
    }

    #endregion

    #region Unity Methods
    void Start()
    {
        ExplosionsSpawner();
    }
 
    void Update()
    {
        //I- Scene Manager ------------------------------------------------------------------------------------
        /*
        starting with "Start Menu"
            featuring
                Play, 
                Difficulty (from easy to hard) > accelerating scalingDifficulty,
                Options (sounds mostly + mouse sensitivity + windowed or not + ...),
                Exit
        
        main game

        game over menu will be implemented in an other way
            but will feature the score and a Retry? button
            *edit: is implemented but isn't triggered because of the Grand Health Issue, that massacred my hair and didn't allow me to rest for way too long
                (the good new behing it being that I discovered the properties and the Dependency Injection Framework and will dig it a bit more for the next games)
        */
        //O- Scene Manager ------------------------------------------------------------------------------------   

        //if scene == actual game
            //I- Ring Creation Loop ---------------------------------------------------------------------------
            if (ring.transform.position.y <= -5){
                counterWall += Time.deltaTime;
                if (counterWall >= ascendingCd) {
                    RingCreator();
                    counterWall -= ascendingCd;
                }
            }
            //O- Ring Creation Loop ---------------------------------------------------------------------------

            //circular light? > some sort of counterWall? With color etc..

            //I- Explosions Manager ---------------------------------------------------------------------------
            counterExplosions += Time.deltaTime;
            if (counterExplosions >= explosionsCd){
                ExplosionsSpawner();

                counterExplosions -= explosionsCd;
            }
            //O- Explosions Manager ---------------------------------------------------------------------------

            //I- Scaling Difficulty Manager -------------------------------------------------------------------
            /*
            counter, following the seconds, Time.deltaTime etc...
            */
            //O- Scaling Difficulty Manager -------------------------------------------------------------------
        //end if
    }
    #endregion
}