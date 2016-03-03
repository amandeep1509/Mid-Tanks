using UnityEngine;
using System.Collections;

public class PlayerCollider : MonoBehaviour
{

    public GameController gameController;
    public EnemyController enemy;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    //Method to detect collisions
    public void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(this.gameController.LivesValue);

        if (other.gameObject.CompareTag("Enemy"))
        {

            this.gameController.LivesValue -= 1;
            this.gameController.ScoreValue += 10;
            this.enemy._Reset();

        }



    }

}
