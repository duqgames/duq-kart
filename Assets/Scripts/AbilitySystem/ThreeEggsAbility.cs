using System.Collections;
using UnityEngine;

namespace AbilitySystem
{
    public class ThreeEggsAbility : AbilityBase
    {
        [SerializeField] private GameObject eggPrefab;
        [SerializeField] private Transform orbitingParent;
        [SerializeField] private Transform projectileStart;
        [SerializeField] private float projectileSpeed;

        private GameObject _egg0;
        private GameObject _egg1;
        private GameObject _egg2;

        private bool _firstEggReady;
        private bool _secondEggReady;
        private bool _thirdEggReady;

        public override void Update()
        {
            base.Update();
            
            if (!IsActive) return;
            orbitingParent.transform.Rotate(0, 100 * Time.deltaTime, 0);

            if (Input && _firstEggReady)
                StartCoroutine(ShootFirstEgg());
            if (Input && _secondEggReady)
                StartCoroutine(ShootSecondEgg());
            if (Input && _thirdEggReady)
                StartCoroutine(ShootThirdEgg());
        }
        
        public override void Activate()
        {
            base.Activate();
            
            _egg0 = Instantiate(eggPrefab, orbitingParent.position + new Vector3(0,0,3), Quaternion.identity);
            _egg0.transform.SetParent(orbitingParent);
            
            _egg1 = Instantiate(eggPrefab, orbitingParent.position + new Vector3(3,0,-3), Quaternion.identity);
            _egg1.transform.SetParent(orbitingParent);
            
            _egg2 = Instantiate(eggPrefab, orbitingParent.position + new Vector3(-3,0,-3), Quaternion.identity);
            _egg2.transform.SetParent(orbitingParent);

            StartCoroutine(CanUseFalse());
            StartCoroutine(IsActiveTrue());
            _firstEggReady = true;
        }

        private IEnumerator ShootFirstEgg()
        {
            StartCoroutine(ShootEgg(_egg0));
            _firstEggReady = false;
            yield return null;
            _secondEggReady = true;
        }

        private IEnumerator ShootSecondEgg()
        {
            StartCoroutine(ShootEgg(_egg1));
            _secondEggReady = false;
            yield return null;
            _thirdEggReady = true;
        }

        private IEnumerator ShootThirdEgg()
        {
            StartCoroutine(ShootEgg(_egg2));
            _thirdEggReady = false;
            yield return null;
            StartCoroutine(IsActiveFalse());
            GetComponent<AbilityChecker>().hasAbility = false;
        }

        private IEnumerator ShootEgg(GameObject egg)
        {
            var rb = egg.GetComponent<Rigidbody>();
            var eggCollider = egg.GetComponent<Collider>();
                
            egg.transform.SetParent(null);
            eggCollider.enabled = false;
            yield return null;
            egg.transform.position = projectileStart.position;
            yield return null;
            rb.constraints = RigidbodyConstraints.None;
            rb.AddForce(transform.forward * projectileSpeed, ForceMode.Impulse);
            yield return new WaitForSeconds(0.1f);
            eggCollider.enabled = true;
        }
    }
}