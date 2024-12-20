using UnityEngine;
using System.Collections;

public class SetChickenPlayerColor : MonoBehaviour
{
    public Color chickenColor = Color.white;
    public SkinnedMeshRenderer[] chickenRenderer;
    private MaterialPropertyBlock mpb;

    public Material FullScreenPass;
    private void OnEnable()
    {
        if (transform.parent != null)
            if (transform.parent.transform.GetComponent<PlayerController>() != null)
                chickenColor = transform.parent.transform.GetComponent<PlayerController>().chickenColor;


        foreach (SkinnedMeshRenderer renderer in chickenRenderer)
        {
            mpb = new MaterialPropertyBlock();
            mpb.SetColor("_PlayerColor", chickenColor);
            renderer.SetPropertyBlock(mpb);
        }


    }
    public void StartImpact()
    {
        StartCoroutine(ImpactFrameProgress());
    }

    public IEnumerator ImpactFrameProgress()
    {
        FullScreenPass.SetFloat("_ImpactActive", 1);


        for (int i = 0; i < 3; i++)
        {
            FullScreenPass.SetFloat("_ImpactStep", i % 2);
            Debug.Log(i % 2);

            yield return new WaitForSeconds(.05f);
        }

        FullScreenPass.SetFloat("_ImpactActive", 0);
        StopCoroutine(ImpactFrameProgress());
    }
}
