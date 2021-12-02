using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallView : MonoBehaviour
{
    private BallController _ballController;

    // Start is called before the first frame update
    void Start()
    {
        _ballController = GetComponent<BallController>();
    }

    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // verify game object type to take damage
        if (collision.gameObject.tag == "Enemy")
        {
            BrickView _brickView = collision.gameObject.GetComponent<BrickView>();
            _brickView.PerformTakeDamage(1f);
        }

        // moviment ball change when player crash
        if (collision.gameObject.tag == "Player")
        {
            _ballController.CalcBallAngleReflect(collision);
        }
        else
        {
            // loads normal angle
            _ballController.PerfectAngleReflect(collision);
        }
        
    }
}
