using System.Collections.Generic;
using System.Reflection;
using eDriven.Gui.Reflection;
using eDriven.Gui.States;
using eDriven.Gui.Styles;
using UnityEngine;

namespace eDriven.Gui.Components
{
    [HostComponent(typeof(CheckBox))]

    [Style(Name = "upTexture", Type = typeof(Texture))]
    [Style(Name = "overTexture", Type = typeof(Texture))]
    [Style(Name = "downTexture", Type = typeof(Texture))]
    [Style(Name = "disabledTexture", Type = typeof(Texture))]

    [Style(Name = "upAndSelectedTexture", Type = typeof(Texture))]
    [Style(Name = "overAndSelectedTexture", Type = typeof(Texture))]
    [Style(Name = "downAndSelectedTexture", Type = typeof(Texture))]
    [Style(Name = "disabledAndSelectedTexture", Type = typeof(Texture))]

    [Style(Name = "overBackgroundTexture", Type = typeof(Texture))]
    
    [Style(Name = "textColor", Type = typeof(Color), Default = 0x333333)]

    public class CheckBoxSkin : Skin
    {
        #region Members

        //private RectShape _background;
        [Obfuscation(Exclude = true)]
        private Image _backgroundImage;
        
        [Obfuscation(Exclude = true)]
        private Image _iconImage;

        private HGroup _hGroup;

        #endregion

        #region Skin parts

        /* skin part */
        ///<summary>Label display
        ///</summary>
        // ReSharper disable MemberCanBePrivate.Global
        public Label LabelDisplay;

        // ReSharper restore MemberCanBePrivate.Global

        #endregion

        public override void StylesInitialized()
        {
            base.StylesInitialized();

            States = new List<State>(new[]
            {
                new State("up"){
                    Overrides = new List<IOverride>
                    {
                        new SetProperty("_iconImage", "Texture", GetStyle("upTexture")),
                    }
                }, 
                new State("over")
                {
                    Overrides = new List<IOverride>
                    {
                        new SetProperty("_iconImage", "Texture", GetStyle("overTexture")),
                        new SetProperty("_backgroundImage", "Visible", true)
                    }
                },
                new State("down") {
                    //BasedOn = "up",
                    Overrides = new List<IOverride>
                    {
                        new SetProperty("_iconImage", "Texture", GetStyle("downTexture")),
                        new SetProperty("_backgroundImage", "Visible", true)
                    }
                },
                new State("disabled") {
                    Overrides = new List<IOverride>
                    {
                        new SetProperty("_iconImage", "Texture", GetStyle("disabledTexture")),
                        new SetProperty("_backgroundImage", "Visible", false)
                    }
                },
                new State("upAndSelected") { 
                    Overrides = new List<IOverride>
                    {
                        new SetProperty("_iconImage", "Texture", GetStyle("upAndSelectedTexture")),
                        new SetProperty("_backgroundImage", "Visible", false)
                    }
                },
                new State("overAndSelected") { 
                    Overrides = new List<IOverride>
                    {
                        new SetProperty("_iconImage", "Texture", GetStyle("overAndSelectedTexture")),
                        new SetProperty("_backgroundImage", "Visible", true)
                    }
                },
                new State("downAndSelected") { 
                    Overrides = new List<IOverride>
                    {
                        new SetProperty("_iconImage", "Texture", GetStyle("downAndSelectedTexture")),
                        new SetProperty("_backgroundImage", "Visible", true)
                    }
                },
                new State("disabledAndSelected") { 
                    Overrides = new List<IOverride>
                    {
                        new SetProperty("_iconImage", "Texture", GetStyle("disabledAndSelectedTexture")),
                        new SetProperty("_backgroundImage", "Visible", false)
                    } }
            });
        }

        /*public override void SetCurrentState(string stateName)
        {
            base.SetCurrentState(stateName);
            Debug.Log("SetCurrentState: " + stateName);
        }*/

        protected override void CreateChildren()
        {
            //Debug.Log("Button skin creating children");
            base.CreateChildren();

            #region Background

            _backgroundImage = new Image
            {
                Left = 0,
                Right = 0,
                Top = 0,
                Bottom = 0,
                Mode = ImageMode.Tiled,
                AdjustWidthToTexture = false,
                AdjustHeightToTexture = false,
                Visible = false // default
            };
            AddChild(_backgroundImage);

            #endregion

            _hGroup = new HGroup
            {
                HorizontalCenter = 0,
                VerticalCenter = 0,
                Right = 6,
                Left = 6,
                Top = 6,
                Bottom = 6
            };
            AddChild(_hGroup);

            #region Icon

            _iconImage = new Image
            {
                Width = 16,
                Height = 16,
                MinWidth = 4,
                MinHeight = 4
            };
            _hGroup.AddChild(_iconImage);

            #endregion

            #region Label

            LabelDisplay = new Label();
            _hGroup.AddChild(LabelDisplay);

            #endregion
        }

        protected override void UpdateDisplayList(float width, float height)
        {
            if (null != _backgroundImage)
            {
                _backgroundImage.Texture = (Texture)GetStyle("overBackgroundTexture");
            }

            if (null != _iconImage)
            {
                _iconImage.Texture = (Texture)GetStyle(CurrentState.EndsWith("AndSelected") ? "upAndSelectedTexture" : "upTexture");
                _iconImage.Visible = _iconImage.IncludeInLayout = null != _iconImage.Texture;
            }

            if (null != LabelDisplay)
            {
                LabelDisplay.SetStyle("color", GetStyle("textColor"));
                LabelDisplay.Visible = LabelDisplay.IncludeInLayout = !string.IsNullOrEmpty(LabelDisplay.Text);
            }

            base.UpdateDisplayList(width, height);
        }
    }
}