using UnityEngine;
using UnityEngine.UI;

public class puck : MonoBehaviour {
    public GameObject playerInPosesion = null;
    private Vector2 currentPosition;
    private bool isMoving;
    public int MovementSpeed = 1;
    public Rigidbody2D rb;
    public float thrust;
    public GameObject redGoal;
    public GameObject greenGoal;
    void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate () {
        if (playerInPosesion != null )
        {
            if ( playerInPosesion.GetComponent<Unit>().PlayerNumber == 0) 
                transform.position = playerInPosesion.transform.position + new Vector3(0.6f,0,0);
            else
                transform.position = playerInPosesion.transform.position - new Vector3(0.6f, 0, 0);
        }
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Triggered");
    }

        void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            playerInPosesion = coll.gameObject;
            rb.isKinematic = true;
            rb.velocity.Set(0, 0);
        }
    }

    public void shootPuck ()
    {
        //get the position of the enemy goal
        //add a force to the puck
        int sign = 1;
        Vector3 target;
        if (playerInPosesion.GetComponent<Unit>().PlayerNumber != 0)
        {
            sign = -1;
            target = Vector3.Normalize(transform.position + transform.up * Random.Range(-1f, 1f) - redGoal.transform.position);
        } else
        {
            target = Vector3.Normalize(greenGoal.transform.position + transform.up * Random.Range(-1f, 1f) - transform.position);
        }
        transform.position = playerInPosesion.transform.position + sign*1f*target;
        playerInPosesion = null;
        rb.isKinematic = false;
        rb.AddForce(target * thrust * sign);
            
    }
}
