/*using UnityEngine;
using UnityEngine.Rendering;

namespace DefaultNamespace
{
    public class PaniniEffect : MonoBehaviour
    {
        public static PaniniEffect Instance;

        private Volume volume;
        private void Awake()
        {
            if (Instance == null) Instance = this;
        
            volume = GetComponent<Volume>();
        }

    
        void Update()
        {
            if (volume.weight > 0)
            {
                float decreaseSpeed = 1f;
                volume.weight -= Time.deltaTime * decreaseSpeed;
            }
        }

        public void SetWeight(float weight)
        {
            volume.weight = weight;
        }
    }
}*/