using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaceGameManager : MonoBehaviour
{
    public GameObject _horse;
    public GameObject _targetOne;

    [Range(0, 10)]
    public float speed;

    public virtual void Update()
    {
        _horse.transform.position = Vector3.MoveTowards(_horse.transform.position, _targetOne.transform.position, speed * Time.deltaTime);
    }
}
