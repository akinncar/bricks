using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class BallView : MonoBehaviour
{
  private BallController _ballController;
  Vector3 myVector;
  Text life;
  AudioSource[] sounds;
  AudioSource _sourceAudio;
  AudioSource _sourceAudioWall;
  AudioSource _sourceAudioTafareu;
  AudioSource _sourceAudioFaustao;
  AudioSource _sourceAudioSilvioSantos;
  Text points;
  Text message;

  // Start is called before the first frame update
  void Start()
  {
    _ballController = GetComponent<BallController>();
    sounds = GetComponents<AudioSource>();
    _sourceAudio = sounds[0];
    _sourceAudioWall = sounds[1];
    _sourceAudioTafareu = sounds[2];
    _sourceAudioFaustao = sounds[3];
    _sourceAudioSilvioSantos = sounds[4];
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
      _ballController.PerfectAngleReflect(collision);
      return;
    }
    else if (collision.gameObject.tag == "Finish")
    {
      int oldLife;
      int newLife;

      _sourceAudioFaustao.Play();

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

        _ballController.PerfectAngleReflect(collision);
        myVector = new Vector3(-1.32f, 0f, 0.0f);
        _ballController.transform.SetPositionAndRotation(myVector, new Quaternion());
      }
      else
      {
        _sourceAudioSilvioSantos.Play();

        // life
        int.TryParse(life.text, out oldLife);
        newLife = oldLife - 1;

        life.text = newLife.ToString();

        message = GameObject.Find("Message").GetComponent<Text>();
        message.text = "Game Over!";

        _ballController.StopBall();
      };

      return;
    }

    // moviment ball change when player crash
    if (collision.gameObject.tag == "Player")
    {
      _sourceAudioTafareu.Play();
      _ballController.CalcBallAngleReflect(collision);

      // score
      //   int oldScore;
      //   int newScore;

      //   points = GameObject.Find("Points").GetComponent<Text>();
      //   int.TryParse(points.text, out oldScore);
      //   newScore = oldScore - 1;

      //   points.text = newScore.ToString();

      return;
    }
    else
    {
      // loads normal angle
      _sourceAudioWall.Play();
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
