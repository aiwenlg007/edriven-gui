using eDriven.Gui.Geom;
using eDriven.Gui.Graphics.Base;
using eDriven.Gui.Mappers;
using eDriven.Gui.Components;
using UnityEngine;
using Rect=eDriven.Gui.Graphics.Rect;

namespace eDriven.Gui.GUIStyles
{
    ///<summary>
    ///</summary>
    public class TextFieldStyle
    {
        #region Quasi-Singleton

        private static GUIStyle _instance;
        public static GUIStyle Instance
        {
            get
            {
                //Debug.Log("Getting FormItemLabelSkin instance");

                if (_instance == null)
                {
                    _instance = new GUIStyle {name = "TextFieldStyle"};
                    Initialize();
                }
                return _instance;
            }
        }

        private TextFieldStyle()
        {
            // constructor is protected
        }

        #endregion

        private static ProgramaticStyle _style;

        private const int Weight = 1;

        private static void Initialize()
        {
            _style = new ProgramaticStyle
            {
                Style = _instance,
                Alignment = TextAnchor.MiddleLeft,
                Padding = new RectOffset(6, 6, 6, 6),
                Font = FontMapper.GetDefault().Font,
                TextClipping = TextClipping.Clip
            };

            //_style.Font = CoreSkinMapper.Instance.System.font;

            int w = (Weight + 1) * 2;

            //_style.FixedWidth = 100;
            //_style.FixedHeight = 100;
            _style.Border = new RectOffset(Weight + 1, Weight + 1, Weight + 1, Weight + 1);

            //_style.FontSize = 8;
            _style.NormalTextColor = Color.black; //Color.grey;
            _style.NormalGraphics = new Rect(w, w,
                                             new Fill(Color.white), //new Fill(new Color(0.9f, 0.9f, 0.9f, 1f)),
                                            new Stroke(Weight) { Color = Color.black }
                );
            _style.HoverTextColor = Color.black;
            _style.HoverGraphics = new Rect(w, w,
                                            new Fill(Color.white),
                                            new Stroke(Weight) { Color = Color.black }
                );
            _style.ActiveTextColor = Color.black;
            _style.ActiveGraphics = new Rect(w, w,
                                             new Fill(Color.white),
                                             new Stroke(Weight) { Color = Color.black }
                );
            //_style.FocusedGraphics = new Rect(w, w,
            //                                  new Fill(Color.blue),
            //                                  new Stroke(Color.yellow, Weight)
            //    );

            _style.Commit();
        }
    }
}