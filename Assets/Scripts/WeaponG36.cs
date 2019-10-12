using UnityEngine;

public class WeaponG36 : MonoBehaviour
{
    public float damage = 10f;
    public float range = 50f;
    private Animator animator;

    // Update is called once per frame
    void Update()
    {
        if (gameObject.activeSelf) {
        animator = GetComponentInParent<Animator>();
        animator.SetBool("UsingSubmachine", true);
        animator.SetBool("UsingHandgun", false);
        animator.SetBool("UsingKnife", false);

        }
        if (Input.GetAxis("Right Trigger") == 1) {
            Shoot();

        }
    }

    void Shoot()
    {
        animator.SetTrigger("Burst");
    }
}
