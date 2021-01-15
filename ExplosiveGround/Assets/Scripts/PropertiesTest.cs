/*
//This code isn't supposed to work that way in Unity of course,
//I'm just playing with it to understand it better
//Sadly, since I discovered it too late for this game, I couldn't work that way

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class HealthManager : MonoBehaviour
{
    private int health;

    public PlayerHealth (int playerHealth){
        Health = playerHealth;
    }    

    public int Health {
        get {
            //Some other code
            return health;
        }
        set {
            //Some other code
            if (value <= 3 && value >= 0){
                health = value;
            }
            else value = 3;
        }
    }
}

//Inside an other class, I should write
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    static void Main()
    {
        PlayerHealth patrick = new PlayerHealth(3);

        patrick.Health = 2; //writing > set
        Debug.Log("Health: " + patrick.Health); //reading > get
    }
}
*/
