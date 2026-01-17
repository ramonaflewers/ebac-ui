using UnityEngine;

public class ButtonStartGame : MonoBehaviour
{
    public ParticleSystem particlePrefab;

    public void OnClick()
    {
        ParticleSystem ps = Instantiate(particlePrefab, transform);

        ps.transform.localPosition = Vector3.zero;
        ps.transform.localRotation = Quaternion.identity;

        ps.Play();

        Destroy(ps.gameObject, ps.main.duration + ps.main.startLifetime.constantMax);
    }
}
