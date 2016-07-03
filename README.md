# Gu.Wpf.AutoGrid

Small prototype for a less noisy WPF grid.

Sample xaml:

```xaml
<Window ...
        xmlns:gu="http://gu.se/AutoGrid">
    <gu:AutoGrid ColumnDefinitions="Auto * 50">
        <TextBlock Grid.Row="0" Grid.Column="0" Text="foo1" />
        <TextBox Grid.Row="0" Grid.Column="1" Text="bar1" />

        <TextBlock Grid.Row="1" Grid.Column="0" Text="foo2" />
        <TextBox Grid.Row="1" Grid.Column="1" Text="bar2" />

        <gu:AtoGridRow>
            <TextBlock Grid.Column="0" Text="foo3" />
            <TextBox Grid.Column="1" Text="bar3" />
        </gu:AtoGridRow>

        <gu:AtoGridRow>
            <TextBlock Grid.Column="0" Text="foo4" />
            <TextBox Grid.Column="1" Text="bar4" />
        </gu:AtoGridRow>

        <Button Grid.Row="4" Grid.Column="2" Content="foo5" />
    </gu:AutoGrid>
</Window>
```

Produces:

![screenie](http://i.imgur.com/RufwoSf.png)
