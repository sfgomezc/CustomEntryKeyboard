using Android.Views.InputMethods;
using Android.Widget;
using NextDoneButton.Classes;
using NextDoneButton.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(Entry), typeof(CustomKeyEntryRenderer))]
namespace NextDoneButton.Droid
{
    public class CustomKeyEntryRenderer : EntryRenderer
    {
        public CustomKeyEntryRenderer(Android.Content.Context context) : base(context)
        {
            AutoPackage = false;
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            CustomKeyEntry entry = (CustomKeyEntry)this.Element;

            if (this.Control != null)
            {
                if (entry != null)
                {
                    SetReturnType(entry);

                    // Editor Action is called when the return button is pressed  
                    Control.EditorAction += (object sender, TextView.EditorActionEventArgs args) =>
                    {
                        if (entry.ReturnType != Classes.ReturnType.Next)
                            entry.Unfocus();

                        // Call all the methods attached to base_entry event handler Completed  
                        entry.InvokeCompleted();
                    };
                }
            }
        }
        private void SetReturnType(CustomKeyEntry entry)
        {
            Classes.ReturnType type = entry.ReturnType;

            switch (type)
            {
                case Classes.ReturnType.Go:
                    Control.ImeOptions = ImeAction.Go;
                    //Control.SetImeActionLabel("Go", ImeAction.Go);
                    break;
                case Classes.ReturnType.Next:
                    Control.ImeOptions = ImeAction.Next;
                    //Control.SetImeActionLabel("Next", ImeAction.Next);
                    break;
                case Classes.ReturnType.Send:
                    Control.ImeOptions = ImeAction.Send;
                    Control.SetImeActionLabel("Send", ImeAction.Send);
                    break;
                case Classes.ReturnType.Search:
                    Control.ImeOptions = ImeAction.Search;
                    Control.SetImeActionLabel("Search", ImeAction.Search);
                    break;
                default:
                    Control.ImeOptions = ImeAction.Done;
                    Control.SetImeActionLabel("Done", ImeAction.Done);
                    break;
            }
        }
    }
}