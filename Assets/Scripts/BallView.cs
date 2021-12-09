using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class BallView : MonoBehaviour
{
    private BallController _ballController;
    Vector3 myVector;
    Text life;

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
        else if (collision.gameObject.tag == "Finish")
        {
            int oldLife;
            int newLife;

            life = GameObject.Find("Life").GetComponent<Text>();
            int.TryParse(life.text, out oldLife);
            newLife = oldLife - 1;

            life.text = newLife.ToString();

            myVector = new Vector3(-1.32f, -3.71f, 0.0f);
            _ballController.transform.SetPositionAndRotation(myVector, new Quaternion());
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
