# WPF IValueConverter Example  


To change the foreground color of a column in datagrid on a wpf form you can use an IValueConverter to change the color based on the data in the column.  In this example I change the row color based on one of the columns value.

To do this we are going to create a ColorConverter class which implements the IValueConverter Interface.  


       public class ColorConverter : IValueConverter
       {
            public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            {
                 int id = 0;

                 if (value != null && int.TryParse(value.ToString(), out id))
                 {
                      if (id == 3)
                      {
                           return new SolidColorBrush(Colors.Red);
                      }
                 }

                  return new SolidColorBrush(Colors.Black);
            }


             public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
             {
                throw new NotImplementedException();
             }
        }
        
 The interface defines 2 method Convert and ConvertBack.  The convert function is called when the data is being displayed.  The ConvertBack function is called when the data is being sent back to what the object is bound to.  In this case I did not implement the ConvertBack function because I am using it to change the column color.
 
 In the ConvertFunction I am converting the value being sent in an object to an int.  Then based on the value I either return a Red or Black solidColorBrush to draw the text with on the datagrid.
 
 So now that we have the class created lets register the namespace in the xaml on the MainPage
 
         xmlns:Converter="clr-namespace:WPFConvertor.Converters"

Then we can add a resource for the converter'

        <Window.Resources>
             <Converter:ColorConverter x:Key="ColorConverter" />
        </Window.Resources>

In our forms xaml here is the implementation for the datagrid that is using the color converter

       <DataGrid ItemsSource="{Binding People}" Height="1500">
            <DataGrid.Columns>
            <DataGridTemplateColumn Header="Name" Width="380" CanUserSort="True">
                <DataGridTemplateColumn.CellTemplate>
                    <DataTemplate>
                        <Label Height="50"
                               Content="{Binding Name}"

                               Foreground="{Binding id, Converter={StaticResource ColorConverter}}"

                               Background="White"
                               HorizontalAlignment="Center"
                               HorizontalContentAlignment="Center"
                               VerticalContentAlignment="Center"
                               BorderThickness="0"
                               VerticalAlignment="Center" />
                    </DataTemplate>
                </DataGridTemplateColumn.CellTemplate>
            </DataGridTemplateColumn>
            </DataGrid.Columns>
        </DataGrid>


