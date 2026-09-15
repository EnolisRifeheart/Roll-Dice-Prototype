using UnityEngine;

public class Dice_Facecheck : MonoBehaviour
{
    Dice dice;

    private void Awake()
    {

        dice = FindFirstObjectByType<Dice>();

    }


    private void OnTriggerStay(Collider other)
    {
        if (dice != null && dice.isRolling)
        {
            Rigidbody rb = dice.GetComponent<Rigidbody>();

            { 
                if (rb.linearVelocity.sqrMagnitude < 0.01f && rb.angularVelocity.sqrMagnitude <0.01f)
              
                {

                    dice.diceFaceNum = int.Parse(other.name);

                    dice.isRolling = false;
                }
            }
        }
    }
}
