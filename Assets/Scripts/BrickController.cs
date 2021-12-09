using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class BrickController : MonoBehaviour
{
    private BrickModel _brickModel;
    Text numberBricks;

    public BrickModel BrickModel { get => _brickModel; set => _brickModel = value; }

    // Start is called before the first frame update
    void Start()
    {
        _brickModel = GetComponent<BrickModel>();
    }

    // Update is called once per frame
    public void TakeDamage(float damage)
    {
        Destroy(gameObject);
        _brickModel.Health -= damage;
        
        if (_brickModel.Health <= 0) 
        {
            int oldScore;
            int newScore;

            numberBricks = GameObject.Find("NumberBricks").GetComponent<Text>();
            int.TryParse(numberBricks.text, out oldScore);
            newScore = oldScore - 1;

            numberBricks.text = newScore.ToString();

            Destroy(gameObject);
        } 
    }
}
