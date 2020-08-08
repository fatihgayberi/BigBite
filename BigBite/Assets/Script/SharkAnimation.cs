using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharkAnimation : MonoBehaviour
{
    SharkCreate sharkCreate;
    Animation anim;

    public void SharkAnim(string animName)
    {
        sharkCreate = FindObjectOfType<SharkCreate>();
        anim = sharkCreate.getSharkPlayer().GetComponent<Animation>();
        anim.Play("Swim");
    }
}
