using Android.App;
using Android.Widget;
using Android.OS;
using System;
using Android.Content;

namespace Phoneword
{
	[Activity(Label = "Phone Word", MainLauncher = true, Icon = "@mipmap/icon")]
	public class MainActivity : Activity
	{

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			// Set our view from the "main" layout resource
			SetContentView(Resource.Layout.Main);

			EditText phoneNumberText = FindViewById<EditText>(Resource.Id.PhoneNumberText);
			Button translateButton = FindViewById<Button>(Resource.Id.TranslateButton);
			Button callButton = FindViewById<Button>(Resource.Id.CallButton);

			callButton.Enabled = false;

			string translatedNumber = string.Empty;

			translateButton.Click += (object sender, EventArgs e) =>
			{
				translatedNumber = Core.PhonewordTranslator.ToNumber(phoneNumberText.Text);

				if (string.IsNullOrWhiteSpace(translatedNumber))
				{
					callButton.Text = "Call";
					callButton.Enabled = false;
				}
				else
				{
					callButton.Text = "Call " + translatedNumber;
					callButton.Enabled = true;
				}
			};

			callButton.Click += (object sender, EventArgs e) =>
			{
				var callDialog = new AlertDialog.Builder(this);
				callDialog.SetMessage("Call " + translatedNumber + "?");
				callDialog.SetNeutralButton("Call", delegate {
					var callIntent = new Intent(Intent.ActionCall);
					callIntent.SetData(Android.Net.Uri.Parse("tel:" + translatedNumber));
					StartActivity(callIntent);
				});

				callDialog.SetNegativeButton("Cancel", delegate {
				});

				callDialog.Show();
			};
		}
	}
}

