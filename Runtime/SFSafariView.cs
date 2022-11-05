#if UNITY_IOS
// .asmdef の defineConstraints を使うと
// RuntimeInitializeOnLoadMethod が呼び出されず
// SFSafariView が正常に動作しなくなる現象に遭遇したので #if を使う形式にしています

using System.Runtime.InteropServices;
using Cysharp.Threading.Tasks;
using Kogane.Internal;
using UnityEngine;

namespace Kogane
{
    public static class SFSafariView
    {
        [DllImport( "__Internal" )] private static extern void launchUrl( string url );
        [DllImport( "__Internal" )] private static extern void dismiss();

        private static SFSafariViewEventHandler m_eventHandler;

        [RuntimeInitializeOnLoadMethod( RuntimeInitializeLoadType.BeforeSceneLoad )]
        private static void RuntimeInitializeOnLoadMethod()
        {
            var gameObject = new GameObject( "SFSafariView" );
            Object.DontDestroyOnLoad( gameObject );
            m_eventHandler = gameObject.AddComponent<SFSafariViewEventHandler>();
        }

        public static void OpenURL( string url )
        {
            OpenURLAsync( url ).Forget();
        }

        public static async UniTask OpenURLAsync( string url )
        {
            var tcs = new UniTaskCompletionSource();
            m_eventHandler.OnCompletedEvent = () => tcs.TrySetResult();
            launchUrl( url );
            await tcs.Task;

            m_eventHandler.OnCompletedEvent = null;
        }

        public static void Close()
        {
            dismiss();
        }
    }
}

#endif