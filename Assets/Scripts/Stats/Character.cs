using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public static Character instance;

    public CharacterStat Damage;
    public CharacterStat Speed;
    public CharacterStat FireRate;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else if(instance != this)
        {
            Destroy(this);
        }
        DontDestroyOnLoad(this.gameObject);
    }
}
