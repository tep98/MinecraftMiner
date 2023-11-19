using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomButtonPlace : MonoBehaviour
{
    [SerializeField] Transform[] Places;
    [SerializeField] Transform Cross;

    private int randPosition;
    private Transform currentPlace;
    public void SetNewPosition()
    {
        gameObject.GetComponent<Animator>().SetBool("playBreack", false);
        randPosition = Random.Range(0, Places.Length);
        currentPlace = Places[randPosition];

        Cross.position = currentPlace.position;
    }
}
