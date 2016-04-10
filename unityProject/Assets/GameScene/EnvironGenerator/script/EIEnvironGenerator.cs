using UnityEngine;

namespace GameScene.EnvironGenerator
{
    using GlobalElement;

    public class EIEnvironGenerator : MonoBehaviour
    {
        [SerializeField] private GameObject planetCreatorPrefab, tankCreatorPrefab, barrierCreatorPrefab, surfaceResearcherPrefab;

        private PlanetCreator planetCreator;
        private TankCreator tankCreator;
        private BarrierCreator barrierCreator;
        private SurfaceResearcher surfaceResearcher;


        public void Init()
        {
            planetCreator = Instantiate(planetCreatorPrefab).GetComponent<PlanetCreator>();
            tankCreator = Instantiate(tankCreatorPrefab).GetComponent<TankCreator>();
            barrierCreator = Instantiate(barrierCreatorPrefab).GetComponent<BarrierCreator>();
            surfaceResearcher = Instantiate(surfaceResearcherPrefab).GetComponent<SurfaceResearcher>();

            CreatePlanet();
            CreateSurfaceResearcher();
        }

        private void CreatePlanet()
        {
            planetCreator.CreatePlanet(GlobalManager.Instance._PlayerData.PlanetID);
        }

        private void CreateSurfaceResearcher()
        {
            surfaceResearcher.Init();
        }

        private void CreateTanks()
        {
            tankCreator.Create(0,1);
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
