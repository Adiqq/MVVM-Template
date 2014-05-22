# My MVVM Template - Noctis modified by Adiqq

## Changes:
Updateded packages.
SimpleIOC replaced with Unity 3.

## Reasoning:
The reason it came to be is that there are lots of small things I hate doing 
over and over, every time I create a project. 

Hopefully, you'll find it useful as well.

## Ok, what's next?
I suggest just opening it, renaming the default namespace (*MVVM_Template_Project*),
and then removing whatever you deem redundant / unnecessary / offensive.

I've commented most of the files so you can just stroll through them and get
the point of why they where they are, and what's the reasoning for their 
existance.

## General structure
* Auxiliary        (top level for all misc folders)
  * Converters
  * Helpers        (Extensions methods, etc.)
  * Resources    (Files, dlls, pictures, etc.)
  * Validations
* Design Time    (Central folder for all design time files)
* Models        
* ViewModels    
* Views

## Some conventions
Even though I personally prefer to start parameters names with "a" or "an" for
exmaple `public void SomeMethod(string aName, int anAge);`, I mainly left 
arguments with their default names, so that familiar parameters will stay the 
same, for example `(object sender, KeyEventArgs e)`.

Having said that, I took the liberty of adding an underscore before `ViewModel` 
and `View` files. If you don't like this, please forward your complaints to
 `/dev/null` and learn to use the rename tool.
 
## Styles
I put all of my styles in **Helpers\Resources\Styles.xaml**. If you have lots
of them, do feel free to break them into more specific style files.
The above file has an error animation, a style for the "base" `Control`, some 
controlls that inherit from the above control style, and some "generic" styles.

## Worth mentioning
**Annotations.cs** :  
I've added the file **Annotations.cs** to the Properties, in order to facilitate
calling the `RaisePropertyChanged` without specifying which property is changing.
The reason is to avoid simple yet annoying and hard to find bugs that happen when
you decide to change your property name, but forget to change the name on the 
`RaisePropertyChanged` string parameter.

---
**Base Class:**  
Next, I've created `MyBase_ViewModel` that extends GalaSoft's `ViewModelBase`, 
with the `RaisePropertyChanged` and `RaisePropertyChanging` so that the above 
will work for all classes derived from it. **Read**: Use
 `MyBase_ViewModel : ViewModelBase` and not `ViewModelBase` as the base for
 your view models.

---
**Duplicate Properties in ViewModelLocator and Main_ViewModel:**    

Because I'm not using the default MainWindow for everything, and because I have
the Main_ViewModel which is used in the ViewModelLocator, you'll have to define
your ViewModels properties in BOTH ViewModelLocator AND Main_ViewModel.
They will both return the same Instance, but this is the reason why:

 - When you're binding in the VIEW, you're using the ViewModelLocator's 
 property.  
 - When you're binding in the MainWindow, you're using the Main_ViewModel 
 property.

For example: 

    <TabItem Header="Random Helper">  
        <ContentControl Content="{Binding Test_VM}"  />
    </TabItem>

Is using the Main_ViewModel's Test_VM Property, but when you bind it in the
Test_View xaml:

    DataContext="{Binding Test_VM, Source={StaticResource Locator}}"

You're using the ViewModelLocator Property.
Feel free to name them differently if it helps you.

If you're not using tabs, or ain't going to bind things in the main view model
You can remove all the properties from the Main_ViewModel, and just have them
in your ViewModelLocator.

---
I've also included **ApexGrid.cs** to the Resources because it's just so sick and
makes working with grids so much nicer. 
You can read more about it on it's 
[Code Project home](http://www.codeproject.com/Articles/233886/Tidy-Up-XAML-with-the-ApexGrid).

---
**Exceptions:**  (Minor, but couldn't find a simple solution)  
When the validation goes from an error, to a non-error state, an exception is
printed to the output in VS, saying  something like:
  
    System.Windows.Data Error: 17 : Cannot get 'Item[]' value (type 'ValidationError') from '(Validation.Errors)'...

 This is from the **Styles.xaml**:

    <Style.Triggers>
         <Trigger Property="Validation.HasError" Value="true">
		    <Setter Property="ToolTip"
					Value="{Binding RelativeSource={x:Static RelativeSource.Self},
								Path=(Validation.Errors)[0].ErrorContent }"/>
	     </Trigger>
    </Style.Triggers>

and it basically means that the Validation.Errors is null and so, cannot be
referenced.

Possible solutions, sources, related:

1. [this post](http://joshsmithonwpf.wordpress.com/2008/10/08/binding-to-validationerrors0-without-creating-debug-spew/) by Josh Smith.
2. [this post](http://zhebrun.blogspot.com.au/2008/03/wpf-bug-with-validationerror.html)by Nikolay Zhebrun.
3.  [stack overflow question](http://stackoverflow.com/q/2260616/1698987).

---
**ICommand:**  
I've used two different ways of creating and initializing the **ICommand**.
Choose the one you like best, and stick with it.

1. Declare & Initialize together in **Random_ViewModel**. Look at the comments
in the file for more info  


        public ICommand RefreshNames_Command  
        {  
			get  
			{
				return _refreshNamesCommand ??
					 (_refreshNamesCommand = 
						new RelayCommand<int>(Execute_RefreshNames, 
											  CanExecute_RefreshNames));
			}
		}
		private ICommand _refreshNamesCommand;

2. Declare the command as normal Property, and initialize in constructor,
in **ValidationsConvertes_ViewModel**. Look at the comments in the file for
more info  

		
		public ValidationsConvertes_ViewModel(IDataService dataService)
		{
			...
			// Inside the constructor:
			BtnDoesNothing_Command = new RelayCommand(Execute_DoesNothing, CanExecute_DoesNothing);
			...
		}
		
		// Outside, like a normal C# Property:
        public ICommand BtnDoesNothing_Command { get; private set; }

---
**Interaction Triggers:**  
True to MVVM, and not wanting to have our clicks go to code in the code behind,
we can use the following to achieve triggers on anything. You'll need to have
`System.Windows.Interactivity` for this to work (if you're having any issues
have a look at this [article](http://www.codeproject.com/Articles/125188/Using-EventTrigger-in-XAML-for-MVVM-No-Code-Behind) for more help).
  
**Application Icon** 

To set the application icon, simply go to your project's properties, and under the Application tab, set the Icon to any icon that you want (note, it has to be an ".ico" file, but you can easily run a google search and find free online websites that will convert your .jpg or .png to icons. Here are two:

 - [http://www.convertico.com/](http://www.convertico.com/)
 - [http://www.online-convert.com/ ](http://www.online-convert.com/ ) 
