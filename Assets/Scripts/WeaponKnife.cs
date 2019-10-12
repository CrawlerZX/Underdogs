using UnityEngine;

public class WeaponKnife : MonoBehaviour
{
    public float damage = 10f;
    private Animator animator;

    // Update is called once per frame
    void Update()
    {
        if (gameObject.activeSelf) {
        animator = GetComponentInParent<Animator>();
        animator.SetBool("UsingKnife", true);
        animator.SetBool("UsingSubmachine", false);
        animator.SetBool("UsingHandgun", false);

        }
        if (Input.GetAxis("Right Trigger") == 1) {
            Cut();
        }
    }

    public void Cut()
    {
        animator.SetTrigger("Cut");
    }
}
