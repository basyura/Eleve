# Eleve

Livet Based OreOre Framework

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
│   ├── EleveSampleViewModel.cs~
│   └── ItemSelectorViewModel.cs
└── Views
    ├── EleveSampleView.xaml
    ├── EleveSampleView.xaml.cs
    ├── ItemSelectorView.xaml
    └── ItemSelectorView.xaml.cs
```

## How to call Action

```
<Button Content="Open">
  <i:Interaction.Triggers>
    <i:EventTrigger EventName="Click">
      <ev:Execute Action="OpenItemSelector" />
    </i:EventTrigger>
  </i:Interaction.Triggers>
</Button>
```


## License

- [zlib/libpng](https://opensource.org/licenses/zlib-license.php) 

zlib/libpngライセンスで提供しています。zlib/libpng ライセンスでは、ライブラリとしての利用に留めるのであれば再配布時にも著作権表示などの義務はありません。しかし、ソースコードを改変しての再配布にはその旨の明示が義務付けられます。

Eleve include Livet's code.

## TODO

- Broken English
- Is License ok?
- Input Validation
