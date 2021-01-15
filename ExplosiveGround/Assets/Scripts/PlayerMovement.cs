using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class PlayerMovement : MonoBehaviour
{
    #region Public&Private Fields
    //Public:
	
    //Private:
    Rigidbody rb;
    private GameObject[] _player;

    [SerializeField] float speed;
    [SerializeField] float jumpForce;

    [SerializeField] Transform groundChecker;
    [SerializeField] float checkRadius; //issue Right Here + lié à la caméra ? > toucher la souris change qqchose
    [SerializeField] LayerMask groundLayer;
    [SerializeField] float sprintMultiplier = 1.5f;

    private ScoreHealthManager _health;

    #endregion

    #region Own Methods
	bool IsOnGround() { //Checking if our imaginarySphere is colliding with "ground-layered elements"
        /*
        Collider[] colliders = Physics.OverlapSphere(groundChecker.position, checkRadius, groundLayer); //Spawns a sphere called OverlapSphere.

        if (colliders.Length > 0) {
            return true;
        }
        else {
            return false;
        }
        */
        if (transform.position.y <= 0.6f){
            return true;
        }
        else return false;
    }
    #endregion

    #region Unity Methods
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        _player = GameObject.FindGameObjectsWithTag("Player");
        _health = GetComponent<ScoreHealthManager>(); //does it works? *_*
    }
 
    void Update()
    {
//      if (dead) { //dead meaning health <= 0; > that way, the player can't move if he's dead
            //I- MoveXY ----------------------------------------------------------------------------
            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");

            Vector3 moveBy = transform.right * x + transform.forward * z;

            float actualSpeed = speed;
            if (Input.GetKey(KeyCode.LeftShift)) {
                actualSpeed *= sprintMultiplier;
            }

            rb.MovePosition(transform.position + moveBy.normalized * actualSpeed * Time.deltaTime);
            //O- MoveXY ----------------------------------------------------------------------------

            //I MoveJump ---------------------------------------------------------------------------
            if (IsOnGround() && Input.GetKeyDown(KeyCode.Space)){
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            
            //jumping eye direction            
            //rb.AddForce(Vector3.forward * jumpForce, ForceMode.Impulse);
            //it isn't the Vector3.forward that I should use ~take character orientation or camera's one (same thing anyway)
            }
            //O MoveJump ---------------------------------------------------------------------------
//        }
    }
    #endregion
}