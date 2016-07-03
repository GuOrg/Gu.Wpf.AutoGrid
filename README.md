# Gu.Wpf.AutoGrid

[![License](https://img.shields.io/badge/license-MIT-blue.svg)](LICENSE)
[![Build status](https://ci.appveyor.com/api/projects/status/weieh2q82cc87ksr/branch/master?svg=true)](https://ci.appveyor.com/project/JohanLarsson/gu-wpf-autogrid/branch/master)
[![NuGet](https://img.shields.io/nuget/v/Gu.Wpf.AutoRowGrid.svg)](https://www.nuget.org/packages/Gu.Wpf.AutoRowGrid/)


Small prototype for a less noisy WPF grid. 

# Grid
Is a `MarkupExtension` that spits out a new vanilla WPF grid when `ProvideValue` is called.

## ColumnDefinitions
### Attribute style

```xaml
<autoRowGrid:Grid ColumnDefinitions="Auto * 50">
    ...
</autoRowGrid:Grid>
```
### Element style

The designer may show a false negative error: `The attachable property 'ColumnDefinitions' was not found in type 'Grid'.`
Not sure if #pragma can be used in xaml somehow.

```xaml
<autoRowGrid:Grid AutoIncrementation="UseExplicitColumns">
    <autoRowGrid:Grid.ColumnDefinitions>
        <ColumnDefinition Width="Auto" MinWidth="70" />
        <ColumnDefinition Width="*" MaxWidth="70" />
    </autoRowGrid:Grid.ColumnDefinitions>
	 ...
</autoRowGrid:Grid>
```

# Row 
Is just a `List<UIElement>` that insers its contents on the next row in the grid. This avoids specifying `Grid.Row="n"`on multiple elements that are oin the same row and makes reordering trivial.

# AutoIncrementation
By default children of a `Row` get column index from their position:
```xaml
<autoRowGrid:Row Name="first row">
    <TextBlock Text="foo1" /> <!--this gets Grid.Column="0"-->
    <TextBox Text="{Binding Value1}" /> <!--this gets Grid.Column="1"-->
</autoRowGrid:Row>
```

If you want to set expllicit columns use UseExplicitColumns
```xaml
<autoRowGrid:Row AutoIncrementation="UseExplicitColumns">
    <Rectangle Grid.Column="0" Fill="Aqua" />
    <TextBlock Grid.Column="0" Text="foo1" />
    <TextBox Grid.Column="1" Text="{Binding Value1}" />
</autoRowGrid:Row>
```

Can also be set on a single `UIElement`: 

```xaml
<autoRowGrid:Row AutoIncrementation="AutoIncrement">
    <Rectangle Grid.Column="0" Fill="Aqua" autoRowGrid:AutoIncrement.AutoIncrementation="UseExplicitColumns" />
    <TextBlock Text="foo3" />
    <TextBox Text="{Binding Value3}" />
</autoRowGrid:Row>
```

Setting this on an element excludes it from the count so following elements are not affected.

## Defaults
The default for `AutoGrid` is `Increment` meaning children for `Row` get column index from position.
The default for `Row`and `Rows` is `Inherit` meaning they inherit incrementation from parent going all the way up to the `GridExtension`

## LastRowFill
If the last row should fill remaining space of if a starsized row should be added after the last row.

```xaml
<autoRowGrid:Grid ColumnDefinitions="Auto *" LastRowFill="True">
    <autoRowGrid:Row>
        <TextBlock Text="foo1" />
        <TextBox Text="{Binding Value1}" />
    </autoRowGrid:Row>
    <autoRowGrid:Row AutoIncrementation="UseExplicitColumns">
        <Rectangle Grid.ColumnSpan="2" Fill="RosyBrown" />
        <TextBlock Grid.ColumnSpan="2" HorizontalAlignment="Center" Text="last" />
    </autoRowGrid:Row>
</autoRowGrid:Grid>
```
# Sample xaml:

```xaml
<Window ...
        xmlns:autoRowGrid="http://gu.se/AutoRowGrid"
        ...>
    <autoRowGrid:Grid ColumnDefinitions="Auto * 50">
        <TextBlock Grid.Row="0" Grid.Column="0" Text="foo1" />
        <TextBox Grid.Row="0" Grid.Column="1"  Text="{Binding Value1}" />

        <TextBlock Grid.Row="1" Grid.Column="0" Text="foo2" />
        <TextBox Grid.Row="1" Grid.Column="1"  Text="{Binding Value2}" />

        <Rectangle Fill="Yellow" Height="15" Grid.Row="2" Grid.Column="0" Grid.ColumnSpan="3" />

        <autoRowGrid:Row>
            <TextBlock Text="foo3" />
            <TextBox Text="{Binding Value3}" />
        </autoRowGrid:Row>

        <autoRowGrid:Row>
            <TextBlock Text="foo4" />
            <TextBox Text="{Binding Value4}" />
        </autoRowGrid:Row>

        <Button Grid.Row="4" Grid.Column="2" Content="foo5" />

        <autoRowGrid:Row AutoIncrementation="UseExplicitColumns">
            <Rectangle Fill="Blue" Height="15" Grid.Row="2" Grid.Column="1" Grid.ColumnSpan="2" />
        </autoRowGrid:Row>
    </autoRowGrid:Grid>
</Window>
```

Produces:

![screenie](http://i.imgur.com/kAr50OX.png)

# Sample with nesting:
```xaml
<UserControl ...
             xmlns:autoRowGrid="http://gu.se/AutoRowGrid"
             ...>
    <autoRowGrid:Grid ColumnDefinitions="Auto *">
        <autoRowGrid:Row Name="first row">
            <TextBlock Text="foo1" />
            <TextBox Text="{Binding Value1}" />
        </autoRowGrid:Row>

        <autoRowGrid:Rows Name="a bunch of rows">
            <autoRowGrid:Row>
                <TextBlock Text="foo2" />
                <TextBox Text="{Binding Value2}" />
            </autoRowGrid:Row>

            <autoRowGrid:Row>
                <TextBlock Text="foo3" />
                <TextBox Text="{Binding Value3}" />
            </autoRowGrid:Row>

            <autoRowGrid:Rows Name="a bunch of nested rows">
                <autoRowGrid:Row>
                    <TextBlock Text="foo4" />
                    <TextBox Text="{Binding Value4}" />
                </autoRowGrid:Row>

                <autoRowGrid:Row>
                    <TextBlock Text="foo5" />
                    <TextBox Text="{Binding Value5}" />
                </autoRowGrid:Row>
            </autoRowGrid:Rows>

            <autoRowGrid:Row>
                <TextBlock Text="foo6" />
                <TextBox Text="{Binding Value6}" />
            </autoRowGrid:Row>
        </autoRowGrid:Rows>

        <autoRowGrid:Row Name="last row">
            <TextBlock Text="foo7" />
            <TextBox Text="{Binding Value7}" />
        </autoRowGrid:Row>
    </autoRowGrid:Grid>
</UserControl>
```

Produces:
![screenie](http://i.imgur.com/GQifcug.png)

