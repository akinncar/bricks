using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class BrickController : MonoBehaviour
{
  private BrickModel _brickModel;

  Text points;
  Text message;
  Vector3 myVector;


  public BrickModel BrickModel { get => _brickModel; set => _brickModel = value; }

  // Start is called before the first frame update
  void Start()
  {
    _brickModel = GetComponent<BrickModel>();
  }

  // Update is called once per frame
  public void TakeDamage(float damage, BallController _ballController)
  {
    Destroy(gameObject);
    _brickModel.Health -= damage;

    if (_brickModel.Health <= 0)
    {
      int oldScore;
      int newScore;

      points = GameObject.Find("Points").GetComponent<Text>();
      int.TryParse(points.text, out oldScore);
      newScore = oldScore + 10;

      points.text = newScore.ToString();

      Destroy(gameObject);

      GlobalVariables.numberOfBricks = GlobalVariables.numberOfBricks - 1;

      if (GlobalVariables.numberOfBricks == 0)
      {
        message = GameObject.Find("Message").GetComponent<Text>();
        message.text = "Vitória!";

        // stop move
        _ballController.StopBall();
      }
    }
  }
}
