using UnityEngine;

namespace GamePlay.Utils.GameObjectDestroyer
{
    [CreateAssetMenu(menuName = "Game Dev/Utils/GameObjectDestroyer")]
    public class GameObjectDestroyer : ScriptableObject
    {
        public void DestroyGameObject(GameObject target)
        {
            Destroy(target);
        }
    }
}