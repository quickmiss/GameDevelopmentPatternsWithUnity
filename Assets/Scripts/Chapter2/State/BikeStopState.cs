using UnityEngine;

namespace Chapter.State
{
    public class BikeStopState : MonoBehaviour, IBikeState
    {
        private BikeController _bikeController;

        public void Handle(BikeController bikecontroller)
        {
            if (!_bikeController) _bikeController = bikecontroller;

            _bikeController.CurrentSpeed = 0;
        }
    }

}
