using UnityEngine;

[RequireComponent(typeof(IExecutable))]
public class ClothesRack : MonoBehaviour
{
    [SerializeField]
    private PlayerAnimationData _newCloth;

    void Awake()
    {
        IExecutable executable= GetComponent<IExecutable>();
        executable.SetAction(GetCloth);
    }

    private void GetCloth()
    {
        FindObjectOfType<PlayerSpriteHandler>().SetSpriteData(_newCloth);

    }
}
