using UnityEngine;

public class SimpleAnimationPlayer : MonoBehaviour
{
    [SerializeField] private Animation _anim;

    void Start()
    {
        _anim.Play();
    }


}
