using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    public float speed = 0.1f;
    private Renderer rendBackground;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.TryGetComponent(out rendBackground);
    }

    // Update is called once per frame
    void Update()
    {
        if (rendBackground == null) return;

        float y = Mathf.Repeat (Time.time * speed, 1);
        Vector2 offset = new Vector2(0.5f, y);
        rendBackground.sharedMaterial.SetTextureOffset("_MainTex_", offset);
    }
}

