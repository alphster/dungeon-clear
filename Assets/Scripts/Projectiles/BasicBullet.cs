using Assets.Scripts;
using System.Collections;
using UnityEngine;

public class BasicBullet : MonoBehaviour
{
    int bounceCount = 0;
    Rigidbody rb;
    MeshRenderer mr;
    ParticleSystem ps;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        mr = GetComponent<MeshRenderer>();
        ps = GetComponent<ParticleSystem>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        var cGo = collision.gameObject;
        switch (cGo.layer)
        {
            case (int)Layers.Enemy:
                cGo.GetComponent<Enemy>().Hit(rb.velocity.normalized);
                Destroy(this.gameObject);
                break;
            default:
                if (bounceCount < 3)
                {
                    bounceCount++;
                }
                else
                {
                    //Destroy(this.gameObject);
                    StartCoroutine(AnimatedDestroy());
                }
                break;
        }
    }

    // every 2 seconds perform the print()
    private IEnumerator AnimatedDestroy()
    {
        mr.enabled = false;
        rb.velocity = Vector3.zero;
        ps.Play();
        yield return new WaitForSeconds(1);
        Destroy(this.gameObject);
    }
}
