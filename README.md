# Kogane SFSafariView

Unity 製の iOS アプリで SFSafariView を使用できるようにするパッケージ

## 使用例

```cs
#if UNITY_IOS

using Kogane;
using UnityEngine;

public sealed class Example : MonoBehaviour
{
    private void Start()
    {
        SFSafariView.OpenURL( "https://www.google.co.jp/" );
    }
}

#endif
```

```cs
#if UNITY_IOS

using Cysharp.Threading.Tasks;
using Kogane;
using UnityEngine;

public sealed class Example : MonoBehaviour
{
    private async UniTaskVoid Start()
    {
        await SFSafariView.OpenURLAsync( "https://www.google.co.jp/" );
        Debug.Log( "閉じました" );
    }
}

#endif
```