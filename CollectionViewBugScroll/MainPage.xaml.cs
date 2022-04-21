using System.Collections.ObjectModel;
using System.Windows.Input;

namespace CollectionViewBugScroll;

public partial class MainPage : ContentPage
{

	public ObservableCollection<GroupedObversableCollection> Examples { get; set; } = new ObservableCollection<GroupedObversableCollection>();

	public ICommand LoadCommand { get; }

	public MainPage()
	{
		BindingContext = this;
		LoadCommand = new Command(() => LoadItems());
		InitializeComponent();
		
		
	}

	public void LoadItems()
    {
		for(int j = 0; j < 10; j++)
        {
			var examples = new List<ExampleItem>();
			for (int i = 0; i < 10; i++)
			{
				ExampleItem item = new ExampleItem() { Id = i, Name = $"This has id {i}", TestBool = i % 2 == 0, SecondExample = new SecondExample { TestBool = i % 2 == 0 } };
				examples.Add(item);
			}
			var grouped = new GroupedObversableCollection($"Group {j}", examples);
			Examples.Add(grouped);
		}
		
	}

	
}

public class ExampleItem
{
	public int Id { get; set; }
	public string Name { get; set; }
	public bool TestBool { get; set; }
    public SecondExample? SecondExample { get; set; }
}

public class SecondExample
{
	public bool TestBool { get; set; }
}
public class GroupedObversableCollection : ObservableCollection<ExampleItem>
{
	public string Name { get; private set; }
	public GroupedObversableCollection(string name, List<ExampleItem> observableCollection) : base(observableCollection)
	{
		Name = name;
	}
}

