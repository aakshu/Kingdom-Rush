using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float movementPeriod = 0.5f;
    [SerializeField] ParticleSystem goalParticle;
    // Start is called before the first frame update
    void Start()
    {
        PathFinder pathFinder = FindObjectOfType<PathFinder>();
        var path = pathFinder.GetPath();
        StartCoroutine(FollowPath(path));
    }

    private IEnumerator FollowPath(List<Waypoint> path)
    {
        foreach (Waypoint waypoint in path)
        {
            Vector3 displacementVector = new Vector3(0f, 3f, 0f);
            transform.position = waypoint.transform.position + displacementVector;
            yield return new WaitForSeconds(movementPeriod);            
        }
        SelfDestruct();
    }

    private void SelfDestruct()
    {
        var deathVFX = Instantiate(goalParticle, transform.position, Quaternion.identity);
        deathVFX.Play();
        Destroy(deathVFX.gameObject, deathVFX.main.duration);
        Destroy(gameObject);
    }

}
