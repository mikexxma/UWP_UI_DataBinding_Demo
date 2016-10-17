# UWP_UI_DataBinding_Demo

remember if one control want to bind a dat, need use the tag 
                
<ComboBox.ItemTemplate>
   <DataTemplate x:DataType="data:BookCover">
          <StackPanel>
            <Image Width="70" Height="140" Source="{x:Bind ImageCover}"></Image>
          </StackPanel>
    </DataTemplate>
</ComboBox.ItemTemplate>


