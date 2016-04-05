using UnityEngine;

namespace GameScene.EnvironGenerator
{
    public class EIEnvironGenerator : MonoBehaviour
    {
        [SerializeField] private PlanetCreator planetCreator;
        [SerializeField] private BarrierCreator barrierCreator;
        [SerializeField] private TankCreator tankCreator;

        public void Init()
        {

        }

    }
}
