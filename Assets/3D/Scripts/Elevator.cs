using UnityEngine;

public class Elevator : MonoBehaviour
{
    //[SerializeField] AnimationClip anim;
    Animation anim;
    void Start()
    {
        anim = GetComponent<Animation>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            anim.Play();
        }
    }
}
