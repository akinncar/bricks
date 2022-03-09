using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class BallController : MonoBehaviour
{
  private BallModel _ballModel;
  private Rigidbody2D _ballRigibody;
  private SpriteRenderer _ballSpriteRenderer;
  private Text message;

  // Start is called before the first frame update
  void Start()
  {
    _ballModel = GetComponent<BallModel>();
    _ballRigibody = GetComponent<Rigidbody2D>();
    _ballSpriteRenderer = GetComponent<SpriteRenderer>();

    _ballRigibody.velocity = _ballModel.Direction * _ballModel.Speed;
  }

  public void StartBall()
  {
    this.transform.position = Vector2.zero;
    _ballRigibody.velocity = Vector2.zero;
  }

  public void StopBall()
  {
    this.transform.position = new Vector2(-999f, -999f);
    _ballRigibody.velocity = Vector2.zero;
  }


  // Update is called once per frame
  public void PerfectAngleReflect(Collision2D collision)
  {
    Vector2 direction = Vector2.Reflect(_ballModel.Direction, collision.contacts[0].normal);
    AngleChange(direction);
  }

  public void CalcBallAngleReflect(Collision2D colision)
  {
    // calc angle for player reflect
    float playerPixels = 250f * 0.4f;

    // convert sizemto unity scale
    float unityScaleHalfPlayerPixels = playerPixels / 2f / 100f;

    // convert 0 to 120 (player) to 0 to 180 (angle)
    float scaleFactorPut1dot180Range = 120 / playerPixels;

    // calc angle from unity scale (0 > 1.8)
    float angleDegUnityScale = (
        colision.transform.position.x -
        transform.position.x +
        unityScaleHalfPlayerPixels
    ) * scaleFactorPut1dot180Range;

    float angleDeg = angleDegUnityScale * 100f;

    float angleRad = angleDeg * Mathf.PI / 120f;

    Vector2 vetorRetorno = new Vector2(Mathf.Cos(angleRad), Mathf.Sin(angleRad));

    AngleChange(vetorRetorno);
  }

  public void AngleChange(Vector2 direcion)
  {
    _ballModel.Direction = direcion;
    _ballRigibody.velocity = _ballModel.Direction * _ballModel.Speed;
  }

  public void ChangeColor(Color color)
  {
    _ballSpriteRenderer.color = color;
  }
}
