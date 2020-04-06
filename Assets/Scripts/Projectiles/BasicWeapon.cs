using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Projectiles
{
    class BasicWeapon : MonoBehaviour
    {
        public GameObject BulletPrefab;

        float bulletSpeed = 20;
        float nextAllowedFireTime = 0;

        AudioSource fireSound;

        public void Awake()
        {
            fireSound = GetComponent<AudioSource>();
        }

        public void Fire()
        {
            if (nextAllowedFireTime <= Time.time)
            {
                nextAllowedFireTime = Time.time + .5f;
                SpawnProjectile();
                fireSound.Play();
            }
        }

        private void SpawnProjectile()
        {
            Debug.Log("Spawning projectile");

            var bullet = GameObject.Instantiate(BulletPrefab);
            bullet.transform.position = transform.position;

            var rb = bullet.GetComponent<Rigidbody>();

            var nearestEnemy = EnemyManager.Instance.GetNearestEnemy(PlayerManager.Instance.Player.transform);

            var dir = (nearestEnemy.transform.position - bullet.transform.position).normalized;

            rb.velocity = dir * bulletSpeed;
        }
    }
}
