using System.Collections.ObjectModel;

namespace CollectionViewBugScroll.Views;

public partial class ModelOptionsView : ContentView
{
    public static readonly BindableProperty ItemSourceProperty = BindableProperty.Create(nameof(ItemSource), typeof(ObservableCollection<GroupedObversableCollection>), typeof(ModelOptionsView), new ObservableCollection<GroupedObversableCollection>(), propertyChanged:
        (b, o, s) => OnListChanged(b, o, s));

    public ObservableCollection<GroupedObversableCollection> ItemSource
    {
        get => (ObservableCollection<GroupedObversableCollection>)GetValue(ItemSourceProperty);
        set => SetValue(ItemSourceProperty, value);

    }

    

    public ModelOptionsView()
	{
        //BindingContext = this;
       
        InitializeComponent();
    }
    private static void OnListChanged(BindableObject bindable, object oldValue, object newValue)
    {
        if(oldValue is ObservableCollection<GroupedObversableCollection> list && newValue is ObservableCollection<GroupedObversableCollection> newList)
        {
            var control = (ModelOptionsView)bindable;
            control.ItemSource = newList;
        }
    }
}