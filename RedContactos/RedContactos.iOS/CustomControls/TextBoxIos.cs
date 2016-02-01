﻿using System.Xml.Serialization;
using RedContactos.CustomControls;
using RedContactos.iOS.CustomControls;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly:ExportRenderer(typeof(TextBox),typeof(TextBoxIos))] //el tipo textbox se implementa a traves de textboxIos
namespace RedContactos.iOS.CustomControls
{
    public class TextBoxIos:EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);
            Control.BorderStyle=UITextBorderStyle.Bezel;
            Control.TextColor=UIColor.Green;
        }
    }
}