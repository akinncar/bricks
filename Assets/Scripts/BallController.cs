using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    private BallModel _ballModel;
    private Rigidbody2D _ballRigibody;

    // Start is called before the first frame update
    void Start()
    {
        _ballModel = GetComponent<BallModel>();
        _ballRigibody = GetComponent<Rigidbody2D>();

        _ballRigibody.velocity = _ballModel.Direction * _ballModel.Speed;
    }

    // Update is called once per frame
    public void PerfectAngleReflect(Collision2D collision)
    {
        _ballModel.Direction = Vector2.Reflect(_ballModel.Direction, collision.contacts[0].normal);
        _ballRigibody.velocity = _ballModel.Direction * _ballModel.Speed;
    }

    public void CalcBallAngleReflect(Collision2D colision)
    {
        // calc angle for player reflect
    }
}
