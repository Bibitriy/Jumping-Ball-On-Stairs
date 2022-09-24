using UnityEngine;

public class BallCustomiser : MonoBehaviour
{
	[SerializeField] private GameObject _ball;
    [SerializeField] private Material _greenMaterial;
    [SerializeField] private Material _yellowMaterial;
    [SerializeField] private Material _blueMaterial;


    private MeshRenderer _meshRenderer;

    private void Start()
    {
        _meshRenderer = _ball.GetComponent<MeshRenderer>();
    }

    public void ChangeColourToYellow()
    {
        _meshRenderer.material = _yellowMaterial;
    }

    public void ChangeColourToBlue()
    {
        _meshRenderer.material = _blueMaterial;
    }

    public void ChangeColourToGreen()
    {
        _meshRenderer.material = _greenMaterial;
    }
}