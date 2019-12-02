using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MiraController : MonoBehaviour
{
    [SerializeField] RectTransform miraPoint = null;
    float localFactor = 1;
    Vector3 defaultSize = new Vector3(1f,1f,1f);
    private void Start() {
        defaultSize = miraPoint.localScale;
    }
    public void SetSizePoint(float factor) {
        localFactor = Mathf.Lerp(localFactor, factor, .2f);
        miraPoint.localScale = defaultSize * localFactor;
    }

}
