using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using NaughtyAttributes;

namespace Screens
{
    public enum ScreenType
    {
        Panel,
        Info_Panel,
        Shop
    }

    public class screenBase : MonoBehaviour
    {
        public ScreenType screenType;
        public List<Transform> objectList;
        public List<Transform> PhraseList;

        public float ObjectsDelay;

        public Image uiBackground;
        public bool HiddenStart = false;

        private void Start()
        {
            if (HiddenStart)
                HideObjects();
        }

        [Button]
        public virtual void Show()
        {
            ShowObjects();
        }

        [Button]
        public virtual void Hide()
        {
            HideObjects();
        }

    private void HideObjects()
    {
        CancelInvoke();

        foreach (var obj in objectList)
            obj.gameObject.SetActive(false);

        foreach (var phrase in PhraseList)
        {
            var type = phrase.GetComponent<typer>();
            if (type != null)
                type.Clear();
        }

        uiBackground.enabled = false;
    }

        private void ShowObjects()
        {
            foreach (var obj in objectList)
                obj.gameObject.SetActive(true);

            uiBackground.enabled = true;


            Invoke(nameof(StartType), ObjectsDelay);
        }

        private void StartType()
        {
            foreach (var phrase in PhraseList)
            {
                var type = phrase.GetComponent<typer>();
                if (type != null)
                    type.StartType();
            }
        }
    }
}
