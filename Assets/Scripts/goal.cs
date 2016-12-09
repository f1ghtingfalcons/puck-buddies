using UnityEngine;
using UnityEngine.UI;

public class goal : MonoBehaviour {
    public int score = 0;
    public GameObject text;
    public string team;
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Puck")
        {
            score++;
            text.transform.GetComponent<Text>().text = team + ": " + score;
        }
    }
}
