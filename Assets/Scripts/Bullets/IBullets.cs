using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBullets
{
    float TravelDistance { get; set; }
    int Damage { get; set; }
    float TravelTime { get; set; }
}
