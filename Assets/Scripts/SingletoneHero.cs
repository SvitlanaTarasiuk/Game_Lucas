using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletoneHero : MonoBehaviour
{
    private static SingletoneHero _singletoneHero;

    public static SingletoneHero singletoneHero
    {
        get
        {
            if (_singletoneHero == null)
            {
                _singletoneHero = GameObject.FindObjectOfType<SingletoneHero>();
                DontDestroyOnLoad(_singletoneHero.gameObject);
            }
            return _singletoneHero;
        }
    }

    void Awake()
    {
        if (_singletoneHero == null)
        {
            _singletoneHero = this;
            DontDestroyOnLoad(_singletoneHero.gameObject);
        }
        else if (this != _singletoneHero)
        {
            Destroy(this.gameObject);
        }
    }
}
