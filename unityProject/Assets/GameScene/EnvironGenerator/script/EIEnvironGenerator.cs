using UnityEngine;

namespace GameScene.EnvironGenerator
{
    using GlobalElement;

    public class EIEnvironGenerator : MonoBehaviour
    {
        [SerializeField] private GameObject planetCreator;
        [SerializeField] private TankCreator tankCreator;
        [SerializeField] private BarrierCreator barrierCreator;


        public void Init()
        {
            CreatePlanet();
        }

        public void CreatePlanet()
        {
            //Не срабатывает CallBack
            GameObject go = Instantiate(planetCreator);
            PlanetCreator planCreat = go.GetComponent<PlanetCreator>();
            planCreat.CreatePlanet(GlobalManager.Instance._PlayerData.PlanetID, TestCall);
        }

        public void TestCall()
        {
            Debug.Log("Сработал callback");
        }

        public void CreateTanks()
        {
            Debug.Log("Create tank");
            tankCreator.CreateTank(0,0,CreateBarriers);
        }

        private void CreateBarriers()
        {

        }
    }
}
