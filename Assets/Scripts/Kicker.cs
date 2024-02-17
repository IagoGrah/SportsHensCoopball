using UnityEngine;

public class Kicker : MonoBehaviour
{
    [SerializeField] float force = 0.1f;

    [SerializeField] GameObject kickEffect;

    public bool ApplyKick = true;

    void OnCollisionEnter(Collision collision)
    {
        if (ApplyKick && collision.gameObject.CompareTag("Ball"))
        {
            Rigidbody ballRigidbody = collision.gameObject.GetComponent<Rigidbody>();

            var contact = collision.GetContact(0);
            Vector3 collisionNormal = contact.normal;
            ballRigidbody.AddForce(-collisionNormal * force, ForceMode.Impulse);

            Instantiate(kickEffect, contact.point, Quaternion.identity);
            AudioManager.Instance.PlayKickSound();
        }
    }
}
