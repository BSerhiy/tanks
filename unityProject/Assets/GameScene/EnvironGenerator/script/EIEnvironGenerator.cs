using UnityEngine;

namespace GameScene.EnvironGenerator
{
    using GlobalElement;

    public class EIEnvironGenerator : MonoBehaviour
    {
        [SerializeField] private GameObject planetCreatorPrefab, tankCreatorPrefab, barrierCreatorPrefab;

        private PlanetCreator planetCreator;
        private TankCreator tankCreator;
        private BarrierCreator barrierCreator;


        public void Init()
        {
            planetCreator = Instantiate(planetCreatorPrefab).GetComponent<PlanetCreator>();
            tankCreator = Instantiate(tankCreatorPrefab).GetComponent<TankCreator>();
            barrierCreator = Instantiate(barrierCreatorPrefab).GetComponent<BarrierCreator>();

            CreatePlanet();
        }

        public void CreatePlanet()
        {
            planetCreator.CreatePlanet(GlobalManager.Instance._PlayerData.PlanetID, CreateTanks);
        }

        public void CreateTanks()
        {
            tankCreator.Create(0,1,CreateBarriers);
        }

        private void CreateBarriers()
        {
            barrierCreator.Create(0, 1, EndOfCreating);
        }

        private void EndOfCreating()
        {

        }
    }
}
