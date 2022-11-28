using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonAndroid : MonoBehaviour
{
    private Hero hero;

    void Start()
    {
        hero = SingletoneHero.singletoneHero.GetComponent<Hero>();
    }

    public void LeftRunDown()
    {
        hero.move = -1;
    }
    public void LefthRunUp()
    {
        hero.move = 0;
    }
    public void RigthRunDown()
    {
        hero.move = 1;
    }
    public void RigthRunUp()
    {
        hero.move = 0;
    }
    public void JumpClick()
    {
        hero.JumpMobile();
    }
    public void AttackClick()
    {
        hero.AttackMomile();
    }
    
}
