using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    GlobalVariables.numberOfBricks = 11;
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
        if (GlobalVariables.level == 1)
        {
          GlobalVariables.level = 2;
          SceneManager.LoadScene("Fase2");
          return;
        }
        else if (GlobalVariables.level == 2)
        {
          GlobalVariables.level = 3;
          SceneManager.LoadScene("Fase3");
          return;
        }
        else if (GlobalVariables.level == 3)
        {
          message = GameObject.Find("Message").GetComponent<Text>();
          message.text = "Vitória!";

          // stop move
          _ballController.StopBall();
        }

      }
    }
  }
}
