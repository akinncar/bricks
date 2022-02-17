using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class BallView : MonoBehaviour
{
  private BallController _ballController;
  Vector3 myVector;
  Text life;
  AudioSource _sourceAudio;
  Text points;
  Text message;

  // Start is called before the first frame update
  void Start()
  {
    _ballController = GetComponent<BallController>();
    _sourceAudio = GetComponent<AudioSource>();
  }

  // Update is called once per frame
  private void OnCollisionEnter2D(Collision2D collision)
  {
    // verify game object type to take damage
    if (collision.gameObject.tag == "enemy")
    {
      _sourceAudio.Play();
      BrickView _brickView = collision.gameObject.GetComponent<BrickView>();
      _brickView.PerformTakeDamage(1f, _ballController);
    }
    else if (collision.gameObject.tag == "Finish")
    {
      int oldLife;
      int newLife;

      life = GameObject.Find("Life").GetComponent<Text>();

      if (life.text != "1")
      {
        // score
        // int oldScore;
        // int newScore;

        // points = GameObject.Find("Points").GetComponent<Text>();
        // int.TryParse(points.text, out oldScore);
        // newScore = oldScore - 10;

        // points.text = newScore.ToString();

        // life
        int.TryParse(life.text, out oldLife);
        newLife = oldLife - 1;

        life.text = newLife.ToString();

        _ballController.StartBall();
      }
      else
      {
        // life
        int.TryParse(life.text, out oldLife);
        newLife = oldLife - 1;

        life.text = newLife.ToString();

        message = GameObject.Find("Message").GetComponent<Text>();
        message.text = "Game Over!";

        _ballController.StopBall();
      };

    }

    // moviment ball change when player crash
    if (collision.gameObject.tag == "Player")
    {
      _sourceAudio.Play();
      _ballController.CalcBallAngleReflect(collision);

      // score
      //   int oldScore;
      //   int newScore;

      //   points = GameObject.Find("Points").GetComponent<Text>();
      //   int.TryParse(points.text, out oldScore);
      //   newScore = oldScore - 1;

      //   points.text = newScore.ToString();
    }
    else
    {
      // loads normal angle
      _sourceAudio.Play();
      _ballController.PerfectAngleReflect(collision);

      // score
      //   int oldScore;
      //   int newScore;

      //   points = GameObject.Find("Points").GetComponent<Text>();
      //   int.TryParse(points.text, out oldScore);
      //   newScore = oldScore - 1;

      //   points.text = newScore.ToString();
    }

  }
}
