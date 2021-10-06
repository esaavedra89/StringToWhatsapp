using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Plugin.CurrentActivity;
using StringToWhatsapp.Droid;


[assembly: Xamarin.Forms.Dependency(typeof(MensajeWhatsapp))]
namespace StringToWhatsapp.Droid
{
    public class MensajeWhatsapp : WhatsApp
    {
        Context CurrentContext => CrossCurrentActivity.Current.Activity;

        public void EnviarMensaje(string message)
        {
            try
            {
                Intent waIntent = new Intent();
                waIntent.SetAction(Intent.ActionSend);
                waIntent.SetType("text/plain");
                
                waIntent.SetPackage("com.whatsapp");
                if (waIntent != null)
                {
                    waIntent.PutExtra(Intent.ExtraText, message);//
                                                                 //StartActivity(Intent.CreateChooser(waIntent, text));
                                                                 //CurrentContext.StartActivity(Intent.CreateChooser(waIntent, text));
                                                                 //CurrentContext.StartActivity(waIntent);
                    Xamarin.Forms.Forms.Context.StartActivity(waIntent);
                }
                else
                {
                    Toast toast = Toast.MakeText(Application.Context, "WhatsApp not found", ToastLength.Short);
                    toast.SetGravity(Gravity.GetAbsoluteGravity(GravityFlags.Center, GravityFlags.FillHorizontal), 0, 0);
                    toast.Show();
                }
            }
            catch (Exception exc)
            {
                Toast toast = Toast.MakeText(Application.Context, exc.Message, ToastLength.Short);
                toast.SetGravity(Gravity.GetAbsoluteGravity(GravityFlags.Center, GravityFlags.FillHorizontal), 0, 0);
                toast.Show();
            }
        }
    }
}