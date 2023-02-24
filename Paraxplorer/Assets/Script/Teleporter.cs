using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Teleporter : MonoBehaviour
{

    [SerializeField] private Transform Destination;

    public Transform GetDestination() {
        return Destination;
    }
}
