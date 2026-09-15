using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Dice : MonoBehaviour
{
    Rigidbody rb;

    [SerializeField] private float maxRandomForceValue, startRollingForce; // Learned from Pixel's Heart Dice Roll Tutorial. https://www.youtube.com/watch?v=rg4rgDdWyPk


    private float forceX, forceY, forceZ;

    public int diceFaceNum;

    public bool isRolling;

    private void Awake()
    {
        Initialize();
    }

    private void Update()
    {
        if (rb != null)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                RollDice();
            }
        }
    }

    private void RollDice()
    {
        diceFaceNum = 0;
        isRolling = true;

        rb.isKinematic = false;

       

        forceX = Random.Range(0, maxRandomForceValue);
        forceY = Random.Range(0, maxRandomForceValue);
        forceZ = Random.Range(0, maxRandomForceValue);

        rb.AddForce(Vector3.up * startRollingForce);
        rb.AddTorque(forceX, forceY, forceZ);

    }

    private void Initialize()
    {
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;
        transform.rotation = new Quaternion(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360), 0);
    }
}

