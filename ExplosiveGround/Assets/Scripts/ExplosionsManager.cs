using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class ExplosionsManager : MonoBehaviour
{
    #region Public&Private Fields
    //Public:
    
    //Private:
    Renderer rend;
    private bool checkForPlayer = false;
    private float growingSpeed;
    private float counter;
    [SerializeField] float maxRadius = 15f;
	private float newX = 0.000001f;
    private float newZ = 0.000001f;
    [SerializeField] float growingCd = 0.01f;
    private GameObject[] _player;

    [SerializeField] private GameObject bigExplosion;
    [SerializeField] private GameObject smallExplosion;

    //should get the scalingDifficulty variable 

    #endregion
 
    #region Own Methods
	public void ExplosionIsTriggered(){
//        _player.GetComponent<ScoreHealthManager>().TakeDamage(1);
        //^removing 1 health point to the player
            //would also like to add a invulnerability for 3 seconds
                //would be inside the else if conditions

        //resetting multiplier

        Instantiate(bigExplosion, new Vector3(newX,0f,newZ), Quaternion.identity); //bad spawning
        //should work more on the direction of the explosion (Quaternion's fault) and its position (Vector's one)
        Destroy(gameObject);
    }

    public void ExplosionIsntTriggered(){
        Instantiate(smallExplosion, new Vector3(newX,0f,newZ), Quaternion.identity); //bad spawning
        //same thing as above

        //by the way, the multiplier follows a new rule:
            //if the player is close (< 3 units) to an explosion but don't get hurt, the multiplier add 1 (max 10)

        //adding score

        Destroy(gameObject);
    }

    #endregion

    #region Unity Methods

    private void OnTriggerEnter(Collider _player){
        checkForPlayer = true;
    }
    private void OnTriggerExit(Collider _player){
        checkForPlayer = false;
    }

    void Start()
    {
        growingSpeed = Random.Range(0.5f,4f/* / scalingDifficulty)*/);
        maxRadius = Random.Range(5f/* + scalingDifficulty)*/, 30f/* + scalingDifficulty)*/);
        // + adding a value inside the Range, growing with the time
        // more time passed, quicker the zone explode and bigger it gets

        _player = GameObject.FindGameObjectsWithTag("Player");

        rend = GetComponent<Renderer>();
    }

    void Update()
    {
        //Scaling
        if (transform.localScale.x <= maxRadius){
            counter += Time.deltaTime;
            if (counter >= growingCd) {
                newX += 0.01f*growingSpeed;
                newZ += 0.01f*growingSpeed;

                transform.localScale = new Vector3(newX,0.1f,newZ);

                counter -= growingCd;
            }
        }
        //Trigger _player
        else if (transform.localScale.x >= maxRadius && checkForPlayer) { 
            ExplosionIsTriggered();
        }
        //Destroying
        else ExplosionIsntTriggered();

        //Color changer
        float lerp = Mathf.Lerp(0f, maxRadius, newX/maxRadius) / maxRadius;
        
        rend.material.color = Color.Lerp(Color.white, Color.red, lerp);
    }
    #endregion
}