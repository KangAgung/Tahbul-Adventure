using Popcorn.Bases;
using Popcorn.Core;
using Popcorn.Metadatas;
using UnityEngine.SceneManagement;
using ScenesNames = Popcorn.Metadatas.Scenes.Names;

namespace Popcorn.Managers
{

    public sealed class ScenesManager : ManagerBase<ScenesManager>
    {

        public void CallNextScene()
        {
            ScenesNames nextSceneName;

            switch (App.currentSceneName)
            {
                case ScenesNames.World1Scene1:
                    nextSceneName = ScenesNames.World1Scene1;
                    break;
                case ScenesNames.World1Scene2:
                    nextSceneName = ScenesNames.World1Scene2;
                    //SceneManager.LoadScene(2);
                    break;
                default:
                    nextSceneName = ScenesNames.World1Scene1;
                    break;
            }
            App.currentSceneName = nextSceneName;
            SceneManager.LoadScene(nextSceneName.ToString());
        }

    }
    
}