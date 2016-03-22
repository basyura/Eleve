# Eleve

Livet Based OreOre Framework

(参考にして自分でアプリケーションが作りやすそうなフレームワークを作ってみましたの意)

## Description

MVVM is so great. But so difficult and complex to build application.  
Eleve is WPF Framwork not fussy about MVVM.

## Livet

Livet is a very powerful MVVM Infrastructure for WPF

- http://ugaya40.hateblo.jp/entry/livet
- https://github.com/ugaya40/Livet


## Files


```
EleveSample
├── Actions
│   ├── EleveSample
│   │   ├── EleveSampleActionBase.cs
│   │   ├── Initialize.cs
│   │   └── OpenItemSelector.cs
│   └── ItemSelector
│       ├── Initialize.cs
│       ├── ItemSelectorActionBase.cs
│       └── Notify.cs
├── Models
│   └── Person.cs
├── ViewModels
│   ├── EleveSampleViewModel.cs
│   └── ItemSelectorViewModel.cs
└── Views
    ├── EleveSampleView.xaml
    ├── EleveSampleView.xaml.cs
    ├── ItemSelectorView.xaml
    └── ItemSelectorView.xaml.cs
```

## Call Action

```xml
<Button Content="Open">
  <i:Interaction.Triggers>
    <i:EventTrigger EventName="Click">
      <ev:Execute Action="OpenItemSelector" />
    </i:EventTrigger>
  </i:Interaction.Triggers>
</Button>
```

## Open Window

Open ItemSelectorView with param and callback.

```xml
OpenDialogWindow<ItemSelectorView>(param, (type, ret) => {
  ViewModel.Message = type.ToString() + " - " + ret;
});
 
```

Close ItemSlectorView and notify param.


```xml
CloseWindow(WindowCloseType.OK, ViewModel.ID);
```


## License

- [zlib/libpng](https://opensource.org/licenses/zlib-license.php) 

zlib/libpngライセンスで提供しています。zlib/libpng ライセンスでは、ライブラリとしての利用に留めるのであれば再配布時にも著作権表示などの義務はありません。しかし、ソースコードを改変しての再配布にはその旨の明示が義務付けられます。

Eleve include Livet's code.

## TODO

- Broken English
- Is License ok?
- Input Validation
