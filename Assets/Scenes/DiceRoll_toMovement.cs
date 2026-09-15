using Unity.VisualScripting;
using UnityEngine;

public class DiceRoll_toMovement : MonoBehaviour
{
    public Dice dice;
    public Player player;

    private Rigidbody diceRB;
    private bool onceDiceStopsRolling;

    private void Start()
    {
        diceRB = dice.GetComponent<Rigidbody>();

        player.canMove = false;
    }

    private void Update()
    {
        if (dice == null || player == null)
        {
            return;
        }

        // Checking to see if a new roll has started.


        if (dice.isRolling)
        {
            onceDiceStopsRolling = true;
            player.canMove = false;
        }


       // Dice result.

        if (onceDiceStopsRolling && !dice.isRolling && dice.diceFaceNum > 0)

        {
            player.movementRange = dice.diceFaceNum;
            player.canMove = true;


            onceDiceStopsRolling = true;
            
            return;
        }


        if (onceDiceStopsRolling && diceRB.linearVelocity.sqrMagnitude < 0.01f && diceRB.angularVelocity.sqrMagnitude < 0.01f)
        {
            player.movementRange = dice.diceFaceNum;

            player.canMove = true;

            onceDiceStopsRolling = false;

            Debug.Log("Dice rolled " + dice.diceFaceNum);
        }
    }
}