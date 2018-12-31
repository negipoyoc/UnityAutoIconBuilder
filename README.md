# UnityAutoIconBuilder
Unityでビルド時に自動でアイコンを生成し設定してくれるものです。

[UnityIconCustomizer](https://github.com/makoto-unity/UnityIconCustomizer)をベースに、

* PC向けに出力サイズと出力場所を変更 
* ビルド時に自動生成する

といった改造をしています。


# 使用法
[こちら](https://github.com/negipoyoc/UnityAutoIconBuilder/releases/download/v1.0/UnityAutoIconBuilder.unitypackage)からunitypackageを取得し、自分のプロジェクトに展開してください。

それだけで終わりです。

注意：自動でビルド時にテクスチャが設定されます！今まで設定していたものがあれば上書きされるので注意。

## Tips
### 出力される画像を編集したい時
Assets/UnityAutoIconBuilder/Scene/IconEdit.unity　で自動出力される画像を任意のものに編集できます。

### PC向けからAndroidやiOS向けに変えたい時(または画像の出力サイズを変えたい時)
1.RenderTexture(Assets/UnityAutoIconBuilder/Res/ConfigrationImageRenderTexture.renderTexture)のサイズを変更する。

2.IconEdit.unityを開き、AndroidやiOS向けに出力される画像を編集したあとPrefabを更新して閉じる。

3.UnityIconCustomizerの以下の部分を参考に、出力される画像の設定先をFixする<br>
https://github.com/makoto-unity/UnityIconCustomizer/blob/85123e94568d4ea4c60ed3eb9a2b33cf9e589e51/Assets/UnityIconCustomizer/Scripts/Editor/IconBuilder.cs#L11

### 解説記事
https://negipoyoc.com/blog/autoicongen/

に書いています。

# 権利表記
使用させていただいたものに関して以下に表記します。

## UnityIconCustomizer

MIT License

Copyright (c) 2018 Makoto Ito

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
