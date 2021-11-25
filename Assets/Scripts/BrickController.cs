using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickController : MonoBehaviour
{
    private BrickModel _brickModel;

    public BrickModel BrickModel { get => _brickModel; set => _brickModel = value; }

    // Start is called before the first frame update
    void Start()
    {
        _brickModel = GetComponent<BrickModel>();
    }

    // Update is called once per frame
    public void TakeDamage(float damage)
    {
        _brickModel.Health -= damage;
        
        if (_brickModel.Health <= 0) 
        {
            Destroy(gameObject);
        } 
    }
}
